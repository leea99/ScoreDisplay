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
            var client = new WebClient();
            var content = client.DownloadString("http://site.api.espn.com/apis/site/v2/sports/baseball/mlb/scoreboard");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(content);
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

        private async Task<MLB> GetMLBGameScore(Event game)
        {
            var vm = new BaseballVM();
            MLB mlbPage = new MLB();
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
