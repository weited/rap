using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Research
{
    class Student:Researcher
    {
        public string Degree { get; set; }
        public Researcher Supervisor { get; set; }
    }
}
