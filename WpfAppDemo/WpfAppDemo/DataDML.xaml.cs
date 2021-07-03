using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using DBLibrary; 

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for DataDML.xaml
    /// </summary>
    public partial class DataDML : Window
    {
        EmpDataStore empData = new EmpDataStore(ConfigurationManager.ConnectionStrings["trainingConnStr"].ConnectionString);
        private ObservableCollection<Emp> empList;

        public DataDML()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {

            empList = new ObservableCollection<Emp>(empData.GetEmps());

            dataGridEmp.DataContext = empList;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Emp emp = empData.GetEmps(int.Parse(txtEmpNo.Text));
            if (emp != null)
            {
                txtEmpName.Text = emp.EmpName;
                txtHire.Text = Convert.ToString(emp.HireDate);
                txtSal.Text = Convert.ToString(emp.Salary);
            }   
            else
            {
                txtEmpNo.Clear();
                txtEmpName.Clear();
                txtHire.Clear();
                txtSal.Clear();
                MessageBox.Show("Invalid Employee No");
            }
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Empno = int.Parse(txtEmpNo.Text);
            emp.EmpName = txtEmpName.Text;
            DateTime dt;
            Boolean st = DateTime.TryParse(txtHire.Text, out dt);
            if (st == false)
                emp.HireDate = null;
            else
                emp.HireDate = dt;

            decimal ds;
            st = Decimal.TryParse(txtSal.Text, out ds);
            if (st == false)
                emp.Salary = null;
            else
                emp.Salary = ds;
            int status = empData.InsertEmp(emp);
            empList.Add(emp);
            if (status > 0)
            {
                txtEmpNo.Clear();
                txtEmpName.Clear();
                txtHire.Clear();
                txtSal.Clear();
                MessageBox.Show("Emp record inserted successfully");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.Empno = int.Parse(txtEmpNo.Text);
            emp.EmpName = txtEmpName.Text;
            DateTime dt;
            Boolean st = DateTime.TryParse(txtHire.Text, out dt);
            if (st == false)
                emp.HireDate = null;
            else
                emp.HireDate = dt;

            decimal ds;
            st = Decimal.TryParse(txtSal.Text, out ds);
            if (st == false)
                emp.Salary = null;
            else
                emp.Salary = ds;

            int status = 0;
            foreach (var item in empList)
            {
                if (item.Empno == int.Parse(txtEmpNo.Text))
                {
                    empList.Remove(item);
                    status = empData.UpdateEmpSql(emp);
                    break;
                }
            }



            if (status > 0)
            {
                Emp e2 = empData.GetEmps(int.Parse(txtEmpNo.Text));
                empList.Add(e2);
                MessageBox.Show("Emp record Updated successfully");
            }
            else
            {
                txtEmpNo.Clear();
                txtEmpName.Clear();
                txtHire.Clear();
                txtSal.Clear();
                MessageBox.Show("Invalid Employee No");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
        
            int empno = int.Parse(txtEmpNo.Text);
            foreach (var item in empList)
            {
                if(item.Empno==empno)
                {
                    empList.Remove(item);
                    break;
                }    
            }
            //Emp emp = empData.GetEmps(empno);

            int status = empData.DeleteEmpSql(empno);
            
            if (status > 0)
                MessageBox.Show("Record deleted successfully");
            else
                MessageBox.Show("Invalid Employee No");
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Application.Current.Shutdown();
        }
    }
}
