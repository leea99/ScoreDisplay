using AvaloniaScoreDisplay.Models.Standings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvaloniaScoreDisplay.ViewModels
{
    public class StandingsViewModel : ConferenceStandingsViewModel
    {
        public List<Entry>? Entries { get; set; }

        public StandingsViewModel(string name)
        {
            Name = name;
            Entries = new List<Entry>();
        }
    }
}
