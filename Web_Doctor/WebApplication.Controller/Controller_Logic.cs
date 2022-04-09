namespace App_Doctor.Logic.Controller
{
    using System.Windows.Input;
    using App_Doctor.Model;

    public partial class Controller : IController
    {
        public ApplicationState CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;

                this.RaisePropertyChanged("CurrentState");
            }
        }
        private ApplicationState currentState = ApplicationState.List;

        public ICommand SearchVisitsCommand { get; private set; }

        public ICommand AddElement { get; private set; }

        public ICommand ShowListCommand { get; private set; }

        public ICommand ShowMapCommand { get; private set; }

        public void SearchVisitAsync()
        {
            this.Model.LoadVisitList();
        }
        public void AddVisitAsync()
        {
            this.Model.NewVisit();
        }

        private void SearchVisits()
        {
            this.Model.LoadVisitList();
        }

        private void AddingElement()
        {
            this.Model.NewVisit();
        }

        private void ShowList()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.List:
                    break;

                default:
                    this.CurrentState = ApplicationState.List;
                    break;
            }
        }

        private void ShowMap()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.Map:
                    break;

                default:
                    this.CurrentState = ApplicationState.Map;
                    break;
            }
        }
    }
}
