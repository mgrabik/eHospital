namespace Visit.Rest
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Visit.Model.Model;
    using Visit.Model.Services;
    using Visit.Logic;
    using System.Collections.Generic;
    using System;

    [ApiController]
    [Route("[controller]")]
    public class VisitController : ControllerBase, IVisit
    {
        private readonly ILogger<VisitController> logger;

        private readonly IVisit visit;

        public VisitController(ILogger<VisitController> logger)
        {
            this.logger = logger;

            visit = new Visits();
        }

        [HttpGet]
        [Route("GetVisits")]
        public List<VisitD> GetVisits(string searchText)
        {
            List<VisitD> visit = this.visit.GetVisits(searchText);

            return visit;
        }

        [HttpPost]
        [Route("AddVisits")]
        public void AddVisits(VisitD[] addedList)
        {

            foreach (VisitD visit in addedList)
            {
                if (visit.Doctor.Name == null || visit.Doctor.Surname == null || visit.Patient.Name == null || visit.Patient.Surname == null ||
                    visit.Patient.PESEL == null || visit.Date.Year == 1)
                {
                    throw new Exception("No values can be null. Check your input data");
                }
            }
            this.visit.AddVisits(addedList);
        }

    }
}
