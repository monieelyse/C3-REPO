using System;
using Avalonia.Controls;

namespace TriviaNight;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        StartButton.Click += StartButton_Click;
    }

    private void StartButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Console.WriteLine("Start Game button clicked!");
        this.Content = null;
    }
}
