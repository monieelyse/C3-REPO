using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGameApp
{
 
    public interface IRepo
        {
            void Add(User user);
           
            List<User> Get();
          
        }
    
}

