namespace Prescription.Model.Services
{
    using Prescription.Model.Model;
    using System.Collections.Generic;

    public interface IPrescription
    {
        public List<PrescriptionData> GetPrescriptions(string searchText);
        public void AddPrescriptions(PrescriptionData[] addedList);
    }
}
