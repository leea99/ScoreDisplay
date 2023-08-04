using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaScoreDisplay.Models.Standings;
using System.IO;
using System.Threading.Tasks;
using System;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.ViewModels;

namespace AvaloniaScoreDisplay.Views.Standings.Soccer
{
    public partial class SoccerStandings : UserControl
    {
        public SoccerStandings()
        {
            InitializeComponent();
        }

        public async Task<SoccerStandings> GetSoccerStandings(SoccerStandingsViewModel standings, int startIndex)
        {
            try
            {
                ConfStandings.Text = standings.Name;
                if (standings != null && standings.Entries != null)
                {
                    for (int i = 0; i < standings.Entries.Count; i++)
                    {
                        var content = await new SoccerTeamEntry().SetTeamEntry(standings.Entries[i], startIndex++);
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
