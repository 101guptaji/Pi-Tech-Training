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
    /// Interaction logic for SimpleCalculator.xaml
    /// </summary>
    public partial class SimpleCalculator : Window
    {
        private int opIndex;
        private double firstNumber;
        private double secondNumber;
        public SimpleCalculator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (txtResult.Text != "0")
            {
                txtResult.Text = $"{txtResult.Text}{btn.Content}";
            }
            else
            {
                txtResult.Text = btn.Content.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            txtResult.Text = "0";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtResult.Text = (double.Parse(txtResult.Text) * -1).ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //int op = txtResult.Text.IndexOf('%');
            firstNumber = double.Parse(txtResult.Text);
            opIndex = txtResult.Text.Length;
            var btn = sender as Button;
            if (txtResult.Text != "0")
            {
                txtResult.Text = $"{txtResult.Text}{btn.Content}";
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            firstNumber = double.Parse(txtResult.Text);
            opIndex= txtResult.Text.Length;
            var btn = sender as Button;
            if (txtResult.Text != "0")
            {
                txtResult.Text = $"{txtResult.Text}{btn.Content}";
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            firstNumber = double.Parse(txtResult.Text);
            opIndex = txtResult.Text.Length;
            var btn = sender as Button;
            if (txtResult.Text != "0")
            {
                txtResult.Text = $"{txtResult.Text}{btn.Content}";
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            firstNumber = double.Parse(txtResult.Text);
            opIndex = txtResult.Text.Length;
            var btn = sender as Button;
            if (txtResult.Text != "0")
            {
                txtResult.Text = $"{txtResult.Text}{btn.Content}";
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            firstNumber = double.Parse(txtResult.Text);
            opIndex = txtResult.Text.Length;
            var btn = sender as Button;
            if (txtResult.Text != "0")
            {
                txtResult.Text = $"{txtResult.Text}{btn.Content}";
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text.IndexOf('.') < 0)
            {
                txtResult.Text += ".";
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            secondNumber = double.Parse(txtResult.Text.Substring(opIndex + 1));
            if (txtResult.Text.ElementAt(opIndex)=='+')
            {
                txtResult.Text= (firstNumber + secondNumber).ToString();
            }
            else if (txtResult.Text.ElementAt(opIndex) == '-')
            {
                txtResult.Text = (firstNumber - secondNumber).ToString();
            }
            else if (txtResult.Text.ElementAt(opIndex) == '*')
            {
                txtResult.Text = (firstNumber * secondNumber).ToString();
            }
            else if (txtResult.Text.ElementAt(opIndex) == '/')
            {
                txtResult.Text = (firstNumber / secondNumber).ToString();
            }
            else if (txtResult.Text.ElementAt(opIndex) == '%')
            {
                firstNumber = (firstNumber / 100);
                txtResult.Text = (firstNumber * secondNumber).ToString();
            }
            else
            {
                txtResult.Text = "0";
            }
        }
    }
}
