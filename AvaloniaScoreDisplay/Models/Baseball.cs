using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Models
{

    public class MLBData
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
        public Link5[] links { get; set; }
        public Weather weather { get; set; }
        public Status status { get; set; }
    }

    public class Season2
    {
        public int year { get; set; }
        public int type { get; set; }
        public string slug { get; set; }
    }

    public class Weather
    {
        public string displayValue { get; set; }
        public int temperature { get; set; }
        public int highTemperature { get; set; }
        public string conditionId { get; set; }
        public Link link { get; set; }
    }

    public class Link
    {
        public string language { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
    }

    public class Status
    {
        public double clock { get; set; }
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
        public bool recent { get; set; }
        public bool wasSuspended { get; set; }
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
        public Headline[] headlines { get; set; }
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
        public double clock { get; set; }
        public string displayClock { get; set; }
        public int period { get; set; }
        public Type3 type { get; set; }
        public List<FeaturedAthlete> featuredAthletes { get; set; }
    }

    public class FeaturedAthlete
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string abbreviation { get; set; }
        public int playerId { get; set; }
        public Athlete athlete { get; set; }
        public Team team { get; set; }
        public List<Statistic> statistics { get; set; }
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
        public Probable[] probables { get; set; }
        public Statistic1[] statistics { get; set; }
        public int hits { get; set; }
        public int errors { get; set; }
        public Record[] records { get; set; }
        public Leader[] leaders { get; set; }
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
        public Link1[] links { get; set; }
        public string logo { get; set; }
    }

    public class Link1
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
    }

    public class Probable
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string abbreviation { get; set; }
        public int playerId { get; set; }
        public Athlete athlete { get; set; }
        public Statistic[] statistics { get; set; }
    }

    public class Athlete
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link2[] links { get; set; }
        public string headshot { get; set; }
        public string jersey { get; set; }
        public string position { get; set; }
        public Team1 team { get; set; }
    }

    public class Team1
    {
        public string id { get; set; }
    }

    public class Link2
    {
        public string[] rel { get; set; }
        public string href { get; set; }
    }

    public class Statistic
    {
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
        public string rankDisplayValue { get; set; }
    }

    public class Statistic1
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
        public Athlete1 athlete { get; set; }
        public Team3 team { get; set; }
    }

    public class Athlete1
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link3[] links { get; set; }
        public string headshot { get; set; }
        public string jersey { get; set; }
        public Position position { get; set; }
        public Team2 team { get; set; }
        public bool active { get; set; }
    }

    public class Position
    {
        public string abbreviation { get; set; }
    }

    public class Team2
    {
        public string id { get; set; }
    }

    public class Link3
    {
        public string[] rel { get; set; }
        public string href { get; set; }
    }

    public class Team3
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
        public Link4[] links { get; set; }
    }

    public class Link4
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
        public Awayteamodds awayTeamOdds { get; set; }
        public Hometeamodds homeTeamOdds { get; set; }
    }

    public class Provider
    {
        public string id { get; set; }
        public string name { get; set; }
        public int priority { get; set; }
    }

    public class Awayteamodds
    {
        public double winPercentage { get; set; }
        public bool favorite { get; set; }
        public bool underdog { get; set; }
        public int moneyLine { get; set; }
        public double spreadOdds { get; set; }
        public Team4 team { get; set; }
        public float averageScore { get; set; }
        public Spreadrecord spreadRecord { get; set; }
    }

    public class Team4
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string logo { get; set; }
    }

    public class Spreadrecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int pushes { get; set; }
        public string summary { get; set; }
    }

    public class Hometeamodds
    {
        public double winPercentage { get; set; }
        public bool favorite { get; set; }
        public bool underdog { get; set; }
        public int moneyLine { get; set; }
        public double spreadOdds { get; set; }
        public Team5 team { get; set; }
        public float averageScore { get; set; }
        public Spreadrecord1 spreadRecord { get; set; }
    }

    public class Team5
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string logo { get; set; }
    }

    public class Spreadrecord1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int pushes { get; set; }
        public string summary { get; set; }
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
    }

    public class SoccerStandins
    {
        public Situation situation { get; set; }
    }

    public class Situation
    {
        public Lastplay lastPlay { get; set; }
        public int balls { get; set; }
        public int strikes { get; set; }
        public int outs { get; set; }
        public Onfirst onFirst { get; set; }
        public Onfirst onSecond { get; set; }
        public Onfirst onThird { get; set; }
        public Pitcher pitcher { get; set; }
        public Batter batter { get; set; }
        public Situationnote[] situationNotes { get; set; }
    }

    public class Lastplay
    {
        public string id { get; set; }
    }

    public class Onfirst
    {
        public int playerId { get; set; }
    }

    public class Pitcher
    {
        public int playerId { get; set; }
    }

    public class Batter
    {
        public int playerId { get; set; }
    }

    public class Situationnote
    {
        public string type { get; set; }
        public string text { get; set; }
    }
    public class Player
    {
        public Team team { get; set; }
        public BoxStatistic[] statistics { get; set; }
    }

    public class Headshot
    {
        public string href { get; set; }
        public string alt { get; set; }
    }


    public class Position1
    {
        public string _ref { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
        public bool leaf { get; set; }
        public Parent parent { get; set; }
        public Statistics statistics { get; set; }
    }

    public class Parent
    {
        public string _ref { get; set; }
    }

    public class Statistics
    {
        public string _ref { get; set; }
    }

    public class Hotzone
    {
        public int configurationId { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public int splitTypeId { get; set; }
        public int season { get; set; }
        public int seasonType { get; set; }
        public Zone[] zones { get; set; }
    }

    public class Zone
    {
        public int zoneId { get; set; }
        public int xMin { get; set; }
        public int xMax { get; set; }
        public int yMin { get; set; }
        public int yMax { get; set; }
        public int atBats { get; set; }
        public int hits { get; set; }
        public float battingAvg { get; set; }
        public float battingAvgScore { get; set; }
        public float slugging { get; set; }
        public float sluggingScore { get; set; }
    }

    public class Position2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
    }

    public class Position3
    {
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
    }

    public class Atbat
    {
        public string id { get; set; }
        public string atBatId { get; set; }
        public string playId { get; set; }
    }

    public class Note
    {
        public string type { get; set; }
        public string text { get; set; }
    }
    public class BoxStatistic
    {
        public string type { get; set; }
        public string[] names { get; set; }
        public string[] keys { get; set; }
        public string[] labels { get; set; }
        public string[] descriptions { get; set; }
        public string[] totals { get; set; }
        public Athlete[] athletes { get; set; }
    }
}

