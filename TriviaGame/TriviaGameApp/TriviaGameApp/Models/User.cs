namespace TriviaGameApp.Models
{
    public class User
    {
        public string Username { get; set; }
        public List<int> Scores { get; set; } = new List<int>();

        public User(string username)
        {
            Username = username;
        }

        public void AddScore(int score)
        {
            Scores.Add(score);
        }

        public double GetAverageScore()
        {
            return Scores.Count > 0 ? Scores.Average() : 0;
        }
    }
}
