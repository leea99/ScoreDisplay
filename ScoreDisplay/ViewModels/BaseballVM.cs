using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreDisplay.ViewModels
{
    public class BaseballVM
    {
        public string HomeLogo { get; set; }
        public string AwayLogo { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int HomeHits { get; set; }
        public int AwayHits { get; set; }
        public int HomeErrors { get; set; }
        public int AwayErrors { get; set; }
        public string Inning { get; set; }
    }
}
