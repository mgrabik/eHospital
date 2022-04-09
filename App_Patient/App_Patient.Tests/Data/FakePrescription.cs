namespace App_Patient.Tests.Data
{
    using System;
    public class FakePrescription
    {
        public string Id { get; set; }
        public FakeDoctor Doctor { get; set; }
        public FakePatient Patient { get; set; }
        public FakeMedicine Medicine { get; set; }
        public DateTime Date { get; set; }
        public FakePrescription(string id, FakeDoctor doctor, FakePatient patient, FakeMedicine medicine, DateTime date)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Medicine = medicine;
            this.Date = date;
        }

        public static DateTime DateOfNewPrescription { get; set; }

        public static FakePrescription OnePrescription()
        {
            return new FakePrescription("1", new FakeDoctor("Marcin", "Nowak"), new FakePatient("Krzysztof", "Kolumb", "12312312312"), new FakeMedicine("SesjaPLUS", 0), new DateTime(2000,10,10,10,30,00));
        }
    }
}
