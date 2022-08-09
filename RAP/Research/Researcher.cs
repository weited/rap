using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public enum OutputType
    {
        Conference, Journal, Other
    }

    
    class Researcher
    {

        public int id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get { return string.Format("{0}, {1}", FamilyName, GivenName); } }
        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public Uri PhotoUrl { get; set; }

        public List<Publication> publications { get; set; }
        public List<Position> positions { get; set; }
        public List<Position> previousPositions
        {
            get
            {
                return (from position in positions
                        where position.end.Ticks != 0
                        select position).ToList();
            }
        }

        public string Type;
        public string Level;


       
       public string JobTitle { get { return CurrentJobTitle(); } }
        public Position GetCurrentJob()
        {
            return positions[0];
        }
        public string CurrentJobTitle()
        {
            return positions[0].Title();
        }

        

        //Commenced current position: The start date of their current position
        public DateTime? CurrentStart { get; set; }
       

        

        //Commenced with instifution: The start date of their earliest position 
        public DateTime UtasStart { get; set; }


        //Tenure: Time in (fractional) years since the researcher commenced with the institution
        
        
        
        public string Tenure
        {
            get
            {
                DateTime now = DateTime.Now;
                double years = Math.Round(new TimeSpan(now.Ticks - UtasStart.Ticks).TotalDays / 365, 1);
                return years + " years";
            }
        }
        
        public int PublicationsCount
        {
            get
            {
                return publications.Count;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} ({2})", FamilyName, GivenName, Title);
        }
    }
}
