namespace App_Patient.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using App_Patient.Tests.Model;
    using App_Patient.Tests.Data;
    using System;

    [TestClass]
    public class App_PatientTests
    {

        [TestMethod]
        public void InputWithoutDate()
        {
            Operations operations = new Operations();

            var newPrescription = FakePrescription.OnePrescription();

            Action action = () => operations.RunNewPrescription(newPrescription.Doctor.Name, newPrescription.Doctor.Name,
                newPrescription.Patient.Name, newPrescription.Patient.Surname, newPrescription.Patient.PESEL, newPrescription.Medicine.Name, newPrescription.Medicine.Amount, new DateTime());

            Assert.ThrowsException<NullReferenceException>(action, "Should throw NullReferenceException");
        }

        [DataTestMethod]
        [DataRow(null, "Nowak", "Krzysztof", "Kolumb", "12345678901", "SesjaPLUS")]
        [DataRow("Marcin", null, "Krzysztof", "Kolumb", "12345678901", "SesjaPLUS")]
        [DataRow("Marcin", "Nowak", null, "Kolumb", "12345678901", "SesjaPLUS")]
        [DataRow("Marcin", "Nowak", "Krzysztof", null, "12345678901", "SesjaPLUS")]
        [DataRow("Marcin", "Nowak", "Krzysztof", "Kolumb", null, "SesjaPLUS")]
        [DataRow("Marcin", "Nowak", "Krzysztof", "Kolumb", "12345678901", null)]
        public void NotAllInputExsist(string doctorName, string doctorSurname, string patientName, string patientSurname, string patientPESEL, string medicineName)
        {
            Operations operations = new Operations();

            var newPrescription = FakePrescription.OnePrescription();

            Action action = () => operations.RunNewPrescription(doctorName, doctorSurname,patientName, patientSurname, 
                patientPESEL, medicineName, newPrescription.Medicine.Amount, new DateTime(2000, 10, 10, 09, 45, 00));

            Assert.ThrowsException<NullReferenceException>(action, "Should throw NullReferenceException");
        }

        [TestMethod]
        public void OutputCorrectness()
        {
            Operations operations = new Operations();

            var newPrescription = FakePrescription.OnePrescription();

            var result = operations.RunNewPrescription(newPrescription.Doctor.Name, newPrescription.Doctor.Name, newPrescription.Patient.Name, 
                newPrescription.Patient.Surname, newPrescription.Patient.PESEL, newPrescription.Medicine.Name, newPrescription.Medicine.Amount, newPrescription.Date);

            Assert.AreEqual(result, operations.OutputFakePrescriptionList[0], "\n Method result: {0} \n Should be: {1}", result, operations.OutputFakePrescriptionList[0]);
        }

    }
}
