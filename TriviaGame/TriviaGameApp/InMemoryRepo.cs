using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGameApp
{
    public class InMemoryRepo
    {
      
        private List<User> _users = new();

        public void Add(User user)
        { 
            _users.Add(user);
        }


        public List<User> Get()
        { 

            return _users;
        }

        
      

        
    }
}
