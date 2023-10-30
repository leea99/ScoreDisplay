using Avalonia.Controls;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models.Standings;
using AvaloniaScoreDisplay.Views.Standings.Hockey;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views.Standings.Basketball
{
    public partial class BasketballTeamEntry : UserControl
    {
        public BasketballTeamEntry()
        {
            InitializeComponent();
        }

        public async Task<BasketballTeamEntry> SetTeamEntry(Models.ConfStandings.Entry team, int startIndex)
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
            GB.Text = team.stats.FirstOrDefault(x => x.abbreviation == "GB")?.displayValue ?? "0";
            return this;
        }
    }
}
