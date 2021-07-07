using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject6.ViewModel.Data
{
    public class EmployeeViewModel
    {
        
        #region Properties
        /// <summary>
        /// Gets or sets employee id.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets employee first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets employee middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets employee last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets employee birth date.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or sets gender.
        /// </summary>
        public char? Gender { get; set; }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets contact number.
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// Gets or sets email id.
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets joining date.
        /// </summary>
        public DateTime? JoiningDate { get; set; }

        /// <summary>
        /// Gets or sets confirmation date.
        /// </summary>
        public DateTime? ConfirmationDate { get; set; }

        /// <summary>
        /// Gets or sets the value if employee has resigned.
        /// </summary>
        public bool IsResigned { get; set; }

        /// <summary>
        /// Gets or sets salary.
        /// </summary>
        public decimal? Salary { get; set; }

        /// <summary>
        /// Gets or sets designation.
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets Department id.
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets department name.
        /// </summary>
        public string DepartmentName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeViewModel"/> class.
        /// </summary>
        /// <param name="dr">The data row that contains data to initialize a new instance.</param>
        public EmployeeViewModel(DataRow dr)
        {
            EmployeeId = (int)dr[0];
            FirstName = dr[1].ToString();
            MiddleName = dr[2].ToString();
            LastName = dr[3].ToString();

            string StringBirthDate = dr[4].ToString();
            if (StringBirthDate != "")
            {
                BirthDate = Convert.ToDateTime(StringBirthDate);
            }

            string StringGender = dr[5].ToString();
            if (StringGender != "")
            {
                Gender = Convert.ToChar(StringGender);
            }

            Address = dr[6].ToString();
            ContactNumber = dr[7].ToString();
            EmailId = dr[8].ToString();

            string StringJoiningDate = dr[9].ToString();
            if (StringJoiningDate != "")
            {
                JoiningDate = Convert.ToDateTime(StringJoiningDate);
            }

            string StringConfirmationDate = dr[10].ToString();
            if (StringConfirmationDate != "")
            {
                ConfirmationDate = Convert.ToDateTime(StringConfirmationDate);
            }

            IsResigned = dr[13].ToString() == "" ? false : (bool)(dr[13]);
            Salary = dr[14].ToString() == "" ? null : (decimal?)dr[14];
            Designation = dr[15].ToString();
            DepartmentId = dr[16].ToString() == "" ? null : (int?)dr[16];
            DepartmentName = dr[17].ToString();
        }

        #endregion
    }
}
