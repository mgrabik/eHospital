namespace App_Patient.Model
{
    using App_Patient.Logic.Model.Service;
    using App_Patient.Logic.Model.Data;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class Model : IOperations
    {
        private static Prescription newPrescriptionToAdd = new Prescription("",new Doctor("",""), new Patient("", "",""), new Medicine("",0), new DateTime());
        private Prescription[] arrayOfNewPrescription = new Prescription[1];
        public void LoadPrescriptionList()
        {

            Task.Run(() => this.LoadPrescriptionTask());
        }

        public void NewPrescription()
        {
            if (this.IsErrorInAdding)
            {
                clearNewPrescription();
            }
            this.IsErrorInAdding = false;
            this.arrayOfNewPrescription[0] = newPrescriptionToAdd;
            try
            {
                switch (this.WhichElementIAm)
                {
                    case 0: //Clear list view
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 1: //Adding Doctor name
                        newPrescriptionToAdd.Doctor.Name = this.ValueInTextBox.ToString();
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 2: //Adding Doctor surname
                        newPrescriptionToAdd.Doctor.Surname = this.ValueInTextBox.ToString();
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 3: //Adding Patient name
                        newPrescriptionToAdd.Patient.Name = this.ValueInTextBox.ToString();
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 4: //Adding Patient surname
                        newPrescriptionToAdd.Patient.Surname = this.ValueInTextBox.ToString();
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 5: //Adding Patient PESEL
                        newPrescriptionToAdd.Patient.PESEL = this.ValueInTextBox.ToString();
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 6: //Adding Medicine name
                        newPrescriptionToAdd.Medicine.Name = this.ValueInTextBox.ToString();
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 7: //Adding Medicine amount
                        newPrescriptionToAdd.Medicine.Amount = Int32.Parse(this.ValueInTextBox);
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 8: //Adding Date
                        if (Prescription.DateOfNewPrescription.Year == 1)
                        {
                            throw new NullReferenceException();
                        }
                        else
                        {
                            newPrescriptionToAdd.Date = Prescription.DateOfNewPrescription;
                            this.PrescriptionList = this.arrayOfNewPrescription.ToList();

                            WhichElementIAm = -1;
                            var sendTask = Task.Run(() => this.PrescriptionPostTask());
                            sendTask.Wait();
                            clearNewPrescription();
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
                        newPrescriptionToAdd.Doctor.Name = "The name entered is not valid\nPlease create new Prescription again by clicking the add button";
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 2: //Adding Doctor surname
                        newPrescriptionToAdd.Doctor.Surname = "The surname entered is not valid\nPlease create new Prescription again by clicking the add button";
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 3: //Adding Patient name
                        newPrescriptionToAdd.Patient.Name = "The name entered is not valid\nPlease create new Prescription again by clicking the add button";
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 4: //Adding Patient surname
                        newPrescriptionToAdd.Patient.Surname = "The surname entered is not valid\nPlease create new Prescription again by clicking the add button";
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 5: //Adding Patient PESEL
                        newPrescriptionToAdd.Patient.PESEL = "The pesel entered is not valid\nPlease create new Prescription again by clicking the add button";
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 6: //Adding Medicine name
                        newPrescriptionToAdd.Medicine.Name = "The name entered is not valid\nPlease create new Prescription again by clicking the add button";
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 7: //Adding Medicine amount
                        newPrescriptionToAdd.Patient.PESEL = "The amount entered is not valid\nPlease create new Prescription again by clicking the add button";
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 8:
                        //Adding Date
                        newPrescriptionToAdd.Patient.PESEL = "The date entered below is not valid\nPlease create new Prescription again by clicking the add button";
                        this.PrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                }
                this.WhichElementIAm = 0;
                this.IsErrorInAdding = true;
            }
        }

        private void LoadPrescriptionTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("docker");

            try
            {
                Prescription[] Prescriptions = networkClient.GetPrescriptions(this.ValueInTextBox);

                this.PrescriptionList = Prescriptions.ToList();
            }
            catch (Exception)
            {
            }
        }

        private void PrescriptionPostTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("docker");
            try
            {
                networkClient.PostPrescriptions(newPrescriptionToAdd);
            }
            catch (Exception)
            {
            }
        }

        public void clearNewPrescription()
        {
            newPrescriptionToAdd.Doctor.Name = "";
            newPrescriptionToAdd.Doctor.Surname = "";
            newPrescriptionToAdd.Patient.Name = "";
            newPrescriptionToAdd.Patient.Surname = "";
            newPrescriptionToAdd.Patient.PESEL = "";
            newPrescriptionToAdd.Medicine.Name = "";
            newPrescriptionToAdd.Medicine.Amount = 0;
            newPrescriptionToAdd.Date = new DateTime();
            this.PrescriptionList = this.arrayOfNewPrescription.ToList();
        }
    }
}
