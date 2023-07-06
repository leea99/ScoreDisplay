using Avalonia.Controls;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Models.Standings;
using AvaloniaScoreDisplay.Scoreboards;
using AvaloniaScoreDisplay.Views.Standings;
using ExCSS;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            #if DEBUG
                WindowState = WindowState.Maximized;
            #else
                WindowState = WindowState.FullScreen;
            #endif
            XmlConfigurator.Configure();
            GetSportsData();
        }

        public async Task GetSportsData()
        {
            #if DEBUG
                //await GetMLBScores();
                await GetMLBStandings();
            #else
                while (true) {
                    await GetMLBScores();
                    await GetMLBStandings();
                }
            #endif
        }

        private string ReplaceURL(string url, string sport, string league)
        {
            url = url.Replace("SPORT", sport);
            return url.Replace("LEAGUE", league);
        }

        private async Task GetMLBScores()
        {
            try
            {
                string? standingsURL = ConfigurationManager.AppSettings["ScoreURL"];
                string standingsURLString = standingsURL != null ? standingsURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(standingsURLString, "baseball", "mlb");
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    MLBData? baseballData = JsonConvert.DeserializeObject<MLBData>(content);
                    List<MLB> graphics = new List<MLB>();
                    foreach (var game in baseballData.events)
                    {
                        try
                        {
                            var graphic = await new MLB().GetMLBGameScore(game);
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

        private async Task GetMLBStandings()
        {
            try
            {
                string? standingsURL = ConfigurationManager.AppSettings["StandingsURL"];
                string standingsURLString = standingsURL != null ? standingsURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(standingsURLString, "baseball", "mlb");
                finalURL += "?level=" + (int)Statics.StandingLevels.Division;
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    StandingObj? baseballStandings = JsonConvert.DeserializeObject<StandingObj>(content);
                    List<MLBStandings> graphics = new List<MLBStandings>();
                    if (baseballStandings != null)
                    {
                        foreach (var league in baseballStandings.children)
                        {
                            foreach (var division in league.children)
                            {
                                try
                                {
                                    if (division != null)
                                    {
                                        var graphic = new MLBStandings().GetMLBStandings(division);
                                        graphics.Add(await graphic);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Error("Game ID: " + division.id + " " + ex.Message);
                                }
                            }
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