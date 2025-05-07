using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System.Timers;

namespace TriviaGameApp;

public partial class TriviaUserControl : UserControl
{
    private System.Timers.Timer _timer;
    private int _timeLeft = 30;

    public TriviaUserControl()
    {
        InitializeComponent();
        StartCountdown();
    }


    private void StartCountdown()
    {
        _timer = new Timer(1000);//1-sec interval
        _timer.Elapsed += OnTimerElapsed;
        _timer.Start();
    }

    private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        _timeLeft--;

        //Update the UI on the main thread
        Dispatcher.UIThread.Post(() =>
        {
            TimerTextBlock.Text = $"Time Left: {_timeLeft}";

            if (_timeLeft <= 0)
            {
                _timer.Stop();
                //******************************
                TimerTextBlock.Text = "Times up!";
                // TODO: Implement event to move to the next question
            }
        });
    }

    protected override void OnDetachedFromVisualTree(Avalonia.VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);
        _timer?.Stop();
        _timer?.Dispose();
    }
}