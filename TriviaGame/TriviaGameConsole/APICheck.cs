using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using TriviaGameApp;

class Program
{
    public static async Task Main()
    {
        using HttpClient client = new HttpClient();
        string _url = "https://opentdb.com/api.php?amount=10";
        string json = await client.GetStringAsync(_url);

        var result = JsonSerializer.Deserialize<Result>(json);
        var _questionSet = result.results;
        InMemoryRepo datastore = new InMemoryRepo();
        User fred = new User("Fred", 0);
        datastore.Add(fred);
        
        var localList = datastore.Get();
        
        foreach ( var item in localList )
        {
            Console.WriteLine(item.id);
            

        }
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