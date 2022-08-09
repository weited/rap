using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Research;
using RAP.Database;
using System.Collections.ObjectModel;

namespace RAP.Control
{
    class ResearcherController
    {
        public static Researcher CurrentResearcher { get; private set; }
        private ERDAdapter DataBase = new ERDAdapter();
        private List<Researcher> researchers;
        public ObservableCollection<Researcher> viewableResearchers;
        
        private string nameFilter = "";
        private string empLevelFilter = "All";
        public ResearcherController()
        {
            ERDAdapter DataBase = new ERDAdapter();
            researchers = DataBase.fetchResearcherList();
            viewableResearchers = new ObservableCollection<Researcher>(researchers);
        }

        public ObservableCollection<Researcher> LoadResearchers()
{
            return viewableResearchers;
        }

        
        public void FilterByName(string name)
        {
            nameFilter = name;
            setFilter();
        }
        public void FilterByEmpLevel(string empLevel)
        {
            empLevelFilter = empLevel;
            setFilter();
        }
        private void setFilter()
        {
            viewableResearchers.Clear();
            
            var selectedResearchers = (from researcher in researchers
                                      where researcher.GivenName.ToUpper().Contains(nameFilter.ToUpper()) || researcher.FamilyName.ToUpper().Contains(nameFilter.ToUpper())
                                      select researcher).ToList();
            
            if (empLevelFilter != "All")
            {

            
                if (empLevelFilter == "Student")
                {
                    selectedResearchers = (from researcher in selectedResearchers
                                           where researcher.Type == "Student"
                                           select researcher).ToList();
                }
                else
                {
                    selectedResearchers = (from researcher in selectedResearchers
                                           where researcher.Level == empLevelFilter
                                           select researcher).ToList();
                }
            }
            selectedResearchers.ForEach(viewableResearchers.Add);
        }
       public Researcher LoadResearcherDetails(int id)
        {
            CurrentResearcher = DataBase.fetchResearcherDetails(id);
            return DataBase.fetchResearcherDetails(id);
        }
        /*  add for button show me */
        public List<Researcher> fetchSupervisions(Researcher researcher)

        {
            return DataBase.fetchSupervisions(researcher.id);
        }


       
    }
}
