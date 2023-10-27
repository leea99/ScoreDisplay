using Avalonia.Controls;
using Avalonia.Media;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using AvaloniaScoreDisplay.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models.HockeyScores;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace AvaloniaScoreDisplay.Views.Scoreboards
{
    public partial class Scoreboard : UserControl
    {
        public Scoreboard()
        {
            InitializeComponent();
        }

        public async Task<Scoreboard> GetHockeyScore(string league, string leagueAbbr, Event game)
        {
            if (game.competitions[0] != null)
            {
                var homeTeam = GetTeamDetails(game.competitions[0].competitors.FirstOrDefault(x => x.homeAway == "home"));
                var awayTeam = GetTeamDetails(game.competitions[0].competitors.FirstOrDefault(x => x.homeAway == "away"));

                var gameData = new ScoreViewModel()
                {
                    LeagueName = league,
                    LeagueAbbr = leagueAbbr,
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    GameState = game.competitions[0].status.type.state ?? "",
                    GameStatus = game.competitions[0].status.type.shortDetail ?? "",
                    IsComplete = game.competitions[0].status.type.completed,
                };
                if (game.competitions[0].broadcasts != null && game.competitions[0].broadcasts.FirstOrDefault() != null)
                {
                    var broadcast = game.competitions[0].broadcasts.FirstOrDefault();
                    if (broadcast != null)
                    {
                        gameData.Channel = broadcast.names.FirstOrDefault() ?? "";
                    }
                }
                if (gameData.GameState == "pre")
                {
                    if (game.competitions[0].odds.FirstOrDefault() != null )
                    {
                        gameData.Info1 = game.competitions[0].odds.FirstOrDefault()?.details ?? "";
                        gameData.Info2 = "O/U: " + game.competitions[0].odds.FirstOrDefault()?.overUnder.ToString() ?? "";
                    }
                }
                return await GetScoreDetails(gameData, leagueAbbr);
            }
            return new Scoreboard();
        }
        public async Task<Scoreboard> GetBasketballScore(string league, string leagueAbbr, Models.BasketballScore.Event game)
        {
            if (game.competitions[0] != null)
            {
                var homeTeam = GetTeamDetails(game.competitions[0].competitors.FirstOrDefault(x => x.homeAway == "home"));
                var awayTeam = GetTeamDetails(game.competitions[0].competitors.FirstOrDefault(x => x.homeAway == "away"));

                var gameData = new ScoreViewModel()
                {
                    LeagueName = league,
                    LeagueAbbr = leagueAbbr,
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    GameState = game.competitions[0].status.type.state ?? "",
                    GameStatus = game.competitions[0].status.type.shortDetail ?? "",
                    IsComplete = game.competitions[0].status.type.completed,
                };
                if (game.competitions[0].broadcasts != null && game.competitions[0].broadcasts.FirstOrDefault() != null)
                {
                    var broadcast = game.competitions[0].broadcasts.FirstOrDefault();
                    if (broadcast != null)
                    {
                        gameData.Channel = broadcast.names.FirstOrDefault() ?? "";
                    }
                }
                if (gameData.GameState == "pre")
                {
                    if (game.competitions[0].odds.FirstOrDefault() != null)
                    {
                        gameData.Info1 = game.competitions[0].odds.FirstOrDefault()?.details ?? "";
                        gameData.Info2 = "O/U: " + game.competitions[0].odds.FirstOrDefault()?.overUnder.ToString() ?? "";
                    }
                }
                return await GetScoreDetails(gameData, leagueAbbr);
            }
            return new Scoreboard();
        }

        private TeamViewModel GetTeamDetails(dynamic? team)
        {
            if (team != null)
            {
                var teamVM = new TeamViewModel()
                {
                    Id = team.id,
                    Abbreviation = team.team.abbreviation,
                    Color = team.team.color,
                    Name = team.team.name,
                    Logo = team.team.logo,
                    Score = team.score,
                    Record = team.records[0].summary
                };
                try
                {
                    teamVM.Rank = team.curatedRank.current;
                }
                catch (RuntimeBinderException)
                {
                    //  MyProperty doesn't exist
                }
                return teamVM;
            }
            else
            {
                return new TeamViewModel();
            }
        }

        public async Task<Scoreboard> GetScoreDetails(ScoreViewModel gameData, string leagueAbbr)
        {
            if (gameData.LeagueName != null)
            {
                LeagueName.Text = gameData.LeagueName + " Scores";
            }
            await GetGeneralInfo(gameData, leagueAbbr);
            if (gameData.GameState == "in")
            {
                GetInStateAttributes(gameData);
            }
            else if (gameData.GameState == "pre")
            {
                GetPreStateAttributes(gameData);
            }
            else if (gameData.GameState == "post" && gameData.IsComplete)
            {
                GetFinalStateAttributes(gameData);
            }
            return this;
        }

        private async Task GetGeneralInfo(ScoreViewModel gameData, string leagueAbbr)
        {
            if (gameData.HomeTeam != null)
            {
                string? homeLogo = null;
                homeLogo = Models.Statics.GetDarkTeamLogo(leagueAbbr, gameData.HomeTeam.Abbreviation, gameData.HomeTeam.Color);
                if (homeLogo != null)
                {
                    using (var httpClient = new HttpClient())
                    using (var response = await httpClient.GetAsync(homeLogo))
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        var memoryStream = new MemoryStream();
                        await stream.CopyToAsync(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        var bitmap = new Bitmap(memoryStream);
                        HomeTeam.Source = bitmap;
                    }
                }
                Color parsedColor = Color.Parse('#' + gameData.HomeTeam.Color);
                Color homeColor = new Color(192, parsedColor.R, parsedColor.G, parsedColor.B);
                HomeLogoBack.Background = new SolidColorBrush(homeColor);
                HomeTeamBack.Background = new SolidColorBrush(homeColor);
                HomeRecordBack.Background = new SolidColorBrush(homeColor);
                HomeTeamName.Text = gameData.HomeTeam.Abbreviation;
                if (gameData.HomeTeam.Rank != null && gameData.HomeTeam.Rank <= 25)
                {
                    HomeTeamName.Text = "#" + gameData.HomeTeam.Rank + " " + HomeTeamName.Text;
                }
                if (gameData.HomeTeam.Record != null)
                {
                    HomeTeamRecord.Text = gameData.HomeTeam.Record;
                }
                else
                {
                    HomeTeamRecord.Text = "0-0";
                }
                HomeScore.Text = gameData.HomeTeam.Score;
            }
            if (gameData.AwayTeam != null)
            {
                string? AwayLogo = null;
                AwayLogo = Models.Statics.GetDarkTeamLogo(leagueAbbr, gameData.AwayTeam.Abbreviation, gameData.AwayTeam.Color);
                if (AwayLogo != null)
                {
                    using (var httpClient = new HttpClient())
                    using (var response = await httpClient.GetAsync(AwayLogo))
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        var memoryStream = new MemoryStream();
                        await stream.CopyToAsync(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        var bitmap = new Bitmap(memoryStream);
                        AwayTeam.Source = bitmap;
                    }
                }
                Color parsedColor = Color.Parse('#' + gameData.AwayTeam.Color);
                Color AwayColor = new Color(192, parsedColor.R, parsedColor.G, parsedColor.B);
                AwayLogoBack.Background = new SolidColorBrush(AwayColor);
                AwayTeamBack.Background = new SolidColorBrush(AwayColor);
                AwayRecordBack.Background = new SolidColorBrush(AwayColor);
                AwayTeamName.Text = gameData.AwayTeam.Abbreviation;
                if (gameData.AwayTeam.Rank != null && gameData.AwayTeam.Rank <= 25)
                {
                    AwayTeamName.Text = "#" + gameData.AwayTeam.Rank + " " + AwayTeamName.Text;
                }
                if (gameData.AwayTeam.Record != null)
                {
                    AwayTeamRecord.Text = gameData.AwayTeam.Record;
                }
                else
                {
                    AwayTeamRecord.Text = "0-0";
                }
                AwayScore.Text = gameData.AwayTeam.Score;
            }
        }

        private void GetInStateAttributes(ScoreViewModel gameData)
        {
            if (gameData != null)
            {
                GameStatus.Text = gameData.GameStatus;
                GameStatus.FontSize = 25;
                Info1.Text = gameData.Info1;
                Info1.FontSize = 25;
            }
        }
        private void GetPreStateAttributes(ScoreViewModel gameData)
        {
            if (gameData != null)
            {
                Info1.Text = gameData.Info1;
                Info2.Text = gameData.Info2;
                Channel.Text = gameData.Channel;
                ChannelBox.IsVisible = true;
            }
        }
        private void GetFinalStateAttributes(ScoreViewModel gameData)
        {
            if (gameData != null)
            {
                GameStatus.Text = gameData.GameStatus;
                GameStatus.FontSize = 25;
            }
        }
    }
}
