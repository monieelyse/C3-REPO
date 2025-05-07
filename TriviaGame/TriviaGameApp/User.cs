using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Platform;

namespace TriviaGameApp
{
    public class User
    {
        public string id { get; set; }
        public int Score { get; set; }

       
    

    public User(string userName, int score)
        {
          id = userName;
            Score = score;
        }
    } 
}
