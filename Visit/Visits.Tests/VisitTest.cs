using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Visit.Logic;
using Visit.Model.Model;

namespace Visit.Tests
{
    [TestClass]
    public class VisitTest
    {
        [TestMethod]
        public void TestGetVisit()
        {
            var doctor = new Doctor("Adam", "Markowski");
            var patient = new Patient("Izabela", "Olszewska", "2137");
            var date = new DateTime(2012, 7, 15);
            var visit = new Visit.Model.Model.Visit("1", doctor, patient, date);
            var visits = new Visits();
            var result = visits.GetVisits();
            Assert.AreEqual(visit.Id, result.First().Id);
            Assert.AreEqual(visit.Patient.Name, result.First().Patient.Name);
            Assert.AreEqual(visit.Doctor.Name, result.First().Doctor.Name);
        }
    }
}
