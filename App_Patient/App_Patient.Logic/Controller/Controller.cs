namespace App_Patient.Logic.Controller
{
    using App_Patient.Model;
    using App_Patient.Logic.Utilities;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;

            this.SearchPrescriptionsCommand = new ControllerCommand(this.SearchPrescription);

            this.AddElement = new ControllerCommand(this.AddingElement);

            this.ShowListCommand = new ControllerCommand(this.ShowList);

            this.ShowMapCommand = new ControllerCommand(this.ShowMap);
        }
    }
}
