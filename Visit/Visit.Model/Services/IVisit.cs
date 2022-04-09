namespace Visit.Model.Services
{
    using System.Collections.Generic;
    using Visit.Model.Model;

    public interface IVisit
    {
        public List<VisitD> GetVisits(string searchText);
        public void AddVisits(VisitD[] addedList);
    }
}
