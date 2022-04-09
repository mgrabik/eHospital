namespace App_Patient.Logic.Model.Data
{
    public class Medicine
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public Medicine(string name, int amount)
        {
            this.Name = name;
            this.Amount = amount;
        }
    }
}
