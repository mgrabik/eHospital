namespace App_Doctor.Tests.Data
{
    using System;
    public class FakeVisit
    {
        public string Id { get; set; }
        public FakeDoctor Doctor { get; set; }
        public FakePatient Patient { get; set; }
        public DateTime Date { get; set; }
        public FakeVisit(string id, FakeDoctor doctor, FakePatient patient, DateTime date)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Date = date;
        }

        public static DateTime DateOfNewVisit { get; set; }

        public static FakeVisit OneVisit()
        {
            return new FakeVisit("100", new FakeDoctor("DoctorName", "DoctorSurname"), new FakePatient("PatientName", "PatientSurname", "12345678901"), new DateTime(2000,10,10,14,30,00));
        }
    }
}
