using Avalonia.Controls;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models.Standings;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views.Standings.Hockey
{
    public partial class HockeyTeamEntry : UserControl
    {
        public HockeyTeamEntry()
        {
            InitializeComponent();
        }

        public async Task<HockeyTeamEntry> SetTeamEntry(Entry team, int startIndex)
        {
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.GetAsync(team.team.logos.Last().href))
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var bitmap = new Bitmap(memoryStream);
                TeamLogo.Source = bitmap;
            }
            Position.Text = startIndex.ToString();
            Wins.Text = team.stats.FirstOrDefault(x => x.abbreviation == "W")?.displayValue ?? "0";
            Losses.Text = team.stats.FirstOrDefault(x => x.abbreviation == "L")?.displayValue ?? "0";
            OTL.Text = team.stats.FirstOrDefault(x => x.abbreviation == "OTL")?.displayValue ?? "0";
            Points.Text = team.stats.FirstOrDefault(x => x.displayName == "Points")?.displayValue ?? "0";
            return this;
        }
    }
}
