using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTestSamples
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}