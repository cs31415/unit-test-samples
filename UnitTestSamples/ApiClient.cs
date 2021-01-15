using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTestSamples
{
    public class ApiClient : IApiClient
    {
        readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _httpClient.GetAsync(url);
        }
    }
}