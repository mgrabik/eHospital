namespace App_Doctor.Logic.Model.Service
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using App_Doctor.Logic.Utilities;
    using App_Doctor.Logic.Model.Data;
    using System.Text;
    using System.Threading.Tasks;

    public class NetworkClient : INetwork
    {
        private readonly ServiceClient serviceClient;

        public NetworkClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public Visit[] GetVisits(string nameAndSurname)
        {
            if (nameAndSurname == "")
            {
                Visit[] visits = new Visit[0] { };
                return visits;
            }
            else
            {
                string callUri = String.Format("ConnectDoctor?name={0}", nameAndSurname);
                Visit[] visits = this.serviceClient.CallWebService<Visit[]>(HttpMethod.Get, callUri);
                return visits;
            }
        }
        public void PostVisits(Visit visitsToPost)
        {
            string callUri = "ConnectDoctor/AddVisits";

            var payload = "[{\"id\": \"" + visitsToPost.Id + "\", \"doctor\": { \"name\": \"" + visitsToPost.Doctor.Name
                + "\",\"surname\": \"" + visitsToPost.Doctor.Surname + "\"},\"patient\": { \"pesel\": \"" + visitsToPost.Patient.PESEL
                + "\",\"name\":\"" + visitsToPost.Patient.Name + "\",\"surname\":\"" + visitsToPost.Patient.Surname
                + "\"},\"date\": \"" + visitsToPost.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "\"}]";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");


            var taskPost = Task.Run(() => this.serviceClient.SendPost(callUri, content));
            taskPost.Wait();

            Console.WriteLine(taskPost.Result);
        }
    }
}
