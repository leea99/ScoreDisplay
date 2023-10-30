using Avalonia.Controls;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models.ConfStandings;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views.Standings.Soccer
{
    public partial class SoccerTeamEntry : UserControl
    {
        public SoccerTeamEntry()
        {
            InitializeComponent();
        }

        public async Task<SoccerTeamEntry> SetTeamEntry(Entry team, int startIndex)
        {
            if (team.team.logos != null)
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
            }
            Position.Text = startIndex.ToString();
            Record.Text = team.stats.FirstOrDefault(x => x.abbreviation == "Total")?.displayValue ?? "";
            GoalFor.Text = team.stats.FirstOrDefault(x => x.abbreviation == "F")?.displayValue ?? "0";
            GoalAgainst.Text = team.stats.FirstOrDefault(x => x.abbreviation == "A")?.displayValue ?? "0";
            Points.Text = team.stats.FirstOrDefault(x => x.abbreviation == "P")?.displayValue ?? "0";
            return this;
        }
    }
}
