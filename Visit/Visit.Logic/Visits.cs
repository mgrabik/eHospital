namespace Visit.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Visit.Model.Model;
    using Visit.Model.Services;

    public class Visits : IVisit
    {
        private static XmlDocument visitXmlDocument;

        public static List<VisitD> Visit;

        private static readonly object visitLock = new object();

        private const string visitXmlFilename = "Visits.xml";
        private const string visitXsdFilename = "VisitSchema.xsd";

        static Visits()
        {
            lock (Logic.Visits.visitLock)
            {
                VisitReader visitReader = new VisitReader();

                Visits.visitXmlDocument = visitReader.ReadVisitXml(visitXmlFilename, visitXsdFilename);

                Visits.Visit = visitReader.ReadVisits(visitXmlDocument).ToList<VisitD>();
            }
        }

        public Visits()
        {
        }

        public List<VisitD> GetVisits(string searchText)
        {
            lock (Visits.visitLock)
            {
                return Visits.Visit;
            }
        }
        public void AddVisits(VisitD[] addedList)
        {
            lock (Logic.Visits.visitLock)
            {
                VisitsWriter.WriteVisitsXml(addedList);
            }
        }
    }
}
