namespace App_Doctor.Logic.Model.Service
{
    using App_Doctor.Logic.Model.Data;
    using System.Threading.Tasks;

    public interface INetwork
    {
        Visit[] GetVisits(string searchText);

        void PostVisits(Visit visitsToPost);
    }
}
