namespace App_Patient.Tests.Model
{
    using App_Patient.Tests.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Operations
    {
        private static FakePrescription newPrescriptionToAdd = new FakePrescription("", new FakeDoctor("", ""), new FakePatient("", "", ""), new FakeMedicine("", 0), new DateTime());
        private FakePrescription[] arrayOfNewPrescription = new FakePrescription[1];
        public List<FakePrescription> OutputFakePrescriptionList = new List<FakePrescription>();
        private int WhichElementIAm = 0;
        public string ValueInTextBox;
        private bool IsErrorInAdding = false;

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
                        this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 1: //Adding Doctor name
                        newPrescriptionToAdd.Doctor.Name = this.ValueInTextBox.ToString();
                        this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 2: //Adding Doctor surname
                        newPrescriptionToAdd.Doctor.Surname = this.ValueInTextBox.ToString();
                        this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 3: //Adding Patient name
                        newPrescriptionToAdd.Patient.Name = this.ValueInTextBox.ToString();
                        this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 4: //Adding Patient surname
                        newPrescriptionToAdd.Patient.Surname = this.ValueInTextBox.ToString();
                        this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 5: //Adding Patient PESEL
                        newPrescriptionToAdd.Patient.PESEL = this.ValueInTextBox.ToString();
                        this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 6: //Adding Medicine name
                        newPrescriptionToAdd.Medicine.Name = this.ValueInTextBox.ToString();
                        this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 7: //Adding Medicine amount
                        newPrescriptionToAdd.Medicine.Amount = Int32.Parse(this.ValueInTextBox);
                        this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
                        break;
                    case 8: //Adding Date
                        if (FakePrescription.DateOfNewPrescription.Year == 1)
                        {
                            throw new NullReferenceException();
                        }
                        else
                        {
                            newPrescriptionToAdd.Date = FakePrescription.DateOfNewPrescription;
                            this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();

                            WhichElementIAm = -1;
                            clearNewPrescription();
                        }
                        break;
                }
                this.ValueInTextBox = null;
                this.WhichElementIAm++;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
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
            this.OutputFakePrescriptionList = this.arrayOfNewPrescription.ToList();
        }

        public FakePrescription RunNewPrescription(string value1, string value2, string value3, string value4, string value5, string value6, int value7, DateTime value8)
        {
            for (int i = 0; i <= 8; i++)
            {
                switch (this.WhichElementIAm)
                {
                    case 0:
                        NewPrescription();
                        break;
                    case 1:
                        this.ValueInTextBox = value1;
                        NewPrescription();
                        break;
                    case 2:
                        this.ValueInTextBox = value2;
                        NewPrescription();
                        break;
                    case 3:
                        this.ValueInTextBox = value3;
                        NewPrescription();
                        break;
                    case 4:
                        this.ValueInTextBox = value4;
                        NewPrescription();
                        break;
                    case 5:
                        this.ValueInTextBox = value5;
                        NewPrescription();
                        break;
                    case 6:
                        this.ValueInTextBox = value6;
                        NewPrescription();
                        break;
                    case 7:
                        this.ValueInTextBox = value7.ToString();
                        NewPrescription();
                        break;
                    case 8:
                        FakePrescription.DateOfNewPrescription = value8;
                        NewPrescription();
                        break;
                }
            }
            return this.OutputFakePrescriptionList[0];

        }
    }
}
