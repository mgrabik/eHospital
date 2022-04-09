namespace Prescription.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Prescription.Model.Model;
    using Prescription.Model.Services;

    public class Prescriptions : IPrescription
    {
        private static XmlDocument prescriptionXmlDocument;

        public static List<PrescriptionData> Prescription;

        private static readonly object prescriptionLock = new object();

        private const string prescriptionXmlFilename = "Prescription.xml";
        private const string prescriptionXsdFilename = "PrescritionSchema.xsd";

        static Prescriptions()
        {
            lock (Logic.Prescriptions.prescriptionLock)
            {
                PrescriptionReader prescriptionReader = new PrescriptionReader();

                Prescriptions.prescriptionXmlDocument = prescriptionReader.ReadPrescriptionXml(prescriptionXmlFilename, prescriptionXsdFilename);

                Prescriptions.Prescription = prescriptionReader.ReadPrescriptions(prescriptionXmlDocument).ToList<PrescriptionData>();
            }
        }

        public Prescriptions()
        {
        }

        public List<PrescriptionData> GetPrescriptions(string searchText)
        {
            lock (Prescriptions.prescriptionLock)
            {
                return Prescriptions.Prescription;
            }
        }
        public void AddPrescriptions(PrescriptionData[] addedList)
        {
            lock (Logic.Prescriptions.prescriptionLock)
            {
                PrescriptionsWriter.WritePrescriptionsXml(addedList);
            }
        }

    }
}
