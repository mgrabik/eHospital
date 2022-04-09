namespace ConnectPatient.REST.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ConnectPatient.Model.Model;
    using ConnectPatient.Model.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using System.Net.Http;
    using System.Text;
    using ConnectPatient.Logic.DataServicesClient;

    [ApiController]
    [Route("[controller]")]
    public class ConnectPatientController : ControllerBase, IConnectPatientHandler
    {
        private readonly IConnectPatientHandler connectPatientHandler;


        public ConnectPatientController(IConnectPatientHandler connectPatientHandler)
        {
            this.connectPatientHandler = connectPatientHandler;
        }

        [HttpGet("Get-Prescription-By-PESEL")]
        public async Task<IEnumerable<Prescription>> GetPrescriptionsByPESEL(string searchText)
        {
            return await connectPatientHandler.GetPrescriptionsByPESEL(searchText);
        }
        [HttpPost]
        [Route("AddPrescriptions")]
        public void AddPrescriptions(Prescription[] addedList)
        {
            var payload = "[";
            foreach (Prescription prescription in addedList)
            {
                if (prescription.Doctor.Name == null || prescription.Doctor.Surname == null || prescription.Patient.Name == null || prescription.Patient.Surname == null ||
                    prescription.Patient.PESEL == null || prescription.Date.Year == 1)
                {
                    throw new Exception("No values can be null. Check your input data");
                }
                payload = payload + "{\"id\": \"" + prescription.Id + "\", \"doctor\": { \"name\": \"" + prescription.Doctor.Name
                + "\",\"surname\": \"" + prescription.Doctor.Surname + "\"},\"patient\": { \"pesel\": \"" + prescription.Patient.PESEL
                + "\",\"name\":\"" + prescription.Patient.Name + "\",\"surname\":\"" + prescription.Patient.Surname
                + "\"}, \"medicine\": { \"name\": \""+prescription.Medicine.Name+ "\",\"amount\": "+prescription.Medicine.Amount+
                " }, \"date\": \"" + prescription.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "\"},";

            }
            payload = payload.Remove(payload.Length - 1);

            payload = payload + "]";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var taskPost = Task.Run(() => PrescriptionServiceClient.SendPost(content));
            taskPost.Wait();

            Console.WriteLine(taskPost.Result);


        }
    }
}
