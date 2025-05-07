using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using TriviaGameApp;


using HttpClient client = new HttpClient();
string _url = "https://opentdb.com/api.php?amount=10";
string json = await client.GetStringAsync(_url);

var result = JsonSerializer.Deserialize<Result>(json);
var _questionSet = result.results;


foreach (var q in _questionSet)
{
    Console.WriteLine(q.type);
    Console.WriteLine(q.difficulty);
    Console.WriteLine(q.question);
    Console.WriteLine(q.correct_answer);


}