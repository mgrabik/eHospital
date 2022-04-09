namespace ConnectPatient.Tests.Queries
{
    using ConnectPatient.Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectPatientQueryHandler : IConnectPatientHandler
    {

        public ConnectPatientQueryHandler()
        {

        }

        public IEnumerable<Prescription> GetPrescriptionsByPESEL(string pesel, IEnumerable<Prescription> prescriptions)
        {
            if (prescriptions.Count() == 0 || pesel == "")
            {
                throw new ArgumentNullException();
            }
            if (pesel.Length != 11)
            {
                throw new ArgumentOutOfRangeException();
            }


            var prescrptionbypesel = from pres in prescriptions
                                     where pres.Patient.PESEL == pesel
                                     select pres;

            return prescrptionbypesel;
        }
    }
}
