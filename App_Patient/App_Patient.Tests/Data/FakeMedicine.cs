namespace App_Patient.Tests.Data
{
    public class FakeMedicine
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public FakeMedicine(string name, int amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
    }
}
