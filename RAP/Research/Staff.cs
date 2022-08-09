using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    class Staff: Researcher
    {
        public int Supervisions { get; set; }
        // Threeyear string
        public string ThreeYearAverage
        {
            get
            {
                int threeYearsAgo = DateTime.Now.Year - 3;
                var pubCount = publications.Where(x => Int32.Parse(x.Year) >= threeYearsAgo).Count() / 3f;
                return String.Format("{0:0.00}", pubCount);
            }
        }


        readonly Dictionary<EmploymentLevel, double> expectedPub = new Dictionary<EmploymentLevel, double>() 
        {
                    { EmploymentLevel.A, 0.5},
                    { EmploymentLevel.B, 1},
                    { EmploymentLevel.C, 2},
                    { EmploymentLevel.D, 3.2},
                    { EmploymentLevel.E, 4},
        };


        public double GetPerformance
        {
            get
            {

                return Double.Parse(ThreeYearAverage) / expectedPub[GetCurrentJob().Level];
                 
            }
        }

        public string Performance
        {
            get
            {
                return GetPerformance * 100 + "%";
            }
        }

    }
}
