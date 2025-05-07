using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TriviaGameApp
{

    public partial class StartWindow : UserControl
    {
        private MainWindow? _mainWindow;


        public StartWindow()
        {
            InitializeComponent();
        }

        public StartWindow(MainWindow mainWindow) : this()
        {
            _mainWindow = mainWindow;
        }



        private void OnStartClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _mainWindow?.NavigateToTrivia();
        }
    }

}