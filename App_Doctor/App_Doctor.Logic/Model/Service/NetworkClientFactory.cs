namespace App_Doctor.Logic.Model.Service
{
    public static class NetworkClientFactory
    {
        public static INetwork GetNetworkClient(string service)
        {
            if(service=="app")
            { 
                const string serviceHost = "localhost";
                const int servicePort = 44372;
                return new NetworkClient(serviceHost, servicePort);
            }
            else if(service == "data")
                {
                const string serviceHost = "localhost";
                const int servicePort = 44329;
                return new NetworkClient(serviceHost, servicePort);
            }
            else if (service == "docker")
            {
                const string serviceHost = "localhost";
                const int servicePort = 42073;
                return new NetworkClient(serviceHost, servicePort);
            }
            else
            {
                throw new System.Exception("NetworkClient service incorrect");
            }

        }
    }
}
