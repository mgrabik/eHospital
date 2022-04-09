namespace ConnectPatient.Tests.Queries
{
    using ConnectPatient.Model.Model;
    using System.Collections.Generic;

    public interface IConnectPatientHandler
    {
        public IEnumerable<Prescription> GetPrescriptionsByPESEL(string searchText, IEnumerable<Prescription> prescriptions);
    }
}
