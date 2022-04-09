namespace Visit.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Schema;
    using Visit.Model.Model;
    public class VisitReader
    {
        private const string visitNamespace = "net";
        private const string visitSchema = "http://tempuri.org/visits.xsd";

        public XmlDocument ReadVisitXml(string xmlFilename, string xsdFilename)
        {
            if (String.IsNullOrWhiteSpace(xsdFilename) || String.IsNullOrWhiteSpace(xmlFilename))
                throw new ArgumentException();

            XmlDocument networkXmlDocument = new XmlDocument();

            XmlReaderSettings xmlReaderSettings = this.GetXmlReaderSettings(xsdFilename);

            using (XmlReader xmlReader = XmlReader.Create(xmlFilename, xmlReaderSettings))
            {
                networkXmlDocument.Load(xmlReader);
            }

            return networkXmlDocument;
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

        public IList<VisitD> ReadVisits(XmlDocument visitXmlDocument)
        {
            List<VisitD> visitList = new List<VisitD>();

            XmlNamespaceManager xmlNamespaceManager = VisitReader.GetXmlNamespaceManager(visitXmlDocument);

            string xPath = String.Format("/net:Visits/net:Visit");

            XmlNodeList nodeXmlVisits = visitXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);


            foreach (XmlElement xmlElement in nodeXmlVisits)
                visitList.Add(VisitReader.ConvertXmlElementToVisit(xmlElement, xmlNamespaceManager));

            return visitList;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument networkXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(networkXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(visitNamespace, visitSchema);

            return xmlNamespaceManager;
        }

        private static VisitD ConvertXmlElementToVisit(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {

            const string personElement = "net:Person";
            const string doctorElement = "net:Doctor";
            const string patientElement = "net:Patient";

            const string idAttribute = "VisitID";
            const string dateAttribute = "Date";
            const string peselAttribute = "PESEL";
            const string nameAttribute = "Name";
            const string surnameAttribute = "Surname";

            string id = xmlElement.GetAttribute(idAttribute);
            DateTime date = DateTime.Parse(xmlElement.GetAttribute(dateAttribute));

            XmlElement doctorXmlElement = xmlElement.SelectSingleNode(doctorElement, xmlNamespaceManager) as XmlElement;

            XmlElement doctor_as_person = doctorXmlElement.SelectSingleNode(personElement, xmlNamespaceManager) as XmlElement;
            string nameofdoctor = doctor_as_person.GetAttribute(nameAttribute);
            string surnameofdoctor = doctor_as_person.GetAttribute(surnameAttribute);


            XmlElement patientXmlElement = xmlElement.SelectSingleNode(patientElement, xmlNamespaceManager) as XmlElement;

            XmlElement patient_as_person = patientXmlElement.SelectSingleNode(personElement, xmlNamespaceManager) as XmlElement;
            string nameofpatient = patient_as_person.GetAttribute(nameAttribute);
            string surnameofpatient = patient_as_person.GetAttribute(surnameAttribute);
            string peselofpatient = patientXmlElement.GetAttribute(peselAttribute);

            return new VisitD(id, new Doctor(nameofdoctor, surnameofdoctor), new Patient(nameofpatient, surnameofpatient, peselofpatient), date);
        }
    }
}
