namespace ConnectDoctor.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ConnectDoctor.Tests.Data;
    using ConnectDoctor.Tests.Queries;
    using ConnectDoctor.Logic;
    using System;

    [TestClass]
    public class ConnectDoctorTests
    {
        private readonly IConnectDoctorHandler connectDoctorHandler = new ConnectDoctorQueryHandler();

        [TestMethod]
        public void DurationWithBigData()
        {
            FakeVisit fakeVisit = new FakeVisit();

            var visits = fakeVisit.BigData();

            Action action = () => connectDoctorHandler.GetVisitsByName("DoctorName DoctorSurname", visits);
        }

        [TestMethod]
        public void ListOfVisitsIsEmpty()
        {
            FakeVisit fakeVisit = new FakeVisit();

            var visits = fakeVisit.GetEmptyVisits();

            Action action = () => connectDoctorHandler.GetVisitsByName("DoctorName DoctorSurname", visits);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException on empty list");
        }

        [DataTestMethod]
        [DataRow("Mikolaj")]
        [DataRow("Mikolaj Krul Nowy")]
        public void NameAndSurnameIsIncorrect(string searchNameAndSurname)
        {
            FakeVisit fakeVisit = new FakeVisit();

            var visits = fakeVisit.GetFewVisits();

            Action action = () => connectDoctorHandler.GetVisitsByName( searchNameAndSurname, visits);

            Assert.ThrowsException<CustomExceptions>(action, "Should throw CustomExceptions on empty list");
        }
    }
}
