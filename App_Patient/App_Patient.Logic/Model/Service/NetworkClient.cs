namespace App_Patient.Logic.Model.Service
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using App_Patient.Logic.Utilities;
    using App_Patient.Logic.Model.Data;
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

        public Prescription[] GetPrescriptions(string nameAndSurname)
        {
            if (nameAndSurname == "")
            {
                Prescription[] visits = new Prescription[0] {};
                return visits;
            }
            else
            {
                string callUri = String.Format("ConnectPatient/Get-Prescription-By-PESEL?searchText={0}", nameAndSurname);
                Prescription[] visits = this.serviceClient.CallWebService<Prescription[]>(HttpMethod.Get, callUri);
                return visits;
            }

        }

        public void PostPrescriptions(Prescription prescriptionToPost)
        {
            string callUri = "ConnectPatient/AddPrescriptions";

            var payload = "[{\"id\": \"" + prescriptionToPost.Id + "\", \"doctor\": { \"name\": \"" + prescriptionToPost.Doctor.Name
                + "\",\"surname\": \"" + prescriptionToPost.Doctor.Surname + "\"},\"patient\": { \"pesel\": \"" + prescriptionToPost.Patient.PESEL
                + "\",\"name\":\"" + prescriptionToPost.Patient.Name + "\",\"surname\":\"" + prescriptionToPost.Patient.Surname
                + "\"},\"medicine\": { \"name\": \"" + prescriptionToPost.Medicine.Name + "\",\"amount\": " + prescriptionToPost.Medicine.Amount
                + "},\"date\": \"" + prescriptionToPost.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "\"}]";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");


            var taskPost = Task.Run(() => this.serviceClient.SendPost(callUri, content));
            taskPost.Wait();

            Console.WriteLine(taskPost.Result);
        }
    }
}
