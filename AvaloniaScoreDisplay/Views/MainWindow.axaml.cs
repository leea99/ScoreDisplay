using Avalonia.Controls;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Scoreboards;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            GetSportsData();
        }

        public async Task GetSportsData()
        {
            /*while (true) {
                await GetMLBData();
            }*/
            await GetMLBData(); //Dev mode
        }

        private async Task GetMLBData()
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
                    try
                    {
                        Content = g;
                        await Task.Delay(5000);
                    }
                    catch (Exception ex) { }
                }
            }
        }
    }
}