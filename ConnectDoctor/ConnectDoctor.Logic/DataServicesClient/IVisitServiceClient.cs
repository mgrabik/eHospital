namespace ConnectDoctor.Logic.DataServicesClient
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ConnectDoctor.Model.Model;

    public interface IVisitServiceClient
    {
        Task<IEnumerable<Visit>> GetAllVisits();
    }
}
