using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace todo.Services
{
    public static class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string BASE_URL = "http://10.0.2.2/todo_app/"; 

        public static async Task<JsonDocument> SignUp(string firstName, string lastName, string email, string password)
        {
            var payload = new
            {
                first_name = firstName,
                last_name = lastName,
                email = email,
                password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(BASE_URL + "signup.php", content);
            var json = await response.Content.ReadAsStringAsync();
            return JsonDocument.Parse(json);
        }

        public static async Task<JsonDocument> SignIn(string email, string password)
        {
            var payload = new
            {
                email = email,
                password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(BASE_URL + "signin.php", content);
            var json = await response.Content.ReadAsStringAsync();
            return JsonDocument.Parse(json);
        }
    }
}