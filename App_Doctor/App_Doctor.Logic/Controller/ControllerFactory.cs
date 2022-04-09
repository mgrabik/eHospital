namespace App_Doctor.Logic.Controller
{
    using App_Doctor.Model;
    using App_Doctor.Logic.Utilities;

    public static class ControllerFactory
    {
        private static IController controller;

        public static IController GetController(IEventDispatcher dispatcher)
        {
            if (controller == null)
            {
                IModel newModel = new Model(dispatcher) as IModel;

                IController newController = new Controller(dispatcher, newModel);

                controller = newController;
            }
            return controller;
        }
    }
}
