using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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

namespace ScoreDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetSportsData();
        }

        public void GetSportsData()
        {
            GetMLBData();
        }

        private void GetMLBData()
        {
            var client = new WebClient();
            var content = client.DownloadString("http://site.api.espn.com/apis/site/v2/sports/baseball/mlb/scoreboard");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(content);
            MLBData baseballData = JsonConvert.DeserializeObject<MLBData>(content);
            foreach (var game in baseballData.events)
            {
                System.Threading.Thread.Sleep(5000);
                GetMLBGameScore(game);
            }
            //GetMLBGameScore(baseballData.events[1]);
        }

        private void GetMLBGameScore(Event game)
        {
            var vm = new BaseballVM();
            MLB mlbPage = new MLB();
            vm.HomeLogo = game.competitions[0].competitors[0].team.logo;
            vm.AwayLogo = game.competitions[0].competitors[1].team.logo;
            vm.HomeScore = Int32.Parse(game.competitions[0].competitors[0].score);
            vm.AwayScore = Int32.Parse(game.competitions[0].competitors[1].score);
            vm.HomeHits = game.competitions[0].competitors[0].hits;
            vm.AwayHits = game.competitions[0].competitors[1].hits;
            vm.HomeErrors = game.competitions[0].competitors[0].errors;
            vm.AwayErrors = game.competitions[0].competitors[1].errors;
            mlbPage.HomeTeam.Source = new BitmapImage(new Uri(vm.HomeLogo));
            mlbPage.AwayTeam.Source = new BitmapImage(new Uri(vm.AwayLogo));
            mlbPage.HomeScore.Text = vm.HomeScore.ToString();
            mlbPage.AwayScore.Text = vm.AwayScore.ToString();
            mlbPage.HomeHits.Text = vm.HomeHits.ToString();
            mlbPage.AwayHits.Text = vm.AwayHits.ToString();
            mlbPage.HomeErrors.Text = vm.HomeErrors.ToString();
            mlbPage.AwayErrors.Text = vm.AwayErrors.ToString();
            var window = new Window
            {
                Title = "MLB Scores",
                Content = mlbPage,
            };

            // Show the window
            window.Show();
        }
    }
}
