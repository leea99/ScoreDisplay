using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Models.BasketballScore
{

    public class BasketballScore
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
        public Link3[] links { get; set; }
        public Status status { get; set; }
    }

    public class Season2
    {
        public int year { get; set; }
        public int type { get; set; }
        public string slug { get; set; }
    }

    public class Status
    {
        public float clock { get; set; }
        public string displayClock { get; set; }
        public int period { get; set; }
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
        public int attendance { get; set; }
        public Type2 type { get; set; }
        public bool timeValid { get; set; }
        public bool neutralSite { get; set; }
        public bool conferenceCompetition { get; set; }
        public bool playByPlayAvailable { get; set; }
        public bool recent { get; set; }
        public Venue venue { get; set; }
        public Competitor[] competitors { get; set; }
        public object[] notes { get; set; }
        public Status1 status { get; set; }
        public Broadcast[] broadcasts { get; set; }
        public Format format { get; set; }
        public Ticket[] tickets { get; set; }
        public string startDate { get; set; }
        public Geobroadcast[] geoBroadcasts { get; set; }
        public Odd[] odds { get; set; }
    }

    public class Type2
    {
        public string id { get; set; }
        public string abbreviation { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public Address address { get; set; }
        public int capacity { get; set; }
        public bool indoor { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string state { get; set; }
    }

    public class Status1
    {
        public float clock { get; set; }
        public string displayClock { get; set; }
        public int period { get; set; }
        public Type3 type { get; set; }
    }

    public class Type3
    {
        public string id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public bool completed { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public string shortDetail { get; set; }
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
        public Team team { get; set; }
        public string score { get; set; }
        public Statistic[] statistics { get; set; }
        public Record[] records { get; set; }
        public Leader[] leaders { get; set; }
        public CuratedRank curatedRank { get; set; }
    }

    public class Team
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string color { get; set; }
        public string alternateColor { get; set; }
        public bool isActive { get; set; }
        public Venue1 venue { get; set; }
        public Link[] links { get; set; }
        public string logo { get; set; }
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
    }

    public class Statistic
    {
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
        public string rankDisplayValue { get; set; }
    }

    public class Record
    {
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string type { get; set; }
        public string summary { get; set; }
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
        public float value { get; set; }
        public Athlete athlete { get; set; }
        public Team2 team { get; set; }
    }

    public class Athlete
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link1[] links { get; set; }
        public string headshot { get; set; }
        public string jersey { get; set; }
        public Position position { get; set; }
        public Team1 team { get; set; }
        public bool active { get; set; }
    }

    public class Position
    {
        public string abbreviation { get; set; }
    }

    public class Team1
    {
        public string id { get; set; }
    }

    public class Link1
    {
        public string[] rel { get; set; }
        public string href { get; set; }
    }

    public class Team2
    {
        public string id { get; set; }
    }

    public class Broadcast
    {
        public string market { get; set; }
        public string[] names { get; set; }
    }

    public class Ticket
    {
        public string summary { get; set; }
        public int numberAvailable { get; set; }
        public Link2[] links { get; set; }
    }

    public class Link2
    {
        public string href { get; set; }
    }

    public class Geobroadcast
    {
        public Type4 type { get; set; }
        public Market market { get; set; }
        public Media media { get; set; }
        public string lang { get; set; }
        public string region { get; set; }
    }

    public class Type4
    {
        public string id { get; set; }
        public string shortName { get; set; }
    }

    public class Market
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Media
    {
        public string shortName { get; set; }
    }

    public class Odd
    {
        public Provider provider { get; set; }
        public string details { get; set; }
        public float overUnder { get; set; }
    }

    public class Provider
    {
        public string id { get; set; }
        public string name { get; set; }
        public int priority { get; set; }
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
    }
    public class CuratedRank
    {
        public int current { get; set; }
    }
}
