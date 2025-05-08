 public class User
    {
        public string Username { get; set; }
        public List<int> Scores { get; set; } = new List<int>();
        public DateTime LastPlayed { get; set; }

        public User(string username)
        {
            Username = username;
            LastPlayed = DateTime.Now;
        }

        public void AddScore(int score)
        {
            Scores.Add(score);
            LastPlayed = DateTime.Now;
        }

        public double GetAverageScore()
        {
            return Scores.Count > 0 ? Scores.Average() : 0;
        }

        public int GetHighestScore()
        {
            return Scores.Count > 0 ? Scores.Max() : 0;
        }

        public override string ToString()
        {
            return $"User: {Username}, Highest Score: {GetHighestScore()}, Average Score: {GetAverageScore():F2}, Last Played: {LastPlayed}";
        }
    }
}
