using Avalonia.Controls;
using Avalonia.Media;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using AvaloniaScoreDisplay.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Avalonia.Media.Imaging;

namespace AvaloniaScoreDisplay.Views.Scoreboards
{
    public partial class Scoreboard : UserControl
    {
        public Scoreboard()
        {
            InitializeComponent();
        }

        public async Task<Scoreboard> GetScoreDetails(ScoreViewModel gameData)
        {
            if (gameData.LeagueName != null)
            {
                LeagueName.Text = gameData.LeagueName + " Scores";
            }
            await GetGeneralInfo(gameData);
            if (gameData.GameStatus == "in")
            {
                GetInStateAttributes(gameData);
            }
            else if (gameData.GameStatus == "pre")
            {
                GetPreStateAttributes(gameData);
            }
            else if (gameData.GameStatus == "post" && gameData.IsComplete)
            {
                GetFinalStateAttributes(gameData);
            }
            return this;
        }

        private async Task GetGeneralInfo(ScoreViewModel gameData)
        {
            if (gameData.HomeTeam != null)
            {
                string? homeLogo = null;
                if (gameData.LeagueAbbr == "NFL")
                {
                    homeLogo = Models.Statics.GetDarkTeamLogo("nfl", gameData.HomeTeam.Id, gameData.HomeTeam.Color);
                }
                else if (gameData.LeagueAbbr == "NCAAF")
                {
                    homeLogo = Models.Statics.GetDarkTeamLogo("ncaa", gameData.HomeTeam.Id, gameData.HomeTeam.Color);
                }
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
                if (gameData.LeagueAbbr == "NFL")
                {
                    AwayLogo = Models.Statics.GetDarkTeamLogo("nfl", gameData.AwayTeam.Id, gameData.AwayTeam.Color);
                }
                else if (gameData.LeagueAbbr == "NCAAF")
                {
                    AwayLogo = Models.Statics.GetDarkTeamLogo("ncaa", gameData.AwayTeam.Id, gameData.AwayTeam.Color);
                }
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
