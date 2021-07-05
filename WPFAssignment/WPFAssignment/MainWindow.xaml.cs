using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Configuration;

namespace WPFAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindEntities db = null;
        List<Employee> empList;

        public MainWindow()
        {
            InitializeComponent();
            db = new NorthwindEntities();
        }
        private void tabEmpRecords_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> titles = new List<string>();
            titles.Add("All");
            empList = db.Employees.ToList();
            titles.AddRange(empList.Select(emp => emp.TitleOfCourtesy).Distinct());
            cmbTitle.ItemsSource = titles;
        }

        private void cmbTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string title = cmbTitle.SelectedValue.ToString();
            if (title == "All")
                lstEmp.ItemsSource = empList;
            else
            {
                lstEmp.ItemsSource = empList.Where(emp => emp.TitleOfCourtesy == title);
            }
        }
        private void rdoTitle_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tabCustOrders_Loaded(object sender, RoutedEventArgs e)
        {
            var custOrdersList = db.Customers.Join(db.Orders, c => c.CustomerID, o => o.CustomerID,
                (c, o) => new
                {
                    OrderID = o.OrderID,
                    CompanyName = c.CompanyName,
                    OrderDate = o.OrderDate,
                    ShippedDate = o.ShippedDate,
                    Freight = o.Freight
                }).ToList();
            grdCustOrders.DataContext = custOrdersList;
        }

        private void tabProd_Loaded(object sender, RoutedEventArgs e)
        {
            //lstProds.ItemsSource = db.Products.ToList();
            grdProd.DataContext = db.Products.ToList();
        }

        private void tabCatProd_Loaded(object sender, RoutedEventArgs e)
        {
            grdCatProd.DataContext = db.Categories.ToList();
        }

        private void tabnorthwind_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=Northwind; integrated security=true;");
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            DataTable table = connection.GetSchema("Tables");
            IEnumerable<string> tables = GetNameList(table.Rows, 2);

            foreach (string tableName in tables)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = tableName;
                itemTable.Items.Add(item);
            }

            //DataTable databasesSchemaTable = connection.GetSchema("Databases");
            //Items = new ObservableCollection<NodeViewModel>();
            //var rootNode = new NodeViewModel
            //{
            //    Name = "Databases",
            //    Children = new ObservableCollection<NodeViewModel>()
            //};
            //Items.Add(rootNode);

            // IEnumerable<string> databases = GetNameList(databasesSchemaTable.Rows, 0);

            //foreach (var dbName in databases)
            //{
            //    var dbNode = new NodeViewModel { Name = dbName.ToString() };
            //    rootNode.Children.Add(dbNode);
            //    if (dbName.Equals("Northwind"))
            //    {
            //        DataTable table = connection.GetSchema("Tables");
            //        IEnumerable<string> tables = GetNameList(table.Rows, 2);

            //        var tableNode = new NodeViewModel { Name = "Tables" };
            //        dbNode.Children.Add(tableNode);
            //        foreach (string tableName in tables)
            //        {
            //            tableNode.Children.Add(new NodeViewModel { Name = tableName });
            //        }
            //    }
            //}
            //treeDB.ItemsSource = Items;
        }
        private IEnumerable<string> GetNameList(DataRowCollection drc, int index)
        {
            return drc.Cast<DataRow>().Select(r => r.ItemArray[index].ToString()).OrderBy(r => r).ToList();
        }
        // public ObservableCollection<NodeViewModel> Items { get; set; }

   
        private void treeDB_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem selectedTable = (TreeViewItem)treeDB.SelectedItem;
            string tableName = selectedTable.Header.ToString();
            SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=Northwind; integrated security=true;");
            string sql = "select * from " + tableName;

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tableName);
            table.DataContext = ds.Tables[tableName];
        }

        
    }
}