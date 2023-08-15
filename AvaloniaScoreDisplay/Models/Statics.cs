using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Models
{
    public static class Statics
    {
        public enum StandingLevels : short
        {
            Overall = 1,
            Conference = 2,
            Division = 3
        }

        public static string? GetDarkTeamLogo(string league, string abbreviation, string hexColor)
        {
            string? logo = ConfigurationManager.AppSettings["TeamLogoURL"];
            if (logo != null)
            {
                logo = logo.Replace("LEAGUE", league);
                logo = logo.Replace("ABBREVIATION", abbreviation);
                if (ColorCloserToWhite(hexColor))
                {
                    logo = logo.Replace("-dark", "");
                }
            }
            return logo;
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
