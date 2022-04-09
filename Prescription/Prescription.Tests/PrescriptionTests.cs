using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prescription.Logic;
using Prescription.Model.Services;
using System.Linq;

namespace Prescription.Tests
{
    [TestClass]
    public class PrescriptionTests
    {
        [TestMethod]
        public void PerscriptionTestNotExistingName()
        {
            var perscriptions = new Prescriptions();
            var results = perscriptions.GetPrescriptions();
            Assert.AreEqual(results.Last().Medicine.Name, "Sudafet");
            Assert.AreEqual(results.Last().Patient.Name, "Jan");
            Assert.AreEqual(results.First().Medicine.Name, "Pyrosal");
            Assert.AreEqual(results.First().Patient.Name, "Karol");
        }
    }
}
