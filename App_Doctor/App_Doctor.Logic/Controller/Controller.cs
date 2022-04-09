namespace App_Doctor.Logic.Controller
{
    using App_Doctor.Model;
    using App_Doctor.Logic.Utilities;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;

            this.SearchVisitsCommand = new ControllerCommand(this.SearchVisits);

            this.AddElement = new ControllerCommand(this.AddingElement);

            this.ShowListCommand = new ControllerCommand(this.ShowList);

            this.ShowMapCommand = new ControllerCommand(this.ShowMap);
        }
    }
}
