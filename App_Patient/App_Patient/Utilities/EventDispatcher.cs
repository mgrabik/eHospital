namespace App_Patient.Utilities
{
    using System;
    using System.Threading.Tasks;

    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;
    using App_Patient.Logic.Utilities;
    public class EventDispatcher : IEventDispatcher
    {
        #region IEventDispatcher

        public async void Dispatch(Action eventAction)
        {
            DispatchedHandler dispatchedHandler = () => eventAction();

            CoreDispatcher dispatcher = this.GetCoreDispatcher();

            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, dispatchedHandler);
        }

        public void Dispatch2(Action eventAction)
        {
            DispatchedHandler dispatchedHandler = () => eventAction();

            CoreDispatcher dispatcher = this.GetCoreDispatcher();

            Action action = async () => await dispatcher.RunAsync(CoreDispatcherPriority.Normal, dispatchedHandler);

            Task.Run(action);
        }
        #endregion

        private CoreDispatcher GetCoreDispatcher()
        {
            return CoreApplication.MainView.CoreWindow.Dispatcher;
        }
    }
}
