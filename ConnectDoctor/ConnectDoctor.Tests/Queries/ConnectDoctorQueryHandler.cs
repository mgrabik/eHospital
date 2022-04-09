namespace ConnectDoctor.Tests.Queries
{
    using ConnectDoctor.Logic.DataServicesClient;
    using ConnectDoctor.Logic;
    using ConnectDoctor.Model.Model;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class ConnectDoctorQueryHandler : IConnectDoctorHandler
    {
        public ConnectDoctorQueryHandler()
        {
        }

        public IEnumerable<Visit> GetVisitsByName(string searchText, IEnumerable<Visit> visits)
        {
            if (visits.Count() == 0)
            {
                throw new ArgumentNullException();
            }
            if (searchText == "")
            {
                throw new CustomExceptions("Nie wprowadzono zadnych danych\nPodaj imie oraz nazwisko w poprawnym formacie: [imie] [nazwisko]");
            }

            string[] name_and_surname = searchText.Split(' ');

            if (name_and_surname.Length != 2)
            {
                throw new CustomExceptions("Podaj imie oraz nazwisko w poprawnym formacie: [imie] [nazwisko]");
            }
            else
            {
                var visit_by_name = from pres in visits
                                    where pres.Doctor.Name == name_and_surname[0] && pres.Doctor.Surname == name_and_surname[1]
                                    select pres;

                return visit_by_name;
            }
        }
    }
}
