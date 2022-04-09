namespace WebApplication.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using App_Doctor.Logic.Model.Data;
    using App_Doctor.Logic.Model.Service;
    using App_Doctor.Model;
    using App_Doctor.Logic.Controller;
    using System;
    using WebApplication.Tests;

    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void OutputCorrectness()
        {
            Operations operations = new Operations();

            bool isCorrect;

            string nameAndSurname = "Mikolaj Nowak";

            Visit[] visitForNowak = visitsForNowak();

            Visit[] result = operations.GetVisits(nameAndSurname);

            if(visitForNowak[0].Id == result[0].Id || visitForNowak[0].Doctor.Name == result[0].Doctor.Name || 
                visitForNowak[0].Doctor.Surname == result[0].Doctor.Surname || visitForNowak[0].Patient.Name == result[0].Patient.Name ||
                visitForNowak[0].Patient.Surname == result[0].Patient.Surname ||
                visitForNowak[0].Patient.PESEL == result[0].Patient.PESEL)
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
            }
            Assert.AreEqual(isCorrect, true, "\n The output are not equal, but should be.");
        }

        [DataTestMethod]
        [DataRow("Mikolaj")]
        [DataRow("Mikolaj Swiety Krul")]
        [DataRow("Mikolaj Swiety Krul Zdecydowanie Za Duzo Info")]
        public void GET_IncorrectInput(string nameAndSurname)
        {
            Operations operations = new Operations();

            Action action = () => operations.GetVisits(nameAndSurname);

            Assert.ThrowsException<ArgumentOutOfRangeException>(action, "Should throw ArgumentOutOfRangeException");
        }

        [DataTestMethod]
        [DataRow("")]
        public void GET_WithoutInput(string nameAndSurname)
        {
            Operations operations = new Operations();

            Action action = () => operations.GetVisits(nameAndSurname);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException");
        }

        [TestMethod]
        public void POST_WithoutInput()
        {
            Operations operations = new Operations();

            Action action = () => operations.PostVisits(null);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException");
        }

        [TestMethod]
        public void POST_WithoutDoctor()
        {
            Operations operations = new Operations();

            Visit newVisit = new Visit() { Id = "1", Patient = new Patient(), Date = new DateTime()};

            Action action = () => operations.PostVisits(newVisit);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException");
        }

        [TestMethod]
        public void POST_WithoutPatient()
        {
            Operations operations = new Operations();

            Visit newVisit = new Visit() { Id = "1", Doctor = new Doctor(), Date = new DateTime() };

            Action action = () => operations.PostVisits(newVisit);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException");
        }

        [TestMethod]
        public void POST_WithoutDate()
        {
            Operations operations = new Operations();

            Visit newVisit = new Visit() { Id = "1", Doctor = new Doctor(), Patient = new Patient() };

            Action action = () => operations.PostVisits(newVisit);

            Assert.ThrowsException<ArgumentNullException>(action, "Should throw ArgumentNullException");
        }

        private Visit[] visitsForNowak()
        {
            return new Visit[] { new Visit("16", new Doctor("Mikolaj", "Nowak"), new Patient("Krystian", "Kowal", "12312312312"), new DateTime(2021, 05, 28, 08, 04, 18)) };
        }
    }
}
