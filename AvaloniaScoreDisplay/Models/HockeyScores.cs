using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Models.HockeyScores
{

    public class HockeyScores
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
        public Link5[] links { get; set; }
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
        public bool playByPlayAvailable { get; set; }
        public bool recent { get; set; }
        public Venue venue { get; set; }
        public Competitor[] competitors { get; set; }
        public object[] notes { get; set; }
        public Status1 status { get; set; }
        public Broadcast[] broadcasts { get; set; }
        public Format format { get; set; }
        public string startDate { get; set; }
        public Geobroadcast[] geoBroadcasts { get; set; }
        public Headline[] headlines { get; set; }
        public Situation situation { get; set; }
        public Ticket[] tickets { get; set; }
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
        public string country { get; set; }
    }

    public class Status1
    {
        public float clock { get; set; }
        public string displayClock { get; set; }
        public int period { get; set; }
        public Type3 type { get; set; }
        public Featuredathlete[] featuredAthletes { get; set; }
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

    public class Featuredathlete
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string abbreviation { get; set; }
        public int playerId { get; set; }
        public Athlete athlete { get; set; }
        public Team1 team { get; set; }
        public Statistic[] statistics { get; set; }
    }

    public class Athlete
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link[] links { get; set; }
        public string headshot { get; set; }
        public string jersey { get; set; }
        public string position { get; set; }
        public Team team { get; set; }
    }

    public class Team
    {
        public string id { get; set; }
    }

    public class Link
    {
        public string[] rel { get; set; }
        public string href { get; set; }
    }

    public class Team1
    {
        public string id { get; set; }
    }

    public class Statistic
    {
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
    }

    public class Format
    {
        public Regulation regulation { get; set; }
    }

    public class Regulation
    {
        public int periods { get; set; }
    }

    public class Situation
    {
        public Lastplay lastPlay { get; set; }
    }

    public class Lastplay
    {
        public string id { get; set; }
        public Type4 type { get; set; }
        public string text { get; set; }
        public int scoreValue { get; set; }
    }

    public class Type4
    {
        public string id { get; set; }
        public string text { get; set; }
        public string abbreviation { get; set; }
    }

    public class Competitor
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string type { get; set; }
        public int order { get; set; }
        public string homeAway { get; set; }
        public bool winner { get; set; }
        public Team2 team { get; set; }
        public string score { get; set; }
        public Linescore[] linescores { get; set; }
        public Statistic1[] statistics { get; set; }
        public Leader[] leaders { get; set; }
        public Probable[] probables { get; set; }
        public Record[] records { get; set; }
    }

    public class Team2
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
        public Link1[] links { get; set; }
        public string logo { get; set; }
    }

    public class Venue1
    {
        public string id { get; set; }
    }

    public class Link1
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
    }

    public class Linescore
    {
        public float value { get; set; }
    }

    public class Statistic1
    {
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
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
        public Team4 team { get; set; }
        public Statistic2[] statistics { get; set; }
    }

    public class Athlete1
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link2[] links { get; set; }
        public string headshot { get; set; }
        public string jersey { get; set; }
        public Position position { get; set; }
        public Team3 team { get; set; }
        public bool active { get; set; }
    }

    public class Position
    {
        public string abbreviation { get; set; }
    }

    public class Team3
    {
        public string id { get; set; }
    }

    public class Link2
    {
        public string[] rel { get; set; }
        public string href { get; set; }
    }

    public class Team4
    {
        public string id { get; set; }
    }

    public class Statistic2
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string description { get; set; }
        public string abbreviation { get; set; }
        public float value { get; set; }
        public string displayValue { get; set; }
    }

    public class Probable
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string abbreviation { get; set; }
        public int playerId { get; set; }
        public Athlete2 athlete { get; set; }
        public Status2 status { get; set; }
        public object[] statistics { get; set; }
    }

    public class Athlete2
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link3[] links { get; set; }
        public string headshot { get; set; }
        public string jersey { get; set; }
        public string position { get; set; }
        public Team5 team { get; set; }
    }

    public class Team5
    {
        public string id { get; set; }
    }

    public class Link3
    {
        public string[] rel { get; set; }
        public string href { get; set; }
    }

    public class Status2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string abbreviation { get; set; }
    }

    public class Record
    {
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string type { get; set; }
        public string summary { get; set; }
    }

    public class Broadcast
    {
        public string market { get; set; }
        public string[] names { get; set; }
    }

    public class Geobroadcast
    {
        public Type5 type { get; set; }
        public Market market { get; set; }
        public Media media { get; set; }
        public string lang { get; set; }
        public string region { get; set; }
    }

    public class Type5
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

    public class Headline
    {
        public string description { get; set; }
        public string type { get; set; }
        public string shortLinkText { get; set; }
        public Video[] video { get; set; }
    }

    public class Video
    {
        public int id { get; set; }
        public string source { get; set; }
        public string headline { get; set; }
        public string thumbnail { get; set; }
        public int duration { get; set; }
        public Tracking tracking { get; set; }
        public Devicerestrictions deviceRestrictions { get; set; }
        public Georestrictions geoRestrictions { get; set; }
        public Links links { get; set; }
    }

    public class Tracking
    {
        public string sportName { get; set; }
        public string leagueName { get; set; }
        public string coverageType { get; set; }
        public string trackingName { get; set; }
        public string trackingId { get; set; }
    }

    public class Devicerestrictions
    {
        public string type { get; set; }
        public string[] devices { get; set; }
    }

    public class Georestrictions
    {
        public string type { get; set; }
        public string[] countries { get; set; }
    }

    public class Links
    {
        public Api api { get; set; }
        public Web web { get; set; }
        public Source source { get; set; }
        public Mobile mobile { get; set; }
    }

    public class Api
    {
        public Self self { get; set; }
        public Artwork artwork { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Artwork
    {
        public string href { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
        public Short _short { get; set; }
        public Self1 self { get; set; }
    }

    public class Short
    {
        public string href { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
    }

    public class Source
    {
        public Mezzanine mezzanine { get; set; }
        public Flash flash { get; set; }
        public Hds hds { get; set; }
        public HLS HLS { get; set; }
        public HD1 HD { get; set; }
        public Full full { get; set; }
        public string href { get; set; }
    }

    public class Mezzanine
    {
        public string href { get; set; }
    }

    public class Flash
    {
        public string href { get; set; }
    }

    public class Hds
    {
        public string href { get; set; }
    }

    public class HLS
    {
        public string href { get; set; }
        public HD HD { get; set; }
    }

    public class HD
    {
        public string href { get; set; }
    }

    public class HD1
    {
        public string href { get; set; }
    }

    public class Full
    {
        public string href { get; set; }
    }

    public class Mobile
    {
        public Alert alert { get; set; }
        public Source1 source { get; set; }
        public string href { get; set; }
        public Streaming streaming { get; set; }
        public Progressivedownload progressiveDownload { get; set; }
    }

    public class Alert
    {
        public string href { get; set; }
    }

    public class Source1
    {
        public string href { get; set; }
    }

    public class Streaming
    {
        public string href { get; set; }
    }

    public class Progressivedownload
    {
        public string href { get; set; }
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

}
