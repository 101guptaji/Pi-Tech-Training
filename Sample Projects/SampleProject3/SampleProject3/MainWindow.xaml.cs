using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SampleProject3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = null;
        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sampleProject"].ConnectionString);

            string sql = "select e.EmpId, e.FirstName, e.MiddleName, e.LastName, e.BirthDate, e.Gender, e.Address, e.ContactNumber, e.EmailId, e.JoiningDate, e.ConfirmationDate, e.ExpectedInTime, e.ExpectedOutTime, e.IsResigned, e.Salary, e.Designation,e.DeptId, d.DeptName as DeptName from Employee e left join Department d on e.DeptId = d.DeptId";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Emp_dept");
            // grdEmps.DataContext = ds.Tables["Emp_dept"];

            List<Employee> lstEmp = new List<Employee>();
            foreach (DataRow row in ds.Tables["Emp_dept"].Rows)
            {
                Employee emp = new Employee(row);
                lstEmp.Add(emp);
            }

            ListViewEmployees.ItemsSource = lstEmp;
             

           
        }
    }
}
