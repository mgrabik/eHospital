namespace App_Doctor.Logic.Model.Data
{
    using System;
    public class Visit
    {
        public string Id { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
        public Visit(string id, Doctor doctor, Patient patient, DateTime date)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Date = date;
        }

        public static DateTime DateOfNewVisit { get; set; }
}
}
