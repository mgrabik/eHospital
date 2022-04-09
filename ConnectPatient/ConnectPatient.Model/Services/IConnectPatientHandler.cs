namespace ConnectPatient.Model.Services
{
    using ConnectPatient.Model.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IConnectPatientHandler
    {
        public Task<IEnumerable<Prescription>> GetPrescriptionsByPESEL(string searchText);
    }
}
