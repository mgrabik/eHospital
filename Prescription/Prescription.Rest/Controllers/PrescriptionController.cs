namespace Prescription.Rest
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Prescription.Model.Model;
    using Prescription.Model.Services;
    using Prescription.Logic;
    using System.Collections.Generic;
    using System;

    [ApiController]
    [Route("[controller]")]
    public class PrescriptionController : ControllerBase, IPrescription
    {
        private readonly ILogger<PrescriptionController> logger;

        private readonly IPrescription prescription;

        public PrescriptionController(ILogger<PrescriptionController> logger)
        {
            this.logger = logger;

            prescription = new Prescriptions();
        }

        [HttpGet]
        [Route("GetPrescptions")]
        public List<PrescriptionData> GetPrescriptions(string searchText)
        {
            List<PrescriptionData> prescription = this.prescription.GetPrescriptions(searchText);

            return prescription;
        }
        [HttpPost]
        [Route("AddPrescriptions")]
        public void AddPrescriptions(PrescriptionData[] addedList)
        {
            foreach (var prescription in addedList)
            {
                if (prescription.Doctor.Name == null || prescription.Doctor.Surname == null || prescription.Patient.Name == null || prescription.Patient.Surname == null ||
                    prescription.Patient.PESEL == null || prescription.Medicine.Name == null || prescription.Medicine.Amount == 0 || prescription.Date.Year == 1)
                {
                    throw new Exception("No values can be null. Check your input data");
                }
            }

            this.prescription.AddPrescriptions(addedList);
        }

    }
}
