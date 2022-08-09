using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Database;
using RAP.Research;

namespace RAP.Control
{
    class PublicationsController
    {
        public static List<Tuple<int, int>> CumulativeCount()
        {
            List<Tuple<int, int>> results = new List<Tuple<int, int>>();
            Researcher researcher = ResearcherController.CurrentResearcher;

            if (researcher != null)
            {
                int start = researcher.UtasStart.Year;
                int current = DateTime.Today.Year;

                for (int year = start; year <= current; year++)
                {
                    var filterQuery =
                        from entry in ResearcherController.CurrentResearcher.publications
                        where Int32.Parse(entry.Year) == year
                        select entry;
                    results.Add(new Tuple<int, int>(year, filterQuery.Count()));
                }
                return results;
            }
            return null;
        }
    }
}
