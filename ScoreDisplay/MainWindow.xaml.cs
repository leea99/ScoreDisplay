using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ScoreDisplay.Models;
using Newtonsoft.Json;
using ScoreDisplay.Scoreboards;
using ScoreDisplay.ViewModels;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.IO;

namespace ScoreDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
        private System.Threading.Timer _timer;
        private int _currentIndex = 0;
        private ObservableCollection<dynamic> _items = new ObservableCollection<dynamic>();
        public MainWindow()
        {
            InitializeComponent();
            //MLB mlbPage = new MLB();
            //this.Content = mlbPage;
            GetSportsData();
            //_timer = new System.Threading.Timer(OnCallBack, null, 0, 50000);
        }

        public void GetSportsData()
        {
            GetMLBData();
        }

        private async void GetMLBData()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://site.api.espn.com/apis/site/v2/sports/baseball/mlb/scoreboard");
                var content = await response.Content.ReadAsStringAsync();
                MLBData baseballData = JsonConvert.DeserializeObject<MLBData>(content);
                List<MLB> graphics = new List<MLB>();
                foreach (var game in baseballData.events)
                {
                    graphics.Add(await new MLB().GetMLBGameScore(game));
                }
                foreach (var g in graphics)
                {
                    this.Content = g;
                    await Task.Delay(5000);
                }
            }
        }

        private async Task<MLB> GetMLBGameScore(Event game)
        {
            var vm = new BaseballVM();
            MLB mlbPage = new MLB();
            vm.HomeAbr = game.competitions[0].competitors[0].team.abbreviation;
            vm.AwayAbr = game.competitions[0].competitors[1].team.abbreviation;
            vm.HomeLogo = game.competitions[0].competitors[0].team.logo;
            vm.AwayLogo = game.competitions[0].competitors[1].team.logo;
            vm.HomeName = game.competitions[0].competitors[0].team.name;
            vm.HomeRecord = game.competitions[0].competitors[0].records[0].summary;
            vm.AwayName = game.competitions[0].competitors[1].team.name;
            vm.AwayRecord = game.competitions[0].competitors[1].records[0].summary;
            vm.HomeScore = Int32.Parse(game.competitions[0].competitors[0].score);
            vm.AwayScore = Int32.Parse(game.competitions[0].competitors[1].score);
            vm.HomeHits = game.competitions[0].competitors[0].hits;
            vm.AwayHits = game.competitions[0].competitors[1].hits;
            vm.HomeErrors = game.competitions[0].competitors[0].errors;
            vm.AwayErrors = game.competitions[0].competitors[1].errors;
            var gameId = game.id;
            if (game.competitions[0].status.type.state == "in")
            {
                using (var client = new HttpClient())
                { 
                    var response = await client.GetAsync("https://site.api.espn.com/apis/site/v2/sports/baseball/mlb/summary?event=" + gameId);
                    var jsonString = await response.Content.ReadAsStringAsync();
                    // deserialize the JSON string into a dynamic object
                    dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);
                    // get the "Situation" object from the dynamic object
                    Situation situation = JsonConvert.DeserializeObject<Situation>(jsonObject.situation.ToString());
                    mlbPage.OnBase.Source = new Uri(GetOnBaseGraphic(situation));
                    mlbPage.Outs.Source = new Uri(GetOuts(situation));
                }
                vm.Inning = game.competitions[0].status.type.detail;
                mlbPage.GameStatus.Text = "Inning: " + vm.Inning;
            }
            else if (game.competitions[0].status.type.state == "pre")
            {
                DateTime startDate = new DateTime();
                DateTime.TryParse(game.competitions[0].startDate, out startDate);
                var homeStarter = game.competitions[0].competitors[0].probables.First();
                var awayStarter = game.competitions[0].competitors[1].probables.First();
                vm.HomeStarter = homeStarter.athlete.displayName;
                vm.AwayStarter = awayStarter.athlete.displayName;
                vm.HomeStarterStats = GetPitcherStats(homeStarter);
                vm.AwayStarterStats = GetPitcherStats(awayStarter);
                vm.Moneyline = game.competitions[0].odds[0].details;
                vm.OverUnder = game.competitions[0].odds[0].overUnder.ToString();
                mlbPage.GameStatus.Text = "Start Time: " + startDate.ToLocalTime().ToString("h:mm tt");
                if (game.competitions[0].broadcasts.Length > 0)
                {
                    mlbPage.ChannelBox.Visibility = Visibility.Visible;
                    mlbPage.Channel.Text = game.competitions[0].broadcasts[0].names[0];
                }
                mlbPage.Info1.Text = vm.HomeAbr + " SP: " + vm.HomeStarter + vm.HomeStarterStats;
                mlbPage.Info2.Text = vm.AwayAbr + " SP: " + vm.AwayStarter + vm.AwayStarterStats;
                mlbPage.Info3.Text = vm.Moneyline;
                mlbPage.Info4.Text = "O/U: " + vm.OverUnder;
            }
            else if (game.competitions[0].status.type.state == "post" && game.competitions[0].status.type.completed)
            {
                var winPitcher = game.competitions[0].status.featuredAthletes.FirstOrDefault(x => x.name == "winningPitcher");
                var lossPitcher = game.competitions[0].status.featuredAthletes.FirstOrDefault(x => x.name == "losingPitcher");
                var savePitcher = game.competitions[0].status.featuredAthletes.FirstOrDefault(x => x.name == "savingPitcher");
                string winPitcherTxt = "";
                string lossPitcherTxt = "";
                string savePitcherTxt = "";
                if (winPitcher != null)
                {
                    winPitcherTxt = "W: " + winPitcher.athlete.displayName;
                }
                if (lossPitcher != null)
                {
                    lossPitcherTxt = "L: " + lossPitcher.athlete.displayName;
                }
                if (savePitcher != null)
                {
                    savePitcherTxt = "SV: " + savePitcher.athlete.displayName;
                }
                if (winPitcherTxt != null && lossPitcherTxt != null && savePitcherTxt != null)
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync("https://site.api.espn.com/apis/site/v2/sports/baseball/mlb/summary?event=" + gameId);
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var settings = new JsonSerializerSettings();
                        settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                        // deserialize the JSON string into a dynamic object
                        dynamic jsonObject = JsonConvert.DeserializeObject(jsonString, settings);
                        var players = jsonObject.boxscore.players;
                        // get the "Situation" object from the dynamic object
                        Models.BaseballGame.Rootobject gameLog = JsonConvert.DeserializeObject<Models.BaseballGame.Rootobject>(jsonString, settings);
                        var test = gameLog.boxscore.players;
                        foreach (var team in test)
                        {
                            var pitchers = team.statistics.FirstOrDefault(x => x.type == "pitching");
                            Dictionary<string, int> pitchStats = ClassToDict(pitchers);
                            foreach (var p in pitchers.athletes)
                            {
                                if (p.athlete.id == winPitcher.playerId)
                                {
                                    winPitcherTxt += " " + p.stats[pitchStats["IP"]] + " IP, " + p.stats[pitchStats["ER"]] + " ER, " + p.stats[pitchStats["K"]] + " K, " + p.stats[pitchStats["BB"]] + " BB";
                                }
                                else if (p.athlete.id == lossPitcher.playerId)
                                {
                                    lossPitcherTxt += " " + p.stats[pitchStats["IP"]] + " IP, " + p.stats[pitchStats["ER"]] + " ER, " + p.stats[pitchStats["K"]] + " K, " + p.stats[pitchStats["BB"]] + " BB";
                                }
                                else if (savePitcher != null && p.athlete.id == savePitcher.playerId)
                                {
                                    savePitcherTxt += " " + p.stats[pitchStats["IP"]] + " IP, " + p.stats[pitchStats["ER"]] + " ER, " + p.stats[pitchStats["K"]] + " K, " + p.stats[pitchStats["BB"]] + " BB";
                                }
                            }
                        }
                        mlbPage.Info1.Text = winPitcherTxt;
                        mlbPage.Info2.Text = lossPitcherTxt;
                        mlbPage.Info3.Text = savePitcherTxt;
                    }
                }
                mlbPage.GameStatus.Text = "Final";
            }
            mlbPage.HomeTeam.Source = new BitmapImage(new Uri(vm.HomeLogo));
            mlbPage.AwayTeam.Source = new BitmapImage(new Uri(vm.AwayLogo));
            var bc = new BrushConverter();
            mlbPage.HomeTeamName.Text = vm.HomeName;
            mlbPage.AwayTeamName.Text = vm.AwayName;
            mlbPage.HomeTeamRecord.Text = vm.HomeRecord;
            mlbPage.AwayTeamRecord.Text = vm.AwayRecord;
            mlbPage.HomeScore.Text = vm.HomeScore.ToString();
            mlbPage.AwayScore.Text = vm.AwayScore.ToString();
            mlbPage.HomeHits.Text = vm.HomeHits.ToString();
            mlbPage.AwayHits.Text = vm.AwayHits.ToString();
            mlbPage.HomeErrors.Text = vm.HomeErrors.ToString();
            mlbPage.AwayErrors.Text = vm.AwayErrors.ToString();
            return mlbPage;
        }

        private Dictionary<string, int> ClassToDict(Models.BaseballGame.Statistic1? pitchers)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int i = 0;
            foreach (string name in pitchers.names)
            {
                dict[name] = i;
                i++;
            }
            return dict;
        }

        private string GetPitcherStats(Probable pitcher)
        { 
            var wins = pitcher.statistics.FirstOrDefault(x => x.name.ToLower() == "wins");
            var losses = pitcher.statistics.FirstOrDefault(x => x.name.ToLower() == "losses");
            var era = pitcher.statistics.FirstOrDefault(x => x.name.ToLower() == "era");
            if (wins != null && losses != null && era!= null)
            {
                return " " + wins.displayValue + "-" + losses.displayValue + " (" + era.displayValue + " ERA)";
            }
            else
            {
                return " No Data";
            }
        }

        private string GetOnBaseGraphic(Situation situation)
        {
            string fileName = "";
            if (situation.onFirst != null)
            {
                fileName += "First";
            }
            if (situation.onSecond != null)
            {
                fileName += "Second";
            }
            if (situation.onThird != null)
            {
                fileName += "Third";
            }
            if (fileName == "")
            {
                return System.IO.Path.Combine(path, "Images", "Baseball", "NoBase.svg");
            }
            else
            {
                return System.IO.Path.Combine(path, "Images", "Baseball", fileName + ".svg");
            }
        }

        private string GetOuts(Situation situation)
        {
            string fileName = "out.svg";
            switch (situation.outs)
            {
                case 0:
                    fileName = 0 + fileName;
                    break;
                case 1:
                    fileName = 1 + fileName;
                    break;
                case 2:
                    fileName = 2 + fileName;
                    break;
            }
            return System.IO.Path.Combine(path, "Images", "Baseball", fileName);
        }
    }
}
