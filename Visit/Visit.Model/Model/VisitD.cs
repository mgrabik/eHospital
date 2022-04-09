namespace Visit.Model.Model
{
    using System;
    public class VisitD
    {
        public string Id { get; set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
        public DateTime Date { get; private set; }
        public VisitD(string id, Doctor doctor, Patient patient, DateTime date)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Date = date;
        }
    }
}
