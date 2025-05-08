using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TriviaGameApp
{
    public class QuestionService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://opentdb.com/api.php?amount=10&type=multiple";

        public QuestionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Question[]> FetchQuestionsAsync()
        {
            string json = await _httpClient.GetStringAsync(ApiUrl);
            var result = JsonSerializer.Deserialize<Result>(json);
            return result?.results ?? new Question[0];
        }
    }
}
