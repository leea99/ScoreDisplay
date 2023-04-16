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
            MLB mlbPage = new MLB();
            var logo1 = baseballData.events[0].competitions[0].competitors[0].team.logo;
            var logo2 = baseballData.events[0].competitions[0].competitors[1].team.logo;
            mlbPage.HomeTeam.Source = new BitmapImage(new Uri(logo1));
            mlbPage.AwayTeam.Source = new BitmapImage(new Uri(logo2));
            var window = new Window
            {
                Title = "MLB Scores",
                Content = mlbPage,
                Width = 800,
                Height = 600,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
            };

            // Show the window
            window.Show();
        }
    }
}
