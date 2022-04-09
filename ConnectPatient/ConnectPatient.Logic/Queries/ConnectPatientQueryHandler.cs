namespace ConnectPatient.Logic.Queries
{
    using ConnectPatient.Model.Services;
    using ConnectPatient.Logic.DataServicesClient;
    using System.Threading.Tasks;
    using ConnectPatient.Model.Model;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class ConnectPatientQueryHandler : IConnectPatientHandler
    {
        private readonly IPrescriptionServiceClient prescriptionServiceClient;

        public ConnectPatientQueryHandler(IPrescriptionServiceClient prescriptionServiceClient)
        {
            this.prescriptionServiceClient = prescriptionServiceClient;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByPESEL(string pesel)
        {
            var prescriptions = prescriptionServiceClient.GetAllPrescriptions();

            if(pesel == "" || pesel == null)
            {
                throw new ArgumentNullException();
            }


            var prescrptionbypesel = from pres in await prescriptions
                                     where pres.Patient.PESEL == pesel
                               select pres;

            return prescrptionbypesel;
        }
    }
}
