using GalaSoft.MvvmLight.Command;
using SampleProject11.Common;
using SampleProject11.View;
using SampleProject11.ViewModel.Data;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SampleProject11.ViewModel
{
    // <summary>
    /// This class is view model for EmployeeFormView.
    /// </summary>
    public class EmployeeFormViewModel : BaseViewModel
    {
        #region Properties
        /// <summary>
        /// connection to the local database SampleProject_db
        /// </summary>
        private SqlConnection _connection = new SqlConnection(@"Server=(local);Database=SampleProject_db;Trusted_Connection=Yes;");

        /// <summary>
        /// The department list.
        /// </summary>
        private ObservableCollection<Department> _departmentList;

        /// <summary>
        /// Gets or sets the department list.
        /// </summary>
        /// <value>
        /// The department list.
        /// </value>
        public ObservableCollection<Department> DepartmentList
        {
            get { return _departmentList; }
            set { Set(() => DepartmentList, ref _departmentList, value); }
        }

        /// <summary>
        /// Gets or sets the selected department.
        /// </summary>
        private Department _selectedDepartment;

        /// <summary>
        /// Gets or sets the selected department.
        /// </summary>
        /// <value>
        /// The selected department.
        /// </value>
        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set { Set(() => SelectedDepartment, ref _selectedDepartment, value); }
        }


        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        private string _firstName;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName
        {
            get { return _firstName; }
            set { Set(() => FirstName, ref _firstName, value); }
        }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        private string _middleName;

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        /// <value>
        /// The middle name.
        /// </value>
        public string MiddleName
        {
            get { return _middleName; }
            set { Set(() => MiddleName, ref _middleName, value); }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName
        {
            get { return _lastName; }
            set { Set(() => LastName, ref _lastName, value); }
        }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        private DateTime? _birthDate;

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { Set(() => BirthDate, ref _birthDate, value); }
        }

        /// <summary>
        /// Gets or sets the value if gender male checked.
        /// </summary>
        private bool _isGenderMaleChecked;

        /// <summary>
        /// Gets or sets the value if gender male checked.
        /// </summary>
        /// <value>
        /// The value if gender male checked i.e true if checked else false.
        /// </value>
        public bool IsGenderMaleChecked
        {
            get { return _isGenderMaleChecked; }
            set { Set(() => IsGenderMaleChecked, ref _isGenderMaleChecked, value); }
        }

        /// <summary>
        /// Gets or sets the value if gender female checked.
        /// </summary>
        private bool _isGenderFemaleChecked;

        /// <summary>
        /// Gets or sets the value if gender female checked.
        /// </summary>
        /// <value>
        /// The value if gender female checked i.e true if checked else false.
        /// </value>
        public bool IsGenderFemaleChecked
        {
            get { return _isGenderFemaleChecked; }
            set { Set(() => IsGenderFemaleChecked, ref _isGenderFemaleChecked, value); }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        private string _address;

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get { return _address; }
            set { Set(() => Address, ref _address, value); }
        }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        public string _contactNumber;

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>
        /// The contact number.
        /// </value>
        public string ContactNumber
        {
            get { return _contactNumber; }
            set { Set(() => ContactNumber, ref _contactNumber, value); }
        }

        /// <summary>
        /// Gets or sets the email id.
        /// </summary>
        public string _emailid;

        /// <summary>
        /// Gets or sets the email id.
        /// </summary>
        /// <value>
        /// The email id.
        /// </value>
        public string EmailId
        {
            get { return _emailid; }
            set { Set(() => EmailId, ref _emailid, value); }
        }

        /// <summary>
        /// Gets or sets the joining date.
        /// </summary>
        private DateTime? _joiningDate;

        /// <summary>
        /// Gets or sets the joining date.
        /// </summary>
        /// <value>
        /// The joining date.
        /// </value>
        public DateTime? JoiningDate
        {
            get { return _joiningDate; }
            set { Set(() => JoiningDate, ref _joiningDate, value); }
        }

        /// <summary>
        /// Gets or sets the confirmation date.
        /// </summary>
        private DateTime? _confirmationDate;

        /// <summary>
        /// Gets or sets the confirmation date.
        /// </summary>
        /// <value>
        /// The confirmation date.
        /// </value>
        public DateTime? ConfirmationDate
        {
            get { return _confirmationDate; }
            set { Set(() => ConfirmationDate, ref _confirmationDate, value); }
        }

        /// <summary>
        /// Gets or sets the value is resigned.
        /// </summary>
        private bool _isResigned;

        /// <summary>
        /// Gets or sets the value if is resigned.
        /// </summary>
        /// <value>
        /// The value if resigned i.e true else false.
        /// </value>
        public bool IsResigned
        {
            get { return _isResigned; }
            set { Set(() => IsResigned, ref _isResigned, value); }
        }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        private string _salary;

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        /// <value>
        /// The salary.
        /// </value>
        public string Salary
        {
            get { return _salary; }
            set { Set(() => Salary, ref _salary, value); }
        }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        private string _designation;

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        public string Designation
        {
            get { return _designation; }
            set { Set(() => Designation, ref _designation, value); }
        }

        #endregion

        #region Relay Commands

        /// <summary>
        /// The save command.
        /// </summary>
        private RelayCommand _saveCommand;

        /// <summary>
        /// Gets the save command.
        /// </summary>
        /// <value>
        /// The save command.
        /// </value>
        public RelayCommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(SaveEmployeeData, CanSaveEmployeeData)); }
        }


        /// <summary>
        /// The cancel command.
        /// </summary>
        private RelayCommand<Window> _cancelCommand;

        /// <summary>
        /// Gets the cancel command.
        /// </summary>
        /// <value>
        /// The cancel command.
        /// </value>
        public RelayCommand<Window> CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(Cancel)); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeFormViewModel"/> class.
        /// </summary>
        public EmployeeFormViewModel()
        {
            IsGenderMaleChecked = true;
            IsResigned = false;

            DataTable dt = new DataTable();
            DepartmentList = new ObservableCollection<Department>();
            try
            {
                GetDepartmentDataFromDb(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Department d = new Department(dr);
                        DepartmentList.Add(d);

                    }
                }

                CreateValidationRules();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the validation rules.
        /// </summary>
        private void CreateValidationRules()
        {
            AddPropertyValidation(() => FirstName, () =>
            {
                return string.IsNullOrWhiteSpace(FirstName) ? Messages.FirstNameIsMandatory : null;
            });


            AddPropertyValidation(() => LastName, () =>
            {
                return string.IsNullOrWhiteSpace(LastName) ? Messages.LastNameIsMandatory : null;
            });
        }

        /// <summary>
        /// Gets the department data from database
        /// </summary>
        /// <param name="dt">The datatable (where data is fetched).</param>
        private void GetDepartmentDataFromDb(DataTable dt)
        {
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            _connection.Open();
            Command.Connection = _connection;
            //inline query to get the departments
            Command.CommandText = "select DeptId , DeptName from Department";
            Adapter.SelectCommand = Command;
            Adapter.Fill(dt);
            _connection.Close();
        }


        /// <summary>
        /// Cancels save and closes the window.
        /// </summary>
        /// <param name="window">Current window <see cref="EmployeeFormView"/> </param>
        private void Cancel(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        /// <summary>
        /// Determines whether this instance [can save employee data].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can save employee data]; otherwise, <c>false</c>.
        /// </returns>
        private bool CanSaveEmployeeData()
        {
            return true;
        }

        /// <summary>
        /// Saves the employee data.
        /// </summary>
        private void SaveEmployeeData()
        {
            try
            {
                if (Validate())
                {
                    string TempFirstName = null;
                    if (FirstName != null && FirstName.Trim() != "")
                    {
                        TempFirstName = "'" + FirstName.ToString() + "'";
                    }
                    else
                    {
                        TempFirstName = "'FirstName'";//Please note that the default first name will be "FirstName"
                    }


                    string TempMiddleName = null;
                    if (MiddleName != null && MiddleName.Trim() != "")
                    {
                        TempMiddleName = "'" + MiddleName.ToString() + "'";
                    }
                    else
                    {
                        TempMiddleName = "NULL";
                    }


                    string TempLastName = null;
                    if (LastName != null && LastName.Trim() != "")
                    {
                        TempLastName = "'" + LastName.ToString() + "'";
                    }
                    else
                    {
                        TempLastName = "'LastName'";//Please note that the default last name will be "LastName"
                    }


                    string TempBirthDate = null;
                    if (BirthDate != null)
                    {
                        DateTime dt = BirthDate.Value;
                        TempBirthDate = "'" + dt.Year + "-" + dt.Month + "-" + dt.Day + "'";
                    }
                    else
                    {
                        TempBirthDate = "NULL";
                    }


                    string TempGender = "'M'";
                    if ((bool)IsGenderMaleChecked)
                    {
                        TempGender = "'M'";
                    }
                    else
                    {
                        TempGender = "'F'";
                    }


                    string TempAddress = null;
                    if (Address != null && Address.Trim() != "")
                    {
                        TempAddress = "'" + Address + "'";
                    }
                    else
                    {
                        TempAddress = "NULL";
                    }


                    string TempContactNumber = null;
                    if (ContactNumber != null && ContactNumber.Trim() != "")
                    {
                        TempContactNumber = "'" + ContactNumber + "'";
                    }
                    else
                    {
                        TempContactNumber = "NULL";
                    }


                    string TempEmailId = null;
                    if (EmailId != null && EmailId.Trim() != "")
                    {
                        TempEmailId = "'" + EmailId + "'";
                    }
                    else
                    {
                        TempEmailId = "NULL";
                    }


                    string TempJoiningDate = null;
                    if (JoiningDate != null)
                    {
                        DateTime dt = JoiningDate.Value;
                        TempJoiningDate = "'" + dt.Year + "-" + dt.Month + "-" + dt.Day + "'";
                    }
                    else
                    {
                        TempJoiningDate = "NULL";
                    }


                    string TempConfirmationDate = null;
                    if (ConfirmationDate != null)
                    {
                        DateTime dt = ConfirmationDate.Value;
                        TempConfirmationDate = "'" + dt.Year + "-" + dt.Month + "-" + dt.Day + "'";
                    }
                    else
                    {
                        TempConfirmationDate = "NULL";
                    }


                    string TempIsResigned = IsResigned == true ? "1" : "0";


                    string TempSalary = null;
                    if (Salary != null && Salary.Trim() != "")
                    {
                        TempSalary = Salary;
                    }
                    else
                    {
                        TempSalary = "NULL";
                    }


                    string TempDesignation = null;
                    if (Designation != null && Designation.Trim() != "")
                    {
                        TempDesignation = "'" + Designation + "'";
                    }
                    else
                    {
                        TempDesignation = "NULL";
                    }


                    string TempDepatmentId = null;
                    if (SelectedDepartment != null)
                    {
                        TempDepatmentId = SelectedDepartment.DepartmentId.ToString();
                    }
                    else
                    {
                        TempDepatmentId = "NULL";
                    }
                    _connection.Open();
                    string strCommand = "INSERT INTO [dbo].[Employee] ([FirstName] ,[MiddleName] ,[LastName] ,[BirthDate] ,[Gender] ,[Address] ,[ContactNumber] ,[EmailId], [JoiningDate], [ConfirmationDate], [IsResigned], [Salary], [Designation], [DeptId]) VALUES (" + TempFirstName + "," + TempMiddleName + "," + TempLastName + "," + TempBirthDate + "," + TempGender + "," + TempAddress + "," + TempContactNumber + "," + TempEmailId + "," + TempJoiningDate + "," + TempConfirmationDate + "," + TempIsResigned + "," + TempSalary + "," + TempDesignation + "," + TempDepatmentId + ")";
                    SqlCommand Command = new SqlCommand(strCommand, _connection);
                    Command.ExecuteNonQuery();
                    _connection.Close();
                    MessageBox.Show(Messages.EmployeeSaveSuccess, "Save", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error); //Show error if first name and/or last name is not entered. 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion

        #region Cleanup

        /// <summary>
        /// This clean up items in collection
        /// </summary>
        /// Note clean up functionality is also form base class i.e. BaseViewModel
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

            if (DepartmentList != null)
            {
                DepartmentList.Clear();
                DepartmentList = null;
            }

            if (SelectedDepartment != null)
            {
                SelectedDepartment = null;
            }

            if (_cancelCommand != null)
            {
                _cancelCommand = null;
            }
            if (_saveCommand != null)
            {
                _saveCommand = null;
            }
            base.Cleanup();
        }

        #endregion

    }
}
