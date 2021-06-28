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

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for ResourceDemo.xaml
    /// </summary>
    public partial class ResourceDemo : Window
    {
        public ResourceDemo()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush colorBrush = new SolidColorBrush(Colors.Yellow);
            this.Resources["brush"] = colorBrush;
        }
    }
}
