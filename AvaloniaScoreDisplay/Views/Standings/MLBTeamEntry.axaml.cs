using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaScoreDisplay.Models;
using System.Linq;

namespace AvaloniaScoreDisplay.Views.Standings
{
    public partial class MLBTeamEntry : UserControl
    {
        public MLBTeamEntry()
        {
            InitializeComponent();
        }

        public MLBTeamEntry SetTeamEntry(Entry team)
        {
            TeamName.Text = team.team.name;
            Wins.Text = team.stats.FirstOrDefault(x => x.abbreviation == "W")?.displayValue ?? "0";
            Loses.Text = team.stats.FirstOrDefault(x => x.abbreviation == "L")?.displayValue ?? "0";
            GB.Text = team.stats.FirstOrDefault(x => x.abbreviation == "GB")?.displayValue ?? "0";
            Pct.Text = team.stats.FirstOrDefault(x => x.abbreviation == "POFF")?.displayValue ?? "0";
            return this;
        }
    }
}
