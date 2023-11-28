using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Models.FootballScores;
using AvaloniaScoreDisplay.Models.SoccerScores;
using AvaloniaScoreDisplay.Models.ConfStandings;
using AvaloniaScoreDisplay.Models.HockeyScores;
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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AvaloniaScoreDisplay.Views.Standings.Hockey;
using AvaloniaScoreDisplay.Models.BasketballScore;
using AvaloniaScoreDisplay.Views.Standings.Basketball;
using SkiaSharp;

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
                var bitmap = new Avalonia.Media.Imaging.Bitmap(path);
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
                    string[] sportsCopy = sports.ToArray();
                    for (int i = 0; i < sportsCopy.Length; i++)
                    {
                        switch (sportsCopy[i].ToLower())
                        {
                            case "baseball":
                                await GetMLBScores();
                                break;
                            case "soccer":
                                //await GetSoccerScores();
                                break;
                            case "college-football":
                                //await GetCFBScores();
                                break;
                            case "nfl":
                                //await GetNFLScores();
                                //await GetNFLStandings();
                                break;
                            case "hockey":
                                await GetNHLScores();
                                //await GetNHLStandings();
                                break;
                            case "basketball":
                                await GetNBAScores();
                                //await GetNBAStandings();
                                break;
                            case "mens-college-basketball":
                                await GetNCAAMScores();
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
                            if (ShowGame(game.date, game.status.type))
                            {
                                var graphic = await new MLB().GetMLBGameScore(game);
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
                                        division.standings.entries = division.standings.entries
                                            .Where(entry => entry.stats.Any(stat => stat.abbreviation == "SEED"))
                                            .OrderBy(entry => entry.stats.FirstOrDefault(stat => stat.abbreviation == "SEED")?.value)
                                            .ToArray();

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
                                        List<Models.ConfStandings.Entry> pageEntries = new List<Models.ConfStandings.Entry>();
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
                string? ncaaScoreGroupsValue = ConfigurationManager.AppSettings["NCAAScoreGroups"];
                if (!string.IsNullOrEmpty(ncaaScoreGroupsValue))
                {
                    List<FootballScoreView> finalGraphics = new List<FootballScoreView>();
                    List<string> finalGameIds = new List<string>();
                    string? scoreURL = ConfigurationManager.AppSettings["ScoreURL"];
                    string[] scoreGroups = ncaaScoreGroupsValue.Split(',');
                    string scoreURLString = scoreURL != null ? scoreURL.ToString() : string.Empty;
                    var finalURL = ReplaceURL(scoreURLString, "football", "college-football");
                    foreach (var group in scoreGroups)
                    {
                        var shortGroup = Int16.Parse(group);
                        if (shortGroup != (Int16)Statics.NCAAGroupID.Top25)
                        {
                            finalURL += "?enable=groups&groups=" + group;
                        }
                        using (var client = new HttpClient())
                        {
                            var response = await client.GetAsync(finalURL);
                            var content = await response.Content.ReadAsStringAsync();
                            FootballScores? footballScores = JsonConvert.DeserializeObject<FootballScores>(content);
                            foreach (var game in footballScores.events)
                            {
                                try
                                {
                                    if (!finalGameIds.Contains(game.id) && ShowGame(game.date, game.status.type))
                                    {
                                        var graphic = await new FootballScoreView().GetFootballScore(game, footballScores.leagues.FirstOrDefault());
                                        finalGraphics.Add(graphic);
                                        finalGameIds.Add(game.id);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Error("Game ID: " + game.id + " " + ex.Message);
                                }
                            }
                        }
                    }
                    if (finalGraphics.Count == 0)
                    {
                        sports.Remove("college-football");
                        return;
                    }
                    foreach (var g in finalGraphics)
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
                log.Error("Error getting CFB game data: " + ex.Message);
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
        private async Task GetNHLScores()
        {
            try
            {
                string? scoreURL = ConfigurationManager.AppSettings["ScoreURL"];
                string scoreURLString = scoreURL != null ? scoreURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(scoreURLString, "hockey", "nhl");
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings();
                    settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                    HockeyScores? hockeyScores = JsonConvert.DeserializeObject<HockeyScores>(content, settings);
                    List<Scoreboard> graphics = new List<Scoreboard>();
                    foreach (var game in hockeyScores.events)
                    {
                        try
                        {
                            if (ShowGame(game.date, game.status.type))
                            {
                                var graphic = await new Scoreboard().GetHockeyScore(hockeyScores.leagues.FirstOrDefault().name, hockeyScores.leagues.FirstOrDefault().abbreviation, game);
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
                        sports.Remove("hockey");
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
                    await GetNHLStandings();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error getting NHL game data: " + ex.Message);
            }
        }
        private async Task GetNHLStandings()
        {
            try
            {
                const int TeamsOnPage = 4;
                string? standingsURL = ConfigurationManager.AppSettings["StandingsURL"];
                string standingsURLString = standingsURL != null ? standingsURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(standingsURLString, "hockey", "nhl");
                finalURL += "?level=" + (int)Statics.StandingLevels.Division;
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    StandingObj? hockeyStandings = JsonConvert.DeserializeObject<StandingObj>(content);
                    List<HockeyStandings> graphics = new List<HockeyStandings>();
                    if (hockeyStandings != null)
                    {
                        foreach (var league in hockeyStandings.children)
                        {
                            foreach (var division in league.children)
                            {
                                try
                                {
                                    int divTotal = 0;
                                    if (division != null)
                                    {
                                        var standingsVM = new StandingsViewModel(division.name);
                                        var entries = division.standings.entries
                                                        .OrderBy(x => x.stats.FirstOrDefault(x => x.name == "rank")?.value ?? int.MaxValue)
                                                        .ToArray();
                                        List<Models.Standings.Entry> pageEntries = new List<Models.Standings.Entry>();
                                        for (int i = 0; i < entries.Count(); i++)
                                        {
                                            if (i > 0 && i % TeamsOnPage == 0)
                                            {
                                                standingsVM.Entries = pageEntries;
                                                var graphic = new HockeyStandings().GetHockeyStandings(standingsVM, i - (TeamsOnPage - 1));
                                                graphics.Add(await graphic);
                                                divTotal += pageEntries.Count;
                                                pageEntries.Clear();
                                            }
                                            pageEntries.Add(entries[i]);
                                        }
                                        standingsVM.Entries = pageEntries;
                                        graphics.Add(await new HockeyStandings().GetHockeyStandings(standingsVM, ++divTotal));
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
                log.Error("Error getting NHL standing data: " + ex.Message);
            }
        }
        private async Task GetNBAScores()
        {
            try
            {
                string? scoreURL = ConfigurationManager.AppSettings["ScoreURL"];
                string scoreURLString = scoreURL != null ? scoreURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(scoreURLString, "basketball", "nba");
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings();
                    settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                    BasketballScore? basketballScores = JsonConvert.DeserializeObject<BasketballScore>(content, settings);
                    List<Scoreboard> graphics = new List<Scoreboard>();
                    foreach (var game in basketballScores.events)
                    {
                        try
                        {
                            if (ShowGame(game.date, game.status.type))
                            {
                                var graphic = await new Scoreboard().GetBasketballScore(basketballScores.leagues.FirstOrDefault().name, basketballScores.leagues.FirstOrDefault().abbreviation, game);
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
                        sports.Remove("basketball");
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
                    await GetNBAStandings();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error getting NBA game data: " + ex.Message);
            }
        }
        private async Task GetNBAStandings()
        {
            try
            {
                const int TeamsOnPage = 5;
                string? standingsURL = ConfigurationManager.AppSettings["StandingsURL"];
                string standingsURLString = standingsURL != null ? standingsURL.ToString() : string.Empty;
                var finalURL = ReplaceURL(standingsURLString, "basketball", "nba");
                finalURL += "?level=" + (int)Statics.StandingLevels.Conference;
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(finalURL);
                    var content = await response.Content.ReadAsStringAsync();
                    StandingObj? nbaStandings = JsonConvert.DeserializeObject<StandingObj>(content);
                    SoccerStandingsMod soccerStandings = JsonConvert.DeserializeObject<SoccerStandingsMod>(content);
                    List<BasketballStandings> graphics = new List<BasketballStandings>();
                    if (nbaStandings != null)
                    {
                        foreach (var league in soccerStandings.children)
                        {
                            try
                            {
                                foreach (var conference in soccerStandings.children)
                                {
                                    int confTotal = 0;
                                    if (conference != null && conference.standings != null)
                                    {
                                        var standingsVM = new ConfStandingsViewModel(conference.name);
                                        var entries = conference.standings.entries
                                                        .OrderBy(x => x.stats.FirstOrDefault(x => x.name == "playoffSeed")?.value ?? int.MaxValue)
                                                        .ToArray();
                                        List<Models.ConfStandings.Entry> pageEntries = new List<Models.ConfStandings.Entry>();
                                        for (int i = 0; i < entries.Count(); i++)
                                        {
                                            if (i > 0 && i % TeamsOnPage == 0)
                                            {
                                                standingsVM.Entries = pageEntries;
                                                var graphic = new BasketballStandings().GetBasketballStandings(standingsVM, i - (TeamsOnPage - 1));
                                                graphics.Add(await graphic);
                                                confTotal += pageEntries.Count;
                                                pageEntries.Clear();
                                            }
                                            pageEntries.Add(entries[i]);
                                        }
                                        standingsVM.Entries = pageEntries;
                                        graphics.Add(await new BasketballStandings().GetBasketballStandings(standingsVM, ++confTotal));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error("Game ID: " + " " + ex.Message);
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
                log.Error("Error getting NHL standing data: " + ex.Message);
            }
        }

        private async Task GetNCAAMScores()
        {
            try
            {
                string? ncaaScoreGroupsValue = ConfigurationManager.AppSettings["NCAAMScoreGroups"];
                if (!string.IsNullOrEmpty(ncaaScoreGroupsValue))
                {
                    List<Scoreboard> graphics = new List<Scoreboard>();
                    List<string> finalGameIds = new List<string>();
                    string? scoreURL = ConfigurationManager.AppSettings["ScoreURL"];
                    string[] scoreGroups = ncaaScoreGroupsValue.Split(',');
                    string scoreURLString = scoreURL != null ? scoreURL.ToString() : string.Empty;
                    var finalURL = ReplaceURL(scoreURLString, "basketball", "mens-college-basketball");
                    foreach (var group in scoreGroups)
                    {
                        var shortGroup = Int16.Parse(group);
                        if (shortGroup != (Int16)Statics.NCAAGroupID.Top25)
                        {
                            finalURL += "?enable=groups&groups=" + group;
                        }
                        using (var client = new HttpClient())
                        {
                            var response = await client.GetAsync(finalURL);
                            var content = await response.Content.ReadAsStringAsync();
                            BasketballScore? basketballScores = JsonConvert.DeserializeObject<BasketballScore>(content);
                            foreach (var game in basketballScores.events)
                            {
                                try
                                {
                                    if (!finalGameIds.Contains(game.id) && ShowGame(game.date, game.status.type))
                                    {
                                        var graphic = await new Scoreboard().GetBasketballScore(basketballScores.leagues.FirstOrDefault().name, basketballScores.leagues.FirstOrDefault().abbreviation, game);
                                        graphics.Add(graphic);
                                        finalGameIds.Add(game.id);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Error("Game ID: " + game.id + " " + ex.Message);
                                }
                            }
                        }
                    }
                    if (graphics.Count == 0)
                    {
                        sports.Remove("mens-college-basketball");
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
                log.Error("Error getting NCAAM game data: " + ex.Message);
            }
        }

        private bool ShowGame(string gameDateStr, dynamic gameState)
        {
            DateTime queryDate = DateTime.Now;
            DateTime gameDate;
            DateTime.TryParse(gameDateStr, out gameDate);
            if (queryDate.Date == gameDate.Date || (gameState.state == "post") && ((gameState.detail == "FT") || (gameState.detail == "Final")) && gameDate.AddDays(1).Date == queryDate.Date)
            {
                return true;
            }
            return false;
        }
    }
}