namespace App_Doctor.Logic.Utilities
{
    using System;

    public class EmptyEventDispatcher : IEventDispatcher
    {
        #region IEventDispatcher

        public void Dispatch(Action eventAction)
        {
        }
        #endregion
    }
}
