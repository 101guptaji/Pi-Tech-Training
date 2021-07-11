using System.Data;
namespace SampleProject10.ViewModel.Data
{
    /// <summary>
    /// This class is used to hold departments data.
    /// </summary>
    public class Department
    {
        #region Properties
        /// <summary>
        /// Gets or sets the department id.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets department name.
        /// </summary>
        public string DepartmentName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Department"/> class.
        /// </summary>
        /// <param name="departmentDetail">The data row that contains data to initialize a new instance.</param>
        public Department(DataRow departmentDetail)
        {
            DepartmentId = (int)departmentDetail[0];
            DepartmentName = departmentDetail[1].ToString();
        }

        #endregion
    }
}

