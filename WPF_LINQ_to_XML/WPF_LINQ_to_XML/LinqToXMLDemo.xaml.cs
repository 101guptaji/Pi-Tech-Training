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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WPF_LINQ_to_XML
{
    /// <summary>
    /// Interaction logic for LinqToXMLDemo.xaml
    /// </summary>
    public partial class LinqToXMLDemo : Window
    {
        public LinqToXMLDemo()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            XDocument document = XDocument.Load(@"D:\HDD\PI Techniques\Training\WPF_LINQ_to_XML\WPF_LINQ_to_XML\ProductData.xml");

            var qData = from x in document.Descendants("product")
                        select new
                        {
                            ProductID = (int)x.Attribute("ProductID"),
                            ProductName = (string)x.Element("ProductName"),
                            UnitPrice = (decimal)x.Element("UnitPrice")
                        };
            lstbox1.ItemsSource = qData;
        }
    }
}
