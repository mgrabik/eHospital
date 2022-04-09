namespace App_Patient
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using App_Patient.Logic.Controller;
    using App_Patient.Logic.Utilities;
    using App_Patient.Model;
    using App_Patient.Utilities;
    using App_Patient.View.Converters;
    using App_Patient.Logic.Model.Data;

    public sealed partial class MainPage : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }
        public MainPage()
        {
            this.InitializeComponent();
            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionDataConverter.IsAdding = false;
            this.prescriptionText.Text = "All your prescriptions:";
            this.peselText.Header = "Type your PESEL:";
            this.addButton.Label = "Add new Presciption";
            whatStep = 0;
            Model.WhichElementIAm = 0;
            if (!searchBeforAdd)
            {
                Model.clearNewPrescription();
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionDataConverter.IsAdding = true;
            if (searchBeforAdd)
            {
                searchBeforAdd = false;
            }
            if (Model.IsErrorInAdding)
            {
                whatStep = 0;
            }

            this.prescriptionText.Text = "Your new Presciption:";

            switch (whatStep)
            {
                case 0:
                    this.addButton.Label = "Add Doctor name";
                    this.peselText.Header = "Type Doctor name";
                    this.peselText.Text = "";
                    break;
                case 1:
                    this.addButton.Label = "Add Doctor surname";
                    this.peselText.Header = "Type Doctor surname";
                    this.peselText.Text = "";
                    break;
                case 2:
                    this.addButton.Label = "Add Patient name";
                    this.peselText.Header = "Type Patient name";
                    this.peselText.Text = "";
                    break;
                case 3:
                    this.addButton.Label = "Add Patient surname";
                    this.peselText.Header = "Type Patient surname";
                    this.peselText.Text = "";
                    break;
                case 4:
                    this.addButton.Label = "Add Patient pesel";
                    this.peselText.Header = "Type Patient pesel";
                    this.peselText.Text = "";
                    break;
                case 5:
                    this.addButton.Label = "Add Medicine name";
                    this.peselText.Header = "Type Medicine name";
                    this.peselText.Text = "";
                    break;
                case 6:
                    this.addButton.Label = "Add Medicine amount";
                    this.peselText.Header = "Type Medicine amount";
                    this.peselText.Text = "";
                    break;
                case 7:
                    this.addButton.Label = "Add Date";
                    this.peselText.Header = "Select Date in Calendary";
                    this.peselText.Text = "";
                    break;
                case 8:
                    try
                    {
                        DateTimeOffset dateTimeOffset = (DateTimeOffset)this.selectDate.Date;
                        Prescription.DateOfNewPrescription = dateTimeOffset.UtcDateTime;

                        this.addButton.Label = "Add new Prescription";
                        this.peselText.Header = "Type your PESEL:";
                        this.peselText.Text = "";

                        whatStep = -1;
                    }
                    catch (InvalidOperationException)
                    {
                        Prescription.DateOfNewPrescription = new DateTime(1, 1, 1, 1, 1, 1, 1);
                    }
                    break;
            }
            whatStep++;
        }

        private int whatStep = 0;
        private bool searchBeforAdd = true;
    }
}
