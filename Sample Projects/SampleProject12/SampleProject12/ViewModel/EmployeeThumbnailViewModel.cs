using SampleProject12.Common;
using SampleProject12.ViewModel.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleProject12.ViewModel
{
    /// <summary>
    /// This class is view model for EmployeeThumbnailView.
    /// </summary>
    /// <seealso cref="SampleProject12.Common.SpecialisedObservableCollection"/>
    class EmployeeThumbnailViewModel : SpecialisedObservableCollection<EmployeeViewModel>
    {
        #region Properties
        /// <summary>
        /// connection to the local database SampleProject_db
        /// </summary>
        SqlConnection _connection = new SqlConnection(@"Server=(local);Database=SampleProject_db;Trusted_Connection=Yes;");

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeThumbnailViewModel"/> class.
        /// </summary>
        public EmployeeThumbnailViewModel()
        {

            if (IsInDesignMode) //Note IsInDesignMode is the property provided by base class i.e. SpecialisedObservableCollection
            {
                List<EmployeeViewModel> lstEmployeeForDesignTime = new List<EmployeeViewModel>();
                for (int i = 1; i <= 10; i++)
                {
                    EmployeeViewModel emp = new EmployeeViewModel();
                    emp.EmployeeId = i;
                    emp.FirstName = "FName" + i;
                    emp.MiddleName = "MName" + i;
                    emp.LastName = "LName" + i;
                    emp.BirthDate = DateTime.Now.AddYears(-(20 + i)).AddDays(2 * i);
                    emp.Gender = i % 2 == 0 ? 'M' : 'F';
                    emp.Address = "Design time address for line number" + i;
                    emp.ContactNumber = (9890586330 + (i * 3)).ToString();
                    emp.EmailId = "FName" + i + "@gmail.com";
                    emp.JoiningDate = DateTime.Now.AddYears(-10 + i).AddDays(i);
                    emp.ConfirmationDate = DateTime.Now.AddYears(-10 + i).AddMonths(2).AddDays(i);
                    emp.IsResigned = (i == 2 || i == 5) ? true : false;
                    emp.Salary = 30000 + (i * 2);
                    emp.Designation = (i == 1 || i == 3) ? "Accountant" : "Software Developer";
                    emp.DepartmentName = (i == 1 || i == 3) ? "Accounts" : "Software Development";
                    lstEmployeeForDesignTime.Add(emp);
                }

                this.AddRange(lstEmployeeForDesignTime);
            }
            else
            {

                DataTable dt = new DataTable();

                try
                {
                    AddIsBusy(); //Note this functionality from base class
                    //get employee data from database
                    SqlDataReader resultReader = null;
                    Task.Run(async () =>
                    {
                        resultReader = await GetDataFromDbAsync();
                    }).Wait();//wait for the data to come as the employee data is used in method


                    dt.Load(resultReader);


                    RemoveIsBusy();//Note this functionality from base class               

                    if (dt.Rows.Count > 0)
                    {
                        this.AddRange(dt.AsEnumerable().Select(row => new EmployeeViewModel(row)));//Note this is the functionality provided by base class (Note add range is not available in list)                  
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

        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the data from database
        /// </summary>
        /// <param name="dt">The datatable (where data is fetched).</param>
        private async Task<SqlDataReader> GetDataFromDbAsync()
        {
            SqlCommand Command = new SqlCommand();
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
                                        ", d.[DeptName] AS DeptName" +
                                        " FROM [SampleProject_db].[dbo].[Employee] e" +
                                        " LEFT JOIN Department d ON e.DeptId = d.DeptId";          

            return await Command.ExecuteReaderAsync();//This asyncronously calls the database
        }

        #endregion

        #region Cleanup

        /// <summary>
        /// This clean up items in collection
        /// </summary>
        /// Note clean up functionality is also form base class i.e. SpecialisedObservableCollection
        public override void Cleanup()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

                _connection = null;
            }
            base.Cleanup();
        }

        #endregion
    }
}
