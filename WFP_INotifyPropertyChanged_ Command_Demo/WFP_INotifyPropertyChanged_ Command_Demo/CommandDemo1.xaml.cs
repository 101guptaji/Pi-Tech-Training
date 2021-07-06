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

namespace WFP_INotifyPropertyChanged__Command_Demo
{
    /// <summary>
    /// Interaction logic for CommandDemo1.xaml
    /// </summary>
    public partial class CommandDemo1 : Window
    {
        IncreamentCounter blObj = new IncreamentCounter();
        public CommandDemo1()
        {
            InitializeComponent();
        }

        private void btCounter_Click(object sender, RoutedEventArgs e)
        {
            //blObj.Increament();
            txtCounter.Text = blObj.Counter.ToString();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.LeftCtrl)
            {
                //blObj.Increament();
                txtCounter.Text= blObj.Counter.ToString();
            }
        }
    }
}
