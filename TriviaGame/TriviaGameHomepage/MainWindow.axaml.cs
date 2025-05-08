using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TriviaNight;

public partial class MainWindow : Window
{
    private readonly Random _random = new();
    private int _clickCount = 0;

    public MainWindow()
    {
        InitializeComponent();
        StartButton.Click += StartButton_Click;
    }

    private void StartButton_Click(object? sender, RoutedEventArgs e)
    {
        _clickCount++;

        if (_clickCount < 3)
        {
            // Move the button to a random position
            double maxLeft = this.ClientSize.Width - StartButton.Width;
            double maxTop = this.ClientSize.Height - StartButton.Height;

            Canvas.SetLeft(StartButton, _random.NextDouble() * maxLeft);
            Canvas.SetTop(StartButton, _random.NextDouble() * maxTop);
        }
        else
        {
            Console.WriteLine("3 clicks reached — clearing content.");
            this.Content = null; // Clears the window
        }
    }
}
