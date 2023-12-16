using Avalonia.Controls;
using AvaloniaScoreDisplay.Models.Standings;
using System.Threading.Tasks;
using System;
using AvaloniaScoreDisplay.ViewModels;

namespace AvaloniaScoreDisplay.Views.Standings.Hockey
{
    public partial class HockeyStandings : UserControl
    {
        public HockeyStandings()
        {
            InitializeComponent();
        }

        public async Task<HockeyStandings> GetHockeyStandings(StandingsViewModel division, int startIndex)
        {
            try
            {
                DivStandings.Text = division.Name;
                for (int i = 0; i < division.Entries.Count; i++)
                {
                    var content = await new HockeyTeamEntry().SetTeamEntry(division.Entries[i], startIndex++);
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
