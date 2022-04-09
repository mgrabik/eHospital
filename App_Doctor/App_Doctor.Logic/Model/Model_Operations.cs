namespace App_Doctor.Model
{
    using App_Doctor.Logic.Model.Service;
    using App_Doctor.Logic.Model.Data;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class Model : IOperations
    {
        private static Visit NewVisitToAdd = new Visit("", new Doctor("", ""), new Patient("", "", ""), new DateTime());
        private Visit[] listofNewVisit = new Visit[1];

        public void LoadVisitList()
        {
            Task.Run(() => this.LoadVisitTask());
        }

        public void NewVisit()
        {
            if (this.IsErrorInAdding)
            {
                clearNewVisit();
            }
            this.IsErrorInAdding = false;
            this.listofNewVisit[0] = NewVisitToAdd;
            try
            {
                switch (this.WhichElementIAm)
                {
                    case 0: //Clear list view
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 1: //Adding Doctor name
                        NewVisitToAdd.Doctor.Name = this.ValueInTextBox.ToString();
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 2: //Adding Doctor surname
                        NewVisitToAdd.Doctor.Surname = this.ValueInTextBox.ToString();
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 3: //Adding Patient name
                        NewVisitToAdd.Patient.Name = this.ValueInTextBox.ToString();
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 4: //Adding Patient surname
                        NewVisitToAdd.Patient.Surname = this.ValueInTextBox.ToString();
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 5: //Adding Patient PESEL
                        NewVisitToAdd.Patient.PESEL = this.ValueInTextBox.ToString();
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 6: //Adding Date
                        if (Visit.DateOfNewVisit.Year == 1)
                        {
                            throw new NullReferenceException();
                        }
                        else
                        {
                            NewVisitToAdd.Date = Visit.DateOfNewVisit;
                            this.VisitList = this.listofNewVisit.ToList();

                            WhichElementIAm = -1;
                            var sendTask = Task.Run(() => this.VisitPostTask());
                            sendTask.Wait();
                            clearNewVisit();
                        }
                        break;
                }
                this.ValueInTextBox = null;
                this.WhichElementIAm++;
            }
            catch (NullReferenceException)
            {
                this.IsErrorInAdding = true;
                switch (this.WhichElementIAm)
                {
                    case 1: //Adding Doctor name
                        NewVisitToAdd.Doctor.Name = "The name entered is not valid\nPlease create new visit again by clicking the add button";
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 2: //Adding Doctor surname
                        NewVisitToAdd.Doctor.Surname = "The surname entered is not valid\nPlease create new visit again by clicking the add button";
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 3: //Adding Patient name
                        NewVisitToAdd.Patient.Name = "The name entered is not valid\nPlease create new visit again by clicking the add button";
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 4: //Adding Patient surname
                        NewVisitToAdd.Patient.Surname = "The surname entered is not valid\nPlease create new visit again by clicking the add button";
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 5: //Adding Patient PESEL
                        NewVisitToAdd.Patient.PESEL = "The pesel entered is not valid\nPlease create new visit again by clicking the add button";
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                    case 6:
                        //Adding Date
                        NewVisitToAdd.Patient.PESEL = "The date entered below is not valid\nPlease create new visit again by clicking the add button";
                        this.VisitList = this.listofNewVisit.ToList();
                        break;
                }
                this.WhichElementIAm = 0;
                this.IsErrorInAdding = true;
            }
        }

        private void LoadVisitTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("docker");

            try
            {
                Visit[] visits = networkClient.GetVisits(this.ValueInTextBox);

                this.VisitList = visits.ToList();
            }
            catch (Exception)
            {
            }
        }

        private void VisitPostTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("docker");
            try
            {
                networkClient.PostVisits(NewVisitToAdd);
            }
            catch (Exception)
            {
            }
        }

        public void clearNewVisit()
        {
            NewVisitToAdd.Doctor.Name = "";
            NewVisitToAdd.Doctor.Surname = "";
            NewVisitToAdd.Patient.Name = "";
            NewVisitToAdd.Patient.Surname = "";
            NewVisitToAdd.Patient.PESEL = "";
            NewVisitToAdd.Date = new DateTime();
            this.VisitList = this.listofNewVisit.ToList();
        }
    }
}

