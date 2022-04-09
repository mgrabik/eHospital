namespace ConnectPatient.Tests
{
    using ConnectPatient.Tests.Queries;
    using ConnectPatient.Tests.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ServiceTests
    {
        private readonly IConnectPatientHandler connectPatientHandler = new ConnectPatientQueryHandler();

        [TestMethod]
        public void RationalDurationWithBigData()
        {
            FakePrescription fakePrescription = new FakePrescription();

            var prescriptions = fakePrescription.BigData();

            Action action = ( ) => connectPatientHandler.GetPrescriptionsByPESEL("12345678901", prescriptions);
        }

        [DataTestMethod]
        [DataRow("")]
        public void PeselIsNull(string pesel)
        {
            FakePrescription fakePrescription = new FakePrescription();

            var prescriptions = fakePrescription.GetFewPrescriptions();

            Action action = () => connectPatientHandler.GetPrescriptionsByPESEL(pesel, prescriptions);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException");
        }

        [DataTestMethod]
        [DataRow("1234")]
        [DataRow("1234567890112345")]
        public void PeselHasIncorrectLenght(string pesel)
        {
            FakePrescription fakePrescription = new FakePrescription();

            var prescriptions = fakePrescription.GetFewPrescriptions();

            Action action = () => connectPatientHandler.GetPrescriptionsByPESEL(pesel, prescriptions);

            Assert.ThrowsException<ArgumentOutOfRangeException>(action, "Should throw ArgumentOutOfRangeException");
        }

        [TestMethod]
        public void ListOfPresriptionsIsEmpty()
        {
            FakePrescription fakeVisit = new FakePrescription();

            var visits = fakeVisit.GetEmptyprescriptons();

            Action action = () => connectPatientHandler.GetPrescriptionsByPESEL("DoctorName DoctorSurname", visits);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException on empty list");
        }
    }
}
