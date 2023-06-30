using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using AvaloniaScoreDisplay.Models;
using AvaloniaScoreDisplay.Models.BaseballGame;
using System;
using System.IO;

namespace AvaloniaScoreDisplay.Views.Standings
{
    public partial class MLBStandings : UserControl
    {
        public MLBStandings()
        {
            InitializeComponent();
            var path = Directory.GetCurrentDirectory();
            path = System.IO.Path.Combine(path, "Images", "background.png");
            var bitmap = new Bitmap(path);
            Background = new ImageBrush(bitmap)
            {
                Stretch = Stretch.Fill
            };
        }

        public MLBStandings GetMLBStandings(Child1 division)
        {
            try
            {
                DivStandings.Text = division.shortName;
                for (int i = 0; i < division.standings.entries.Length; i++)
                {
                    var content = new MLBTeamEntry().SetTeamEntry(division.standings.entries[i]);
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
