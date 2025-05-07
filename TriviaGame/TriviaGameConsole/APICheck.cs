using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using TriviaGameApp;
using User = TriviaGameApp.User;

class Program
{
    public static async Task Main()
    {
        CosmosDBRepo datastore = new CosmosDBRepo();
        using HttpClient client = new HttpClient();
        string _url = "https://opentdb.com/api.php?amount=10";
        string json = await client.GetStringAsync(_url);

        var result = JsonSerializer.Deserialize<Result>(json);
        var _questionSet = result.results;
       // InMemoryRepo datastore = new InMemoryRepo();
        User currentUser = new User("Fred", 0);
        datastore.SaveUserAsync(currentUser);

        var localuser = datastore.Get(currentUser);
       Console.WriteLine(localuser.Score);

 
       
        /*  foreach (var q in _questionSet)
          {
              Console.WriteLine(q.type);
              Console.WriteLine(q.difficulty);
              Console.WriteLine(q.question);
              Console.WriteLine(q.correct_answer);


          }


          */

       // Console.WriteLine(datastore.Get());

        
    }
}