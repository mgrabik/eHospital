namespace App_Doctor
{
    using App_Doctor.Logic.Controller;
    using App_Doctor.Logic.Utilities;
    using App_Doctor.Model;
    using App_Doctor.Utilities;
    using App_Doctor.View.Converters;
    using App_Doctor.Logic.Model.Data;
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

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

        private void nodeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            VisitDataConverter.IsAdding = false;
            this.visitsText.Text = "Your upcoming visits:";
            this.searchText.Header = "Type your name and surname:";
            this.addButton.Label = "Add new Visit";
            whatStep = 0;
            Model.WhichElementIAm = 0;
            Model.clearNewVisit();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            VisitDataConverter.IsAdding = true;
            this.visitsText.Text = "Your new Visit:";
            if (Model.IsErrorInAdding)
            {
                whatStep = 0;
            }

            switch (whatStep)
            {
                case 0:
                    this.addButton.Label = "Add Doctor name";
                    this.searchText.Header = "Type Doctor name";
                    this.searchText.Text = "";
                    break;
                case 1:
                    this.addButton.Label = "Add Doctor surname";
                    this.searchText.Header = "Type Doctor surname";
                    this.searchText.Text = "";
                    break;
                case 2:
                    this.addButton.Label = "Add Patient name";
                    this.searchText.Header = "Type Patient name";
                    this.searchText.Text = "";
                    break;
                case 3:
                    this.addButton.Label = "Add Patient surname";
                    this.searchText.Header = "Type Patient surname";
                    this.searchText.Text = "";
                    break;
                case 4:
                    this.addButton.Label = "Add Patient pesel";
                    this.searchText.Header = "Type Patient pesel";
                    this.searchText.Text = "";
                    break;
                case 5:
                    this.addButton.Label = "Add Date";
                    this.searchText.Header = "Select Date in Calendary";
                    this.searchText.Text = "";
                    break;
                case 6:
                    try
                    {
                        DateTimeOffset dateTimeOffset = (DateTimeOffset)this.selectDate.Date;
                        Visit.DateOfNewVisit = dateTimeOffset.UtcDateTime;

                        this.addButton.Label = "Add new Visit";
                        this.searchText.Header = "Type your name and surname:";
                        this.searchText.Text = "";

                        whatStep = -1;
                    }
                    catch (InvalidOperationException)
                    {
                        Visit.DateOfNewVisit = new DateTime(1,1,1,1,1,1,1);
                    }
                    break;
            }
            whatStep++;
        }

        private int whatStep = 0;
    }
}
