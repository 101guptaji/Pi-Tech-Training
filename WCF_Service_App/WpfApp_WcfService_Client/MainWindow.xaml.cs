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
using WpfApp_WcfService_Client.ProductServiceReference;

namespace WpfApp_WcfService_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductServiceClient proxyObj = new ProductServiceClient();

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPanel_Loaded(object sender, RoutedEventArgs e)
        {
            dgProduct.DataContext = proxyObj.GetAllProducts();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            Product prod = proxyObj.getProductById(int.Parse(txtPid.Text));
            txtId.Text = prod.ProductID.ToString();
            txtName.Text = prod.ProductName;
        }
    }
}
