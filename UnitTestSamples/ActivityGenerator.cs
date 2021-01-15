using Newtonsoft.Json.Linq;

namespace UnitTestSamples
{
    public class ActivityGenerator
    {
        private readonly IApiClient _apiClient;

        public ActivityGenerator(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public string GetActivity()
        {
            var uri = "https://www.boredapi.com/api/activity";
            var response = _apiClient.GetAsync(uri).Result;
            var responseJson = response?.Content?.ReadAsStringAsync().Result;
            if (!string.IsNullOrEmpty(responseJson))
            {
                dynamic jObj = JObject.Parse(responseJson);
                var activity = jObj.activity?.ToString();
                return activity;
            }

            return null;
        }
    }
}
