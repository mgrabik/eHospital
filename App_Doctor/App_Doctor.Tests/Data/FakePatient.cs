namespace App_Doctor.Tests.Data
{
    public class FakePatient : FakePerson
    {
        public string PESEL { get; set; }
        public FakePatient(string name, string surname, string pesel) : base(name, surname)
        {
            this.PESEL = pesel;
        }
    }
}
