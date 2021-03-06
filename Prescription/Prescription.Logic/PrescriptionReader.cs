namespace Prescription.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Schema;
    using Prescription.Model.Model;

    public class PrescriptionReader
    {
        private const string prescriptionNamespace = "net";
        private const string prescriptionSchema = "http://tempuri.org/prescriptions.xsd";

        public XmlDocument ReadPrescriptionXml(string xmlFilename, string xsdFilename)
        {
            if (String.IsNullOrWhiteSpace(xsdFilename) || String.IsNullOrWhiteSpace(xmlFilename))
                throw new ArgumentException();

            XmlDocument prescriptionsXmlDocument = new XmlDocument();

            XmlReaderSettings xmlReaderSettings = this.GetXmlReaderSettings(xsdFilename);

            using (XmlReader xmlReader = XmlReader.Create(xmlFilename, xmlReaderSettings))
            {
                prescriptionsXmlDocument.Load(xmlReader);
            }

            return prescriptionsXmlDocument;
        }

        private XmlReaderSettings GetXmlReaderSettings(string xsdFilename)
        {
            Debug.Assert(condition: !String.IsNullOrWhiteSpace(xsdFilename));

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();

            xmlReaderSettings.Schemas.Add(null, xsdFilename);
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);

            return xmlReaderSettings;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }

        public IList<PrescriptionData> ReadPrescriptions(XmlDocument prescriptionXmlDocument)
        {
            List<PrescriptionData> prescriptionList = new List<PrescriptionData>();

            XmlNamespaceManager xmlNamespaceManager = PrescriptionReader.GetXmlNamespaceManager(prescriptionXmlDocument);

            string xPath = String.Format("/net:Prescriptions/net:Prescription");

            XmlNodeList nodeXmlPrescriptions = prescriptionXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in nodeXmlPrescriptions)
                prescriptionList.Add(PrescriptionReader.ConvertXmlElementToPrescription(xmlElement, xmlNamespaceManager));

            return prescriptionList;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument networkXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(networkXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(prescriptionNamespace, prescriptionSchema);

            return xmlNamespaceManager;
        }

        private static PrescriptionData ConvertXmlElementToPrescription(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {

            const string personElement = "net:Person";
            const string doctorElement = "net:Doctor";
            const string patientElement = "net:Patient";
            const string medicineElement = "net:Medicine";

            const string idAttribute = "PrescriptionID";
            const string dateAttribute = "Date";
            const string peselAttribute = "PESEL";
            const string nameAttribute = "Name";
            const string surnameAttribute = "Surname";
            const string amountAttribute = "Amount";

            string id = xmlElement.GetAttribute(idAttribute);
            DateTime date = DateTime.Parse(xmlElement.GetAttribute(dateAttribute));

            XmlElement medicineXmlElement = xmlElement.SelectSingleNode(medicineElement, xmlNamespaceManager) as XmlElement;
            string nameofmedicine = medicineXmlElement.GetAttribute(nameAttribute);
            int amount = int.Parse(medicineXmlElement.GetAttribute(amountAttribute));

            XmlElement doctorXmlElement = xmlElement.SelectSingleNode(doctorElement, xmlNamespaceManager) as XmlElement;

            XmlElement doctor_as_person = doctorXmlElement.SelectSingleNode(personElement, xmlNamespaceManager) as XmlElement;
            string nameofdoctor = doctor_as_person.GetAttribute(nameAttribute);
            string surnameofdoctor = doctor_as_person.GetAttribute(surnameAttribute);


            XmlElement patientXmlElement = xmlElement.SelectSingleNode(patientElement, xmlNamespaceManager) as XmlElement;

            XmlElement patient_as_person = patientXmlElement.SelectSingleNode(personElement, xmlNamespaceManager) as XmlElement;
            string nameofpatient = patient_as_person.GetAttribute(nameAttribute);
            string surnameofpatient = patient_as_person.GetAttribute(surnameAttribute);
            string peselofpatient = patientXmlElement.GetAttribute(peselAttribute);

            return new PrescriptionData(id, new Doctor(nameofdoctor, surnameofdoctor), new Patient(nameofpatient, surnameofpatient, peselofpatient),
                new Medicine(nameofmedicine, amount), date);
        }

    }
}
