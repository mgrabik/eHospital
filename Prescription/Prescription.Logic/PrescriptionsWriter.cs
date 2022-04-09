using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Prescription.Model.Model;

namespace Prescription.Logic
{
    public class PrescriptionsWriter
    {
        private const string filePath = "Prescription.xml";
        private const string prescriptionNamespace = "net";
        private const string prescriptionSchema = @"http://tempuri.org/prescriptions.xsd";
        static public void WritePrescriptionsXml(PrescriptionData[] inputPrescritpions)
        {


            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);

                List<PrescriptionData> prescriptions = new List<PrescriptionData>();
                prescriptions.AddRange(Prescriptions.Prescription);
                prescriptions.AddRange(inputPrescritpions);
                int id = Prescriptions.Prescription.Count() + 1;
                foreach (PrescriptionData newPrescription in inputPrescritpions)
                {
                    newPrescription.Id = id.ToString();
                    Prescriptions.Prescription.Add(newPrescription);
                    id++;
                }
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmldecl;
                xmldecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(xmldecl);
                XmlElement prescriptionselem = doc.CreateElement(prescriptionNamespace, "Prescriptions", prescriptionSchema);
                int iD = 1;
                doc.AppendChild(prescriptionselem);

                foreach (PrescriptionData prescription in prescriptions)
                {
                    XmlElement prescriptionelem = doc.CreateElement(prescriptionNamespace, "Prescription", prescriptionSchema);

                    prescriptionelem.SetAttributeNode("PrescriptionID", "");
                    prescriptionelem.SetAttribute("PrescriptionID", iD.ToString());
                    iD++;
                    prescriptionelem.SetAttributeNode("Date", "");
                    prescriptionelem.SetAttribute("Date", prescription.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                    prescriptionselem.AppendChild(prescriptionelem);

                    XmlElement doctorelem = doc.CreateElement(prescriptionNamespace, "Doctor", prescriptionSchema);
                    doctorelem.Prefix = prescriptionNamespace;
                    prescriptionelem.AppendChild(doctorelem);

                    XmlElement personelem = doc.CreateElement(prescriptionNamespace, "Person", prescriptionSchema);
                    personelem.SetAttributeNode("Name", "");
                    personelem.SetAttribute("Name", prescription.Doctor.Name);
                    personelem.SetAttributeNode("Surname", "");
                    personelem.SetAttribute("Surname", prescription.Doctor.Surname);
                    doctorelem.AppendChild(personelem);


                    XmlElement patientelem = doc.CreateElement(prescriptionNamespace, "Patient", prescriptionSchema);
                    patientelem.SetAttributeNode("PESEL", "");
                    patientelem.SetAttribute("PESEL", prescription.Patient.PESEL);
                    prescriptionelem.AppendChild(patientelem);

                    XmlElement personelem2 = doc.CreateElement(prescriptionNamespace, "Person", prescriptionSchema);
                    personelem2.SetAttributeNode("Name", "");
                    personelem2.SetAttribute("Name", prescription.Patient.Name);
                    personelem2.SetAttributeNode("Surname", "");
                    personelem2.SetAttribute("Surname", prescription.Patient.Surname);
                    patientelem.AppendChild(personelem2);

                    XmlElement medicineelem = doc.CreateElement(prescriptionNamespace, "Medicine", prescriptionSchema);
                    medicineelem.SetAttributeNode("Name", "");
                    medicineelem.SetAttribute("Name", prescription.Medicine.Name);
                    medicineelem.SetAttributeNode("Amount", "");
                    medicineelem.SetAttribute("Amount", prescription.Medicine.Amount.ToString());
                    prescriptionelem.AppendChild(medicineelem);
                }
                doc.Save(filePath);
            }
            else throw new FileNotFoundException();
        }

        static public void FakeWritePrescriptionsXml(PrescriptionData[] inputPrescritpions, string filePath)
        {
            if (inputPrescritpions.Length == 0)
            {
                throw new System.ArgumentNullException();
            }


            if (File.Exists(filePath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);

                List<PrescriptionData> prescriptions = new List<PrescriptionData>();
                prescriptions.AddRange(Prescriptions.Prescription);
                prescriptions.AddRange(inputPrescritpions);
                int id = Prescriptions.Prescription.Count() + 1;
                foreach (PrescriptionData newPrescription in inputPrescritpions)
                {
                    newPrescription.Id = id.ToString();
                    Prescriptions.Prescription.Add(newPrescription);
                    id++;
                }
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmldecl;
                xmldecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(xmldecl);
                XmlElement prescriptionselem = doc.CreateElement(prescriptionNamespace, "Prescriptions", prescriptionSchema);
                int iD = 1;
                doc.AppendChild(prescriptionselem);

                foreach (PrescriptionData prescription in prescriptions)
                {
                    XmlElement prescriptionelem = doc.CreateElement(prescriptionNamespace, "Prescription", prescriptionSchema);

                    prescriptionelem.SetAttributeNode("PrescriptionID", "");
                    prescriptionelem.SetAttribute("PrescriptionID", iD.ToString());
                    iD++;
                    prescriptionelem.SetAttributeNode("Date", "");
                    prescriptionelem.SetAttribute("Date", prescription.Date.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                    prescriptionselem.AppendChild(prescriptionelem);

                    XmlElement doctorelem = doc.CreateElement(prescriptionNamespace, "Doctor", prescriptionSchema);
                    doctorelem.Prefix = prescriptionNamespace;
                    prescriptionelem.AppendChild(doctorelem);

                    XmlElement personelem = doc.CreateElement(prescriptionNamespace, "Person", prescriptionSchema);
                    personelem.SetAttributeNode("Name", "");
                    personelem.SetAttribute("Name", prescription.Doctor.Name);
                    personelem.SetAttributeNode("Surname", "");
                    personelem.SetAttribute("Surname", prescription.Doctor.Surname);
                    doctorelem.AppendChild(personelem);


                    XmlElement patientelem = doc.CreateElement(prescriptionNamespace, "Patient", prescriptionSchema);
                    patientelem.SetAttributeNode("PESEL", "");
                    patientelem.SetAttribute("PESEL", prescription.Patient.PESEL);
                    prescriptionelem.AppendChild(patientelem);

                    XmlElement personelem2 = doc.CreateElement(prescriptionNamespace, "Person", prescriptionSchema);
                    personelem2.SetAttributeNode("Name", "");
                    personelem2.SetAttribute("Name", prescription.Patient.Name);
                    personelem2.SetAttributeNode("Surname", "");
                    personelem2.SetAttribute("Surname", prescription.Patient.Surname);
                    patientelem.AppendChild(personelem2);

                    XmlElement medicineelem = doc.CreateElement(prescriptionNamespace, "Medicine", prescriptionSchema);
                    medicineelem.SetAttributeNode("Name", "");
                    medicineelem.SetAttribute("Name", prescription.Medicine.Name);
                    medicineelem.SetAttributeNode("Amount", "");
                    medicineelem.SetAttribute("Amount", prescription.Medicine.Amount.ToString());
                    prescriptionelem.AppendChild(medicineelem);
                }
                doc.Save(filePath);
            }
            else throw new FileNotFoundException();
        }
    }
}
