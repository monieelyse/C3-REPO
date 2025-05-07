using Avalonia.Controls;

namespace TriviaGameApp
{
    public MainWindow()
{
    InitializeComponent();
    var startButton = this.FindControl<Button>("StartButton"); // Find the button
    startButton.Click += StartGame; // Attach the click event
}

private void StartGame(object sender, RoutedEventArgs e)
{
    var questionWindow = new QuestionWindow(); // Create next screen
    questionWindow.Show(); // Open the question screen
    this.Close(); // Close current window
}
