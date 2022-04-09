namespace App_Doctor.Logic.Model.Data
{
    public class Patient : Person
    {
        public string PESEL { get; set; }
        public Patient(string name, string surname, string pesel) : base(name, surname)
        {
            this.PESEL = pesel;
        }
        public Patient()
        {

        }
    }
}
