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
            log.Debug("Main Window");
            InitializeComponent();
            WindowState = WindowState.Maximized;
            XmlConfigurator.Configure();
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
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("http://site.api.espn.com/apis/site/v2/sports/baseball/mlb/scoreboard");
                    var content = await response.Content.ReadAsStringAsync();
                    MLBData baseballData = JsonConvert.DeserializeObject<MLBData>(content);
                    List<MLB> graphics = new List<MLB>();
                    foreach (var game in baseballData.events)
                    {
                        try
                        {
                            log.Debug(game.id);
                            graphics.Add(await new MLB().GetMLBGameScore(game));
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
                            await Task.Delay(5000);
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