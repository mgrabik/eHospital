namespace ConnectDoctor.Tests.Queries
{
    using ConnectDoctor.Model.Model;
    using System.Collections.Generic;

    public interface IConnectDoctorHandler
    {
        public IEnumerable<Visit> GetVisitsByName(string searchText, IEnumerable<Visit> visits);
    }
}
