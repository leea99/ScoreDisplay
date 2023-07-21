using AvaloniaScoreDisplay.Models.SoccerStandings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.ViewModels
{
    public class SoccerStandingsViewModel : ConferenceStandingsViewModel
    {
        public List<Entry>? Entries { get; set; }

        public SoccerStandingsViewModel(string name)
        {
            Name = name;
            Entries = new List<Entry>();
        }
    }
}
