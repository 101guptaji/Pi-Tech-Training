using System;
using System.Data;

namespace SampleProject9.ViewModel.Data
{
    /// <summary>
    /// This class holds employee data.
    /// </summary>
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
        /// <param name="employeeData">The data row that contains data to initialize a new instance.</param>
        public EmployeeViewModel(DataRow employeeData)
        {
            EmployeeId = (int)employeeData[0];
            FirstName = employeeData[1].ToString();
            MiddleName = employeeData[2].ToString();
            LastName = employeeData[3].ToString();

            string StringBirthDate = employeeData[4].ToString();
            if (StringBirthDate != "")
            {
                BirthDate = Convert.ToDateTime(StringBirthDate);
            }

            string StringGender = employeeData[5].ToString();
            if (StringGender != "")
            {
                Gender = Convert.ToChar(StringGender);
            }

            Address = employeeData[6].ToString();
            ContactNumber = employeeData[7].ToString();
            EmailId = employeeData[8].ToString();

            string StringJoiningDate = employeeData[9].ToString();
            if (StringJoiningDate != "")
            {
                JoiningDate = Convert.ToDateTime(StringJoiningDate);
            }

            string StringConfirmationDate = employeeData[10].ToString();
            if (StringConfirmationDate != "")
            {
                ConfirmationDate = Convert.ToDateTime(StringConfirmationDate);
            }

            IsResigned = employeeData[13].ToString() == "" ? false : (bool)(employeeData[13]);
            Salary = employeeData[14].ToString() == "" ? null : (decimal?)employeeData[14];
            Designation = employeeData[15].ToString();
            DepartmentId = employeeData[16].ToString() == "" ? null : (int?)employeeData[16];
            DepartmentName = employeeData[17].ToString();
        }
       
        /// <summary>
        /// Default constructor. Initializes a new instance of the <see cref="EmployeeViewModel"/> class. 
        /// </summary>
        public EmployeeViewModel()
        { }

        #endregion
    }
}
