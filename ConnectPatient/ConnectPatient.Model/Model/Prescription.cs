namespace ConnectPatient.Model.Model
{
    using System;
    public class Prescription
    {
        public string Id { get; private set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
        public Medicine Medicine { get; private set; }
        public DateTime Date { get; private set; }
        public Prescription(string id, Doctor doctor, Patient patient, Medicine medicine, DateTime date)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Medicine = medicine;
            this.Date = date;
        }
    }
}
