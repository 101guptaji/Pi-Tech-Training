using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo01.Models
{
   public class Numbers : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region Properties
        private double fNum;

        public double FirstNum
        {
            get { return fNum; }
            set { fNum = value;
                OnPropertyChanged("FirstNum");
            }
        }

        private double sNum;

        public double SecondNum
        {
            get { return sNum; }
            set { sNum = value;
                OnPropertyChanged("SecondNum");
            }
        }


        #endregion
    }
}
