using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WFP_INotifyPropertyChanged__Command_Demo
{
    //Business Logic Class
    public class IncreamentCounter : INotifyPropertyChanged
    {
        //private IncreamentCommandCounter IncreamentCommandCounter = null;
        //private DecreamentCommandCounter DecreamentCommandCounter;

        //public IncreamentCounter()
        // {
        //    IncreamentCommandCounter = new IncreamentCommandCounter(this);
        //    DecreamentCommandCounter = new DecreamentCommandCounter(this);
        // }

        //public ICommand IncCommandObj
        //{
        //    get { return IncreamentCommandCounter; }
        //}

        //public ICommand DecCommandObj
        //{
        //    get { return DecreamentCommandCounter; }
        //}

        public IncreamentCounter()
        {
            IncCommand = new RelayCommand(Increament, IncCondition);
            DecCommand = new RelayCommand(Decreament, DecCondition);
        }

        private bool DecCondition(object obj)
        {
            if (Counter > 0)
                return true;
            return false;
        }

        private bool IncCondition(object obj)
        {
            if (Counter < 10)
                return true;
            return false;
        }

        private RelayCommand relayCommand;

        public RelayCommand IncCommand
        {
            get { return relayCommand; }
            set { relayCommand = value;  }
        }

        public RelayCommand DecCommand { get; set; }

       
        private int counter;

        public int Counter
        {
            get { return counter; }
            set { counter = value;
               PropertyChanged(this, new PropertyChangedEventArgs("Counter"));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void Increament(Object obj)
        {
            Counter++;
            PropertyChanged(this, new PropertyChangedEventArgs("Counter"));

        }
        public void Decreament(Object obj)
        {
            Counter--;
            PropertyChanged(this, new PropertyChangedEventArgs("Counter"));
        }


    }
}
