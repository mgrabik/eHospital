namespace WebApplication.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using App_Doctor.Logic.Model.Data;
    using App_Doctor.Logic.Utilities;

    public class Operations
    {
        private ServiceClient serviceClient = new ServiceClient("localhost", 42073);

        public Visit[] GetVisits(string nameAndSurname)
        {
            string[] splited;
            if (nameAndSurname == "")
            {
                throw new ArgumentNullException();
            }
            else
            {
                splited = nameAndSurname.Split(' ');
                if (splited.Length != 2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    string callUri = String.Format("ConnectDoctor?name={0}", nameAndSurname);
                    Visit[] visits = this.serviceClient.CallWebService<Visit[]>(HttpMethod.Get, callUri);
                    return visits;
                }
            }
        }
        public void PostVisits(Visit visitsToPost)
        {
            if (visitsToPost == null || visitsToPost.Doctor == null || visitsToPost.Patient == null || visitsToPost.Date == new DateTime(0001,01,01,00,00,00))
            {
                throw new ArgumentNullException();
            }
            else
            {
                string callUri = "ConnectDoctor/AddVisits";

                var payload = "[{\"id\": \"" + visitsToPost.Id + "\", \"doctor\": { \"name\": \"" + visitsToPost.Doctor.Name
                    + "\",\"surname\": \"" + visitsToPost.Doctor.Surname + "\"},\"patient\": { \"pesel\": \"" + visitsToPost.Patient.PESEL
                    + "\",\"name\":\"" + visitsToPost.Patient.Name + "\",\"surname\":\"" + visitsToPost.Patient.Surname
                    + "\"},\"date\": \"" + visitsToPost.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "\"}]";

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            }
        }
    }
}
