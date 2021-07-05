using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject1
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public char? Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public bool IsResigned { get; set; }
        public decimal? Salary { get; set; }
        public string Designation { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }




        #region Constructor
        public Employee(DataRow empColumns)
        {
            EmployeeId = (int)empColumns[0];
            FirstName = empColumns[1].ToString();
            MiddleName = empColumns[2].ToString();
            LastName = empColumns[3].ToString();

            string StringBirthDate = empColumns[4].ToString();
            if (StringBirthDate != "")
            {
                BirthDate = Convert.ToDateTime(StringBirthDate);
            }

            string StringGender = empColumns[5].ToString();
            if (StringGender != "")
            {
                Gender = Convert.ToChar(StringGender);
            }

            Address = empColumns[6].ToString();
            ContactNumber = empColumns[7].ToString();
            EmailId = empColumns[8].ToString();

            string StringJoiningDate = empColumns[9].ToString();
            if (StringJoiningDate != "")
            {
                JoiningDate = Convert.ToDateTime(StringJoiningDate);
            }

            string StringConfirmationDate = empColumns[10].ToString();
            if (StringConfirmationDate != "")
            {
                ConfirmationDate = Convert.ToDateTime(StringConfirmationDate);
            }

            IsResigned = empColumns[13].ToString() == "" ? false : (bool)(empColumns[13]);
            Salary = empColumns[14].ToString() == "" ? null : (decimal?)empColumns[14];
            Designation = empColumns[15].ToString();
            DepartmentId = empColumns[16].ToString() == "" ? null : (int?)empColumns[16];
            DepartmentName = empColumns[17].ToString();
        }
        #endregion
    }
}
