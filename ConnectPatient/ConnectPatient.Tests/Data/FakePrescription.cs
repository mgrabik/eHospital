namespace ConnectPatient.Tests.Data
{
    using ConnectPatient.Model.Model;
    using System.Collections.Generic;

    public class FakePrescription
    {
        public IEnumerable<Prescription> BigData()
        {
            List<Prescription> prescriptions = new List<Prescription>();

            for(int i = 0; i < 1000; i++)
            {
                if (i%2 == 0) {
                    prescriptions.Add(new Prescription( i.ToString(), new Doctor("DoctorName", "DoctorSurname"), new Patient("PatientName", "PatientSurname", "12345678901"),
                        new Medicine("MedicineName", 1), new System.DateTime(2000, 10, 10, 14, 30, 00)));
                }
                else
                {
                    prescriptions.Add(new Prescription( i.ToString(), new Doctor("DoctorName2", "DoctorSurname2"), new Patient("PatientName2", "PatientSurname2", "88888888888"),
                        new Medicine("MedicineName2", 2), new System.DateTime(2012, 11, 11, 12, 20, 00)));
                }
            }

            return prescriptions;
        }

        public IEnumerable<Prescription> GetFewPrescriptions()
        {
            return new List<Prescription>() {new Prescription("1", new Doctor("DoctorName", "DoctorSurname"), new Patient("PatientName", "PatientSurname", "12345678901"),
                        new Medicine("MedicineName", 1), new System.DateTime(2000, 10, 10, 14, 30, 00)),
            new Prescription("2", new Doctor("DoctorName2", "DoctorSurname2"), new Patient("PatientName2", "PatientSurname2", "88888888888"),
                        new Medicine("MedicineName2", 2), new System.DateTime(2000, 10, 10, 14, 30, 00))};
        }

        public IEnumerable<Prescription> GetEmptyprescriptons()
        {
            return new List<Prescription>() { };
        }
    }
}
