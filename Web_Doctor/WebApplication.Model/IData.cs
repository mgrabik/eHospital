namespace App_Doctor.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using App_Doctor.Logic.Model.Data;

    public interface IData : INotifyPropertyChanged
    {
        string ValueInTextBox { get; set; }

        int WhichElementIAm { get; set; }
        bool IsErrorInAdding { get; set; }

        List<Visit> VisitList { get; }

        Visit SelectedVisit { get; set; }
    }
}
