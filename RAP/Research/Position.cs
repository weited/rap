using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    public enum EmploymentLevel
    {
        Student, A, B, C, D, E
    }
    class Position
    {
        public EmploymentLevel Level { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string Title()
        {
            string empLevel = "";
            switch (Level)
            {
                case EmploymentLevel.A:
                    empLevel = "Postdoc";
                    break;
                case EmploymentLevel.B:
                    empLevel = "Lecturer";
                    break;
                case EmploymentLevel.C:
                    empLevel = "Senior Lecturer";
                    break;
                case EmploymentLevel.D:
                    empLevel = "Associate Professor";
                    break;
                case EmploymentLevel.E:
                    empLevel = "Professor";
                    break;


                default:
                    empLevel = "Student";
                    break;
            }
                
            return empLevel;
        }
        public string ToTitle(EmploymentLevel l)
        {
            return "";
        }
        
        public override string ToString()
        {
            if (Level == EmploymentLevel.Student) return null;
            return string.Format("{0}  {1}  {2}", start.ToString("dd-MM-yyyy"), end.ToString("dd-MM-yyyy"), Title());
        }
        
    }
}
