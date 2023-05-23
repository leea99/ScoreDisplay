using Avalonia.Controls;
using Avalonia.Media;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.ViewModels;
using Avalonia.Media.Imaging;


namespace AvaloniaScoreDisplay.Scoreboards
{
    public partial class MLB : UserControl
    {
        public static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
        public MLB()
        {
            InitializeComponent();
            var path = Directory.GetCurrentDirectory();
            var testPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\..\"));
            testPath = System.IO.Path.Combine(testPath, "Images", "background.png");
            var bitmap = new Bitmap(testPath);
            Background = new ImageBrush(bitmap)
            {
                Stretch = Stretch.Fill
            };
            if (HomeTeam.Width > AwayTeam.Width)
            {
                HomeTeam.Width = AwayTeam.Width;
            }
            else
            {
                AwayTeam.Width = AwayTeam.Width;
            }
        }

        public async Task<MLB> GetMLBGameScore(Event game)
        {
            var vm = new BaseballVM();
            await GetGeneralAttributes(game, vm);
            var gameId = game.id;
            if (game.competitions[0].status.type.state == "in")
            {
                await GetInStateAttributes(game, vm, gameId);
            }
            else if (game.competitions[0].status.type.state == "pre")
            {
                GetPreStateAttributes(game, vm);
            }
            else if (game.competitions[0].status.type.state == "post" && game.competitions[0].status.type.completed)
            {
                await GetFinalAttributes(game, gameId);
            }
            return this;
        }

        private async Task GetGeneralAttributes(Event game, BaseballVM vm)
        {
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
            try
            {
                using (var httpClient = new HttpClient())
                using (var response = await httpClient.GetAsync(vm.HomeLogo))
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var bitmap = new Bitmap(memoryStream);
                    HomeTeam.Source = bitmap;
                }
                using (var httpClient = new HttpClient())
                using (var response = await httpClient.GetAsync(vm.AwayLogo))
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var bitmap = new Bitmap(memoryStream);
                    AwayTeam.Source = bitmap;
                }
            }
            catch (Exception e)
            {

            }
            var bc = new BrushConverter();
            HomeTeamName.Text = vm.HomeName;
            AwayTeamName.Text = vm.AwayName;
            HomeTeamRecord.Text = vm.HomeRecord;
            AwayTeamRecord.Text = vm.AwayRecord;
            HomeScore.Text = vm.HomeScore.ToString();
            AwayScore.Text = vm.AwayScore.ToString();
            HomeHits.Text = vm.HomeHits.ToString();
            AwayHits.Text = vm.AwayHits.ToString();
            HomeErrors.Text = vm.HomeErrors.ToString();
            AwayErrors.Text = vm.AwayErrors.ToString();
        }

        private async Task GetFinalAttributes(Event game, string gameId)
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
                    dynamic? jsonObject = JsonConvert.DeserializeObject(jsonString, settings);
                    if (jsonObject == null)
                    {
                        return;
                    }
                    var players = jsonObject.boxscore.players;
                    // get the "Situation" object from the dynamic object
                    Models.BaseballGame.Rootobject? gameLog = JsonConvert.DeserializeObject<Models.BaseballGame.Rootobject>(jsonString, settings);
                    if (gameLog == null)
                    {
                        return;
                    }
                    var test = gameLog.boxscore.players;
                    foreach (var team in test)
                    {
                        var pitchers = team.statistics.FirstOrDefault(x => x.type == "pitching");
                        Dictionary<string, int> pitchStats = ClassToDict(pitchers);
                        if (pitchers != null)
                        {
                            foreach (var p in pitchers.athletes)
                            {
                                if (winPitcher != null && p.athlete.id == winPitcher.playerId)
                                {
                                    winPitcherTxt += " " + p.stats[pitchStats["IP"]] + " IP, " + p.stats[pitchStats["ER"]] + " ER, " + p.stats[pitchStats["K"]] + " K, " + p.stats[pitchStats["BB"]] + " BB";
                                }
                                else if (lossPitcher != null && p.athlete.id == lossPitcher.playerId)
                                {
                                    lossPitcherTxt += " " + p.stats[pitchStats["IP"]] + " IP, " + p.stats[pitchStats["ER"]] + " ER, " + p.stats[pitchStats["K"]] + " K, " + p.stats[pitchStats["BB"]] + " BB";
                                }
                                else if (savePitcher != null && p.athlete.id == savePitcher.playerId)
                                {
                                    savePitcherTxt += " " + p.stats[pitchStats["IP"]] + " IP, " + p.stats[pitchStats["ER"]] + " ER, " + p.stats[pitchStats["K"]] + " K, " + p.stats[pitchStats["BB"]] + " BB";
                                }
                            }
                        }
                    }
                    Info1.Text = winPitcherTxt;
                    Info2.Text = lossPitcherTxt;
                    Info3.Text = savePitcherTxt;
                }
            }
            GameStatus.Text = "Final";
        }

        private void GetPreStateAttributes(Event game, BaseballVM vm)
        {
            DateTime startDate = new DateTime();
            DateTime.TryParse(game.competitions[0].startDate, out startDate);
            var homeStarter = game.competitions[0].competitors[0].probables.First();
            var awayStarter = game.competitions[0].competitors[1].probables.First();
            vm.HomeStarter = homeStarter.athlete.displayName;
            vm.AwayStarter = awayStarter.athlete.displayName;
            vm.HomeStarterStats = GetPitcherStats(homeStarter);
            vm.AwayStarterStats = GetPitcherStats(awayStarter);
            if (game.competitions[0].odds != null)
            {
                vm.Moneyline = game.competitions[0].odds[0].details;
                vm.OverUnder = game.competitions[0].odds[0].overUnder.ToString();
            }
            GameStatus.Text = "Start Time: " + startDate.ToLocalTime().ToString("h:mm tt");
            if (game.competitions[0].broadcasts.Length > 0)
            {
                ChannelBox.IsVisible = true;
                Channel.Text = game.competitions[0].broadcasts[0].names[0];
            }
            Info1.Text = vm.HomeAbr + " SP: " + vm.HomeStarter + vm.HomeStarterStats;
            Info2.Text = vm.AwayAbr + " SP: " + vm.AwayStarter + vm.AwayStarterStats;
            Info3.Text = vm.Moneyline;
            Info4.Text = "O/U: " + vm.OverUnder;
        }

        private async Task GetInStateAttributes(Event game, BaseballVM vm, string gameId)
        {
            string? jsonString = "";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://site.api.espn.com/apis/site/v2/sports/baseball/mlb/summary?event=" + gameId);
                jsonString = await response.Content.ReadAsStringAsync();
                // deserialize the JSON string into a dynamic object
                dynamic? jsonObject = JsonConvert.DeserializeObject(jsonString);
                // get the "Situation" object from the dynamic object
                if (jsonObject == null)
                {
                    return;
                }
                Situation situation = JsonConvert.DeserializeObject<Situation>(jsonObject.situation.ToString());
                OnBase.Source = new Bitmap(GetOnBaseGraphic(situation));
                Outs.Source = new Bitmap(GetOuts(situation));
            }
            vm.Inning = game.competitions[0].status.type.detail;
            GameStatus.Text = "Inning: " + vm.Inning;
        }

        private Dictionary<string, int> ClassToDict(Models.BaseballGame.Statistic1? pitchers)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int i = 0;
            if (pitchers != null)
            {
                foreach (string name in pitchers.names)
                {
                    dict[name] = i;
                    i++;
                }
            }
            return dict;
        }

        private string GetPitcherStats(Probable pitcher)
        {
            var wins = pitcher.statistics.FirstOrDefault(x => x.name.ToLower() == "wins");
            var losses = pitcher.statistics.FirstOrDefault(x => x.name.ToLower() == "losses");
            var era = pitcher.statistics.FirstOrDefault(x => x.name.ToLower() == "era");
            if (wins != null && losses != null && era != null)
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
                return System.IO.Path.Combine(path, "Images", "Baseball", "NoBase.png");
            }
            else
            {
                return System.IO.Path.Combine(path, "Images", "Baseball", fileName + ".png");
            }
        }

        private string GetOuts(Situation situation)
        {
            string fileName = "out.png";
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
