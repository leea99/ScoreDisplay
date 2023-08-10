using Avalonia.Controls;
using AvaloniaScoreDisplay.Models.Standings;
using System.Threading.Tasks;
using System;

namespace AvaloniaScoreDisplay.Views.Standings.NFL
{
    public partial class NFLStandings : UserControl
    {
        public NFLStandings()
        {
            InitializeComponent();
        }

        public async Task<NFLStandings> GetNFLStandings(Child1 division)
        {
            try
            {
                DivStandings.Text = division.name;
                for (int i = 0; i < division.standings.entries.Length; i++)
                {
                    var content = await new NFLTeamEntry().SetTeamEntry(division.standings.entries[i]);
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
