using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.ViewModels
{
    public class SoccerEventViewModel
    {
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public List<string>? EventTimes { get; set; }
        public int TeamId { get; set; }
    }
}
