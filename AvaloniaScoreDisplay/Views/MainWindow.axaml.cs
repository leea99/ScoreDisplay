using Avalonia.Controls;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Scoreboards;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views
{ 
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            XmlConfigurator.Configure();
            GetSportsData();
        }

        public async Task GetSportsData()
        {
            while (true) {
                await GetMLBData();
            }
            //await GetMLBData(); //Dev mode
        }

        private async Task GetMLBData()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("http://site.api.espn.com/apis/site/v2/sports/baseball/mlb/scoreboard");
                    var content = await response.Content.ReadAsStringAsync();
                    MLBData baseballData = JsonConvert.DeserializeObject<MLBData>(content);
                    List<MLB> graphics = new List<MLB>();
                    var height = this.Height;
                    foreach (var game in baseballData.events)
                    {
                        try
                        {
                            var graphic = await new MLB().GetMLBGameScore(game);
                            graphic.HomeTeam.Height = height * .20;
                            graphic.AwayTeam.Height = height * .20;
                            graphics.Add(graphic);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Game ID: " + game.id + " " + ex.Message);
                        }
                    }
                    foreach (var g in graphics)
                    {
                        try
                        {
                            Content = g;
                            await Task.Delay(7000);
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error getting MLB game data: " + ex.Message);
            }
        }
    }
}