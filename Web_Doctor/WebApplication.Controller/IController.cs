namespace App_Doctor.Logic.Controller
{
    using System.ComponentModel;
    using System.Windows.Input;

    using App_Doctor.Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ApplicationState CurrentState { get; }

        ICommand SearchVisitsCommand { get; }

        ICommand AddElement { get; }

        ICommand ShowListCommand { get; }

        ICommand ShowMapCommand { get; }

        void SearchVisitAsync();
        void AddVisitAsync();
    }
}
