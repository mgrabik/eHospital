namespace App_Doctor.Model
{
    using App_Doctor.Logic.Model.Service;
    using App_Doctor.Logic.Model.Data;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class Model : IOperations
    {
        public void LoadVisitList()
        {
            Task.Run(() => this.LoadVisitTask());
        }
        public void NewVisit()
        {
            Task.Run(() => this.NewVisitTask());
        }

        public void NewVisitTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("docker");

            try
            {
                networkClient.PostVisits(this.SelectedVisit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadVisitTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("docker");

            try
            {
                Visit[] visits = networkClient.GetVisits(this.ValueInTextBox);

                this.VisitList = visits.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

