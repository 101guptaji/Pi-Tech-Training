using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    public class Temperature : INotifyPropertyChanged
    {
        public Temperature()
        {
            CelToFarCommand = new RelayCommand(CelToFar);
            FarToCelCommand = new RelayCommand(FarToCel);
        }


        private RelayCommand celTofarCommand;

        public RelayCommand CelToFarCommand
        {
            get { return celTofarCommand; }
            set { celTofarCommand = value; }
        }

        private RelayCommand farToCel;

        public RelayCommand FarToCelCommand
        {
            get { return farToCel; }
            set { farToCel = value; }
        }

        private double cel;

        public double Cel
        {
            get { return cel; }
            set { cel = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        private double far;

        public double Far
        {
            get { return far; }
            set
            {
                far = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        private string result;

        
        public string Result
        {
            get { return result; }
            set { result = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CelToFar(object c)
        {
            result = "Fahrenheit: "+(double.Parse(Cel.ToString())*9/5 + 32).ToString();
            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
        }
        public void FarToCel(object f)
        {
            result = "Celsius:  " + ((double.Parse(Far.ToString()) - 32) * 5 / 9).ToString();
            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
        }
    }
}
