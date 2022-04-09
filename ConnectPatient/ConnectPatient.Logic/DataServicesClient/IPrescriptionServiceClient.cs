namespace ConnectPatient.Logic.DataServicesClient
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ConnectPatient.Model.Model;

    public interface IPrescriptionServiceClient
    {
        Task<IEnumerable<Prescription>> GetAllPrescriptions();
    }
}
