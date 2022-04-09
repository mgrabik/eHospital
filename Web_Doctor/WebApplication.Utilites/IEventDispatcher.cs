namespace App_Doctor.Logic.Utilities
{
    using System;

    public interface IEventDispatcher
    {
        void Dispatch(Action eventAction);
    }
}