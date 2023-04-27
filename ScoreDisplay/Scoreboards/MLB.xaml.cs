using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScoreDisplay.Scoreboards
{
    /// <summary>
    /// Interaction logic for MLB.xaml
    /// </summary>
    public partial class MLB : Page
    {
        public MLB()
        {
            InitializeComponent();
            var path = Directory.GetCurrentDirectory();
            var testPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\..\"));
            testPath = System.IO.Path.Combine(testPath, "Images", "background.png");
            BitmapImage image = new BitmapImage(new Uri(testPath));
            background.ImageSource = image;
            if (HomeTeam.Width > AwayTeam.Width)
            {
                HomeTeam.Width = AwayTeam.Width;
            }
            else
            {
                AwayTeam.Width = AwayTeam.Width;
            }
        }
    }
}
