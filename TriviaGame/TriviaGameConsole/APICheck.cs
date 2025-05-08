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
    Debug.WriteLine(q.type);
    Debug.WriteLine(q.difficulty);
    Debug.WriteLine(q.question);
    Debug.WriteLine(q.correct_answer);


}