namespace App_Patient.Logic.Utilities
{
    using System;

    public interface IEventDispatcher
    {
        void Dispatch(Action eventAction);
    }
}