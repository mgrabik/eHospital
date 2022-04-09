namespace Visit.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Visit.Logic;
    using Visit.Model.Model;
    using System;
    using System.Xml;
    using System.IO;

    [TestClass]
    public class VisitReaderTests
    {
        private const string xsdFilename = "./../../../VisitSchema.xsd";
        private const string xmlFilename = "./../../../Visits.xml";
        private const string xmlFilenameWhichNotExist = "NotExistfile.xml";

        [DataTestMethod]
        [DataRow(xmlFilename, "")]
        [DataRow("", xsdFilename)]
        public void ReadXmlDocument_EmptyFilename_ThrowsArgumentException(string xmlFilename, string xsdFilename)
        {
            VisitReader visitReader = new VisitReader();

            Action action = () => visitReader.ReadVisitXml(xmlFilename, xsdFilename);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [TestMethod]
        public void ReadVisits_XmlFile_Returns15Visits()
        {
            VisitReader visitReader = new VisitReader();

            XmlDocument visitXmlFile = visitReader.ReadVisitXml(xmlFilename, xsdFilename);

            int count = visitReader.ReadVisits(visitXmlFile).Count;

            int countedVisits = 15;

            Assert.AreEqual(countedVisits, count, "Prescription count should be {0} and not {1}", countedVisits, count);
        }

        [TestMethod]
        public void ReadXmlDocument_DefaultXmlFileStreams_DocumentElementHas15ChildNodes()
        {
            VisitReader visitReader = new VisitReader();

            XmlDocument networkXmlDocument = visitReader.ReadVisitXml(xmlFilename, xsdFilename);

            int count = networkXmlDocument.DocumentElement.ChildNodes.Count;

            int countedChildNodes = 15;

            Assert.AreEqual(countedChildNodes, count, "The child count of the document element should be {0} and not {1}", countedChildNodes, count);
        }

        [TestMethod]
        public void XmlFile_ForXmlWriter_ThatDoesNotExist()
        {
            Action action = () => VisitsWriter.FakeWriteVisitsXml(fakeData(), xmlFilenameWhichNotExist);

            Assert.ThrowsException<FileNotFoundException>(action, "Should throw FileNotFoundException");
        }

        [TestMethod]
        public void InputForWriter_IsEmpty()
        {
            Action action = () => VisitsWriter.FakeWriteVisitsXml(emptyData(), xmlFilename);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException");
        }

        private VisitD[] fakeData()
        {
            return new VisitD[] { new VisitD("id", new Doctor("name", "surname"), new Patient("name", "surname", "pesel"), new DateTime()) };
        }

        private VisitD[] emptyData()
        {
            return new VisitD[0];
        }
    }
}
