namespace App_Doctor.Tests.Data
{
    public class FakePerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public FakePerson(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
