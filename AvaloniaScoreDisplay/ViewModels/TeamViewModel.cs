using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.ViewModels
{
    public class TeamViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty; 
        public int? Rank { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Score { get; set; } = string.Empty;
        public string Record { get; set; } = string.Empty;
    }
}
