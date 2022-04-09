namespace App_Patient.Logic.Model.Service
{
    using App_Patient.Logic.Model.Data;
    using System.Threading.Tasks;

    public interface INetwork
    {
        Prescription[] GetPrescriptions(string searchText);
        void PostPrescriptions(Prescription visitsToPost);
    }
}
