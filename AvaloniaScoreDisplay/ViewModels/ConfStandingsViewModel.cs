using AvaloniaScoreDisplay.Models.ConfStandings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.ViewModels
{
    public class ConfStandingsViewModel : ConferenceStandingsViewModel
    {
        public List<Entry>? Entries { get; set; }

        public ConfStandingsViewModel(string name)
        {
            Name = name;
            Entries = new List<Entry>();
        }
    }
}
