namespace App_Doctor.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using App_Doctor.Tests.Model;
    using App_Doctor.Tests.Data;
    using System;

    [TestClass]
    public class ModelTests
    {

        [TestMethod]
        public void OutputCorrectness()
        {
            Operations operations = new Operations();

            var newVisit = FakeVisit.OneVisit();

            var result = operations.RunNewVisit(newVisit.Doctor.Name, newVisit.Doctor.Name,
                newVisit.Patient.Name, newVisit.Patient.Surname, newVisit.Patient.PESEL, newVisit.Date);

            Assert.AreEqual(result, operations.OutputFakeVisitList[0], "\n Method result: {0} \n Should be: {1}", result, operations.OutputFakeVisitList[0]);
        }

        [DataTestMethod]
        [DataRow(null, "Nowak", "Krzysztof", "Kolumb", "12345678901")]
        [DataRow("Marcin", null, "Krzysztof", "Kolumb", "12345678901")]
        [DataRow("Marcin", "Nowak", null, "Kolumb", "12345678901")]
        [DataRow("Marcin", "Nowak", "Krzysztof", null, "12345678901")]
        [DataRow("Marcin", "Nowak", "Krzysztof", "Kolumb", null)]
        public void NotAllInputExsist(string doctorName, string doctorSurname, string patientName, string patientSurname, string patientPESEL)
        {
            Operations operations = new Operations();

            var newVisit = FakeVisit.OneVisit();

            Action action = () => operations.RunNewVisit(doctorName, doctorSurname,
                patientName, patientSurname, patientPESEL, new DateTime(2000,10,10,09,45,00));

            Assert.ThrowsException<NullReferenceException>(action, "Should throw NullReferenceException");
        }

        [TestMethod]
        public void InputDateIsEmpty()
        {
            Operations operations = new Operations();

            var newVisit = FakeVisit.OneVisit();

            Action action = () => operations.RunNewVisit(newVisit.Doctor.Name, newVisit.Doctor.Name,
                newVisit.Patient.Name, newVisit.Patient.Surname, newVisit.Patient.PESEL, new DateTime());

            Assert.ThrowsException<NullReferenceException>(action, "Should throw NullReferenceException");
        }
    }
}
