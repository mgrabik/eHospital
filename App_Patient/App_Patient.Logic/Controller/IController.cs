namespace App_Patient.Logic.Controller
{
    using System.ComponentModel;
    using System.Windows.Input;

    using App_Patient.Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ApplicationState CurrentState { get; }

        ICommand AddElement { get; }

        ICommand SearchPrescriptionsCommand { get; }

        ICommand ShowListCommand { get; }

        ICommand ShowMapCommand { get; }
    }
}
