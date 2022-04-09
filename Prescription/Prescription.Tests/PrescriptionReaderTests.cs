namespace Prescription.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Prescription.Logic;
    using Prescription.Model.Model;
    using System;
    using System.IO;
    using System.Xml;

    [TestClass]
    public class PrescriptionReaderTests
    {


        [DataTestMethod]
        [DataRow(xmlFilename, "")]
        [DataRow("", xsdFilename)]
        public void ReadXmlDocument_EmptyFilename_ThrowsArgumentException(string xmlFilename, string xsdFilename)
        {
            PrescriptionReader prescriptionReader = new PrescriptionReader();

            Action action = () => prescriptionReader.ReadPrescriptionXml(xmlFilename, xsdFilename);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [TestMethod]
        public void ReadPrescriptions_XmlFile_Returns15Prescriptions()
        {
            PrescriptionReader prescriptionReader = new PrescriptionReader();

            XmlDocument prescriptionXmlFile = prescriptionReader.ReadPrescriptionXml(xmlFilename, xsdFilename);

            int count = prescriptionReader.ReadPrescriptions(prescriptionXmlFile).Count;

            int countedPrescription = 15;

            Assert.AreEqual(countedPrescription, count, "Prescription count should be {0} and not {1}", countedPrescription, count);
        }

        [TestMethod]
        public void ReadXmlDocument_DefaultXmlFileStreams_DocumentElementHas15ChildNodes()
        {
            PrescriptionReader prescriptionReader = new PrescriptionReader();

            XmlDocument networkXmlDocument = prescriptionReader.ReadPrescriptionXml(xmlFilename, xsdFilename);

            int count = networkXmlDocument.DocumentElement.ChildNodes.Count;

            int countedChildNodes = 15;

            Assert.AreEqual(countedChildNodes, count, "The child count of the document element should be {0} and not {1}", countedChildNodes, count);
        }

        [TestMethod]
        public void XmlFile_ForXmlWriter_ThatDoesNotExist()
        {
            Action action = () =>  PrescriptionsWriter.FakeWritePrescriptionsXml(fakeData(), xmlFilenameWhichNotExist);

            Assert.ThrowsException<FileNotFoundException>(action, "Should throw FileNotFoundException");
        }

        [TestMethod]
        public void InputForWriter_IsEmpty()
        {
            Action action = () => PrescriptionsWriter.FakeWritePrescriptionsXml(emptyData(), xmlFilename);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException");
        }

        private PrescriptionData[] fakeData()
        {
            return new PrescriptionData[] { new PrescriptionData("id", new Doctor("name", "surname"), new Patient("name", "surname", "pesel"), new Medicine("name", 1), new DateTime()) };
        }

        private PrescriptionData[] emptyData()
        {
            return new PrescriptionData[0];
        }

        
        private const string xsdFilename = "./../../../PrescritionSchema.xsd";
        private const string xmlFilename = "./../../../Prescription.xml";
        private const string xmlFilenameWhichNotExist = "SomeFile.xml";
    }
}