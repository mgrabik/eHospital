namespace App_Doctor.Logic.Model.Service
{
    using System;
    using System.Collections.Generic;
    using App_Doctor.Logic.Model.Data;

    public class FakeNetworkClient : INetwork
    {
        private static readonly Visit[] assignedRooms = new Visit[] { new Visit("123", new Doctor("doc1","docsur1"), new Patient("pat1","patsur1","12345678910"), new DateTime(2008, 5, 1, 8, 30, 52)),
        new Visit("222", new Doctor("doc2","docsur2"), new Patient("pat2","patsur2","01987654321"), new DateTime(2020, 5, 1, 8, 30, 52))};

        public Visit[] GetVisits(string searchText)
        {
            return FakeNetworkClient.assignedRooms;
        }
        public void PostVisits(Visit visitsToPost)
        {
        }
    }
}
