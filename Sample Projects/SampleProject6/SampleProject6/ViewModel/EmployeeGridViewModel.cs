using SampleProject6.ViewModel.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SampleProject6.ViewModel
{
    public class EmployeeGridViewModel
    {
        #region Properties
        /// <summary>
        /// connection to the local database SampleProject_db
        /// </summary>
        SqlConnection _connection = new SqlConnection(@"Server=(local);Database=SampleProject_db;Trusted_Connection=Yes;");

        /// <summary>
        /// Gets or sets the list of employees
        /// </summary>
        public List<EmployeeViewModel> EmployeeList { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeGridViewModel"/> class.
        /// </summary>
        public EmployeeGridViewModel()
        {
           
            DataTable dt = new DataTable();

            try
            {
                //get employee data from database
                GetDataFromDb(dt);

                EmployeeList = new List<EmployeeViewModel>();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        EmployeeViewModel emp = new EmployeeViewModel(dr);
                        EmployeeList.Add(emp);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the data from database
        /// </summary>
        /// <param name="dt">The datatable (where data is fetched).</param>
        private void GetDataFromDb(DataTable dt)
        {
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();

            _connection.Open();
            Command.Connection = _connection;
            Command.CommandText = "SELECT e.[EmpId]" +
                                        ",e.[FirstName]" +
                                        ",e.[MiddleName]" +
                                        ",e.[LastName]" +
                                        ",e.[BirthDate]" +
                                        ",e.[Gender]" +
                                        ",e.[Address]" +
                                        ",e.[ContactNumber]" +
                                        ",e.[EmailId]" +
                                        ",e.[JoiningDate]" +
                                        ",e.[ConfirmationDate]" +
                                        ",e.[ExpectedInTime]" +
                                        ",e.[ExpectedOutTime]" +
                                        ",e.[IsResigned]" +
                                        ",e.[Salary]" +
                                        ",e.[Designation]" +
                                        ",e.[DeptId]" +
                                        ", d.[DeptName] AS DepartmentName" +
                                        " FROM [SampleProject_db].[dbo].[Employee] e" +
                                        " LEFT JOIN Department d ON e.DeptId = d.DeptId";
            Adapter.SelectCommand = Command;
            Adapter.Fill(dt);
            _connection.Close();
        }

        #endregion
    }
}
