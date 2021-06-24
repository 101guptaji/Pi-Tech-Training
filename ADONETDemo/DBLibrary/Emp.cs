using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class Emp
    {
        public int Empno { get; set; }

        public string EmpName { get; set; }

        public DateTime? HireDate { get; set; }

        public decimal? Salary { get; set; }

        public override string ToString()
        {
            return string.Format($"EmpNo: {Empno} EmpName: {EmpName} HireDate: {HireDate} Salary: {Salary}");
        }
    }
}
