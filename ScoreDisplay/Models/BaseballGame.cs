using Newtonsoft.Json;
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
        public Seasonsery[] seasonseries { get; set; }
        public Broadcast2[] broadcasts { get; set; }
        public Predictor predictor { get; set; }
        public Pickcenter[] pickcenter { get; set; }
        public Againstthespread[] againstTheSpread { get; set; }
        public object[] odds { get; set; }
        public Roster[] rosters { get; set; }
        public Winprobability[] winprobability { get; set; }
        public Header header { get; set; }
        public News news { get; set; }
        public Article1 article { get; set; }
        public Video1[] videos { get; set; }
        public Play[] plays { get; set; }
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
        public Statistic[] statistics { get; set; }
        public Detail[] details { get; set; }
    }

    public class Team1
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string slug { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string color { get; set; }
        public string alternateColor { get; set; }
        public string logo { get; set; }
    }

    public class Statistic
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public Stat[] stats { get; set; }
    }

    public class Stat
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string description { get; set; }
        public string abbreviation { get; set; }
        public float value { get; set; }
        public string displayValue { get; set; }
    }

    public class Detail
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public Stat1[] stats { get; set; }
    }

    public class Stat1
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
    }

    public class Player
    {
        public Team2 team { get; set; }
        public Statistic1[] statistics { get; set; }
    }

    public class Team2
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string slug { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string color { get; set; }
        public string alternateColor { get; set; }
        public string logo { get; set; }
    }

    public class Statistic1
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
        public Atbat[] atBats { get; set; }
        public string[] stats { get; set; }
        public Position3[] positions { get; set; }
        public Note[] notes { get; set; }
    }

    public class Athlete1
    {
        public int id { get; set; }
        public string uid { get; set; }
        public string guid { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link[] links { get; set; }
        public Headshot headshot { get; set; }
        public string jersey { get; set; }
        public Position position { get; set; }
        public Position1[] positions { get; set; }
        public Hotzone[] hotZones { get; set; }
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
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }
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

    public class Atbat
    {
        public string id { get; set; }
        public string atBatId { get; set; }
        public string playId { get; set; }
    }

    public class Position3
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
        public Regulation regulation { get; set; }
    }

    public class Regulation
    {
        public int periods { get; set; }
        public string displayName { get; set; }
        public string slug { get; set; }
    }

    public class Gameinfo
    {
        public Venue venue { get; set; }
        public int attendance { get; set; }
        public Official[] officials { get; set; }
        public string gameDuration { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public Address address { get; set; }
        public int capacity { get; set; }
        public Image[] images { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }

    public class Image
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string alt { get; set; }
        public string[] rel { get; set; }
    }

    public class Official
    {
        public string displayName { get; set; }
        public Position4 position { get; set; }
        public int order { get; set; }
    }

    public class Position4
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string id { get; set; }
    }

    public class Predictor
    {
        public string header { get; set; }
        public Hometeam homeTeam { get; set; }
        public Awayteam awayTeam { get; set; }
    }

    public class Hometeam
    {
        public string id { get; set; }
        public string gameProjection { get; set; }
        public string teamChanceLoss { get; set; }
    }

    public class Awayteam
    {
        public string id { get; set; }
        public string gameProjection { get; set; }
        public string teamChanceLoss { get; set; }
    }

    public class Header
    {
        public string id { get; set; }
        public string uid { get; set; }
        public Season season { get; set; }
        public bool timeValid { get; set; }
        public Competition[] competitions { get; set; }
        public Link5[] links { get; set; }
        public int week { get; set; }
        public League league { get; set; }
    }

    public class Season
    {
        public int year { get; set; }
        public int type { get; set; }
    }

    public class League
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string midsizeName { get; set; }
        public string slug { get; set; }
        public bool isTournament { get; set; }
        public Link1[] links { get; set; }
    }

    public class Link1
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
    }

    public class Competition
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string date { get; set; }
        public bool neutralSite { get; set; }
        public bool conferenceCompetition { get; set; }
        public bool boxscoreAvailable { get; set; }
        public bool commentaryAvailable { get; set; }
        public bool liveAvailable { get; set; }
        public bool onWatchESPN { get; set; }
        public bool recent { get; set; }
        public string boxscoreSource { get; set; }
        public string playByPlaySource { get; set; }
        public Competitor[] competitors { get; set; }
        public Status status { get; set; }
        public Broadcast[] broadcasts { get; set; }
        public Series[] series { get; set; }
    }

    public class Status
    {
        public Type type { get; set; }
        public Featuredathlete[] featuredAthletes { get; set; }
        public string periodPrefix { get; set; }
    }

    public class Type
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
        public int playerId { get; set; }
        public Athlete2 athlete { get; set; }
        public Team3 team { get; set; }
    }

    public class Athlete2
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string guid { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link2[] links { get; set; }
        public Headshot1 headshot { get; set; }
        public string record { get; set; }
        public string saves { get; set; }
    }

    public class Headshot1
    {
        public string href { get; set; }
        public string alt { get; set; }
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
    }

    public class Team3
    {
        public string id { get; set; }
        public string name { get; set; }
        public Logo[] logos { get; set; }
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

    public class Competitor
    {
        public string id { get; set; }
        public string uid { get; set; }
        public int order { get; set; }
        public string homeAway { get; set; }
        public bool winner { get; set; }
        public Team4 team { get; set; }
        public string score { get; set; }
        public Linescore[] linescores { get; set; }
        public Record[] record { get; set; }
        public Probable[] probables { get; set; }
        public bool possession { get; set; }
        public int hits { get; set; }
        public int errors { get; set; }
    }

    public class Team4
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string color { get; set; }
        public string alternateColor { get; set; }
        public Logo1[] logos { get; set; }
        public Link3[] links { get; set; }
    }

    public class Logo1
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string alt { get; set; }
        public string[] rel { get; set; }
        public string lastUpdated { get; set; }
    }

    public class Link3
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
    }

    public class Linescore
    {
        public string displayValue { get; set; }
        public int hits { get; set; }
        public int errors { get; set; }
    }

    public class Record
    {
        public string type { get; set; }
        public string summary { get; set; }
        public string displayValue { get; set; }
    }

    public class Probable
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string abbreviation { get; set; }
        public int playerId { get; set; }
        public Athlete3 athlete { get; set; }
        public Statistics1 statistics { get; set; }
    }

    public class Athlete3
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string guid { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public Link4[] links { get; set; }
        public Headshot2 headshot { get; set; }
        public string jersey { get; set; }
        public Position5 position { get; set; }
        public Throws throws { get; set; }
    }

    public class Headshot2
    {
        public string href { get; set; }
        public string alt { get; set; }
    }

    public class Position5
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
    }

    public class Throws
    {
        public string type { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
    }

    public class Link4
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
    }

    public class Statistics1
    {
        public Splits splits { get; set; }
    }

    public class Splits
    {
        public Category[] categories { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public string abbreviation { get; set; }
        public float value { get; set; }
        public string displayValue { get; set; }
    }

    public class Broadcast
    {
        public Type1 type { get; set; }
        public Market market { get; set; }
        public Media media { get; set; }
        public string lang { get; set; }
        public string region { get; set; }
    }

    public class Type1
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

    public class Series
    {
        public string type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string summary { get; set; }
        public bool completed { get; set; }
        public int totalCompetitions { get; set; }
        public Competitor1[] competitors { get; set; }
        public Event[] events { get; set; }
    }

    public class Competitor1
    {
        public string id { get; set; }
        public string uid { get; set; }
        public int wins { get; set; }
        public int ties { get; set; }
        public Team5 team { get; set; }
    }

    public class Team5
    {
        public string _ref { get; set; }
    }

    public class Event
    {
        public string _ref { get; set; }
        public string id { get; set; }
    }

    public class Link5
    {
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
    }

    public class News
    {
        public string header { get; set; }
        public Link6 link { get; set; }
        public Article[] articles { get; set; }
    }

    public class Link6
    {
        public string language { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
    }

    public class Article
    {
        public Image1[] images { get; set; }
        public string dataSourceIdentifier { get; set; }
        public string description { get; set; }
        public DateTime published { get; set; }
        public string type { get; set; }
        public bool premium { get; set; }
        public Links links { get; set; }
        public DateTime lastModified { get; set; }
        public Category1[] categories { get; set; }
        public string headline { get; set; }
    }

    public class Links
    {
        public Api api { get; set; }
        public Web web { get; set; }
        public Mobile mobile { get; set; }
    }

    public class Api
    {
        public News1 news { get; set; }
        public Self self { get; set; }
    }

    public class News1
    {
        public string href { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
        public Short _short { get; set; }
    }

    public class Short
    {
        public string href { get; set; }
    }

    public class Mobile
    {
        public string href { get; set; }
    }

    public class Image1
    {
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public string ratio { get; set; }
        public int height { get; set; }
        public string caption { get; set; }
        public string alt { get; set; }
        public string dataSourceIdentifier { get; set; }
        public int id { get; set; }
        public string credit { get; set; }
    }

    public class Category1
    {
        public int id { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int sportId { get; set; }
        public int leagueId { get; set; }
        public League1 league { get; set; }
        public string uid { get; set; }
        public DateTime createDate { get; set; }
        public int teamId { get; set; }
        public Team6 team { get; set; }
        public string guid { get; set; }
        public int athleteId { get; set; }
        public Athlete4 athlete { get; set; }
        public int topicId { get; set; }
    }

    public class League1
    {
        public int id { get; set; }
        public string description { get; set; }
        public Links1 links { get; set; }
    }

    public class Links1
    {
        public Api1 api { get; set; }
        public Web1 web { get; set; }
        public Mobile1 mobile { get; set; }
    }

    public class Api1
    {
        public Leagues leagues { get; set; }
    }

    public class Leagues
    {
        public string href { get; set; }
    }

    public class Web1
    {
        public Leagues1 leagues { get; set; }
    }

    public class Leagues1
    {
        public string href { get; set; }
    }

    public class Mobile1
    {
        public Leagues2 leagues { get; set; }
    }

    public class Leagues2
    {
        public string href { get; set; }
    }

    public class Team6
    {
        public int id { get; set; }
        public string description { get; set; }
        public Links2 links { get; set; }
    }

    public class Links2
    {
        public Api2 api { get; set; }
        public Web2 web { get; set; }
        public Mobile2 mobile { get; set; }
    }

    public class Api2
    {
        public Teams teams { get; set; }
    }

    public class Teams
    {
        public string href { get; set; }
    }

    public class Web2
    {
        public Teams1 teams { get; set; }
    }

    public class Teams1
    {
        public string href { get; set; }
    }

    public class Mobile2
    {
        public Teams2 teams { get; set; }
    }

    public class Teams2
    {
        public string href { get; set; }
    }

    public class Athlete4
    {
        public int id { get; set; }
        public string description { get; set; }
        public Links3 links { get; set; }
    }

    public class Links3
    {
        public Api3 api { get; set; }
        public Web3 web { get; set; }
        public Mobile3 mobile { get; set; }
    }

    public class Api3
    {
        public Athletes athletes { get; set; }
    }

    public class Athletes
    {
        public string href { get; set; }
    }

    public class Web3
    {
        public Athletes1 athletes { get; set; }
    }

    public class Athletes1
    {
        public string href { get; set; }
    }

    public class Mobile3
    {
        public Athletes2 athletes { get; set; }
    }

    public class Athletes2
    {
        public string href { get; set; }
    }

    public class Article1
    {
        public string dataSourceIdentifier { get; set; }
        public object[] keywords { get; set; }
        public string description { get; set; }
        public string source { get; set; }
        public Video[] video { get; set; }
        public string type { get; set; }
        public string nowId { get; set; }
        public bool premium { get; set; }
        public object[] related { get; set; }
        public bool allowSearch { get; set; }
        public Links4 links { get; set; }
        public int id { get; set; }
        public Category3[] categories { get; set; }
        public string headline { get; set; }
        public string gameId { get; set; }
        public Image3[] images { get; set; }
        public string linkText { get; set; }
        public DateTime published { get; set; }
        public bool allowComments { get; set; }
        public DateTime lastModified { get; set; }
        public Metric[] metrics { get; set; }
        public object[] inlines { get; set; }
        public string story { get; set; }
    }

    public class Links4
    {
        public Api4 api { get; set; }
        public Web4 web { get; set; }
        public App app { get; set; }
        public Mobile4 mobile { get; set; }
    }

    public class Api4
    {
        public News2 news { get; set; }
        public Events events { get; set; }
    }

    public class News2
    {
        public string href { get; set; }
    }

    public class Events
    {
        public string href { get; set; }
    }

    public class Web4
    {
        public string href { get; set; }
        public Short1 _short { get; set; }
    }

    public class Short1
    {
    }

    public class App
    {
        public Sportscenter sportscenter { get; set; }
    }

    public class Sportscenter
    {
        public string href { get; set; }
    }

    public class Mobile4
    {
        public string href { get; set; }
    }

    public class Video
    {
        public string source { get; set; }
        public int id { get; set; }
        public string dataSourceIdentifier { get; set; }
        public string headline { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public bool premium { get; set; }
        public Ad ad { get; set; }
        public Tracking tracking { get; set; }
        public string cerebroId { get; set; }
        public DateTime lastModified { get; set; }
        public DateTime originalPublishDate { get; set; }
        public Timerestrictions timeRestrictions { get; set; }
        public Devicerestrictions deviceRestrictions { get; set; }
        public Georestrictions geoRestrictions { get; set; }
        public bool syndicatable { get; set; }
        public int duration { get; set; }
        public Category2[] categories { get; set; }
        public object[] keywords { get; set; }
        public Posterimages posterImages { get; set; }
        public Image2[] images { get; set; }
        public string thumbnail { get; set; }
        public Links5 links { get; set; }
        public string title { get; set; }
    }

    public class Ad
    {
        public string sport { get; set; }
        public string bundle { get; set; }
    }

    public class Tracking
    {
        public string sportName { get; set; }
        public string leagueName { get; set; }
        public string coverageType { get; set; }
        public string trackingName { get; set; }
        public string trackingId { get; set; }
    }

    public class Timerestrictions
    {
        public DateTime embargoDate { get; set; }
        public DateTime expirationDate { get; set; }
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

    public class Posterimages
    {
        public Default _default { get; set; }
        public Full full { get; set; }
        public Wide wide { get; set; }
        public Square square { get; set; }
    }

    public class Default
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Full
    {
        public string href { get; set; }
    }

    public class Wide
    {
        public string href { get; set; }
    }

    public class Square
    {
        public string href { get; set; }
    }

    public class Links5
    {
        public Api5 api { get; set; }
        public Web5 web { get; set; }
        public Source source { get; set; }
        public Mobile5 mobile { get; set; }
    }

    public class Api5
    {
        public Self1 self { get; set; }
        public Artwork artwork { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
    }

    public class Artwork
    {
        public string href { get; set; }
    }

    public class Web5
    {
        public string href { get; set; }
        public Short2 _short { get; set; }
        public Self2 self { get; set; }
    }

    public class Short2
    {
        public string href { get; set; }
    }

    public class Self2
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
        public Full1 full { get; set; }
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

    public class Full1
    {
        public string href { get; set; }
    }

    public class Mobile5
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

    public class Category2
    {
        public int id { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int sportId { get; set; }
        public int leagueId { get; set; }
        public League2 league { get; set; }
        public string uid { get; set; }
        public int teamId { get; set; }
        public Team7 team { get; set; }
        public int athleteId { get; set; }
        public Athlete5 athlete { get; set; }
    }

    public class League2
    {
        public int id { get; set; }
        public string description { get; set; }
        public Links6 links { get; set; }
    }

    public class Links6
    {
        public Api6 api { get; set; }
        public Web6 web { get; set; }
        public Mobile6 mobile { get; set; }
    }

    public class Api6
    {
        public Leagues3 leagues { get; set; }
    }

    public class Leagues3
    {
        public string href { get; set; }
    }

    public class Web6
    {
        public Leagues4 leagues { get; set; }
    }

    public class Leagues4
    {
        public string href { get; set; }
    }

    public class Mobile6
    {
        public Leagues5 leagues { get; set; }
    }

    public class Leagues5
    {
        public string href { get; set; }
    }

    public class Team7
    {
        public int id { get; set; }
        public string description { get; set; }
        public Links7 links { get; set; }
    }

    public class Links7
    {
        public Api7 api { get; set; }
        public Web7 web { get; set; }
        public Mobile7 mobile { get; set; }
    }

    public class Api7
    {
        public Teams3 teams { get; set; }
    }

    public class Teams3
    {
        public string href { get; set; }
    }

    public class Web7
    {
        public Teams4 teams { get; set; }
    }

    public class Teams4
    {
        public string href { get; set; }
    }

    public class Mobile7
    {
        public Teams5 teams { get; set; }
    }

    public class Teams5
    {
        public string href { get; set; }
    }

    public class Athlete5
    {
        public int id { get; set; }
        public string description { get; set; }
        public Links8 links { get; set; }
    }

    public class Links8
    {
        public Api8 api { get; set; }
        public Web8 web { get; set; }
        public Mobile8 mobile { get; set; }
    }

    public class Api8
    {
        public Athletes3 athletes { get; set; }
    }

    public class Athletes3
    {
        public string href { get; set; }
    }

    public class Web8
    {
        public Athletes4 athletes { get; set; }
    }

    public class Athletes4
    {
        public string href { get; set; }
    }

    public class Mobile8
    {
        public Athletes5 athletes { get; set; }
    }

    public class Athletes5
    {
        public string href { get; set; }
    }

    public class Image2
    {
        public string name { get; set; }
        public string url { get; set; }
        public string alt { get; set; }
        public string caption { get; set; }
        public string credit { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Category3
    {
        public int id { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int sportId { get; set; }
        public int leagueId { get; set; }
        public League3 league { get; set; }
        public string uid { get; set; }
        public int teamId { get; set; }
        public Team8 team { get; set; }
    }

    public class League3
    {
        public int id { get; set; }
        public string description { get; set; }
        public Links9 links { get; set; }
    }

    public class Links9
    {
        public Api9 api { get; set; }
        public Web9 web { get; set; }
        public Mobile9 mobile { get; set; }
    }

    public class Api9
    {
        public Leagues6 leagues { get; set; }
    }

    public class Leagues6
    {
        public string href { get; set; }
    }

    public class Web9
    {
        public Leagues7 leagues { get; set; }
    }

    public class Leagues7
    {
        public string href { get; set; }
    }

    public class Mobile9
    {
        public Leagues8 leagues { get; set; }
    }

    public class Leagues8
    {
        public string href { get; set; }
    }

    public class Team8
    {
        public int id { get; set; }
        public string description { get; set; }
        public Links10 links { get; set; }
    }

    public class Links10
    {
        public Api10 api { get; set; }
        public Web10 web { get; set; }
        public Mobile10 mobile { get; set; }
    }

    public class Api10
    {
        public Teams6 teams { get; set; }
    }

    public class Teams6
    {
        public string href { get; set; }
    }

    public class Web10
    {
        public Teams7 teams { get; set; }
    }

    public class Teams7
    {
        public string href { get; set; }
    }

    public class Mobile10
    {
        public Teams8 teams { get; set; }
    }

    public class Teams8
    {
        public string href { get; set; }
    }

    public class Image3
    {
        public string name { get; set; }
        public int width { get; set; }
        public string alt { get; set; }
        public string caption { get; set; }
        public string url { get; set; }
        public int height { get; set; }
    }

    public class Metric
    {
        public int count { get; set; }
        public string type { get; set; }
    }

    public class Playsmap
    {
        public _4014714350000000059 _4014714350000000059 { get; set; }
        public _4014714350001010001 _4014714350001010001 { get; set; }
        public _4014714350001020036 _4014714350001020036 { get; set; }
        public _4014714350001030005 _4014714350001030005 { get; set; }
        public _4014714350001040022 _4014714350001040022 { get; set; }
        public _4014714350001990057 _4014714350001990057 { get; set; }
        public _4014714350001990099 _4014714350001990099 { get; set; }
        public _4014714350002010001 _4014714350002010001 { get; set; }
        public _4014714350002020036 _4014714350002020036 { get; set; }
        public _4014714350002030021 _4014714350002030021 { get; set; }
        public _4014714350002040021 _4014714350002040021 { get; set; }
        public _4014714350002050005 _4014714350002050005 { get; set; }
        public _4014714350002060021 _4014714350002060021 { get; set; }
        public _4014714350002070002 _4014714350002070002 { get; set; }
        public _4014714350002990057 _4014714350002990057 { get; set; }
        public _4014714350002990099 _4014714350002990099 { get; set; }
        public _4014714350003010001 _4014714350003010001 { get; set; }
        public _4014714350003020005 _4014714350003020005 { get; set; }
        public _4014714350003030022 _4014714350003030022 { get; set; }
        public _4014714350003990057 _4014714350003990057 { get; set; }
        public _4014714350003990099 _4014714350003990099 { get; set; }
        public _4014714350004010001 _4014714350004010001 { get; set; }
        public _4014714350004020005 _4014714350004020005 { get; set; }
        public _4014714350004030021 _4014714350004030021 { get; set; }
        public _4014714350004040005 _4014714350004040005 { get; set; }
        public _4014714350004050005 _4014714350004050005 { get; set; }
        public _4014714350004060022 _4014714350004060022 { get; set; }
        public _4014714350004990057 _4014714350004990057 { get; set; }
        public _4014714350004990099 _4014714350004990099 { get; set; }
        public _4014714350099990058 _4014714350099990058 { get; set; }
        public _4014714350100000059 _4014714350100000059 { get; set; }
        public _4014714350101010001 _4014714350101010001 { get; set; }
        public _4014714350101020036 _4014714350101020036 { get; set; }
        public _4014714350101030021 _4014714350101030021 { get; set; }
        public _4014714350101040024 _4014714350101040024 { get; set; }
        public _4014714350101990057 _4014714350101990057 { get; set; }
        public _4014714350101990099 _4014714350101990099 { get; set; }
        public _4014714350102010001 _4014714350102010001 { get; set; }
        public _4014714350102020005 _4014714350102020005 { get; set; }
        public _4014714350102030036 _4014714350102030036 { get; set; }
        public _4014714350102040002 _4014714350102040002 { get; set; }
        public _4014714350102990057 _4014714350102990057 { get; set; }
        public _4014714350102990099 _4014714350102990099 { get; set; }
        public _4014714350103010001 _4014714350103010001 { get; set; }
        public _4014714350103020005 _4014714350103020005 { get; set; }
        public _4014714350103030036 _4014714350103030036 { get; set; }
        public _4014714350103040005 _4014714350103040005 { get; set; }
        public _4014714350103050015 _4014714350103050015 { get; set; }
        public _4014714350103990057 _4014714350103990057 { get; set; }
        public _4014714350103990099 _4014714350103990099 { get; set; }
        public _4014714350104010001 _4014714350104010001 { get; set; }
        public _4014714350104020005 _4014714350104020005 { get; set; }
        public _4014714350104030037 _4014714350104030037 { get; set; }
        public _4014714350104040022 _4014714350104040022 { get; set; }
        public _4014714350104990057 _4014714350104990057 { get; set; }
        public _4014714350104990099 _4014714350104990099 { get; set; }
        public _4014714350199990058 _4014714350199990058 { get; set; }
        public _4014714350200000059 _4014714350200000059 { get; set; }
        public _4014714350201010001 _4014714350201010001 { get; set; }
        public _4014714350201020036 _4014714350201020036 { get; set; }
        public _4014714350201030005 _4014714350201030005 { get; set; }
        public _4014714350201040036 _4014714350201040036 { get; set; }
        public _4014714350201050005 _4014714350201050005 { get; set; }
        public _4014714350201060024 _4014714350201060024 { get; set; }
        public _4014714350201990057 _4014714350201990057 { get; set; }
        public _4014714350201990099 _4014714350201990099 { get; set; }
        public _4014714350202010001 _4014714350202010001 { get; set; }
        public _4014714350202020005 _4014714350202020005 { get; set; }
        public _4014714350202030036 _4014714350202030036 { get; set; }
        public _4014714350202040021 _4014714350202040021 { get; set; }
        public _4014714350202050037 _4014714350202050037 { get; set; }
        public _4014714350202990057 _4014714350202990057 { get; set; }
        public _4014714350202990099 _4014714350202990099 { get; set; }
        public _4014714350203010001 _4014714350203010001 { get; set; }
        public _4014714350203020036 _4014714350203020036 { get; set; }
        public _4014714350203030037 _4014714350203030037 { get; set; }
        public _4014714350203040005 _4014714350203040005 { get; set; }
        public _4014714350203050021 _4014714350203050021 { get; set; }
        public _4014714350203060036 _4014714350203060036 { get; set; }
        public _4014714350203990057 _4014714350203990057 { get; set; }
        public _4014714350203990099 _4014714350203990099 { get; set; }
        public _4014714350299990058 _4014714350299990058 { get; set; }
        public _4014714350300000059 _4014714350300000059 { get; set; }
        public _4014714350301010001 _4014714350301010001 { get; set; }
        public _4014714350301020036 _4014714350301020036 { get; set; }
        public _4014714350301030032 _4014714350301030032 { get; set; }
        public _4014714350301990057 _4014714350301990057 { get; set; }
        public _4014714350301990099 _4014714350301990099 { get; set; }
        public _4014714350302010001 _4014714350302010001 { get; set; }
        public _4014714350302020005 _4014714350302020005 { get; set; }
        public _4014714350302030037 _4014714350302030037 { get; set; }
        public _4014714350302040032 _4014714350302040032 { get; set; }
        public _4014714350302990057 _4014714350302990057 { get; set; }
        public _4014714350302990099 _4014714350302990099 { get; set; }
        public _4014714350303010001 _4014714350303010001 { get; set; }
        public _4014714350303020005 _4014714350303020005 { get; set; }
        public _4014714350303030005 _4014714350303030005 { get; set; }
        public _4014714350303040005 _4014714350303040005 { get; set; }
        public _4014714350303050005 _4014714350303050005 { get; set; }
        public _4014714350303990057 _4014714350303990057 { get; set; }
        public _4014714350303990099 _4014714350303990099 { get; set; }
        public _4014714350304010001 _4014714350304010001 { get; set; }
        public _4014714350304020036 _4014714350304020036 { get; set; }
        public _4014714350304030036 _4014714350304030036 { get; set; }
        public _4014714350304040005 _4014714350304040005 { get; set; }
        public _4014714350304050033 _4014714350304050033 { get; set; }
        public _4014714350304990057 _4014714350304990057 { get; set; }
        public _4014714350304990099 _4014714350304990099 { get; set; }
        public _4014714350399990058 _4014714350399990058 { get; set; }
        public _4014714350400000059 _4014714350400000059 { get; set; }
        public _4014714350401010001 _4014714350401010001 { get; set; }
        public _4014714350401020037 _4014714350401020037 { get; set; }
        public _4014714350401030005 _4014714350401030005 { get; set; }
        public _4014714350401040003 _4014714350401040003 { get; set; }
        public _4014714350401990057 _4014714350401990057 { get; set; }
        public _4014714350401990099 _4014714350401990099 { get; set; }
        public _4014714350402010001 _4014714350402010001 { get; set; }
        public _4014714350402020024 _4014714350402020024 { get; set; }
        public _4014714350402990057 _4014714350402990057 { get; set; }
        public _4014714350402990099 _4014714350402990099 { get; set; }
        public _4014714350403010001 _4014714350403010001 { get; set; }
        public _4014714350403020036 _4014714350403020036 { get; set; }
        public _4014714350403030036 _4014714350403030036 { get; set; }
        public _4014714350403040037 _4014714350403040037 { get; set; }
        public _4014714350403990057 _4014714350403990057 { get; set; }
        public _4014714350403990099 _4014714350403990099 { get; set; }
        public _4014714350404010001 _4014714350404010001 { get; set; }
        public _4014714350404020005 _4014714350404020005 { get; set; }
        public _4014714350404030002 _4014714350404030002 { get; set; }
        public _4014714350404990057 _4014714350404990057 { get; set; }
        public _4014714350404990099 _4014714350404990099 { get; set; }
        public _4014714350405010001 _4014714350405010001 { get; set; }
        public _4014714350405020024 _4014714350405020024 { get; set; }
        public _4014714350405990057 _4014714350405990057 { get; set; }
        public _4014714350405990099 _4014714350405990099 { get; set; }
        public _4014714350499990058 _4014714350499990058 { get; set; }
        public _4014714350500000059 _4014714350500000059 { get; set; }
        public _4014714350501010001 _4014714350501010001 { get; set; }
        public _4014714350501020005 _4014714350501020005 { get; set; }
        public _4014714350501030036 _4014714350501030036 { get; set; }
        public _4014714350501040003 _4014714350501040003 { get; set; }
        public _4014714350501990057 _4014714350501990057 { get; set; }
        public _4014714350501990099 _4014714350501990099 { get; set; }
        public _4014714350502010001 _4014714350502010001 { get; set; }
        public _4014714350502020002 _4014714350502020002 { get; set; }
        public _4014714350502990057 _4014714350502990057 { get; set; }
        public _4014714350502990099 _4014714350502990099 { get; set; }
        public _4014714350503010001 _4014714350503010001 { get; set; }
        public _4014714350503020037 _4014714350503020037 { get; set; }
        public _4014714350503030037 _4014714350503030037 { get; set; }
        public _4014714350503040021 _4014714350503040021 { get; set; }
        public _4014714350503050037 _4014714350503050037 { get; set; }
        public _4014714350503990057 _4014714350503990057 { get; set; }
        public _4014714350503990099 _4014714350503990099 { get; set; }
        public _4014714350504010001 _4014714350504010001 { get; set; }
        public _4014714350504020021 _4014714350504020021 { get; set; }
        public _4014714350504030021 _4014714350504030021 { get; set; }
        public _4014714350504040002 _4014714350504040002 { get; set; }
        public _4014714350504990057 _4014714350504990057 { get; set; }
        public _4014714350504990099 _4014714350504990099 { get; set; }
        public _4014714350505010001 _4014714350505010001 { get; set; }
        public _4014714350505020021 _4014714350505020021 { get; set; }
        public _4014714350505030021 _4014714350505030021 { get; set; }
        public _4014714350505040005 _4014714350505040005 { get; set; }
        public _4014714350505050026 _4014714350505050026 { get; set; }
        public _4014714350505990057 _4014714350505990057 { get; set; }
        public _4014714350505990099 _4014714350505990099 { get; set; }
        public _4014714350506010001 _4014714350506010001 { get; set; }
        public _4014714350506020021 _4014714350506020021 { get; set; }
        public _4014714350506030021 _4014714350506030021 { get; set; }
        public _4014714350506040021 _4014714350506040021 { get; set; }
        public _4014714350506050021 _4014714350506050021 { get; set; }
        public _4014714350506060024 _4014714350506060024 { get; set; }
        public _4014714350506990057 _4014714350506990057 { get; set; }
        public _4014714350506990099 _4014714350506990099 { get; set; }
        public _4014714350599990058 _4014714350599990058 { get; set; }
        public _4014714350600000059 _4014714350600000059 { get; set; }
        public _4014714350601010001 _4014714350601010001 { get; set; }
        public _4014714350601020036 _4014714350601020036 { get; set; }
        public _4014714350601030005 _4014714350601030005 { get; set; }
        public _4014714350601040005 _4014714350601040005 { get; set; }
        public _4014714350601050037 _4014714350601050037 { get; set; }
        public _4014714350601060005 _4014714350601060005 { get; set; }
        public _4014714350601070004 _4014714350601070004 { get; set; }
        public _4014714350601990057 _4014714350601990057 { get; set; }
        public _4014714350601990099 _4014714350601990099 { get; set; }
        public _4014714350602010001 _4014714350602010001 { get; set; }
        public _4014714350602020035 _4014714350602020035 { get; set; }
        public _4014714350602990057 _4014714350602990057 { get; set; }
        public _4014714350602990099 _4014714350602990099 { get; set; }
        public _4014714350603010001 _4014714350603010001 { get; set; }
        public _4014714350603020022 _4014714350603020022 { get; set; }
        public _4014714350603990057 _4014714350603990057 { get; set; }
        public _4014714350603990099 _4014714350603990099 { get; set; }
        public _4014714350604010001 _4014714350604010001 { get; set; }
        public _4014714350604020005 _4014714350604020005 { get; set; }
        public _4014714350604030005 _4014714350604030005 { get; set; }
        public _4014714350604040036 _4014714350604040036 { get; set; }
        public _4014714350604050021 _4014714350604050021 { get; set; }
        public _4014714350604060002 _4014714350604060002 { get; set; }
        public _4014714350604990057 _4014714350604990057 { get; set; }
        public _4014714350604990099 _4014714350604990099 { get; set; }
        public _4014714350605010001 _4014714350605010001 { get; set; }
        public _4014714350605020005 _4014714350605020005 { get; set; }
        public _4014714350605030037 _4014714350605030037 { get; set; }
        public _4014714350605040005 _4014714350605040005 { get; set; }
        public _4014714350605050005 _4014714350605050005 { get; set; }
        public _4014714350605060021 _4014714350605060021 { get; set; }
        public _4014714350605070005 _4014714350605070005 { get; set; }
        public _4014714350605990057 _4014714350605990057 { get; set; }
        public _4014714350605990099 _4014714350605990099 { get; set; }
        public _4014714350606010001 _4014714350606010001 { get; set; }
        public _4014714350606020037 _4014714350606020037 { get; set; }
        public _4014714350606030021 _4014714350606030021 { get; set; }
        public _4014714350606040005 _4014714350606040005 { get; set; }
        public _4014714350606050026 _4014714350606050026 { get; set; }
        public _4014714350606990057 _4014714350606990057 { get; set; }
        public _4014714350606990099 _4014714350606990099 { get; set; }
        public _4014714350607010001 _4014714350607010001 { get; set; }
        public _4014714350607020005 _4014714350607020005 { get; set; }
        public _4014714350607030005 _4014714350607030005 { get; set; }
        public _4014714350607040021 _4014714350607040021 { get; set; }
        public _4014714350607050037 _4014714350607050037 { get; set; }
        public _4014714350607060005 _4014714350607060005 { get; set; }
        public _4014714350607070021 _4014714350607070021 { get; set; }
        public _4014714350607080021 _4014714350607080021 { get; set; }
        public _4014714350607090036 _4014714350607090036 { get; set; }
        public _4014714350607990057 _4014714350607990057 { get; set; }
        public _4014714350607990099 _4014714350607990099 { get; set; }
        public _4014714350699990058 _4014714350699990058 { get; set; }
        public _4014714350700000059 _4014714350700000059 { get; set; }
        public _4014714350701010001 _4014714350701010001 { get; set; }
        public _4014714350701020005 _4014714350701020005 { get; set; }
        public _4014714350701030036 _4014714350701030036 { get; set; }
        public _4014714350701040024 _4014714350701040024 { get; set; }
        public _4014714350701990057 _4014714350701990057 { get; set; }
        public _4014714350701990099 _4014714350701990099 { get; set; }
        public _4014714350702010001 _4014714350702010001 { get; set; }
        public _4014714350702020037 _4014714350702020037 { get; set; }
        public _4014714350702030036 _4014714350702030036 { get; set; }
        public _4014714350702040002 _4014714350702040002 { get; set; }
        public _4014714350702990057 _4014714350702990057 { get; set; }
        public _4014714350702990099 _4014714350702990099 { get; set; }
        public _4014714350703010001 _4014714350703010001 { get; set; }
        public _4014714350703020005 _4014714350703020005 { get; set; }
        public _4014714350703020252 _4014714350703020252 { get; set; }
        public _4014714350703020298 _4014714350703020298 { get; set; }
        public _4014714350703030021 _4014714350703030021 { get; set; }
        public _4014714350703040037 _4014714350703040037 { get; set; }
        public _4014714350703050005 _4014714350703050005 { get; set; }
        public _4014714350703060037 _4014714350703060037 { get; set; }
        public _4014714350703990057 _4014714350703990057 { get; set; }
        public _4014714350703990099 _4014714350703990099 { get; set; }
        public _4014714350704010001 _4014714350704010001 { get; set; }
        public _4014714350704020003 _4014714350704020003 { get; set; }
        public _4014714350704990057 _4014714350704990057 { get; set; }
        public _4014714350704990099 _4014714350704990099 { get; set; }
        public _4014714350705010001 _4014714350705010001 { get; set; }
        public _4014714350705020021 _4014714350705020021 { get; set; }
        public _4014714350705030036 _4014714350705030036 { get; set; }
        public _4014714350705040021 _4014714350705040021 { get; set; }
        public _4014714350705050005 _4014714350705050005 { get; set; }
        public _4014714350705060021 _4014714350705060021 { get; set; }
        public _4014714350705070005 _4014714350705070005 { get; set; }
        public _4014714350705080005 _4014714350705080005 { get; set; }
        public _4014714350705080250 _4014714350705080250 { get; set; }
        public _4014714350705080298 _4014714350705080298 { get; set; }
        public _4014714350799990058 _4014714350799990058 { get; set; }
        public _4014714350800000059 _4014714350800000059 { get; set; }
        public _4014714350801000257 _4014714350801000257 { get; set; }
        public _4014714350801000357 _4014714350801000357 { get; set; }
        public _4014714350801000457 _4014714350801000457 { get; set; }
        public _4014714350801001057 _4014714350801001057 { get; set; }
        public _4014714350801010001 _4014714350801010001 { get; set; }
        public _4014714350801020037 _4014714350801020037 { get; set; }
        public _4014714350801030005 _4014714350801030005 { get; set; }
        public _4014714350801040005 _4014714350801040005 { get; set; }
        public _4014714350801050005 _4014714350801050005 { get; set; }
        public _4014714350801060037 _4014714350801060037 { get; set; }
        public _4014714350801070032 _4014714350801070032 { get; set; }
        public _4014714350801990057 _4014714350801990057 { get; set; }
        public _4014714350801990099 _4014714350801990099 { get; set; }
        public _4014714350802010001 _4014714350802010001 { get; set; }
        public _4014714350802020036 _4014714350802020036 { get; set; }
        public _4014714350802030005 _4014714350802030005 { get; set; }
        public _4014714350802040005 _4014714350802040005 { get; set; }
        public _4014714350802050037 _4014714350802050037 { get; set; }
        public _4014714350802060021 _4014714350802060021 { get; set; }
        public _4014714350802070022 _4014714350802070022 { get; set; }
        public _4014714350802990057 _4014714350802990057 { get; set; }
        public _4014714350802990099 _4014714350802990099 { get; set; }
        public _4014714350803010001 _4014714350803010001 { get; set; }
        public _4014714350803020036 _4014714350803020036 { get; set; }
        public _4014714350803030005 _4014714350803030005 { get; set; }
        public _4014714350803040005 _4014714350803040005 { get; set; }
        public _4014714350803050024 _4014714350803050024 { get; set; }
        public _4014714350803990057 _4014714350803990057 { get; set; }
        public _4014714350803990099 _4014714350803990099 { get; set; }
        public _4014714350899990058 _4014714350899990058 { get; set; }
        public _4014714350900000059 _4014714350900000059 { get; set; }
        public _4014714350901010001 _4014714350901010001 { get; set; }
        public _4014714350901020002 _4014714350901020002 { get; set; }
        public _4014714350901990057 _4014714350901990057 { get; set; }
        public _4014714350901990099 _4014714350901990099 { get; set; }
        public _4014714350902010001 _4014714350902010001 { get; set; }
        public _4014714350902020037 _4014714350902020037 { get; set; }
        public _4014714350902030036 _4014714350902030036 { get; set; }
        public _4014714350902040005 _4014714350902040005 { get; set; }
        public _4014714350902050005 _4014714350902050005 { get; set; }
        public _4014714350902060037 _4014714350902060037 { get; set; }
        public _4014714350902990057 _4014714350902990057 { get; set; }
        public _4014714350902990099 _4014714350902990099 { get; set; }
        public _4014714350903010001 _4014714350903010001 { get; set; }
        public _4014714350903020036 _4014714350903020036 { get; set; }
        public _4014714350903030021 _4014714350903030021 { get; set; }
        public _4014714350903040024 _4014714350903040024 { get; set; }
        public _4014714350903990057 _4014714350903990057 { get; set; }
        public _4014714350903990099 _4014714350903990099 { get; set; }
        public _4014714350999990058 _4014714350999990058 { get; set; }
        public _4014714351000000059 _4014714351000000059 { get; set; }
        public _4014714351001001157 _4014714351001001157 { get; set; }
        public _4014714351001010001 _4014714351001010001 { get; set; }
        public _4014714351001020005 _4014714351001020005 { get; set; }
        public _4014714351001030005 _4014714351001030005 { get; set; }
        public _4014714351001040028 _4014714351001040028 { get; set; }
        public _4014714351001990057 _4014714351001990057 { get; set; }
        public _4014714351001990099 _4014714351001990099 { get; set; }
        public _4014714351002010001 _4014714351002010001 { get; set; }
        public _4014714351002020005 _4014714351002020005 { get; set; }
        public _4014714351002030005 _4014714351002030005 { get; set; }
        public _4014714351002040021 _4014714351002040021 { get; set; }
        public _4014714351002050005 _4014714351002050005 { get; set; }
        public _4014714351002060033 _4014714351002060033 { get; set; }
        public _4014714351002990057 _4014714351002990057 { get; set; }
        public _4014714351002990099 _4014714351002990099 { get; set; }
        public _4014714351003010001 _4014714351003010001 { get; set; }
        public _4014714351003020021 _4014714351003020021 { get; set; }
        public _4014714351003030024 _4014714351003030024 { get; set; }
        public _4014714351003990057 _4014714351003990057 { get; set; }
        public _4014714351003990099 _4014714351003990099 { get; set; }
        public _4014714351004000957 _4014714351004000957 { get; set; }
        public _4014714351004010001 _4014714351004010001 { get; set; }
        public _4014714351004020032 _4014714351004020032 { get; set; }
        public _4014714351004990057 _4014714351004990057 { get; set; }
        public _4014714351004990099 _4014714351004990099 { get; set; }
        public _4014714351099990058 _4014714351099990058 { get; set; }
        public _4014714351100000059 _4014714351100000059 { get; set; }
        public _4014714351101000957 _4014714351101000957 { get; set; }
        public _4014714351101010001 _4014714351101010001 { get; set; }
        public _4014714351101020037 _4014714351101020037 { get; set; }
        public _4014714351101030024 _4014714351101030024 { get; set; }
        public _4014714351101990057 _4014714351101990057 { get; set; }
        public _4014714351101990099 _4014714351101990099 { get; set; }
        public _4014714351102010001 _4014714351102010001 { get; set; }
        public _4014714351102020005 _4014714351102020005 { get; set; }
        public _4014714351102030037 _4014714351102030037 { get; set; }
        public _4014714351102040022 _4014714351102040022 { get; set; }
        public _4014714351102990057 _4014714351102990057 { get; set; }
        public _4014714351102990099 _4014714351102990099 { get; set; }
        public _4014714351103010001 _4014714351103010001 { get; set; }
        public _4014714351103020005 _4014714351103020005 { get; set; }
        public _4014714351103030022 _4014714351103030022 { get; set; }
        public _4014714351103990057 _4014714351103990057 { get; set; }
        public _4014714351103990099 _4014714351103990099 { get; set; }
        public _4014714351199990058 _4014714351199990058 { get; set; }
        public _4014714351200000059 _4014714351200000059 { get; set; }
        public _4014714351201001157 _4014714351201001157 { get; set; }
        public _4014714351201010001 _4014714351201010001 { get; set; }
        public _4014714351201020033 _4014714351201020033 { get; set; }
        public _4014714351201990057 _4014714351201990057 { get; set; }
        public _4014714351201990099 _4014714351201990099 { get; set; }
        public _4014714351202010001 _4014714351202010001 { get; set; }
        public _4014714351202020002 _4014714351202020002 { get; set; }
        public _4014714351202990057 _4014714351202990057 { get; set; }
        public _4014714351202990099 _4014714351202990099 { get; set; }
        public _4014714351203010001 _4014714351203010001 { get; set; }
        public _4014714351203020021 _4014714351203020021 { get; set; }
        public _4014714351203030021 _4014714351203030021 { get; set; }
        public _4014714351203040005 _4014714351203040005 { get; set; }
        public _4014714351203040254 _4014714351203040254 { get; set; }
        public _4014714351203040298 _4014714351203040298 { get; set; }
        public _4014714351203050005 _4014714351203050005 { get; set; }
        public _4014714351203060021 _4014714351203060021 { get; set; }
        public _4014714351203070036 _4014714351203070036 { get; set; }
        public _4014714351203990057 _4014714351203990057 { get; set; }
        public _4014714351203990099 _4014714351203990099 { get; set; }
        public _4014714351204010001 _4014714351204010001 { get; set; }
        public _4014714351204020080 _4014714351204020080 { get; set; }
        public _4014714351204030080 _4014714351204030080 { get; set; }
        public _4014714351204040080 _4014714351204040080 { get; set; }
        public _4014714351204050080 _4014714351204050080 { get; set; }
        public _4014714351204990057 _4014714351204990057 { get; set; }
        public _4014714351204990099 _4014714351204990099 { get; set; }
        public _4014714351205010001 _4014714351205010001 { get; set; }
        public _4014714351205020005 _4014714351205020005 { get; set; }
        public _4014714351205030036 _4014714351205030036 { get; set; }
        public _4014714351205040032 _4014714351205040032 { get; set; }
        public _4014714351205990057 _4014714351205990057 { get; set; }
        public _4014714351205990099 _4014714351205990099 { get; set; }
        public _4014714351299990058 _4014714351299990058 { get; set; }
        public _4014714351300000059 _4014714351300000059 { get; set; }
        public _4014714351301001157 _4014714351301001157 { get; set; }
        public _4014714351301010001 _4014714351301010001 { get; set; }
        public _4014714351301020005 _4014714351301020005 { get; set; }
        public _4014714351301030021 _4014714351301030021 { get; set; }
        public _4014714351301040036 _4014714351301040036 { get; set; }
        public _4014714351301050021 _4014714351301050021 { get; set; }
        public _4014714351301060024 _4014714351301060024 { get; set; }
        public _4014714351301990057 _4014714351301990057 { get; set; }
        public _4014714351301990099 _4014714351301990099 { get; set; }
        public _4014714351302010001 _4014714351302010001 { get; set; }
        public _4014714351302020005 _4014714351302020005 { get; set; }
        public _4014714351302030024 _4014714351302030024 { get; set; }
        public _4014714351302990057 _4014714351302990057 { get; set; }
        public _4014714351302990099 _4014714351302990099 { get; set; }
        public _4014714351303010001 _4014714351303010001 { get; set; }
        public _4014714351303020036 _4014714351303020036 { get; set; }
        public _4014714351303030005 _4014714351303030005 { get; set; }
        public _4014714351303040005 _4014714351303040005 { get; set; }
        public _4014714351303050024 _4014714351303050024 { get; set; }
        public _4014714351303990057 _4014714351303990057 { get; set; }
        public _4014714351303990099 _4014714351303990099 { get; set; }
        public _4014714351399990058 _4014714351399990058 { get; set; }
        public _4014714351400000059 _4014714351400000059 { get; set; }
        public _4014714351401001157 _4014714351401001157 { get; set; }
        public _4014714351401010001 _4014714351401010001 { get; set; }
        public _4014714351401020036 _4014714351401020036 { get; set; }
        public _4014714351401030036 _4014714351401030036 { get; set; }
        public _4014714351401040024 _4014714351401040024 { get; set; }
        public _4014714351401990057 _4014714351401990057 { get; set; }
        public _4014714351401990099 _4014714351401990099 { get; set; }
        public _4014714351402010001 _4014714351402010001 { get; set; }
        public _4014714351402020005 _4014714351402020005 { get; set; }
        public _4014714351402030021 _4014714351402030021 { get; set; }
        public _4014714351402040005 _4014714351402040005 { get; set; }
        public _4014714351402050002 _4014714351402050002 { get; set; }
        public _4014714351402990057 _4014714351402990057 { get; set; }
        public _4014714351402990099 _4014714351402990099 { get; set; }
        public _4014714351403000857 _4014714351403000857 { get; set; }
        public _4014714351403010001 _4014714351403010001 { get; set; }
        public _4014714351403020021 _4014714351403020021 { get; set; }
        public _4014714351403030002 _4014714351403030002 { get; set; }
        public _4014714351403990057 _4014714351403990057 { get; set; }
        public _4014714351403990099 _4014714351403990099 { get; set; }
        public _4014714351404010001 _4014714351404010001 { get; set; }
        public _4014714351404020036 _4014714351404020036 { get; set; }
        public _4014714351404030032 _4014714351404030032 { get; set; }
        public _4014714351404990057 _4014714351404990057 { get; set; }
        public _4014714351404990099 _4014714351404990099 { get; set; }
        public _4014714351499990058 _4014714351499990058 { get; set; }
        public _4014714351500000059 _4014714351500000059 { get; set; }
        public _4014714351501000857 _4014714351501000857 { get; set; }
        public _4014714351501001157 _4014714351501001157 { get; set; }
        public _4014714351501010001 _4014714351501010001 { get; set; }
        public _4014714351501020005 _4014714351501020005 { get; set; }
        public _4014714351501030005 _4014714351501030005 { get; set; }
        public _4014714351501040036 _4014714351501040036 { get; set; }
        public _4014714351501050005 _4014714351501050005 { get; set; }
        public _4014714351501060005 _4014714351501060005 { get; set; }
        public _4014714351501990057 _4014714351501990057 { get; set; }
        public _4014714351501990099 _4014714351501990099 { get; set; }
        public _4014714351502010001 _4014714351502010001 { get; set; }
        public _4014714351502020036 _4014714351502020036 { get; set; }
        public _4014714351502030037 _4014714351502030037 { get; set; }
        public _4014714351502040002 _4014714351502040002 { get; set; }
        public _4014714351502990057 _4014714351502990057 { get; set; }
        public _4014714351502990099 _4014714351502990099 { get; set; }
        public _4014714351503010001 _4014714351503010001 { get; set; }
        public _4014714351503020035 _4014714351503020035 { get; set; }
        public _4014714351503990057 _4014714351503990057 { get; set; }
        public _4014714351503990099 _4014714351503990099 { get; set; }
        public _4014714351504001157 _4014714351504001157 { get; set; }
        public _4014714351504010001 _4014714351504010001 { get; set; }
        public _4014714351504020021 _4014714351504020021 { get; set; }
        public _4014714351504030037 _4014714351504030037 { get; set; }
        public _4014714351504040005 _4014714351504040005 { get; set; }
        public _4014714351504050024 _4014714351504050024 { get; set; }
        public _4014714351504990057 _4014714351504990057 { get; set; }
        public _4014714351504990099 _4014714351504990099 { get; set; }
        public _4014714351505010001 _4014714351505010001 { get; set; }
        public _4014714351505020005 _4014714351505020005 { get; set; }
        public _4014714351505030005 _4014714351505030005 { get; set; }
        public _4014714351505040036 _4014714351505040036 { get; set; }
        public _4014714351505050005 _4014714351505050005 { get; set; }
        public _4014714351505060037 _4014714351505060037 { get; set; }
        public _4014714351505070037 _4014714351505070037 { get; set; }
        public _4014714351505990057 _4014714351505990057 { get; set; }
        public _4014714351505990099 _4014714351505990099 { get; set; }
        public _4014714351599990058 _4014714351599990058 { get; set; }
        public _4014714351600000059 _4014714351600000059 { get; set; }
        public _4014714351601001157 _4014714351601001157 { get; set; }
        public _4014714351601010001 _4014714351601010001 { get; set; }
        public _4014714351601020036 _4014714351601020036 { get; set; }
        public _4014714351601030021 _4014714351601030021 { get; set; }
        public _4014714351601040005 _4014714351601040005 { get; set; }
        public _4014714351601050022 _4014714351601050022 { get; set; }
        public _4014714351601990057 _4014714351601990057 { get; set; }
        public _4014714351601990099 _4014714351601990099 { get; set; }
        public _4014714351602010001 _4014714351602010001 { get; set; }
        public _4014714351602020005 _4014714351602020005 { get; set; }
        public _4014714351602030036 _4014714351602030036 { get; set; }
        public _4014714351602040037 _4014714351602040037 { get; set; }
        public _4014714351602050021 _4014714351602050021 { get; set; }
        public _4014714351602060036 _4014714351602060036 { get; set; }
        public _4014714351602990057 _4014714351602990057 { get; set; }
        public _4014714351602990099 _4014714351602990099 { get; set; }
        public _4014714351603010001 _4014714351603010001 { get; set; }
        public _4014714351603020037 _4014714351603020037 { get; set; }
        public _4014714351603030037 _4014714351603030037 { get; set; }
        public _4014714351603040024 _4014714351603040024 { get; set; }
        public _4014714351603990057 _4014714351603990057 { get; set; }
        public _4014714351603990099 _4014714351603990099 { get; set; }
    }

    public class _4014714350000000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350001010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350001020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350001030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350001040022
    {
        public string _ref { get; set; }
    }

    public class _4014714350001990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350001990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350002010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350002020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350002030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350002040021
    {
        public string _ref { get; set; }
    }

    public class _4014714350002050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350002060021
    {
        public string _ref { get; set; }
    }

    public class _4014714350002070002
    {
        public string _ref { get; set; }
    }

    public class _4014714350002990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350002990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350003010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350003020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350003030022
    {
        public string _ref { get; set; }
    }

    public class _4014714350003990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350003990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350004010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350004020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350004030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350004040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350004050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350004060022
    {
        public string _ref { get; set; }
    }

    public class _4014714350004990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350004990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350099990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350100000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350101010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350101020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350101030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350101040024
    {
        public string _ref { get; set; }
    }

    public class _4014714350101990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350101990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350102010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350102020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350102030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350102040002
    {
        public string _ref { get; set; }
    }

    public class _4014714350102990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350102990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350103010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350103020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350103030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350103040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350103050015
    {
        public string _ref { get; set; }
    }

    public class _4014714350103990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350103990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350104010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350104020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350104030037
    {
        public string _ref { get; set; }
    }

    public class _4014714350104040022
    {
        public string _ref { get; set; }
    }

    public class _4014714350104990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350104990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350199990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350200000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350201010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350201020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350201030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350201040036
    {
        public string _ref { get; set; }
    }

    public class _4014714350201050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350201060024
    {
        public string _ref { get; set; }
    }

    public class _4014714350201990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350201990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350202010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350202020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350202030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350202040021
    {
        public string _ref { get; set; }
    }

    public class _4014714350202050037
    {
        public string _ref { get; set; }
    }

    public class _4014714350202990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350202990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350203010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350203020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350203030037
    {
        public string _ref { get; set; }
    }

    public class _4014714350203040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350203050021
    {
        public string _ref { get; set; }
    }

    public class _4014714350203060036
    {
        public string _ref { get; set; }
    }

    public class _4014714350203990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350203990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350299990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350300000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350301010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350301020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350301030032
    {
        public string _ref { get; set; }
    }

    public class _4014714350301990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350301990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350302010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350302020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350302030037
    {
        public string _ref { get; set; }
    }

    public class _4014714350302040032
    {
        public string _ref { get; set; }
    }

    public class _4014714350302990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350302990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350303010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350303020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350303030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350303040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350303050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350303990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350303990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350304010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350304020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350304030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350304040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350304050033
    {
        public string _ref { get; set; }
    }

    public class _4014714350304990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350304990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350399990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350400000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350401010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350401020037
    {
        public string _ref { get; set; }
    }

    public class _4014714350401030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350401040003
    {
        public string _ref { get; set; }
    }

    public class _4014714350401990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350401990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350402010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350402020024
    {
        public string _ref { get; set; }
    }

    public class _4014714350402990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350402990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350403010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350403020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350403030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350403040037
    {
        public string _ref { get; set; }
    }

    public class _4014714350403990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350403990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350404010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350404020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350404030002
    {
        public string _ref { get; set; }
    }

    public class _4014714350404990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350404990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350405010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350405020024
    {
        public string _ref { get; set; }
    }

    public class _4014714350405990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350405990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350499990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350500000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350501010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350501020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350501030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350501040003
    {
        public string _ref { get; set; }
    }

    public class _4014714350501990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350501990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350502010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350502020002
    {
        public string _ref { get; set; }
    }

    public class _4014714350502990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350502990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350503010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350503020037
    {
        public string _ref { get; set; }
    }

    public class _4014714350503030037
    {
        public string _ref { get; set; }
    }

    public class _4014714350503040021
    {
        public string _ref { get; set; }
    }

    public class _4014714350503050037
    {
        public string _ref { get; set; }
    }

    public class _4014714350503990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350503990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350504010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350504020021
    {
        public string _ref { get; set; }
    }

    public class _4014714350504030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350504040002
    {
        public string _ref { get; set; }
    }

    public class _4014714350504990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350504990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350505010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350505020021
    {
        public string _ref { get; set; }
    }

    public class _4014714350505030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350505040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350505050026
    {
        public string _ref { get; set; }
    }

    public class _4014714350505990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350505990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350506010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350506020021
    {
        public string _ref { get; set; }
    }

    public class _4014714350506030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350506040021
    {
        public string _ref { get; set; }
    }

    public class _4014714350506050021
    {
        public string _ref { get; set; }
    }

    public class _4014714350506060024
    {
        public string _ref { get; set; }
    }

    public class _4014714350506990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350506990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350599990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350600000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350601010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350601020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350601030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350601040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350601050037
    {
        public string _ref { get; set; }
    }

    public class _4014714350601060005
    {
        public string _ref { get; set; }
    }

    public class _4014714350601070004
    {
        public string _ref { get; set; }
    }

    public class _4014714350601990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350601990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350602010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350602020035
    {
        public string _ref { get; set; }
    }

    public class _4014714350602990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350602990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350603010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350603020022
    {
        public string _ref { get; set; }
    }

    public class _4014714350603990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350603990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350604010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350604020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350604030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350604040036
    {
        public string _ref { get; set; }
    }

    public class _4014714350604050021
    {
        public string _ref { get; set; }
    }

    public class _4014714350604060002
    {
        public string _ref { get; set; }
    }

    public class _4014714350604990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350604990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350605010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350605020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350605030037
    {
        public string _ref { get; set; }
    }

    public class _4014714350605040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350605050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350605060021
    {
        public string _ref { get; set; }
    }

    public class _4014714350605070005
    {
        public string _ref { get; set; }
    }

    public class _4014714350605990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350605990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350606010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350606020037
    {
        public string _ref { get; set; }
    }

    public class _4014714350606030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350606040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350606050026
    {
        public string _ref { get; set; }
    }

    public class _4014714350606990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350606990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350607010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350607020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350607030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350607040021
    {
        public string _ref { get; set; }
    }

    public class _4014714350607050037
    {
        public string _ref { get; set; }
    }

    public class _4014714350607060005
    {
        public string _ref { get; set; }
    }

    public class _4014714350607070021
    {
        public string _ref { get; set; }
    }

    public class _4014714350607080021
    {
        public string _ref { get; set; }
    }

    public class _4014714350607090036
    {
        public string _ref { get; set; }
    }

    public class _4014714350607990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350607990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350699990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350700000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350701010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350701020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350701030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350701040024
    {
        public string _ref { get; set; }
    }

    public class _4014714350701990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350701990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350702010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350702020037
    {
        public string _ref { get; set; }
    }

    public class _4014714350702030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350702040002
    {
        public string _ref { get; set; }
    }

    public class _4014714350702990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350702990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350703010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350703020005
    {
        public string _ref { get; set; }
    }

    public class _4014714350703020252
    {
        public string _ref { get; set; }
    }

    public class _4014714350703020298
    {
        public string _ref { get; set; }
    }

    public class _4014714350703030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350703040037
    {
        public string _ref { get; set; }
    }

    public class _4014714350703050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350703060037
    {
        public string _ref { get; set; }
    }

    public class _4014714350703990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350703990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350704010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350704020003
    {
        public string _ref { get; set; }
    }

    public class _4014714350704990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350704990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350705010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350705020021
    {
        public string _ref { get; set; }
    }

    public class _4014714350705030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350705040021
    {
        public string _ref { get; set; }
    }

    public class _4014714350705050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350705060021
    {
        public string _ref { get; set; }
    }

    public class _4014714350705070005
    {
        public string _ref { get; set; }
    }

    public class _4014714350705080005
    {
        public string _ref { get; set; }
    }

    public class _4014714350705080250
    {
        public string _ref { get; set; }
    }

    public class _4014714350705080298
    {
        public string _ref { get; set; }
    }

    public class _4014714350799990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350800000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350801000257
    {
        public string _ref { get; set; }
    }

    public class _4014714350801000357
    {
        public string _ref { get; set; }
    }

    public class _4014714350801000457
    {
        public string _ref { get; set; }
    }

    public class _4014714350801001057
    {
        public string _ref { get; set; }
    }

    public class _4014714350801010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350801020037
    {
        public string _ref { get; set; }
    }

    public class _4014714350801030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350801040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350801050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350801060037
    {
        public string _ref { get; set; }
    }

    public class _4014714350801070032
    {
        public string _ref { get; set; }
    }

    public class _4014714350801990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350801990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350802010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350802020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350802030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350802040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350802050037
    {
        public string _ref { get; set; }
    }

    public class _4014714350802060021
    {
        public string _ref { get; set; }
    }

    public class _4014714350802070022
    {
        public string _ref { get; set; }
    }

    public class _4014714350802990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350802990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350803010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350803020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350803030005
    {
        public string _ref { get; set; }
    }

    public class _4014714350803040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350803050024
    {
        public string _ref { get; set; }
    }

    public class _4014714350803990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350803990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350899990058
    {
        public string _ref { get; set; }
    }

    public class _4014714350900000059
    {
        public string _ref { get; set; }
    }

    public class _4014714350901010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350901020002
    {
        public string _ref { get; set; }
    }

    public class _4014714350901990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350901990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350902010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350902020037
    {
        public string _ref { get; set; }
    }

    public class _4014714350902030036
    {
        public string _ref { get; set; }
    }

    public class _4014714350902040005
    {
        public string _ref { get; set; }
    }

    public class _4014714350902050005
    {
        public string _ref { get; set; }
    }

    public class _4014714350902060037
    {
        public string _ref { get; set; }
    }

    public class _4014714350902990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350902990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350903010001
    {
        public string _ref { get; set; }
    }

    public class _4014714350903020036
    {
        public string _ref { get; set; }
    }

    public class _4014714350903030021
    {
        public string _ref { get; set; }
    }

    public class _4014714350903040024
    {
        public string _ref { get; set; }
    }

    public class _4014714350903990057
    {
        public string _ref { get; set; }
    }

    public class _4014714350903990099
    {
        public string _ref { get; set; }
    }

    public class _4014714350999990058
    {
        public string _ref { get; set; }
    }

    public class _4014714351000000059
    {
        public string _ref { get; set; }
    }

    public class _4014714351001001157
    {
        public string _ref { get; set; }
    }

    public class _4014714351001010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351001020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351001030005
    {
        public string _ref { get; set; }
    }

    public class _4014714351001040028
    {
        public string _ref { get; set; }
    }

    public class _4014714351001990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351001990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351002010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351002020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351002030005
    {
        public string _ref { get; set; }
    }

    public class _4014714351002040021
    {
        public string _ref { get; set; }
    }

    public class _4014714351002050005
    {
        public string _ref { get; set; }
    }

    public class _4014714351002060033
    {
        public string _ref { get; set; }
    }

    public class _4014714351002990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351002990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351003010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351003020021
    {
        public string _ref { get; set; }
    }

    public class _4014714351003030024
    {
        public string _ref { get; set; }
    }

    public class _4014714351003990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351003990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351004000957
    {
        public string _ref { get; set; }
    }

    public class _4014714351004010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351004020032
    {
        public string _ref { get; set; }
    }

    public class _4014714351004990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351004990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351099990058
    {
        public string _ref { get; set; }
    }

    public class _4014714351100000059
    {
        public string _ref { get; set; }
    }

    public class _4014714351101000957
    {
        public string _ref { get; set; }
    }

    public class _4014714351101010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351101020037
    {
        public string _ref { get; set; }
    }

    public class _4014714351101030024
    {
        public string _ref { get; set; }
    }

    public class _4014714351101990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351101990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351102010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351102020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351102030037
    {
        public string _ref { get; set; }
    }

    public class _4014714351102040022
    {
        public string _ref { get; set; }
    }

    public class _4014714351102990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351102990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351103010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351103020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351103030022
    {
        public string _ref { get; set; }
    }

    public class _4014714351103990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351103990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351199990058
    {
        public string _ref { get; set; }
    }

    public class _4014714351200000059
    {
        public string _ref { get; set; }
    }

    public class _4014714351201001157
    {
        public string _ref { get; set; }
    }

    public class _4014714351201010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351201020033
    {
        public string _ref { get; set; }
    }

    public class _4014714351201990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351201990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351202010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351202020002
    {
        public string _ref { get; set; }
    }

    public class _4014714351202990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351202990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351203010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351203020021
    {
        public string _ref { get; set; }
    }

    public class _4014714351203030021
    {
        public string _ref { get; set; }
    }

    public class _4014714351203040005
    {
        public string _ref { get; set; }
    }

    public class _4014714351203040254
    {
        public string _ref { get; set; }
    }

    public class _4014714351203040298
    {
        public string _ref { get; set; }
    }

    public class _4014714351203050005
    {
        public string _ref { get; set; }
    }

    public class _4014714351203060021
    {
        public string _ref { get; set; }
    }

    public class _4014714351203070036
    {
        public string _ref { get; set; }
    }

    public class _4014714351203990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351203990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351204010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351204020080
    {
        public string _ref { get; set; }
    }

    public class _4014714351204030080
    {
        public string _ref { get; set; }
    }

    public class _4014714351204040080
    {
        public string _ref { get; set; }
    }

    public class _4014714351204050080
    {
        public string _ref { get; set; }
    }

    public class _4014714351204990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351204990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351205010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351205020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351205030036
    {
        public string _ref { get; set; }
    }

    public class _4014714351205040032
    {
        public string _ref { get; set; }
    }

    public class _4014714351205990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351205990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351299990058
    {
        public string _ref { get; set; }
    }

    public class _4014714351300000059
    {
        public string _ref { get; set; }
    }

    public class _4014714351301001157
    {
        public string _ref { get; set; }
    }

    public class _4014714351301010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351301020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351301030021
    {
        public string _ref { get; set; }
    }

    public class _4014714351301040036
    {
        public string _ref { get; set; }
    }

    public class _4014714351301050021
    {
        public string _ref { get; set; }
    }

    public class _4014714351301060024
    {
        public string _ref { get; set; }
    }

    public class _4014714351301990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351301990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351302010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351302020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351302030024
    {
        public string _ref { get; set; }
    }

    public class _4014714351302990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351302990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351303010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351303020036
    {
        public string _ref { get; set; }
    }

    public class _4014714351303030005
    {
        public string _ref { get; set; }
    }

    public class _4014714351303040005
    {
        public string _ref { get; set; }
    }

    public class _4014714351303050024
    {
        public string _ref { get; set; }
    }

    public class _4014714351303990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351303990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351399990058
    {
        public string _ref { get; set; }
    }

    public class _4014714351400000059
    {
        public string _ref { get; set; }
    }

    public class _4014714351401001157
    {
        public string _ref { get; set; }
    }

    public class _4014714351401010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351401020036
    {
        public string _ref { get; set; }
    }

    public class _4014714351401030036
    {
        public string _ref { get; set; }
    }

    public class _4014714351401040024
    {
        public string _ref { get; set; }
    }

    public class _4014714351401990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351401990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351402010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351402020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351402030021
    {
        public string _ref { get; set; }
    }

    public class _4014714351402040005
    {
        public string _ref { get; set; }
    }

    public class _4014714351402050002
    {
        public string _ref { get; set; }
    }

    public class _4014714351402990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351402990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351403000857
    {
        public string _ref { get; set; }
    }

    public class _4014714351403010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351403020021
    {
        public string _ref { get; set; }
    }

    public class _4014714351403030002
    {
        public string _ref { get; set; }
    }

    public class _4014714351403990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351403990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351404010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351404020036
    {
        public string _ref { get; set; }
    }

    public class _4014714351404030032
    {
        public string _ref { get; set; }
    }

    public class _4014714351404990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351404990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351499990058
    {
        public string _ref { get; set; }
    }

    public class _4014714351500000059
    {
        public string _ref { get; set; }
    }

    public class _4014714351501000857
    {
        public string _ref { get; set; }
    }

    public class _4014714351501001157
    {
        public string _ref { get; set; }
    }

    public class _4014714351501010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351501020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351501030005
    {
        public string _ref { get; set; }
    }

    public class _4014714351501040036
    {
        public string _ref { get; set; }
    }

    public class _4014714351501050005
    {
        public string _ref { get; set; }
    }

    public class _4014714351501060005
    {
        public string _ref { get; set; }
    }

    public class _4014714351501990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351501990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351502010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351502020036
    {
        public string _ref { get; set; }
    }

    public class _4014714351502030037
    {
        public string _ref { get; set; }
    }

    public class _4014714351502040002
    {
        public string _ref { get; set; }
    }

    public class _4014714351502990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351502990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351503010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351503020035
    {
        public string _ref { get; set; }
    }

    public class _4014714351503990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351503990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351504001157
    {
        public string _ref { get; set; }
    }

    public class _4014714351504010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351504020021
    {
        public string _ref { get; set; }
    }

    public class _4014714351504030037
    {
        public string _ref { get; set; }
    }

    public class _4014714351504040005
    {
        public string _ref { get; set; }
    }

    public class _4014714351504050024
    {
        public string _ref { get; set; }
    }

    public class _4014714351504990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351504990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351505010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351505020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351505030005
    {
        public string _ref { get; set; }
    }

    public class _4014714351505040036
    {
        public string _ref { get; set; }
    }

    public class _4014714351505050005
    {
        public string _ref { get; set; }
    }

    public class _4014714351505060037
    {
        public string _ref { get; set; }
    }

    public class _4014714351505070037
    {
        public string _ref { get; set; }
    }

    public class _4014714351505990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351505990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351599990058
    {
        public string _ref { get; set; }
    }

    public class _4014714351600000059
    {
        public string _ref { get; set; }
    }

    public class _4014714351601001157
    {
        public string _ref { get; set; }
    }

    public class _4014714351601010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351601020036
    {
        public string _ref { get; set; }
    }

    public class _4014714351601030021
    {
        public string _ref { get; set; }
    }

    public class _4014714351601040005
    {
        public string _ref { get; set; }
    }

    public class _4014714351601050022
    {
        public string _ref { get; set; }
    }

    public class _4014714351601990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351601990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351602010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351602020005
    {
        public string _ref { get; set; }
    }

    public class _4014714351602030036
    {
        public string _ref { get; set; }
    }

    public class _4014714351602040037
    {
        public string _ref { get; set; }
    }

    public class _4014714351602050021
    {
        public string _ref { get; set; }
    }

    public class _4014714351602060036
    {
        public string _ref { get; set; }
    }

    public class _4014714351602990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351602990099
    {
        public string _ref { get; set; }
    }

    public class _4014714351603010001
    {
        public string _ref { get; set; }
    }

    public class _4014714351603020037
    {
        public string _ref { get; set; }
    }

    public class _4014714351603030037
    {
        public string _ref { get; set; }
    }

    public class _4014714351603040024
    {
        public string _ref { get; set; }
    }

    public class _4014714351603990057
    {
        public string _ref { get; set; }
    }

    public class _4014714351603990099
    {
        public string _ref { get; set; }
    }

    public class Atbats
    {
        public _4014714350001[] _4014714350001 { get; set; }
        public _4014714350002[] _4014714350002 { get; set; }
        public _4014714350003[] _4014714350003 { get; set; }
        public _4014714350004[] _4014714350004 { get; set; }
        public _4014714350101[] _4014714350101 { get; set; }
        public _4014714350102[] _4014714350102 { get; set; }
        public _4014714350103[] _4014714350103 { get; set; }
        public _4014714350104[] _4014714350104 { get; set; }
        public _4014714350201[] _4014714350201 { get; set; }
        public _4014714350202[] _4014714350202 { get; set; }
        public _4014714350203[] _4014714350203 { get; set; }
        public _4014714350301[] _4014714350301 { get; set; }
        public _4014714350302[] _4014714350302 { get; set; }
        public _4014714350303[] _4014714350303 { get; set; }
        public _4014714350304[] _4014714350304 { get; set; }
        public _4014714350401[] _4014714350401 { get; set; }
        public _4014714350402[] _4014714350402 { get; set; }
        public _4014714350403[] _4014714350403 { get; set; }
        public _4014714350404[] _4014714350404 { get; set; }
        public _4014714350405[] _4014714350405 { get; set; }
        public _4014714350501[] _4014714350501 { get; set; }
        public _4014714350502[] _4014714350502 { get; set; }
        public _4014714350503[] _4014714350503 { get; set; }
        public _4014714350504[] _4014714350504 { get; set; }
        public _4014714350505[] _4014714350505 { get; set; }
        public _4014714350506[] _4014714350506 { get; set; }
        public _4014714350601[] _4014714350601 { get; set; }
        public _4014714350602[] _4014714350602 { get; set; }
        public _4014714350603[] _4014714350603 { get; set; }
        public _4014714350604[] _4014714350604 { get; set; }
        public _4014714350605[] _4014714350605 { get; set; }
        public _4014714350606[] _4014714350606 { get; set; }
        public _4014714350607[] _4014714350607 { get; set; }
        public _4014714350701[] _4014714350701 { get; set; }
        public _4014714350702[] _4014714350702 { get; set; }
        public _4014714350703[] _4014714350703 { get; set; }
        public _4014714350704[] _4014714350704 { get; set; }
        public _4014714350705[] _4014714350705 { get; set; }
        public _4014714350801[] _4014714350801 { get; set; }
        public _4014714350802[] _4014714350802 { get; set; }
        public _4014714350803[] _4014714350803 { get; set; }
        public _4014714350901[] _4014714350901 { get; set; }
        public _4014714350902[] _4014714350902 { get; set; }
        public _4014714350903[] _4014714350903 { get; set; }
        public _4014714351001[] _4014714351001 { get; set; }
        public _4014714351002[] _4014714351002 { get; set; }
        public _4014714351003[] _4014714351003 { get; set; }
        public _4014714351004[] _4014714351004 { get; set; }
        public _4014714351101[] _4014714351101 { get; set; }
        public _4014714351102[] _4014714351102 { get; set; }
        public _4014714351103[] _4014714351103 { get; set; }
        public _4014714351201[] _4014714351201 { get; set; }
        public _4014714351202[] _4014714351202 { get; set; }
        public _4014714351203[] _4014714351203 { get; set; }
        public _4014714351204[] _4014714351204 { get; set; }
        public _4014714351205[] _4014714351205 { get; set; }
        public _4014714351301[] _4014714351301 { get; set; }
        public _4014714351302[] _4014714351302 { get; set; }
        public _4014714351303[] _4014714351303 { get; set; }
        public _4014714351401[] _4014714351401 { get; set; }
        public _4014714351402[] _4014714351402 { get; set; }
        public _4014714351403[] _4014714351403 { get; set; }
        public _4014714351404[] _4014714351404 { get; set; }
        public _4014714351501[] _4014714351501 { get; set; }
        public _4014714351502[] _4014714351502 { get; set; }
        public _4014714351503[] _4014714351503 { get; set; }
        public _4014714351504[] _4014714351504 { get; set; }
        public _4014714351505[] _4014714351505 { get; set; }
        public _4014714351601[] _4014714351601 { get; set; }
        public _4014714351602[] _4014714351602 { get; set; }
        public _4014714351603[] _4014714351603 { get; set; }
    }

    public class _4014714350001
    {
        public string _ref { get; set; }
    }

    public class _4014714350002
    {
        public string _ref { get; set; }
    }

    public class _4014714350003
    {
        public string _ref { get; set; }
    }

    public class _4014714350004
    {
        public string _ref { get; set; }
    }

    public class _4014714350101
    {
        public string _ref { get; set; }
    }

    public class _4014714350102
    {
        public string _ref { get; set; }
    }

    public class _4014714350103
    {
        public string _ref { get; set; }
    }

    public class _4014714350104
    {
        public string _ref { get; set; }
    }

    public class _4014714350201
    {
        public string _ref { get; set; }
    }

    public class _4014714350202
    {
        public string _ref { get; set; }
    }

    public class _4014714350203
    {
        public string _ref { get; set; }
    }

    public class _4014714350301
    {
        public string _ref { get; set; }
    }

    public class _4014714350302
    {
        public string _ref { get; set; }
    }

    public class _4014714350303
    {
        public string _ref { get; set; }
    }

    public class _4014714350304
    {
        public string _ref { get; set; }
    }

    public class _4014714350401
    {
        public string _ref { get; set; }
    }

    public class _4014714350402
    {
        public string _ref { get; set; }
    }

    public class _4014714350403
    {
        public string _ref { get; set; }
    }

    public class _4014714350404
    {
        public string _ref { get; set; }
    }

    public class _4014714350405
    {
        public string _ref { get; set; }
    }

    public class _4014714350501
    {
        public string _ref { get; set; }
    }

    public class _4014714350502
    {
        public string _ref { get; set; }
    }

    public class _4014714350503
    {
        public string _ref { get; set; }
    }

    public class _4014714350504
    {
        public string _ref { get; set; }
    }

    public class _4014714350505
    {
        public string _ref { get; set; }
    }

    public class _4014714350506
    {
        public string _ref { get; set; }
    }

    public class _4014714350601
    {
        public string _ref { get; set; }
    }

    public class _4014714350602
    {
        public string _ref { get; set; }
    }

    public class _4014714350603
    {
        public string _ref { get; set; }
    }

    public class _4014714350604
    {
        public string _ref { get; set; }
    }

    public class _4014714350605
    {
        public string _ref { get; set; }
    }

    public class _4014714350606
    {
        public string _ref { get; set; }
    }

    public class _4014714350607
    {
        public string _ref { get; set; }
    }

    public class _4014714350701
    {
        public string _ref { get; set; }
    }

    public class _4014714350702
    {
        public string _ref { get; set; }
    }

    public class _4014714350703
    {
        public string _ref { get; set; }
    }

    public class _4014714350704
    {
        public string _ref { get; set; }
    }

    public class _4014714350705
    {
        public string _ref { get; set; }
    }

    public class _4014714350801
    {
        public string _ref { get; set; }
    }

    public class _4014714350802
    {
        public string _ref { get; set; }
    }

    public class _4014714350803
    {
        public string _ref { get; set; }
    }

    public class _4014714350901
    {
        public string _ref { get; set; }
    }

    public class _4014714350902
    {
        public string _ref { get; set; }
    }

    public class _4014714350903
    {
        public string _ref { get; set; }
    }

    public class _4014714351001
    {
        public string _ref { get; set; }
    }

    public class _4014714351002
    {
        public string _ref { get; set; }
    }

    public class _4014714351003
    {
        public string _ref { get; set; }
    }

    public class _4014714351004
    {
        public string _ref { get; set; }
    }

    public class _4014714351101
    {
        public string _ref { get; set; }
    }

    public class _4014714351102
    {
        public string _ref { get; set; }
    }

    public class _4014714351103
    {
        public string _ref { get; set; }
    }

    public class _4014714351201
    {
        public string _ref { get; set; }
    }

    public class _4014714351202
    {
        public string _ref { get; set; }
    }

    public class _4014714351203
    {
        public string _ref { get; set; }
    }

    public class _4014714351204
    {
        public string _ref { get; set; }
    }

    public class _4014714351205
    {
        public string _ref { get; set; }
    }

    public class _4014714351301
    {
        public string _ref { get; set; }
    }

    public class _4014714351302
    {
        public string _ref { get; set; }
    }

    public class _4014714351303
    {
        public string _ref { get; set; }
    }

    public class _4014714351401
    {
        public string _ref { get; set; }
    }

    public class _4014714351402
    {
        public string _ref { get; set; }
    }

    public class _4014714351403
    {
        public string _ref { get; set; }
    }

    public class _4014714351404
    {
        public string _ref { get; set; }
    }

    public class _4014714351501
    {
        public string _ref { get; set; }
    }

    public class _4014714351502
    {
        public string _ref { get; set; }
    }

    public class _4014714351503
    {
        public string _ref { get; set; }
    }

    public class _4014714351504
    {
        public string _ref { get; set; }
    }

    public class _4014714351505
    {
        public string _ref { get; set; }
    }

    public class _4014714351601
    {
        public string _ref { get; set; }
    }

    public class _4014714351602
    {
        public string _ref { get; set; }
    }

    public class _4014714351603
    {
        public string _ref { get; set; }
    }

    public class Standings
    {
        public Fullviewlink fullViewLink { get; set; }
        public Group[] groups { get; set; }
    }

    public class Fullviewlink
    {
        public string text { get; set; }
        public string href { get; set; }
    }

    public class Group
    {
        public Standings1 standings { get; set; }
        public string header { get; set; }
        public string href { get; set; }
    }

    public class Standings1
    {
        public Entry[] entries { get; set; }
    }

    public class Entry
    {
        public string team { get; set; }
        public string link { get; set; }
        public string id { get; set; }
        public string uid { get; set; }
        public Stat2[] stats { get; set; }
        public Logo2[] logo { get; set; }
    }

    public class Stat2
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string description { get; set; }
        public string abbreviation { get; set; }
        public string type { get; set; }
        public float value { get; set; }
        public string displayValue { get; set; }
    }

    public class Logo2
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string alt { get; set; }
        public string[] rel { get; set; }
        public string lastUpdated { get; set; }
    }

    public class Seasonsery
    {
        public string type { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string summary { get; set; }
        public bool completed { get; set; }
        public int totalCompetitions { get; set; }
        public Event1[] events { get; set; }
    }

    public class Event1
    {
        public string id { get; set; }
        public string uid { get; set; }
        public DateTime date { get; set; }
        public bool timeValid { get; set; }
        public string status { get; set; }
        public Statustype statusType { get; set; }
        public Competitor2[] competitors { get; set; }
        public Link8[] links { get; set; }
        public Broadcast1[] broadcasts { get; set; }
    }

    public class Statustype
    {
        public string id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public bool completed { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public string shortDetail { get; set; }
    }

    public class Competitor2
    {
        public string homeAway { get; set; }
        public bool winner { get; set; }
        public Team9 team { get; set; }
        public string score { get; set; }
    }

    public class Team9
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
        public Link7[] links { get; set; }
        public string logo { get; set; }
        public Logo3[] logos { get; set; }
    }

    public class Link7
    {
        public string href { get; set; }
        public string text { get; set; }
    }

    public class Logo3
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string alt { get; set; }
        public string[] rel { get; set; }
        public string lastUpdated { get; set; }
    }

    public class Link8
    {
        public string language { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
    }

    public class Broadcast1
    {
        public Type2 type { get; set; }
        public Market1 market { get; set; }
        public Media1 media { get; set; }
        public string lang { get; set; }
        public string region { get; set; }
    }

    public class Type2
    {
        public string id { get; set; }
        public string shortName { get; set; }
    }

    public class Market1
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Media1
    {
        public string shortName { get; set; }
    }

    public class Broadcast2
    {
        public Type3 type { get; set; }
        public Market2 market { get; set; }
        public Media2 media { get; set; }
        public string lang { get; set; }
        public string region { get; set; }
    }

    public class Type3
    {
        public string id { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public string slug { get; set; }
    }

    public class Market2
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Media2
    {
        public string callLetters { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
    }

    public class Pickcenter
    {
        public Provider provider { get; set; }
        public string details { get; set; }
        public float overUnder { get; set; }
        public float spread { get; set; }
        public Awayteamodds awayTeamOdds { get; set; }
        public Hometeamodds homeTeamOdds { get; set; }
        public object[] links { get; set; }
    }

    public class Provider
    {
        public string id { get; set; }
        public string name { get; set; }
        public int priority { get; set; }
    }

    public class Awayteamodds
    {
        public bool favorite { get; set; }
        public bool underdog { get; set; }
        public int moneyLine { get; set; }
        public string teamId { get; set; }
        public double winPercentage { get; set; }
        public double spreadOdds { get; set; }
        public float averageScore { get; set; }
        public Spreadrecord spreadRecord { get; set; }
        public Spreadrecordasfavorite spreadRecordAsFavorite { get; set; }
    }

    public class Spreadrecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int pushes { get; set; }
        public string summary { get; set; }
    }

    public class Spreadrecordasfavorite
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int pushes { get; set; }
        public string summary { get; set; }
    }

    public class Hometeamodds
    {
        public bool favorite { get; set; }
        public bool underdog { get; set; }
        public int moneyLine { get; set; }
        public string teamId { get; set; }
        public double winPercentage { get; set; }
        public double spreadOdds { get; set; }
        public float averageScore { get; set; }
        public Spreadrecord1 spreadRecord { get; set; }
        public Spreadrecordasunderdog spreadRecordAsUnderdog { get; set; }
    }

    public class Spreadrecord1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int pushes { get; set; }
        public string summary { get; set; }
    }

    public class Spreadrecordasunderdog
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int pushes { get; set; }
        public string summary { get; set; }
    }

    public class Againstthespread
    {
        public Team10 team { get; set; }
        public object[] records { get; set; }
    }

    public class Team10
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
        public Link9[] links { get; set; }
        public string logo { get; set; }
        public Logo4[] logos { get; set; }
    }

    public class Link9
    {
        public string href { get; set; }
        public string text { get; set; }
    }

    public class Logo4
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string alt { get; set; }
        public string[] rel { get; set; }
        public string lastUpdated { get; set; }
    }

    public class Roster
    {
        public string homeAway { get; set; }
        public bool winner { get; set; }
        public Team11 team { get; set; }
        public Roster1[] roster { get; set; }
    }

    public class Team11
    {
        public string id { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string color { get; set; }
        public string alternateColor { get; set; }
        public Logo5[] logos { get; set; }
    }

    public class Logo5
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string alt { get; set; }
        public string[] rel { get; set; }
        public string lastUpdated { get; set; }
    }

    public class Roster1
    {
        public bool active { get; set; }
        public bool starter { get; set; }
        public Athlete6 athlete { get; set; }
        public Position7 position { get; set; }
        public Position8[] positions { get; set; }
        public int batOrder { get; set; }
        public bool subbedIn { get; set; }
        public bool subbedOut { get; set; }
        public Media3 media { get; set; }
        public Stat3[] stats { get; set; }
        public string jersey { get; set; }
        public Note1[] notes { get; set; }
    }

    public class Athlete6
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string guid { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public Link10[] links { get; set; }
        public Headshot3 headshot { get; set; }
        public Position6[] positions { get; set; }
        public Hotzone1[] hotZones { get; set; }
        public Bats bats { get; set; }
        public Throws1 throws { get; set; }
    }

    public class Headshot3
    {
        public string href { get; set; }
        public string alt { get; set; }
    }

    public class Bats
    {
        public string type { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
    }

    public class Throws1
    {
        public string type { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
    }

    public class Link10
    {
        public string language { get; set; }
        public string[] rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
    }

    public class Position6
    {
        public string _ref { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
        public bool leaf { get; set; }
        public Parent1 parent { get; set; }
        public Statistics2 statistics { get; set; }
    }

    public class Parent1
    {
        public string _ref { get; set; }
    }

    public class Statistics2
    {
        public string _ref { get; set; }
    }

    public class Hotzone1
    {
        public int configurationId { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public int splitTypeId { get; set; }
        public int season { get; set; }
        public int seasonType { get; set; }
        public Zone1[] zones { get; set; }
    }

    public class Zone1
    {
        public int zoneId { get; set; }
        public double xMin { get; set; }
        public double xMax { get; set; }
        public double yMin { get; set; }
        public double yMax { get; set; }
        public int atBats { get; set; }
        public int hits { get; set; }
        public float battingAvg { get; set; }
        public float battingAvgScore { get; set; }
        public float slugging { get; set; }
        public float sluggingScore { get; set; }
    }

    public class Position7
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
    }

    public class Media3
    {
    }

    public class Position8
    {
        public string id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string abbreviation { get; set; }
    }

    public class Stat3
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string description { get; set; }
        public string abbreviation { get; set; }
        public float value { get; set; }
        public string displayValue { get; set; }
    }

    public class Note1
    {
        public string type { get; set; }
        public string text { get; set; }
        public string annotationKey { get; set; }
    }

    public class Winprobability
    {
        public float tiePercentage { get; set; }
        public float homeWinPercentage { get; set; }
        public string playId { get; set; }
    }

    public class Video1
    {
        public string source { get; set; }
        public int id { get; set; }
        public string headline { get; set; }
        public string description { get; set; }
        public Ad1 ad { get; set; }
        public Tracking1 tracking { get; set; }
        public string cerebroId { get; set; }
        public DateTime lastModified { get; set; }
        public DateTime originalPublishDate { get; set; }
        public Timerestrictions1 timeRestrictions { get; set; }
        public Devicerestrictions1 deviceRestrictions { get; set; }
        public Georestrictions1 geoRestrictions { get; set; }
        public int duration { get; set; }
        public string thumbnail { get; set; }
        public Links11 links { get; set; }
    }

    public class Ad1
    {
        public string sport { get; set; }
        public string bundle { get; set; }
    }

    public class Tracking1
    {
        public string sportName { get; set; }
        public string leagueName { get; set; }
        public string coverageType { get; set; }
        public string trackingName { get; set; }
        public string trackingId { get; set; }
    }

    public class Timerestrictions1
    {
        public DateTime embargoDate { get; set; }
        public DateTime expirationDate { get; set; }
    }

    public class Devicerestrictions1
    {
        public string type { get; set; }
        public string[] devices { get; set; }
    }

    public class Georestrictions1
    {
        public string type { get; set; }
        public string[] countries { get; set; }
    }

    public class Links11
    {
        public Api11 api { get; set; }
        public Web11 web { get; set; }
        public Source2 source { get; set; }
        public Mobile11 mobile { get; set; }
    }

    public class Api11
    {
        public Self3 self { get; set; }
        public Artwork1 artwork { get; set; }
    }

    public class Self3
    {
        public string href { get; set; }
    }

    public class Artwork1
    {
        public string href { get; set; }
    }

    public class Web11
    {
        public string href { get; set; }
        public Short3 _short { get; set; }
        public Self4 self { get; set; }
    }

    public class Short3
    {
        public string href { get; set; }
    }

    public class Self4
    {
        public string href { get; set; }
    }

    public class Source2
    {
        public Mezzanine1 mezzanine { get; set; }
        public Flash1 flash { get; set; }
        public Hds1 hds { get; set; }
        public HLS1 HLS { get; set; }
        public HD3 HD { get; set; }
        public Full2 full { get; set; }
        public string href { get; set; }
    }

    public class Mezzanine1
    {
        public string href { get; set; }
    }

    public class Flash1
    {
        public string href { get; set; }
    }

    public class Hds1
    {
        public string href { get; set; }
    }

    public class HLS1
    {
        public string href { get; set; }
        public HD2 HD { get; set; }
    }

    public class HD2
    {
        public string href { get; set; }
    }

    public class HD3
    {
        public string href { get; set; }
    }

    public class Full2
    {
        public string href { get; set; }
    }

    public class Mobile11
    {
        public Alert1 alert { get; set; }
        public Source3 source { get; set; }
        public string href { get; set; }
        public Streaming1 streaming { get; set; }
        public Progressivedownload1 progressiveDownload { get; set; }
    }

    public class Alert1
    {
        public string href { get; set; }
    }

    public class Source3
    {
        public string href { get; set; }
    }

    public class Streaming1
    {
        public string href { get; set; }
    }

    public class Progressivedownload1
    {
        public string href { get; set; }
    }

    public class Play
    {
        public string id { get; set; }
        public string sequenceNumber { get; set; }
        public Type4 type { get; set; }
        public string text { get; set; }
        public int awayScore { get; set; }
        public int homeScore { get; set; }
        public Period period { get; set; }
        public bool scoringPlay { get; set; }
        public int scoreValue { get; set; }
        public Team12 team { get; set; }
        public DateTime wallclock { get; set; }
        public string atBatId { get; set; }
        public string summaryType { get; set; }
        public Pitchcount pitchCount { get; set; }
        public Resultcount resultCount { get; set; }
        public int outs { get; set; }
        public Participant[] participants { get; set; }
        public int batOrder { get; set; }
        public Bats1 bats { get; set; }
        public int atBatPitchNumber { get; set; }
        public Pitchcoordinate pitchCoordinate { get; set; }
        public Pitchtype pitchType { get; set; }
        public int pitchVelocity { get; set; }
        public string trajectory { get; set; }
        public Hitcoordinate hitCoordinate { get; set; }
        public Alternativetype alternativeType { get; set; }
        public string alternativePlay { get; set; }
        public Onfirst onFirst { get; set; }
        public Onsecond onSecond { get; set; }
        public Onthird onThird { get; set; }
    }

    public class Type4
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public string alternativeText { get; set; }
        public string abbreviation { get; set; }
    }

    public class Period
    {
        public string type { get; set; }
        public int number { get; set; }
        public string displayValue { get; set; }
    }

    public class Team12
    {
        public string id { get; set; }
    }

    public class Pitchcount
    {
        public int balls { get; set; }
        public int strikes { get; set; }
    }

    public class Resultcount
    {
        public int balls { get; set; }
        public int strikes { get; set; }
    }

    public class Bats1
    {
        public string type { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
    }

    public class Pitchcoordinate
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Pitchtype
    {
        public string id { get; set; }
        public string text { get; set; }
        public string abbreviation { get; set; }
    }

    public class Hitcoordinate
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Alternativetype
    {
        public string id { get; set; }
        public string text { get; set; }
        public string abbreviation { get; set; }
        public string alternativeText { get; set; }
        public string type { get; set; }
    }

    public class Onfirst
    {
        public Athlete7 athlete { get; set; }
    }

    public class Athlete7
    {
        public string id { get; set; }
    }

    public class Onsecond
    {
        public Athlete8 athlete { get; set; }
    }

    public class Athlete8
    {
        public string id { get; set; }
    }

    public class Onthird
    {
        public Athlete9 athlete { get; set; }
    }

    public class Athlete9
    {
        public string id { get; set; }
    }

    public class Participant
    {
        public Athlete10 athlete { get; set; }
        public string type { get; set; }
    }

    public class Athlete10
    {
        public string id { get; set; }
    }

}
