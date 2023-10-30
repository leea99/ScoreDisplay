using Avalonia.Controls;
using AvaloniaScoreDisplay.ViewModels;
using AvaloniaScoreDisplay.Views.Standings.Hockey;
using System.Threading.Tasks;
using System;

namespace AvaloniaScoreDisplay.Views.Standings.Basketball
{
    public partial class BasketballStandings : UserControl
    {
        public BasketballStandings()
        {
            InitializeComponent();
        }

        public async Task<BasketballStandings> GetBasketballStandings(ConfStandingsViewModel division, int startIndex)
        {
            try
            {
                DivStandings.Text = division.Name;
                for (int i = 0; i < division.Entries.Count; i++)
                {
                    var content = await new BasketballTeamEntry().SetTeamEntry(division.Entries[i], startIndex++);
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
