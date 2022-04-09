namespace ConnectDoctor.Logic.DataServicesClient
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;
    using ConnectDoctor.Model.Model;
    using System.Net.Http;
    using System;

    public class VisitServiceClient : IVisitServiceClient
    {
        public IHttpClientFactory ClientFactory;

        public VisitServiceClient(IHttpClientFactory clientFactory)
        {
            this.ClientFactory = clientFactory;
        }

        public async Task<IEnumerable<Visit>> GetAllVisits()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://visitrest/Visit/GetVisits");

            request.Headers.Add("Accept", "application/json");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };


            return await JsonSerializer.DeserializeAsync<IEnumerable<Visit>>(responseStream, options);
        }
        static public async Task<string> SendPost(HttpContent content)
        {
            string serviceHost = "visitrest";
            string callUri = "Visit/AddVisits";
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                Uri httpUri = new Uri(String.Format("http://{0}/{1}", serviceHost, callUri));
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

    }
}
