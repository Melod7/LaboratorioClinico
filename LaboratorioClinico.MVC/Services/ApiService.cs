using System.Net.Http.Headers;
using System.Text.Json;

namespace LaboratorioClinico.MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => true;

            _httpClient = new HttpClient(handler);

            _httpClient.BaseAddress = new Uri("https://localhost:7165/api/");
        }

        public async Task<List<T>> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<T>>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task PostAsync<T>(string endpoint, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data);
            response.EnsureSuccessStatusCode();
        }
    }
}