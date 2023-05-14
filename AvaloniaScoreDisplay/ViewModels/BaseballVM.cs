using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.ViewModels
{
    public class BaseballVM
    {
        public string? HomeAbr { get; set; }
        public string? AwayAbr { get; set; }
        public string? HomeLogo { get; set; }
        public string? AwayLogo { get; set; }
        public string? HomeName { get; set; }
        public string? AwayName { get; set; }
        public string? HomeRecord { get; set; }
        public string? AwayRecord { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int HomeHits { get; set; }
        public int AwayHits { get; set; }
        public int HomeErrors { get; set; }
        public int AwayErrors { get; set; }
        public string? Inning { get; set; }
        public string? Moneyline { get; set; }
        public string? OverUnder { get; set; }
        public string? HomeStarter { get; set; }
        public string? AwayStarter { get; set; }
        public string? HomeStarterStats { get; set; }
        public string? AwayStarterStats { get; set; }
    }
}
