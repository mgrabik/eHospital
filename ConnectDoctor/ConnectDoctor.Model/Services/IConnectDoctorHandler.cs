namespace ConnectDoctor.Model.Services
{
    using ConnectDoctor.Model.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IConnectDoctorHandler
    {
        public Task<IEnumerable<Visit>> GetVisitsByName(string searchText);
    }
}
