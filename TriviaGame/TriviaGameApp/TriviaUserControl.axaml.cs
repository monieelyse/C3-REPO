using Avalonia;
using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace TriviaGameApp
{

    public partial class TriviaUserControl : UserControl
    {
        private Question _currentQuestion;
        public event EventHandler? AnswerSelected;
        private System.Timers.Timer _timer;
        private int _timeLeft = 30;

        //Parameterless Constructor
        public TriviaUserControl()
        {
            InitializeComponent();
        }

        public TriviaUserControl(Question question)
        {
            InitializeComponent();
            _currentQuestion = question;
            LoadQuestion();

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

        private void LoadQuestion()
        {
            //Set the question text
            QuestionTextBlock.Text = _currentQuestion.question;

            //combing correct and incorrect answers, then shuffle
            var answers = new List<string>(_currentQuestion.incorrect_answers)
        {
            _currentQuestion.correct_answer
        };
            answers = answers.OrderBy(_ => Guid.NewGuid()).ToList();

            AnswerButton1.Content = answers[0];
            AnswerButton2.Content = answers[1];
            AnswerButton3.Content = answers[2];
            AnswerButton4.Content = answers[3];
        }

        private void OnAnswerClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var selectedAnswer = button?.Content!.ToString();
                Console.WriteLine($"Selected Answer: {selectedAnswer}");
                if (selectedAnswer == _currentQuestion.correct_answer)
                {
                    Debug.WriteLine("Correct!");
                }
                else
                {
                    Debug.WriteLine("Incorrect");
                }

                //trigger event to notify parent control
                AnswerSelected?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}