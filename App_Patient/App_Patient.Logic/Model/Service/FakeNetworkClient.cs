namespace App_Patient.Logic.Model.Service
{
    using System;
    using App_Patient.Logic.Model.Data;

    public class FakeNetworkClient : INetwork
    {
        private static readonly Prescription[] prescriptions = new Prescription[] { new Prescription("123", new Doctor("doc1","docsur1"), new Patient("pat1","patsur1","12345678910"), new Medicine("Lek1",5) ,new DateTime(2008, 5, 1, 8, 30, 52)),
        new Prescription("222", new Doctor("doc2","docsur2"), new Patient("pat2","patsur2","01987654321"), new Medicine("Lek2",2) , new DateTime(2020, 5, 1, 8, 30, 52))};

        public Prescription[] GetPrescriptions(string searchText)
        {
            return FakeNetworkClient.prescriptions;
        }
        public void PostPrescriptions(Prescription visitsToPost)
        {
        }
    }
}
