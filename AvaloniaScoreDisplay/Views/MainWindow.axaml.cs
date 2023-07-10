using Avalonia.Controls;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Models.SoccerScores;
using AvaloniaScoreDisplay.Models.Standings;
using AvaloniaScoreDisplay.Scoreboards;
using AvaloniaScoreDisplay.Views.Scoreboards;
using AvaloniaScoreDisplay.Views.Standings;
using DynamicData;
using ExCSS;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
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
            string? sportsStr = ConfigurationManager.AppSettings["Sports"];
            if (sportsStr != null)
            {
                var sports = sportsStr.Split(',');
                while (true)
                {
                    foreach (var sport in sports)
                    {
                        switch (sport.ToLower())
                        {
                            case "baseball":
                                //await GetMLBScores();
                                //await GetMLBStandings();
                                break;
                            case "soccer":
                                await GetSoccerScores();
                                break;
                        }
                    }
                }
            }
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
                string? scoreURL = ConfigurationManager.AppSettings["ScoreURL"];
                string scoreURLString = scoreURL != null ? scoreURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(scoreURLString, "baseball", "mlb");
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

        private async Task GetSoccerScores()
        {
            try
            {
                string? scoreURL = ConfigurationManager.AppSettings["ScoreURL"];
                string scoreURLString = scoreURL != null ? scoreURL.ToString() : string.Empty;
                string? leaguesStr = ConfigurationManager.AppSettings["SoccerLeagues"];
                if (leaguesStr != null)
                {
                    var leagues = leaguesStr.Split(',');
                    foreach (var league in leagues)
                    {
                        var finalURL = ReplaceURL(scoreURLString, "soccer", league);
                        using (var client = new HttpClient())
                        {
                            var response = await client.GetAsync(finalURL);
                            var content = await response.Content.ReadAsStringAsync();
                            SoccerScore? soccerData = JsonConvert.DeserializeObject<SoccerScore>(content);
                            List<SoccerScoreView> graphics = new List<SoccerScoreView>();
                            foreach (var game in soccerData.events)
                            {
                                try
                                {
                                    if (ShowGame(game.date, game.status.type))
                                    {
                                        var graphic = await new SoccerScoreView().GetSoccerScore(game, soccerData.leagues.FirstOrDefault());
                                        graphics.Add(graphic);
                                    }
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
                }
            }
            catch (Exception ex)
            {
                log.Error("Error getting Soccer game data: " + ex.Message);
            }
        }

        private bool ShowGame(string gameDateStr, Models.SoccerScores.Type1 gameState)
        {
            DateTime queryDate = DateTime.Now;
            DateTime gameDate;
            DateTime.TryParse(gameDateStr, out gameDate);
            if (queryDate.Date == gameDate.Date || (gameState.state == "post") && (gameState.detail == "FT"))
            {
                return true;
            }
            return false;
        }
    }
}