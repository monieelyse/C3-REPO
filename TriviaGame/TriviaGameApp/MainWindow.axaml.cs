using Avalonia.Controls;

namespace TriviaGameApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainContent.Content = new StartWindow(this);
        }

        public void NavigateToTrivia()
        {
            //Navigate to trivia screen
            MainContent.Content = new TriviaUserControl();
        }
    }
}