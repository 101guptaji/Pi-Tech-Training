using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WFP_INotifyPropertyChanged__Command_Demo
{
    class DecreamentCommandCounter : ICommand
    {
        private IncreamentCounter DecCounter;

        //Dependency Injection by Costructor DI
        public DecreamentCommandCounter(IncreamentCounter counterObj)
        {
            DecCounter = counterObj;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) //When to excute
        {
            //return true;
            if (DecCounter.Counter > 0)
                return true;
            return false;
        }

        public void Execute(object parameter) //what to execute
        {
           // DecCounter.Decreament();
        }
    }
}
