namespace App_Patient.Logic.Model.Data
{
    using System;
    public class Prescription
    {
        public string Id { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Medicine Medicine { get; set; }
        public DateTime Date { get; set; }
        public Prescription(string id, Doctor doctor, Patient patient, Medicine medicine, DateTime date)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Medicine = medicine;
            this.Date = date;
        }

        public static DateTime DateOfNewPrescription { get; set; }
    }
}
