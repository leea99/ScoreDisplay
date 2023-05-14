using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace AvaloniaScoreDisplay.Views
{
    public partial class TodoListView : UserControl
    {
        public TodoListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
