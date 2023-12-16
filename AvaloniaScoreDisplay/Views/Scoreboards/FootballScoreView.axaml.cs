using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models.FootballScores;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views.Scoreboards
{
    public partial class FootballScoreView : UserControl
    {
        public FootballScoreView()
        {
            InitializeComponent();
        }

        public async Task<FootballScoreView> GetFootballScore(Event game, League? league)
        {
            if (league != null)
            {
                LeagueName.Text = league.name + " Scores";
            }
            await GetGeneralInfo(game, league);
            if (game.competitions[0].status.type.state == "in")
            {
                GetInStateAttributes(game);
            }
            else if (game.competitions[0].status.type.state == "pre")
            {
                GetPreStateAttributes(game);
            }
            else if (game.competitions[0].status.type.state == "post" && game.competitions[0].status.type.completed)
            {
                GetFinalStateAttributes(game);
            }
            return this;
        }

        private async Task GetGeneralInfo(Event game, League? league)
        {
            var competition = game.competitions.First();
            if (competition != null)
            {
                var home = competition.competitors.FirstOrDefault(x => x.homeAway == "home");
                if (home != null)
                {
                    string? homeLogo = null;
                    if (league != null && league.abbreviation == "NFL")
                    {
                        homeLogo = Models.Statics.GetDarkTeamLogo("nfl", home.team.abbreviation, home.team.color);
                    }
                    else if (league != null && league.abbreviation == "NCAAF")
                    {
                        homeLogo = Models.Statics.GetDarkTeamLogo("ncaa", home.team.id, home.team.color);
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
                    Color parsedColor = Color.Parse('#' + home.team.color);
                    Color homeColor = new Color(192, parsedColor.R, parsedColor.G, parsedColor.B);
                    HomeLogoBack.Background = new SolidColorBrush(homeColor);
                    HomeTeamBack.Background = new SolidColorBrush(homeColor);
                    HomeRecordBack.Background = new SolidColorBrush(homeColor);
                    HomeTeamName.Text = home.team.abbreviation;
                    if (home.curatedRank != null && home.curatedRank.current <= 25)
                    {
                        HomeTeamName.Text = "#" + home.curatedRank.current + " " + HomeTeamName.Text;
                    }
                    if (home.records != null && home.records.Length > 0)
                    {
                        HomeTeamRecord.Text = home.records.First().summary;
                    }
                    else
                    {
                        HomeTeamRecord.Text = "0-0";
                    }
                    HomeScore.Text = home.score;
                }
                var away = competition.competitors.FirstOrDefault(x => x.homeAway == "away");
                if (away != null)
                {
                    string? awayLogo = null;
                    if (league != null && league.abbreviation == "NFL")
                    {
                        awayLogo = Models.Statics.GetDarkTeamLogo("nfl", away.team.abbreviation, away.team.color);
                    }
                    else if (league != null && league.abbreviation == "NCAAF")
                    {
                        awayLogo = Models.Statics.GetDarkTeamLogo("ncaa", away.team.id, away.team.color);
                    }
                    if (awayLogo != null)
                    {
                        using (var httpClient = new HttpClient())
                        using (var response = await httpClient.GetAsync(awayLogo))
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            var memoryStream = new MemoryStream();
                            await stream.CopyToAsync(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            var bitmap = new Bitmap(memoryStream);
                            AwayTeam.Source = bitmap;
                        }
                    }
                    Color parsedColor = Color.Parse('#' + away.team.color);
                    Color awayColor = new Color(192, parsedColor.R, parsedColor.G, parsedColor.B);
                    AwayLogoBack.Background = new SolidColorBrush(awayColor);
                    AwayTeamBack.Background = new SolidColorBrush(awayColor);
                    AwayRecordBack.Background = new SolidColorBrush(awayColor);
                    AwayTeamName.Text = away.team.abbreviation;
                    if (away.curatedRank != null && away.curatedRank.current <= 25)
                    {
                        AwayTeamName.Text = "#" + away.curatedRank.current + " " + AwayTeamName.Text;
                    }
                    if (away.records != null && away.records.Length > 0)
                    {
                        AwayTeamRecord.Text = away.records.First().summary;
                    }
                    else
                    {
                        AwayTeamRecord.Text = "0-0";
                    }
                    AwayScore.Text = away.score;
                }
            }
        }

        private void GetInStateAttributes(Event game)
        {
            var competition = game.competitions.FirstOrDefault();
            if (competition != null)
            {
                GameStatus.Text = competition.status.type.shortDetail;
                GameStatus.FontSize = 25;
                Info1.Text = competition.situation.downDistanceText;
                Info1.FontSize = 25;
            }
        }
        private void GetPreStateAttributes(Event game)
        {
            var competition = game.competitions.FirstOrDefault();
            if (competition != null)
            {
                if (competition.odds != null)
                {
                    var odds = competition.odds.LastOrDefault();
                    if (odds != null && odds.details != null)
                    {
                        Info1.Text = odds.details;
                        Info2.Text = "O/U: " + odds.overUnder.ToString();
                    }
                }
                DateTime startDate = new DateTime();
                DateTime.TryParse(competition.startDate, out startDate);
                GameStatus.Text = startDate.ToLocalTime().ToString("h:mm tt");
                if (competition.broadcasts != null && competition.broadcasts.FirstOrDefault() != null)
                {
                    var broadcast = competition.broadcasts.FirstOrDefault();
                    if (broadcast != null && broadcast.market == "national")
                    {
                        Channel.Text = broadcast.names.FirstOrDefault();
                        ChannelBox.IsVisible = true;
                    }
                }
            }
        }
        private void GetFinalStateAttributes(Event game)
        {
            var competition = game.competitions.FirstOrDefault();
            if (competition != null)
            {
                GameStatus.Text = competition.status.type.shortDetail;
                GameStatus.FontSize = 25;
            }
        }
    }
}
