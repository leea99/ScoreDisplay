using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Models.BaseballGame;
using AvaloniaScoreDisplay.Models.Standings;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AvaloniaScoreDisplay.Views.Standings
{
    public partial class MLBStandings : UserControl
    {
        public MLBStandings()
        {
            InitializeComponent();
        }

        public async Task<MLBStandings> GetMLBStandings(Child1 division)
        {
            try
            {
                DivStandings.Text = division.shortName;
                for (int i = 0; i < division.standings.entries.Length; i++)
                {
                    var content = await new MLBTeamEntry().SetTeamEntry(division.standings.entries[i]);
                    switch (i)
                    {
                        case 0:
                            FirstTeam.Content = content;
                            break;
                        case 1:
                            SecondTeam.Content = content;
                            break;
                        case 2:
                            ThirdTeam.Content = content;
                            break;
                        case 3:
                            FourthTeam.Content = content;
                            break;
                        case 4:
                            FifthTeam.Content = content;
                            break;
                    }
                }
                return this;
            }
            catch (Exception ex)
            {

            }
            return this;
        }
    }
}
