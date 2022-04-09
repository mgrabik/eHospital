namespace App_Patient.Logic.Model.Service
{
    public static class NetworkClientFactory
    {
        public static INetwork GetNetworkClient(string service)
        {
            if (service == "app")
            {
                const string serviceHost = "localhost";
                const int servicePort = 44371;
                return new NetworkClient(serviceHost, servicePort);
            }
            else if (service == "data")
            {
                const string serviceHost = "localhost";
                const int servicePort = 44328;
                return new NetworkClient(serviceHost, servicePort);
            }
            else if (service == "docker")
            {
                const string serviceHost = "localhost";
                const int servicePort = 42072;
                return new NetworkClient(serviceHost, servicePort);
            }
            else
            {
                throw new System.Exception("NetworkClient service incorrect");
            }

        }
    }
}
