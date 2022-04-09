namespace Prescription.Model.Model
{
    using System;
    public class PrescriptionData
    {
        public string Id { get; set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
        public Medicine Medicine { get; private set; }
        public DateTime Date { get; private set; }
        public PrescriptionData(string id , Doctor doctor, Patient patient, Medicine medicine, DateTime date)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Medicine = medicine;
            this.Date = date;
        }
    }
}
