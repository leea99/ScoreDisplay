using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Models
{
    public static class Statics
    {
        private static Dictionary<string, Dictionary<string, bool>> logoMappings =
         new Dictionary<string, Dictionary<string, bool>>();
        public enum StandingLevels : short
        {
            Overall = 1,
            Conference = 2,
            Division = 3
        }

        public enum NCAAGroupID : short
        {
            Top25 = 0,
            ACC = 1,
            Big12 = 4,
            Big10 = 5,
            SEC = 8,
            Pac12 = 9,
            CUSA = 12,
            MAC = 15,
            MWC = 17,
            FBSInd = 18,
            BigSky = 20,
            MVFC = 21,
            Ivy = 22,
            MEAC = 24,
            NEC = 25,
            Patriot = 27,
            Pioneer = 28,
            Southern = 29,
            Southland = 30,
            SWAC = 31,
            FCSInd = 32,
            Div2and3 = 35,
            SunBelt = 37,
            CAA = 48,
            FCS = 81,
            American = 151,
            UAC = 177,
            BigSouthOVC = 179,
        }

        public static void ReadLogoMappings()
        {
            try
            {
                string? filePath = ConfigurationManager.AppSettings["LogoMappingsPath"];
                if (filePath != null)
                {
                    var json = File.ReadAllText(filePath);
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(json);
                    if (dict != null)
                    {
                        logoMappings = dict;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static string? GetDarkTeamLogo(string league, string abbreviation, string hexColor)
        {
            string? logo = ConfigurationManager.AppSettings["TeamLogoURL"];
            if (logo != null)
            {
                logo = logo.Replace("LEAGUE", league);
                logo = logo.Replace("ABBREVIATION", abbreviation);
                var isForcedDark = CheckLogoMappings(league, abbreviation);
                if (isForcedDark == null)
                {
                    if (ColorCloserToWhite(hexColor))
                    {
                        logo = logo.Replace("-dark", "");
                    }
                }
                else
                {
                    if (!isForcedDark.Value)
                    {
                        logo = logo.Replace("-dark", "");
                    }
                }
            }
            return logo;
        }

        private static bool? CheckLogoMappings(string league, string abbreviation)
        {
            if (logoMappings.ContainsKey(league))
            {
                var leagueMappings = logoMappings[league];
                if (leagueMappings.ContainsKey(abbreviation))
                {
                    return leagueMappings[abbreviation];
                }
            }
            return null;
        }

        private static bool ColorCloserToWhite(string hexColor)
        {
            int r = Convert.ToInt32(hexColor.Substring(0, 2), 16);
            int g = Convert.ToInt32(hexColor.Substring(2, 2), 16);
            int b = Convert.ToInt32(hexColor.Substring(4, 2), 16);

            // Calculate relative luminance
            double relativeLuminance = 0.2126 * r / 255.0 + 0.7152 * g / 255.0 + 0.0722 * b / 255.0;

            // Compare to threshold and determine closer color
            if (relativeLuminance > 0.20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
