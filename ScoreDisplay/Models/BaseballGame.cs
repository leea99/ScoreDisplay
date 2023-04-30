using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreDisplay.Models.BaseballGame
{

    public class Rootobject
    {
        public object[] notes { get; set; }
        public Boxscore boxscore { get; set; }
        public Format format { get; set; }
        public Gameinfo gameInfo { get; set; }
        public object[] seasonseries { get; set; }
        public object[] broadcasts { get; set; }
        public Predictor predictor { get; set; }
        public object[] pickcenter { get; set; }
        public object[] againstTheSpread { get; set; }
        public object[] odds { get; set; }
        public object[] rosters { get; set; }
        public object[] winprobability { get; set; }
        public Header header { get; set; }
        public News news { get; set; }
        public Article article { get; set; }
        public object[] videos { get; set; }
        public object[] plays { get; set; }
        public Playsmap playsMap { get; set; }
        public Atbats atBats { get; set; }
        public Standings standings { get; set; }
    }

    public class Boxscore
    {
        public Team[] teams { get; set; }
        public Player[] players { get; set; }
    }

    public class Team
    {
        public Team1 team { get; set; }
        public object[] statistics { get; set; }
        public object[] details { get; set; }
    }

    public class Team1
    {
    }

    public class Player
    {
        public Team2 team { get; set; }
        public Statistic[] statistics { get; set; }
    }

    public class Team2
    {
    }

    public class Statistic
    {
        public string type { get; set; }
        public string[] names { get; set; }
        public string[] keys { get; set; }
        public string[] labels { get; set; }
        public string[] descriptions { get; set; }
        public string[] totals { get; set; }
        public Athlete[] athletes { get; set; }
    }

    public class Athlete
    {
        public bool active { get; set; }
        public Athlete1 athlete { get; set; }
        public bool starter { get; set; }
        public int batOrder { get; set; }
        public Position2 position { get; set; }
        public string[] stats { get; set; }
        public Note[] notes { get; set; }
    }

    public class Athlete1
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string guid { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link[] links { get; set; }
        public Headshot headshot { get; set; }
        public string jersey { get; set; }
        public Position position { get; set; }
        public Position1[] positions { get; set; }
        public string throws { get; set; }
    }

    public class Headshot
    {
        public string href { get; set; }
        public string alt { get; set; }
    }

    public class Position
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
    }

    public class Link
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
    }

    public class Position1
    {
        public string _ref { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
        public bool leaf { get; set; }
        public Statistics statistics { get; set; }
        public Parent parent { get; set; }
    }

    public class Statistics
    {
        public string _ref { get; set; }
    }

    public class Parent
    {
        public string _ref { get; set; }
    }

    public class Position2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
    }

    public class Note
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Format
    {
    }

    public class Gameinfo
    {
    }

    public class Predictor
    {
    }

    public class Header
    {
    }

    public class News
    {
    }

    public class Article
    {
    }

    public class Playsmap
    {
    }

    public class Atbats
    {
    }

    public class Standings
    {
    }

}
