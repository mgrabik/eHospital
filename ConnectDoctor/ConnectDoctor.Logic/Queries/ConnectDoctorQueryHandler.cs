namespace ConnectDoctor.Logic.Queries
{
    using ConnectDoctor.Model.Services;
    using ConnectDoctor.Logic.DataServicesClient;
    using System.Threading.Tasks;
    using ConnectDoctor.Model.Model;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class ConnectDoctorQueryHandler : IConnectDoctorHandler
    {
        private readonly IVisitServiceClient visitServiceClient;

        public ConnectDoctorQueryHandler(IVisitServiceClient visitServiceClient)
        {
            this.visitServiceClient = visitServiceClient;
        }

        public async Task<IEnumerable<Visit>> GetVisitsByName(string NameAndSurname)
        {
            var visits = visitServiceClient.GetAllVisits();

            List<Visit> list_of_visits = new List<Visit>();

            foreach (var visit in await visits)
            {
                list_of_visits.Add(visit);
            }

            if (list_of_visits.Count() == 0)
            {
                throw new ArgumentNullException();
            }

            if (NameAndSurname == null || NameAndSurname == "")
            {
                throw new CustomExceptions("Nie wprowadzono zadnych danych\nPodaj imie oraz nazwisko w poprawnym formacie: [imie] [nazwisko]");
            }

            string[] name_and_surname = NameAndSurname.Split(' ');

            if (name_and_surname.Length != 2)
            {
                throw new CustomExceptions("Podaj imie oraz nazwisko w poprawnym formacie: [imie] [nazwisko]");
            }
            else
            {
                var visit_by_name = from pres in list_of_visits
                                    where pres.Doctor.Name == name_and_surname[0] && pres.Doctor.Surname == name_and_surname[1]
                                    select pres;

                return visit_by_name;
            }
        }
    }
}
