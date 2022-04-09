namespace App_Patient.Model
{
    using App_Patient.Logic.Model.Data;
    using System.Collections.Generic;

    public partial class Model : IData
    {
        public int WhichElementIAm { get; set; }
        public bool IsErrorInAdding { get; set; }
        public string ValueInTextBox
        {
            get { return this.pesel; }
            set
            {
                this.pesel = value;

                this.RaisePropertyChanged("PESEL");
            }
        }
        private string pesel;

        public List<Prescription> PrescriptionList
        {
            get { return this.prescriptionList; }
            private set
            {
                this.prescriptionList = value;

                this.RaisePropertyChanged("PrescriptionList");
            }
        }
        private List<Prescription> prescriptionList = new List<Prescription>();

        public Prescription SelectedPrescription
        {
            get { return this.selectedPrescription; }
            set
            {
                this.selectedPrescription = value;

                this.RaisePropertyChanged("SelectedPrescription");
            }
        }
        private Prescription selectedPrescription;
    }
}
