namespace ConnectDoctor.Tests.Data
{
    using ConnectDoctor.Model.Model;
    using System.Collections.Generic;


    public class FakeVisit
    {
        public IEnumerable<Visit> BigData()
        {
            List<Visit> visits = new List<Visit>();

            for (int i = 0; i < 1000; i++)
            {
                if (i % 2 == 0)
                {
                    visits.Add(new Visit(i.ToString(), new Doctor("DoctorName", "DoctorSurname"), new Patient("PatientName", "PatientSurname", "12345678901"),
                        new System.DateTime(2000, 10, 10, 14, 30, 00)));
                }
                else
                {
                    visits.Add(new Visit(i.ToString(), new Doctor("DoctorName2", "DoctorSurname2"), new Patient("PatientName2", "PatientSurname2", "88888888888"),
                        new System.DateTime(2012, 11, 11, 12, 20, 00)));
                }
            }

            return visits;
        }

        public IEnumerable<Visit> GetEmptyVisits()
        {
            return new List<Visit>() { };
        }

        public IEnumerable<Visit> GetFewVisits()
        {
            return new List<Visit>() {new Visit("1", new Doctor("DoctorName", "DoctorSurname"), new Patient("PatientName", "PatientSurname", "12345678901"),
                        new System.DateTime(2000, 10, 10, 14, 30, 00)),
            new Visit("2", new Doctor("DoctorName2", "DoctorSurname2"), new Patient("PatientName2", "PatientSurname2", "88888888888"),
                        new System.DateTime(2000, 10, 10, 14, 30, 00))};
        }
    }
}
