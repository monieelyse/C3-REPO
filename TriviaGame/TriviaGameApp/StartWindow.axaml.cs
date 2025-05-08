using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TriviaGameApp
{

    public partial class StartWindow : UserControl
    {
        private readonly MainWindow _mainWindow;


        //parameterless constructor
        public StartWindow()
        {
            InitializeComponent();
        }


        public StartWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

   

        private async void OnStartClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            await _mainWindow.NavigateToTrivia();
        }
    }

}