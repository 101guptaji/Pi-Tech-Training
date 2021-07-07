using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleProject2
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        SqlConnection conn = null;
        public EmployeeForm()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Server= (localdb)\MSSQLLocalDB; Database=SampleProject_db;Trusted_Connection=Yes;");

            string sql = "select DeptId, DeptName from Department";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "dept");

            cmbDept.ItemsSource = ds.Tables["dept"].DefaultView;
            cmbDept.DisplayMemberPath = ds.Tables["dept"].Columns["DeptName"].ToString();
            cmbDept.SelectedValuePath = ds.Tables["dept"].Columns["DeptId"].ToString();

            //List<Department> lstDept = new List<Department>();
            //foreach (DataRow row in ds.Tables["dept"].Rows)
            //{
            //    Department d = new Department();
            //    d.DeptId = (int)row[0];
            //    d.DetName = row[1].ToString();
            //    lstDept.Add(d);

            //}
            //foreach (Department d in lstDept)
            //{
            //    cmbDept.Items.Add(d);
            //}
            //cmbDept.DisplayMemberPath = ds.Tables["dept"].Columns["DeptName"].ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string FirstName = null;
                if (txtFirstName.Text != null && txtFirstName.Text.Trim() != "")
                {
                    FirstName = "'" + txtFirstName.Text.ToString() + "'";
                }
                else
                {
                    FirstName = "'FirstName'";//Please note that the default first name will be "FirstName"
                }


                string MiddleName = null;
                if (txtMiddleName.Text != null && txtMiddleName.Text.Trim() != "")
                {
                    MiddleName = "'" + txtMiddleName.Text.ToString() + "'";
                }
                else
                {
                    MiddleName = "NULL";
                }


                string LastName = null;
                if (txtLastName.Text != null && txtLastName.Text.Trim() != "")
                {
                    LastName = "'" + txtLastName.Text.ToString() + "'";
                }
                else
                {
                    LastName = "'LastName'";//Please note that the default last name will be "LastName"
                }


                string BirthDate = null;
                if (dtBirthDate.SelectedDate != null)
                {
                    DateTime dt = dtBirthDate.SelectedDate.Value;
                    BirthDate = "'" + dt.Year + "-" + dt.Month + "-" + dt.Day + "'";
                }
                else
                {
                    BirthDate = "NULL";
                }


                string gender = "'M'";
                if ((bool)rbtnMale.IsChecked)
                {
                    gender = "'M'";
                }
                else
                {
                    gender = "'F'";
                }


                string Address = null;
                if (txtAddress.Text != null && txtAddress.Text.Trim() != "")
                {
                    Address = "'" + txtAddress.Text + "'";
                }
                else
                {
                    Address = "NULL";
                }


                string ContactNumber = null;
                if (txtContact.Text != null && txtContact.Text.Trim() != "")
                {
                    ContactNumber = "'" + txtContact.Text + "'";
                }
                else
                {
                    ContactNumber = "NULL";
                }


                string EmailId = null;
                if (txtEmail.Text != null && txtEmail.Text.Trim() != "")
                {
                    EmailId = "'" + txtEmail.Text + "'";
                }
                else
                {
                    EmailId = "NULL";
                }


                string JoiningDate = null;
                if (dtJoinDate.SelectedDate != null)
                {
                    DateTime dt = dtJoinDate.SelectedDate.Value;
                    JoiningDate = "'" + dt.Year + "-" + dt.Month + "-" + dt.Day + "'";
                }
                else
                {
                    JoiningDate = "NULL";
                }


                string ConfirmationDate = null;
                if (dtConfirmDate.SelectedDate != null)
                {
                    DateTime dt = dtConfirmDate.SelectedDate.Value;
                    ConfirmationDate = "'" + dt.Year + "-" + dt.Month + "-" + dt.Day + "'";
                }
                else
                {
                    ConfirmationDate = "NULL";
                }


                string IsResigned = chkResigned.IsChecked == true ? "1" : "0";


                string Salary = null;
                if (txtSalary.Text != null && txtSalary.Text.Trim() != "")
                {
                    Salary = txtSalary.Text;
                }
                else
                {
                    Salary = "NULL";
                }


                string Designation = null;
                if (txtDesign.Text != null && txtDesign.Text.Trim() != "")
                {
                    Designation = "'" + txtDesign.Text + "'";
                }
                else
                {
                    Designation = "NULL";
                }


                string DepatmentId = null;
                if (cmbDept.SelectedItem != null)
                {
                    DepatmentId = cmbDept.SelectedValue.ToString();
                }
                else
                {
                    DepatmentId = "NULL";
                }

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string strCommand = "INSERT INTO [dbo].[Employee] ([FirstName] ,[MiddleName] ,[LastName] ,[BirthDate] ,[Gender] ,[Address] ,[ContactNumber] ,[EmailId], [JoiningDate], [ConfirmationDate], [IsResigned], [Salary], [Designation], [DeptId]) VALUES (" + FirstName + "," + MiddleName + "," + LastName + "," + BirthDate + "," + gender + "," + Address + "," + ContactNumber + "," + EmailId + "," + JoiningDate + "," + ConfirmationDate + "," + IsResigned + "," + Salary + "," + Designation + "," + DepatmentId + ")";
                SqlCommand Command = new SqlCommand(strCommand, conn);
                Command.ExecuteNonQuery();
                MessageBox.Show("Employee data saved successfully.", "Save", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
