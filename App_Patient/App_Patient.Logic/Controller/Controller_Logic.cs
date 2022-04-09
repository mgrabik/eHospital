namespace App_Patient.Logic.Controller
{
    using System.Windows.Input;
    using App_Patient.Model;

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

        public ICommand SearchPrescriptionsCommand { get; private set; }

        public ICommand AddElement { get; private set; }

        public ICommand ShowListCommand { get; private set; }

        public ICommand ShowMapCommand { get; private set; }

        private void SearchPrescription()
        {
            this.Model.LoadPrescriptionList();
        }
        private void AddingElement()
        {
            this.Model.NewPrescription();
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
