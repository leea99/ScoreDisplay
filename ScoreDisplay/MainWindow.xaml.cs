using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using ScoreDisplay.Models;
using Newtonsoft.Json;
using System.Globalization;
using ScoreDisplay.Scoreboards;
using ScoreDisplay.ViewModels;
using System.Threading;
using System.Collections.ObjectModel;
using System.Timers;
using System.Reflection.Metadata;
using System.Net.Http;

namespace ScoreDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
                    graphics.Add(await GetMLBGameScore(game));
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
            if (game.competitions[0].status.type.state == "in")
            {
                using (var client = new HttpClient())
                {
                    var gameId = game.id;
                    var response = await client.GetAsync("https://site.api.espn.com/apis/site/v2/sports/baseball/mlb/summary?event=" + gameId);
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonString = await response.Content.ReadAsStringAsync();

                    // deserialize the JSON string into a dynamic object
                    dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);

                    // get the "Situation" object from the dynamic object
                    var test = jsonObject.situation;
                    Situation situationObject = JsonConvert.DeserializeObject<Situation>(jsonObject.situation.ToString());
                }
                vm.Inning = game.competitions[0].status.type.detail;
                mlbPage.GameStatus.Text = "Inning: " + vm.Inning;
            }
            else if (game.competitions[0].status.type.state == "pre")
            {
                DateTime startDate = new DateTime();
                DateTime.TryParse(game.competitions[0].startDate, out startDate);
                vm.HomeStarter = game.competitions[0].competitors[0].probables.First().athlete.displayName;
                vm.AwayStarter = game.competitions[0].competitors[1].probables.First().athlete.displayName;
                vm.Moneyline = game.competitions[0].odds[0].details;
                vm.OverUnder = game.competitions[0].odds[0].overUnder.ToString();
                mlbPage.GameStatus.Text = "Start Time: " + startDate.ToLocalTime().ToString("h:mm tt");
                mlbPage.Info1.Text = vm.HomeAbr + " SP: " + vm.HomeStarter;
                mlbPage.Info2.Text = vm.AwayAbr + " SP: " + vm.AwayStarter;
                mlbPage.Info3.Text = vm.Moneyline;
                mlbPage.Info4.Text = "O/U: " + vm.OverUnder;
            }
            else if (game.competitions[0].status.type.state == "post")
            {
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
    }
}
