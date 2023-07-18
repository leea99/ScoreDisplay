using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models.SoccerScores;
using AvaloniaScoreDisplay.Scoreboards;
using AvaloniaScoreDisplay.ViewModels;
using JetBrains.Annotations;
using ReactiveUI;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views.Scoreboards
{
    public partial class SoccerScoreView : UserControl
    {
        public SoccerScoreView()
        {
            InitializeComponent();
            var path = Directory.GetCurrentDirectory();
            path = System.IO.Path.Combine(path, "Images", "background.png");
            var bitmap = new Bitmap(path);
            Background = new ImageBrush(bitmap)
            {
                Stretch = Stretch.Fill
            };
        }
        public async Task<SoccerScoreView> GetSoccerScore(Event game, League? league)
        {
            if (league != null)
            {
                LeagueName.Text = league.name + " Scores";
            }
            await GetGeneralInfo(game);
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
                    HomeTeamRecord.Text = home.records.First().summary;
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
                    AwayTeamRecord.Text = away.records.First().summary;
                    AwayScore.Text = away.score;
                }
            }
        }

        private void GetInStateAttributes(Event game)
        {
            var competition = game.competitions.FirstOrDefault();
            if (competition != null)
            {
                GameStatus.Text = game.status.displayClock.ToString();
            }
        }
        private void GetPreStateAttributes(Event game)
        {
            var competition = game.competitions.FirstOrDefault();
            if (competition != null)
            {
                var odds = competition.odds.LastOrDefault();
                if (odds != null)
                {
                    string homeOdds = odds.homeTeamOdds.moneyLine.ToString();
                    if (!homeOdds.Contains('-'))
                    {
                        homeOdds = '+' + homeOdds;
                    }
                    homeOdds = odds.homeTeamOdds.team.abbreviation + ": " + homeOdds;
                    string awayOdds = odds.awayTeamOdds.moneyLine.ToString();
                    if (!awayOdds.Contains('-'))
                    {
                        awayOdds = '+' + awayOdds;
                    }
                    awayOdds = odds.awayTeamOdds.team.abbreviation + ": " + awayOdds;
                    string drawOdds = odds.drawOdds.moneyLine.ToString();
                    if (!drawOdds.Contains('-'))
                    {
                        drawOdds = '+' + drawOdds;
                    }
                    drawOdds = "Draw: " + drawOdds;
                    Info1.Text = homeOdds + ", " + awayOdds + ", " + drawOdds;
                    Info2.Text = "O/U: " + odds.overUnder.ToString();
                }
                DateTime startDate = new DateTime();
                DateTime.TryParse(competition.startDate, out startDate);
                GameStatus.Text = startDate.ToLocalTime().ToString("h:mm tt");
            }
        }
        private void GetFinalStateAttributes(Event game)
        {
            var competition = game.competitions.FirstOrDefault();
            if (competition != null)
            {
                GetGameEvents(game);
                GameStatus.Text = competition.status.type.shortDetail;
            }
        }

        private void GetGameEvents(Event game)
        {
            var competition = game.competitions.FirstOrDefault();
            var home = competition.competitors.FirstOrDefault(x => x.homeAway == "home");
            var away = competition.competitors.FirstOrDefault(x => x.homeAway == "away");
            List<SoccerEventViewModel> goalScorers = new List<SoccerEventViewModel>();
            List<SoccerEventViewModel> redCards = new List<SoccerEventViewModel>();
            foreach (var detail in competition.details)
            {
                dynamic dynamicDetail = (dynamic)detail;
                string type = dynamicDetail.type.text;
                bool scoringPlay = dynamicDetail.scoringPlay;
                string displayTime = dynamicDetail.clock.displayValue;
                if (scoringPlay)
                {
                    int playerId = dynamicDetail.athletesInvolved[0].id;
                    var goalMatch = goalScorers.FirstOrDefault(x => x.PlayerId == playerId);
                    if (goalMatch == null)
                    {
                        goalScorers.Add(new SoccerEventViewModel()
                        {
                            PlayerId = dynamicDetail.athletesInvolved[0].id,
                            TeamId = dynamicDetail.athletesInvolved[0].team.id,
                            EventTimes = new List<string> { displayTime },
                            Name = dynamicDetail.athletesInvolved[0].displayName,
                        });
                    }
                    else if (goalMatch.EventTimes != null)
                    {
                        string time = dynamicDetail.clock.displayValue;
                        goalMatch.EventTimes.Add(time);
                    }
                }
                else if (type == "Red Card") {
                    var redCardMatch = redCards.FirstOrDefault(x => x.PlayerId == dynamicDetail.athletesInvolved[0].id);
                    if (redCardMatch == null)
                    {
                        redCards.Add(new SoccerEventViewModel()
                        {
                            PlayerId = dynamicDetail.athletesInvolved[0].id,
                            TeamId = dynamicDetail.athletesInvolved[0].team.id,
                            EventTimes = new List<string> { displayTime },
                            Name = dynamicDetail.athletesInvolved[0].displayName,
                        });
                    }
                    else if (redCardMatch.EventTimes != null)
                    {
                        redCardMatch.EventTimes.Add(dynamicDetail.clock.displayValue);
                    }
                }
            }
            AvaloniaList<object> homeGoals = new AvaloniaList<object>();
            AvaloniaList<object> awayGoals = new AvaloniaList<object>();
            foreach (var scorer in goalScorers)
            {
                string goals = "";
                if (home != null && scorer.TeamId.ToString() == home.id)
                {
                    goals += scorer.Name + ":";
                    if (scorer.EventTimes != null)
                    {
                        foreach (var goal in scorer.EventTimes)
                        {
                            goals += " " + goal;
                            if (goal != scorer.EventTimes.LastOrDefault())
                            {
                                goals += ',';
                            }
                        }
                    }
                    homeGoals.Add(new ListBoxItem() { Content = goals });
                }
                else
                {
                    goals += scorer.Name + ":";
                    if (scorer.EventTimes != null)
                    {
                        foreach (var goal in scorer.EventTimes)
                        {
                            goals += " " + goal;
                            if (goal != scorer.EventTimes.LastOrDefault())
                            {
                                goals += ',';
                            }
                        }
                    }
                    try
                    {
                        awayGoals.Add(new ListBoxItem() { Content = goals, Foreground = new SolidColorBrush(Colors.White) });
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            HomeGoals.Items = homeGoals;
            AwayGoals.Items = awayGoals;
            string homeReds = "";
            string awayReds = "";
            if (redCards.Count > 0)
            {
                foreach (var player in redCards)
                {
                    if (home != null && player.TeamId.ToString() == home.id)
                    {
                        homeReds += player.Name + ":";
                        if (player.EventTimes != null)
                        {
                            foreach (var goal in player.EventTimes)
                            {
                                homeReds += " " + goal;
                                if (goal != player.EventTimes.LastOrDefault())
                                {
                                    homeReds += ',';
                                }
                            }
                        }
                        homeReds += '\n';
                    }
                    else
                    {
                        awayReds += player.Name + ":";
                        if (player.EventTimes != null)
                        {
                            foreach (var goal in player.EventTimes)
                            {
                                awayReds += " " + goal;
                                if (goal != player.EventTimes.LastOrDefault())
                                {
                                    awayReds += ',';
                                }
                            }
                        }
                        awayReds += '\n';
                    }
                }
            }
            else
            {
                HomeReds.IsVisible = false;
                AwayReds.IsVisible = false;
            }
            HomeReds.Text = homeReds;
            AwayReds.Text = awayReds;
        }
    }
}
