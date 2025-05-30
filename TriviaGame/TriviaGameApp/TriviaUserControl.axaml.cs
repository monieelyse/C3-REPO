using Avalonia;
using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net;

namespace TriviaGameApp
{

    public partial class TriviaUserControl : UserControl
    {
        private Question _currentQuestion;
        public event EventHandler<AnswerSelectedEventArgs>? AnswerSelected;
        private System.Timers.Timer _timer;
        private int _timeLeft = 30;

        //Parameterless Constructor
        public TriviaUserControl()
        {
            InitializeComponent();
        }

        public TriviaUserControl(Question question, int questionNumber, int totalQuestions, int score)
        {
            InitializeComponent();
            _currentQuestion = question;

            //display question number and score
            QuestionNumberTextBlock.Text = $"Quesiton {questionNumber} of {totalQuestions}";
            ScoreTextBlock.Text = $"Score: {score}";

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

            // Update the UI on the main thread
            Dispatcher.UIThread.Post(() =>
            {
                TimerTextBlock.Text = $"{_timeLeft}";

                if (_timeLeft <= 0)
                {
                    _timer.Stop();

                    // Trigger the AnswerSelected event to notify the parent control
                    AnswerSelected?.Invoke(this, new AnswerSelectedEventArgs(false));
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
            QuestionTextBlock.Text = WebUtility.HtmlDecode(_currentQuestion.question);

            //combing correct and incorrect answers, then shuffle
            var answers = new List<string>(_currentQuestion.incorrect_answers)
        {
            _currentQuestion.correct_answer
        };
            answers = answers.OrderBy(_ => Guid.NewGuid()).ToList();

            AnswerButton1.Content = WebUtility.HtmlDecode(answers[0]);
            AnswerButton2.Content = WebUtility.HtmlDecode(answers[1]);
            AnswerButton3.Content = WebUtility.HtmlDecode(answers[2]);
            AnswerButton4.Content = WebUtility.HtmlDecode(answers[3]);
        }

        private void OnAnswerClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var selectedAnswer = button?.Content!.ToString();
                bool isCorrect = selectedAnswer == _currentQuestion.correct_answer;
                Console.WriteLine($"Selected Answer: {selectedAnswer}");

                //trigger event to notify parent control
                AnswerSelected?.Invoke(this, new AnswerSelectedEventArgs(isCorrect));
            }
        }
    }

    public class AnswerSelectedEventArgs : EventArgs
    {
        public bool IsCorrect { get; }
        public AnswerSelectedEventArgs(bool isCorrect)
        {
            IsCorrect = isCorrect;
        }
    }
}