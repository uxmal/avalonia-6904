using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using EagerEnumeration.ViewModels;

namespace EagerEnumeration
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.DataContext = new MainWindowViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
