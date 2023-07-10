using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Models.SoccerScores
{

    public class SoccerScore
    {
        public League[] leagues { get; set; }
        public Season season { get; set; }
        public Day day { get; set; }
        public Event[] events { get; set; }
    }

    public class Season
    {
        public int type { get; set; }
        public int year { get; set; }
    }

    public class Day
    {
        public string date { get; set; }
    }

    public class League
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string midsizeName { get; set; }
        public string slug { get; set; }
        public Season1 season { get; set; }
        public Logo[] logos { get; set; }
        public string calendarType { get; set; }
        public bool calendarIsWhitelist { get; set; }
        public string calendarStartDate { get; set; }
        public string calendarEndDate { get; set; }
        public string[] calendar { get; set; }
    }

    public class Season1
    {
        public int year { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string displayName { get; set; }
        public Type type { get; set; }
    }

    public class Type
    {
        public string id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
    }

    public class Logo
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string alt { get; set; }
        public string[] rel { get; set; }
        public string lastUpdated { get; set; }
    }

    public class Event
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public Season2 season { get; set; }
        public Competition[] competitions { get; set; }
        public Status status { get; set; }
        public Link5[] links { get; set; }
    }

    public class Season2
    {
        public int year { get; set; }
        public int type { get; set; }
        public string slug { get; set; }
    }

    public class Status
    {
        public double clock { get; set; }
        public string displayClock { get; set; }
        public Type1 type { get; set; }
    }

    public class Type1
    {
        public string id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public bool completed { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public string shortDetail { get; set; }
    }

    public class Competition
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string date { get; set; }
        public string startDate { get; set; }
        public int attendance { get; set; }
        public bool timeValid { get; set; }
        public bool recent { get; set; }
        public Status1 status { get; set; }
        public Venue venue { get; set; }
        public Format format { get; set; }
        public object[] notes { get; set; }
        public object[] geoBroadcasts { get; set; }
        public object[] broadcasts { get; set; }
        public Competitor[] competitors { get; set; }
        public object[] details { get; set; }
        public Odd[] odds { get; set; }
        public bool wasSuspended { get; set; }
        public bool playByPlayAvailable { get; set; }
        public Headline[] headlines { get; set; }
    }

    public class Status1
    {
        public double clock { get; set; }
        public string displayClock { get; set; }
        public Type2 type { get; set; }
    }

    public class Type2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public bool completed { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public string shortDetail { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string country { get; set; }
    }

    public class Format
    {
        public Regulation regulation { get; set; }
    }

    public class Regulation
    {
        public int periods { get; set; }
    }

    public class Competitor
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string type { get; set; }
        public int order { get; set; }
        public string homeAway { get; set; }
        public bool winner { get; set; }
        public string form { get; set; }
        public string score { get; set; }
        public Record[] records { get; set; }
        public Team team { get; set; }
        public object[] statistics { get; set; }
        public Leader[] leaders { get; set; }
    }

    public class Team
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string color { get; set; }
        public string alternateColor { get; set; }
        public bool isActive { get; set; }
        public string logo { get; set; }
        public Link[] links { get; set; }
        public Venue1 venue { get; set; }
    }

    public class Venue1
    {
        public string id { get; set; }
    }

    public class Link
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
        public bool isHidden { get; set; }
    }

    public class Record
    {
        public string name { get; set; }
        public string type { get; set; }
        public string summary { get; set; }
        public string abbreviation { get; set; }
    }

    public class Leader
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string abbreviation { get; set; }
        public Leader1[] leaders { get; set; }
    }

    public class Leader1
    {
        public string displayValue { get; set; }
        public string shortDisplayValue { get; set; }
        public double value { get; set; }
        public Athlete athlete { get; set; }
        public Team2 team { get; set; }
    }

    public class Athlete
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public string fullName { get; set; }
        public string jersey { get; set; }
        public bool active { get; set; }
        public Team1 team { get; set; }
        public string headshot { get; set; }
        public Link1[] links { get; set; }
        public Position position { get; set; }
    }

    public class Team1
    {
        public string id { get; set; }
    }

    public class Position
    {
        public string abbreviation { get; set; }
    }

    public class Link1
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public bool isHidden { get; set; }
    }

    public class Team2
    {
        public string id { get; set; }
    }

    public class Odd
    {
        public float overUnder { get; set; }
        public Provider provider { get; set; }
        public Drawodds drawOdds { get; set; }
        public string details { get; set; }
        public Awayteamodds awayTeamOdds { get; set; }
        public Hometeamodds homeTeamOdds { get; set; }
    }

    public class Provider
    {
        public string id { get; set; }
        public string name { get; set; }
        public int priority { get; set; }
    }

    public class Drawodds
    {
        public int moneyLine { get; set; }
        public Link2 link { get; set; }
    }

    public class Link2
    {
        public string language { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
        public bool isHidden { get; set; }
    }

    public class Awayteamodds
    {
        public bool favorite { get; set; }
        public bool underdog { get; set; }
        public int moneyLine { get; set; }
        public Team3 team { get; set; }
        public Link3 link { get; set; }
        public double spreadOdds { get; set; }
    }

    public class Team3
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string logo { get; set; }
    }

    public class Link3
    {
        public string language { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
        public bool isHidden { get; set; }
    }

    public class Hometeamodds
    {
        public bool favorite { get; set; }
        public bool underdog { get; set; }
        public int moneyLine { get; set; }
        public Team4 team { get; set; }
        public Link4 link { get; set; }
        public double spreadOdds { get; set; }
    }

    public class Team4
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string logo { get; set; }
    }

    public class Link4
    {
        public string language { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
        public bool isHidden { get; set; }
    }

    public class Headline
    {
        public string description { get; set; }
        public string type { get; set; }
        public string shortLinkText { get; set; }
    }

    public class Link5
    {
        public string language { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
        public bool isHidden { get; set; }
    }
}
