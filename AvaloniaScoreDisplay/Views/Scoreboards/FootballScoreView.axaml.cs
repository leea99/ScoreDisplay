using Avalonia.Controls;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models.FootballScores;
using System;
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
            await GetGeneralInfo(game);
            if (game.competitions[0].status.type.state == "in")
            {
                //GetInStateAttributes(game);
            }
            else if (game.competitions[0].status.type.state == "pre")
            {
                GetPreStateAttributes(game);
            }
            else if (game.competitions[0].status.type.state == "post" && game.competitions[0].status.type.completed)
            {
                //GetFinalStateAttributes(game);
            }
            return this;
        }

        private async Task GetGeneralInfo(Event game)
        {
            var competition = game.competitions.First();
            if (competition != null)
            {
                var home = competition.competitors.FirstOrDefault(x => x.homeAway == "home");
                if (home != null)
                {
                    if (home.team.logo != null && home.team.logo != "")
                    {
                        using (var httpClient = new HttpClient())
                        using (var response = await httpClient.GetAsync(home.team.logo))
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            var memoryStream = new MemoryStream();
                            await stream.CopyToAsync(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            var bitmap = new Bitmap(memoryStream);
                            HomeTeam.Source = bitmap;
                        }
                    }
                    HomeTeamName.Text = home.team.displayName;
                    if (home.records != null && home.records.Length > 0)
                    {
                        HomeTeamRecord.Text = home.records.First().summary;
                    }
                    HomeScore.Text = home.score;
                }
                var away = competition.competitors.FirstOrDefault(x => x.homeAway == "away");
                if (away != null)
                {
                    if (away.team.logo != null && away.team.logo != "")
                    {
                        using (var httpClient = new HttpClient())
                        using (var response = await httpClient.GetAsync(away.team.logo))
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            var memoryStream = new MemoryStream();
                            await stream.CopyToAsync(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            var bitmap = new Bitmap(memoryStream);
                            AwayTeam.Source = bitmap;
                        }
                    }
                    AwayTeamName.Text = away.team.displayName;
                    if (away.records != null && away.records.Length > 0)
                    {
                        AwayTeamRecord.Text = away.records.First().summary;
                    }
                    AwayScore.Text = away.score;
                }
            }
        }
        private void GetPreStateAttributes(Event game)
        {
            var competition = game.competitions.FirstOrDefault();
            if (competition != null)
            {
                var odds = competition.odds.LastOrDefault();
                if (odds != null && odds.details != null)
                {
                    Info1.Text = odds.details;
                    Info2.Text = "O/U: " + odds.overUnder.ToString();
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
    }
}
