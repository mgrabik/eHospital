namespace App_Patient.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using App_Patient.Logic.Model.Data;

    public interface IData : INotifyPropertyChanged
    {
        string ValueInTextBox { get; set; }

        int WhichElementIAm { get; set; }

        bool IsErrorInAdding { get; set; }

        List<Prescription> PrescriptionList { get; }

        Prescription SelectedPrescription { get; set; }
        void clearNewPrescription();
    }
}
