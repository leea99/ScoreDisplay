using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Models
{


    public class StandingObj
    {
        public string uid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string shortName { get; set; }
        public Child[] children { get; set; }
        public Link2[] links { get; set; }
        public Season[] seasons { get; set; }
    }

    public class Child
    {
        public string uid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string shortName { get; set; }
        public Child1[] children { get; set; }
    }

    public class Child1
    {
        public string uid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string shortName { get; set; }
        public Standings standings { get; set; }
    }

    public class Standings
    {
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public Link[] links { get; set; }
        public int season { get; set; }
        public int seasonType { get; set; }
        public string seasonDisplayName { get; set; }
        public Entry[] entries { get; set; }
    }


    public class Entry
    {
        public Team team { get; set; }
        public Stat[] stats { get; set; }
    }
    public class Stat
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string description { get; set; }
        public string abbreviation { get; set; }
        public string type { get; set; }
        public float value { get; set; }
        public string displayValue { get; set; }
        public string id { get; set; }
        public string summary { get; set; }
    }

}
