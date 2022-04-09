namespace App_Doctor.Logic.Utilities
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using System.Net.Http;
    using System.Text.Json;

    public class ServiceClient
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private readonly string serviceHost;
        private readonly ushort servicePort;

        public ServiceClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceHost = serviceHost;
            this.servicePort = (ushort)servicePort;
        }

        public R CallWebService<R>(HttpMethod httpMethod, string webServiceUri)
        {
            Task<string> webServiceCall = this.CallWebService(httpMethod, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            R result = this.ConvertJson<R>(jsonResponseContent);

            return result;
        }

        public async Task<string> CallWebService(HttpMethod httpMethod, string callUri)
        {
            Uri httpUri = new Uri(String.Format("http://{0}:{1}/{2}", this.serviceHost, this.servicePort, callUri));
            //Uri httpUri = new Uri($"http://localhost:42073/ConnectDoctor?name=Mikolaj%20Krul");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = httpUri
            };

            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }
        public async Task<string> SendPost(String callUri, HttpContent content)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                Uri httpUri = new Uri(String.Format("http://{0}:{1}/{2}", this.serviceHost, this.servicePort, callUri));
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = httpUri,
                    Content = content
                };

                HttpResponseMessage result = await client.SendAsync(request);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
            return response;
        }
        private T ConvertJson<T>(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
