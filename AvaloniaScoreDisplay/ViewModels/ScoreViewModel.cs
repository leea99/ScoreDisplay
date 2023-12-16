using AvaloniaScoreDisplay.Models.BaseballGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.ViewModels
{
    public class ScoreViewModel
    {
        public string LeagueName { get; set; } = string.Empty;
        public string LeagueAbbr { get; set; } = string.Empty;
        public TeamViewModel? HomeTeam { get; set; }
        public TeamViewModel? AwayTeam { get; set; }
        public string Info1 { get; set; } = string.Empty;
        public string Info2 { get; set; } = string.Empty;
        public string GameState { get; set; } = string.Empty;
        public string GameStatus { get; set; } = string.Empty;
        public string Channel { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;
    }
}
