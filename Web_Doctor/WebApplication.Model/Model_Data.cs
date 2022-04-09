namespace App_Doctor.Model
{
    using App_Doctor.Logic.Model.Data;
    using System;
    using System.Collections.Generic;

    public partial class Model : IData
    {
        public int WhichElementIAm { get; set; }
        public bool IsErrorInAdding { get; set; }
        public string ValueInTextBox
        {
            get { return this.searchText; }
            set
            {
                this.searchText = value;
                
                this.RaisePropertyChanged("NameAndSurname");
            }
        }
        private string searchText;

        public List<Visit> VisitList
        {
            get { return this.visitList; }
            private set
            {
                this.visitList = value;

                this.RaisePropertyChanged("VisitList");
            }
        }
        private List<Visit> visitList = new List<Visit>();

        public Visit SelectedVisit
        {
            get { return this.selectedVisit; }
            set
            {
                this.selectedVisit = value;

                this.RaisePropertyChanged("SelectedVisit");
            }
        }
        private Visit selectedVisit;
    }
}
