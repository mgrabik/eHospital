namespace Prescription.Model.Model
{
    public class Medicine
    {
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public Medicine(string name, int amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
    }
}
