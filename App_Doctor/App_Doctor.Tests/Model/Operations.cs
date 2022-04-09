namespace App_Doctor.Tests.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using App_Doctor.Tests.Data;
    public class Operations
    {
        private static FakeVisit NewFakeVisitToAdd = new FakeVisit("", new FakeDoctor("", ""), new FakePatient("", "", ""), new DateTime());
        private FakeVisit[] listofNewFakeVisit = new FakeVisit[1];
        public List<FakeVisit> OutputFakeVisitList = new List<FakeVisit>();
        private int WhichElementIAm = 0;
        public string ValueInTextBox;
        private bool IsErrorInAdding = false;


        public void NewVisit()
        {
            if (this.IsErrorInAdding)
            {
                clearNewFakeVisit();
            }
            this.IsErrorInAdding = false;
            this.listofNewFakeVisit[0] = NewFakeVisitToAdd;
            try
            {
                switch (this.WhichElementIAm)
                {
                    case 0: //Clear list view
                        this.OutputFakeVisitList = this.listofNewFakeVisit.ToList();
                        break;
                    case 1: //Adding FakeDoctor name
                        NewFakeVisitToAdd.Doctor.Name = this.ValueInTextBox.ToString();
                        this.OutputFakeVisitList = this.listofNewFakeVisit.ToList();
                        break;
                    case 2: //Adding FakeDoctor surname
                        NewFakeVisitToAdd.Doctor.Surname = this.ValueInTextBox.ToString();
                        this.OutputFakeVisitList = this.listofNewFakeVisit.ToList();
                        break;
                    case 3: //Adding Patient name
                        NewFakeVisitToAdd.Patient.Name = this.ValueInTextBox.ToString();
                        this.OutputFakeVisitList = this.listofNewFakeVisit.ToList();
                        break;
                    case 4: //Adding Patient surname
                        NewFakeVisitToAdd.Patient.Surname = this.ValueInTextBox.ToString();
                        this.OutputFakeVisitList = this.listofNewFakeVisit.ToList();
                        break;
                    case 5: //Adding Patient PESEL
                        NewFakeVisitToAdd.Patient.PESEL = this.ValueInTextBox.ToString();
                        this.OutputFakeVisitList = this.listofNewFakeVisit.ToList();
                        break;
                    case 6: //Adding Date
                        if (FakeVisit.DateOfNewVisit.Year == 1)
                        {
                            throw new NullReferenceException();
                        }
                        else
                        {
                            NewFakeVisitToAdd.Date = FakeVisit.DateOfNewVisit;
                            this.OutputFakeVisitList = this.listofNewFakeVisit.ToList();

                            WhichElementIAm = -1;
                            /*    Run task for send data to other service
                            
                            var sendTask = Task.Run(() => this.VisitPostTask());
                            sendTask.Wait();
                            */
                            clearNewFakeVisit();
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

        public FakeVisit RunNewVisit(string value1, string value2, string value3, string value4, string value5, DateTime value6)
        {
            for(int i = 0; i < 7; i++)
            {
                switch (this.WhichElementIAm)
                {
                    case 0:
                        NewVisit();
                        break;
                    case 1:
                        this.ValueInTextBox = value1;
                        NewVisit();
                        break;
                    case 2:
                        this.ValueInTextBox = value2;
                        NewVisit();
                        break;
                    case 3:
                        this.ValueInTextBox = value3;
                        NewVisit();
                        break;
                    case 4:
                        this.ValueInTextBox = value4;
                        NewVisit();
                        break;
                    case 5:
                        this.ValueInTextBox = value5;
                        NewVisit();
                        break;
                    case 6:
                        FakeVisit.DateOfNewVisit = value6;
                        NewVisit();
                        break;
                }
            }
            return this.OutputFakeVisitList[0];

        }


        public void clearNewFakeVisit()
        {
            NewFakeVisitToAdd.Doctor.Name = "";
            NewFakeVisitToAdd.Doctor.Surname = "";
            NewFakeVisitToAdd.Patient.Name = "";
            NewFakeVisitToAdd.Patient.Surname = "";
            NewFakeVisitToAdd.Patient.PESEL = "";
            NewFakeVisitToAdd.Date = new DateTime();
            this.OutputFakeVisitList = this.listofNewFakeVisit.ToList();
        }

    }
}
