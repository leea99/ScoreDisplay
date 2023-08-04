using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Models.Standings;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views.Standings
{
    public partial class MLBTeamEntry : UserControl
    {
        public MLBTeamEntry()
        {
            InitializeComponent();
        }

        public async Task<MLBTeamEntry> SetTeamEntry(Entry team)
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
            //TeamName.Text = team.team.name;
            Wins.Text = team.stats.FirstOrDefault(x => x.abbreviation == "W")?.displayValue ?? "0";
            Loses.Text = team.stats.FirstOrDefault(x => x.abbreviation == "L")?.displayValue ?? "0";
            GB.Text = team.stats.FirstOrDefault(x => x.abbreviation == "GB")?.displayValue ?? "0";
            Pct.Text = team.stats.FirstOrDefault(x => x.abbreviation == "POFF")?.displayValue ?? "0";
            return this;
        }
    }
}
