
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Visit.Model.Model;

namespace Visit.Logic
{
    public class VisitsWriter
    {
        private const string filePath = "Visits.xml";
        private const string visitNamespace = "net";
        private const string visitSchema = @"http://tempuri.org/visits.xsd";

        static public void WriteVisitsXml(VisitD[] inputVisits)
        {
            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);

                List<VisitD> visits = new List<VisitD>();
                visits.AddRange(Visits.Visit);
                visits.AddRange(inputVisits);
                int id = Visits.Visit.Count() + 1;
                foreach (VisitD eachVisit in inputVisits)
                {
                    eachVisit.Id = id.ToString();
                    Visits.Visit.Add(eachVisit);
                    id++;
                }
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmldecl;
                xmldecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(xmldecl);
                XmlElement visitselem = doc.CreateElement(visitNamespace, "Visits", visitSchema);
                VisitD lastVisit = Visits.Visit.Last<VisitD>();
                int iD = 1;
                doc.AppendChild(visitselem);
                foreach (VisitD visit in visits)
                {
                    XmlElement visitelem = doc.CreateElement(visitNamespace, "Visit", visitSchema);

                    visitelem.SetAttributeNode("VisitID", "");
                    visitelem.SetAttribute("VisitID", iD.ToString());
                    iD++;
                    visitelem.SetAttributeNode("Date", "");
                    visitelem.SetAttribute("Date", visit.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                    visitselem.AppendChild(visitelem);

                    XmlElement doctorelem = doc.CreateElement(visitNamespace, "Doctor", visitSchema);
                    doctorelem.Prefix = visitNamespace;
                    visitelem.AppendChild(doctorelem);

                    XmlElement personelem = doc.CreateElement(visitNamespace, "Person", visitSchema);
                    personelem.SetAttributeNode("Name", "");
                    personelem.SetAttribute("Name", visit.Doctor.Name);
                    personelem.SetAttributeNode("Surname", "");
                    personelem.SetAttribute("Surname", visit.Doctor.Surname);
                    doctorelem.AppendChild(personelem);


                    XmlElement patientelem = doc.CreateElement(visitNamespace, "Patient", visitSchema);
                    patientelem.SetAttributeNode("PESEL", "");
                    patientelem.SetAttribute("PESEL", visit.Patient.PESEL);
                    visitelem.AppendChild(patientelem);

                    XmlElement personelem2 = doc.CreateElement(visitNamespace, "Person", visitSchema);
                    personelem2.SetAttributeNode("Name", "");
                    personelem2.SetAttribute("Name", visit.Patient.Name);
                    personelem2.SetAttributeNode("Surname", "");
                    personelem2.SetAttribute("Surname", visit.Patient.Surname);
                    patientelem.AppendChild(personelem2);



                }
                doc.Save("Visits.xml");
            }
        }
        static public void FakeWriteVisitsXml(VisitD[] inputVisits, string filePath)
        {
            if (inputVisits.Length == 0)
            {
                throw new System.ArgumentNullException();
            }

            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);

                List<VisitD> visits = new List<VisitD>();
                visits.AddRange(Visits.Visit);
                visits.AddRange(inputVisits);
                int id = Visits.Visit.Count() + 1;
                foreach (VisitD eachVisit in inputVisits)
                {
                    eachVisit.Id = id.ToString();
                    Visits.Visit.Add(eachVisit);
                    id++;
                }
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmldecl;
                xmldecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(xmldecl);
                XmlElement visitselem = doc.CreateElement(visitNamespace, "Visits", visitSchema);
                VisitD lastVisit = Visits.Visit.Last<VisitD>();
                int iD = 1;
                doc.AppendChild(visitselem);
                foreach (VisitD visit in visits)
                {
                    XmlElement visitelem = doc.CreateElement(visitNamespace, "Visit", visitSchema);

                    visitelem.SetAttributeNode("VisitID", "");
                    visitelem.SetAttribute("VisitID", iD.ToString());
                    iD++;
                    visitelem.SetAttributeNode("Date", "");
                    visitelem.SetAttribute("Date", visit.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                    visitselem.AppendChild(visitelem);

                    XmlElement doctorelem = doc.CreateElement(visitNamespace, "Doctor", visitSchema);
                    doctorelem.Prefix = visitNamespace;
                    visitelem.AppendChild(doctorelem);

                    XmlElement personelem = doc.CreateElement(visitNamespace, "Person", visitSchema);
                    personelem.SetAttributeNode("Name", "");
                    personelem.SetAttribute("Name", visit.Doctor.Name);
                    personelem.SetAttributeNode("Surname", "");
                    personelem.SetAttribute("Surname", visit.Doctor.Surname);
                    doctorelem.AppendChild(personelem);


                    XmlElement patientelem = doc.CreateElement(visitNamespace, "Patient", visitSchema);
                    patientelem.SetAttributeNode("PESEL", "");
                    patientelem.SetAttribute("PESEL", visit.Patient.PESEL);
                    visitelem.AppendChild(patientelem);

                    XmlElement personelem2 = doc.CreateElement(visitNamespace, "Person", visitSchema);
                    personelem2.SetAttributeNode("Name", "");
                    personelem2.SetAttribute("Name", visit.Patient.Name);
                    personelem2.SetAttributeNode("Surname", "");
                    personelem2.SetAttribute("Surname", visit.Patient.Surname);
                    patientelem.AppendChild(personelem2);



                }
                doc.Save("Visits.xml");
            }
            else throw new FileNotFoundException();
        }
    }
}

