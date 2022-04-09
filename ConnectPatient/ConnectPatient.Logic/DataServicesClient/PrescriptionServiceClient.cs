namespace ConnectPatient.Logic.DataServicesClient
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Net.Http;
    using ConnectPatient.Model.Model;
    using System;

    public class PrescriptionServiceClient : IPrescriptionServiceClient
    {
        public IHttpClientFactory ClientFactory;

        public PrescriptionServiceClient(IHttpClientFactory clientFactory)
        {
            this.ClientFactory = clientFactory;
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptions()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://prescriptionrest/Prescription/GetPrescptions");

            request.Headers.Add("Accept", "application/json");

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };


            return await JsonSerializer.DeserializeAsync<IEnumerable<Prescription>>(responseStream, options);
        }
        static public async Task<string> SendPost(HttpContent content)
        {
            string serviceHost = "prescriptionrest";
            string callUri = "Prescription/AddPrescriptions";
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                Uri httpUri = new Uri(String.Format("http://{0}/{2}", serviceHost, callUri));
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
