using Avalonia.Controls;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaGameApp
{
    public partial class MainWindow : Window
    {
        private int _currentQuestionIndex = 0;
        private Question[] _questions;
        private int _score = 0;

        public MainWindow()
        {
            InitializeComponent();

            //set startwindow as the initial content
            MainContent.Content = new StartWindow(this);
           
            
        }

        public async Task NavigateToTrivia()
        {
            var questionService = new QuestionService();
            _questions = await questionService.FetchQuestionsAsync();
            _currentQuestionIndex = 0;

            if (_questions.Length > 0)
            {
                LoadQuestion(_questions[_currentQuestionIndex]);
            }
            else
            {
                Console.WriteLine("No questions available.");
            }
        }

        private void LoadQuestion(Question question)
        {
            var triviaControl = new TriviaUserControl(question, _currentQuestionIndex +1, _questions.Length,_score);
            triviaControl.AnswerSelected += (s, e) =>
            {
                if (e is AnswerSelectedEventArgs args && args.IsCorrect)
                {
                    _score++;
                }
                _currentQuestionIndex++;
                if (_currentQuestionIndex < _questions.Length)
                {
                    LoadQuestion(_questions[_currentQuestionIndex]);
                }
                else
                {
                    Debug.WriteLine($"Trivia complete, Final Score: {_score}");
                    //TODO: create a game over page that shows final score
                }
            };

            MainContent.Content = triviaControl;
        }

    }

}