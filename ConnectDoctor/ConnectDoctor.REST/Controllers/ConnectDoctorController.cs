namespace ConnectDoctor.REST.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using ConnectDoctor.Model.Model;
    using ConnectDoctor.Model.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text;
    using ConnectDoctor.Logic.DataServicesClient;

    [ApiController]
    [Route("[controller]")]
    public class ConnectDoctorController : ControllerBase, IConnectDoctorHandler
    {
        private readonly IConnectDoctorHandler connectDoctorHandler;


        public ConnectDoctorController(IConnectDoctorHandler connectDoctorHandler)
        {
            this.connectDoctorHandler = connectDoctorHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<Visit>> GetVisitsByName(string name)
        {
            return await connectDoctorHandler.GetVisitsByName(name);
        }
        [HttpPost]
        [Route("AddVisits")]
        public void AddVisits(Visit[] addedList)
        {
            var payload = "[";
            foreach (Visit visit in addedList)
            {
                if (visit.Doctor.Name == null || visit.Doctor.Surname == null || visit.Patient.Name == null || visit.Patient.Surname == null ||
                    visit.Patient.PESEL == null || visit.Date.Year == 1)
                {
                    throw new Exception("No values can be null. Check your input data");
                }
                payload = payload + "{\"id\": \"" + visit.Id + "\", \"doctor\": { \"name\": \"" + visit.Doctor.Name
                + "\",\"surname\": \"" + visit.Doctor.Surname + "\"},\"patient\": { \"pesel\": \"" + visit.Patient.PESEL
                + "\",\"name\":\"" + visit.Patient.Name + "\",\"surname\":\"" + visit.Patient.Surname
                + "\"},\"date\": \"" + visit.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "\"},";

            }
            payload = payload.Remove(payload.Length - 1);

            payload = payload + "]";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var taskPost = Task.Run(() => VisitServiceClient.SendPost(content));
            taskPost.Wait();

            Console.WriteLine(taskPost.Result);
            
            
        }
    }
}
