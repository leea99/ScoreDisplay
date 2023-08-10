using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Models.FootballScores;
using AvaloniaScoreDisplay.Models.SoccerScores;
using AvaloniaScoreDisplay.Models.SoccerStandings;
using AvaloniaScoreDisplay.Models.Standings;
using AvaloniaScoreDisplay.Scoreboards;
using AvaloniaScoreDisplay.ViewModels;
using AvaloniaScoreDisplay.Views.Scoreboards;
using AvaloniaScoreDisplay.Views.Standings;
using AvaloniaScoreDisplay.Views.Standings.NFL;
using AvaloniaScoreDisplay.Views.Standings.Soccer;
using DynamicData;
using ExCSS;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views
{
    public partial class MainWindow : Window
    {
        public static List<string> sports = new List<string>();
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
            var path = ConfigurationManager.AppSettings["ImagePath"];
            if (path != null)
            {
                path = System.IO.Path.Combine(path, "background.png");
                var bitmap = new Bitmap(path);
                Background = new ImageBrush(bitmap)
                {
                    Stretch = Stretch.Fill
                };
                GetSportsData();
            }
        }

        public async Task GetSportsData()
        {
            string? sportsStr = ConfigurationManager.AppSettings["Sports"];
            if (sportsStr != null)
            {
                sports = sportsStr.Split(',').ToList();
                while (true)
                {
                    for (int i = 0; i < sports.Count; i++)
                    {
                        switch (sports[i].ToLower())
                        {
                            case "baseball":
                                //await GetMLBScores();
                                break;
                            case "soccer":
                                //await GetSoccerScores();
                                break;
                            case "college-football":
                                //await GetCFBScores();
                                break;
                            case "nfl":
                                await GetNFLScores();
                                await GetNFLStandings();
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
                    if (graphics.Count == 0)
                    {
                        sports.Remove("baseball");
                        return;
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
                    await GetMLBStandings();
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
                            if (graphics.Count == 0)
                            {
                                sports.Remove("soccer");
                                return;
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
                            await GetSoccerStandings();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error getting soccer game data: " + ex.Message);
            }
        }
        private async Task GetSoccerStandings()
        {
            try
            {
                const int TeamsOnPage = 5;
                string? standingsURL = ConfigurationManager.AppSettings["StandingsURL"];
                string standingsURLString = standingsURL != null ? standingsURL.ToString() : string.Empty;
                string? leaguesStr = ConfigurationManager.AppSettings["SoccerLeagues"];
                if (leaguesStr != null)
                {
                    var leagues = leaguesStr.Split(',');
                    foreach (var league in leagues)
                    {
                        var finalURL = ReplaceURL(standingsURLString, "soccer", league);
                        finalURL += "?level=" + (int)Statics.StandingLevels.Conference;
                        using (var client = new HttpClient())
                        {
                            var response = await client.GetAsync(finalURL);
                            var content = await response.Content.ReadAsStringAsync();
                            SoccerStandingsMod? soccerStandings = JsonConvert.DeserializeObject<SoccerStandingsMod>(content);
                            List<SoccerStandings> graphics = new List<SoccerStandings>();
                            if (soccerStandings != null)
                            {
                                foreach (var conference in soccerStandings.children)
                                {
                                    int confTotal = 0;
                                    if (conference != null && conference.standings != null)
                                    {
                                        var standingsVM = new SoccerStandingsViewModel(conference.name);
                                        var entries = conference.standings.entries
                                                        .OrderBy(x => x.stats.FirstOrDefault(x => x.name == "rank")?.value ?? int.MaxValue)
                                                        .ToArray();
                                        List<Models.SoccerStandings.Entry> pageEntries = new List<Models.SoccerStandings.Entry>();
                                        for (int i = 0; i < entries.Count(); i++)
                                        {
                                            if (i > 0 && i % TeamsOnPage == 0)
                                            {
                                                standingsVM.Entries = pageEntries;
                                                var graphic = new SoccerStandings().GetSoccerStandings(standingsVM, i - (TeamsOnPage - 1));
                                                graphics.Add(await graphic);
                                                confTotal += pageEntries.Count;
                                                pageEntries.Clear();
                                            }
                                            pageEntries.Add(entries[i]);
                                        }
                                        standingsVM.Entries = pageEntries;
                                        graphics.Add(await new SoccerStandings().GetSoccerStandings(standingsVM, ++confTotal));
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
                }
            }
            catch (Exception ex)
            {
                log.Error("Error getting soccer standings data: " + ex.Message);
            }
        }
        private async Task GetCFBScores()
        {
            try
            {
                string? scoreURL = ConfigurationManager.AppSettings["ScoreURL"];
                string scoreURLString = scoreURL != null ? scoreURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(scoreURLString, "football", "college-football");
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    FootballScores? footballScores = JsonConvert.DeserializeObject<FootballScores>(content);
                    List<FootballScoreView> graphics = new List<FootballScoreView>();
                    foreach (var game in footballScores.events)
                    {
                        try
                        {
                            var graphic = await new FootballScoreView().GetFootballScore(game, footballScores.leagues.FirstOrDefault());
                            graphics.Add(graphic);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Game ID: " + game.id + " " + ex.Message);
                        }
                    }
                    if (graphics.Count == 0)
                    {
                        sports.Remove("college-football");
                        return;
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
        private async Task GetNFLScores()
        {
            try
            {
                string? scoreURL = ConfigurationManager.AppSettings["ScoreURL"];
                string scoreURLString = scoreURL != null ? scoreURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(scoreURLString, "football", "nfl");
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings();
                    settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                    FootballScores? footballScores = JsonConvert.DeserializeObject<FootballScores>(content, settings);
                    List<FootballScoreView> graphics = new List<FootballScoreView>();
                    foreach (var game in footballScores.events)
                    {
                        try
                        {
                            if (ShowGame(game.date, game.status.type))
                            {
                                var graphic = await new FootballScoreView().GetFootballScore(game, footballScores.leagues.FirstOrDefault());
                                graphics.Add(graphic);
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("Game ID: " + game.id + " " + ex.Message);
                        }
                    }
                    if (graphics.Count == 0)
                    {
                        sports.Remove("nfl");
                        return;
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
                await GetNFLStandings();
            }
            catch (Exception ex)
            {
                log.Error("Error getting NFL game data: " + ex.Message);
            }
        }
        private async Task GetNFLStandings()
        {
            try
            {
                string? standingsURL = ConfigurationManager.AppSettings["StandingsURL"];
                string standingsURLString = standingsURL != null ? standingsURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(standingsURLString, "football", "nfl");
                finalURL += "?level=" + (int)Statics.StandingLevels.Division;
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    StandingObj? nflStandings = JsonConvert.DeserializeObject<StandingObj>(content);
                    List<NFLStandings> graphics = new List<NFLStandings>();
                    if (nflStandings != null)
                    {
                        foreach (var league in nflStandings.children)
                        {
                            foreach (var division in league.children)
                            {
                                try
                                {
                                    if (division != null)
                                    {
                                        var graphic = new NFLStandings().GetNFLStandings(division);
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
                log.Error("Error getting NFL standing data: " + ex.Message);
            }
        }

        private bool ShowGame(string gameDateStr, dynamic gameState)
        {
            DateTime queryDate = DateTime.Now;
            DateTime gameDate;
            DateTime.TryParse(gameDateStr, out gameDate);
            if (queryDate.Date == gameDate.Date || (gameState.state == "post") && (gameState.detail == "FT") && gameDate.AddDays(1) == queryDate.Date)
            {
                return true;
            }
            return false;
        }
    }
}