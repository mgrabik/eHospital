namespace ConnectDoctor.Model.Model
{
    using System;
    public class Visit
    {
        public string Id { get; private set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
        public DateTime Date { get; private set; }
        public Visit(string id , Doctor doctor, Patient patient, DateTime date)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Date = date;
        }
    }
}
