namespace ConnectPatient.Model.Model
{
    public class Patient : Person
    {
        public string PESEL { get; private set; }

        public Patient(string name, string surname, string pesel) : base(name, surname)
        {
            this.PESEL = pesel;
        }
    }
}
