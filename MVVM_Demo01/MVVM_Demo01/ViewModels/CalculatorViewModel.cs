using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_Demo01.Models;
using MVVM_Demo01.Commands;

namespace MVVM_Demo01.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region Number's Properties

        Numbers num = new Numbers();

        public string FirstNum
        {
            get { return num.FirstNum.ToString(); }
            set {
                num.FirstNum = double.Parse(value);
                OnPropertyChanged("Result");
            }
        }
        public string SecondNum
        {
            get { return num.SecondNum.ToString(); }
            set
            {
                num.SecondNum = double.Parse(value);
                OnPropertyChanged("Result");
            }
        }
        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get { return addCommand; }
            set { addCommand = value; }
        }

        private ICommand subCommand;

        public ICommand SubCommand
        {
            get { return subCommand; }
            set { subCommand = value; }
        }

        private ICommand multiplyCommand;

        public ICommand MultiplyCommand
        {
            get { return multiplyCommand; }
            set { multiplyCommand = value; }
        }

        private ICommand divideCommand;

        public ICommand DivideCommand
        {
            get { return divideCommand; }
            set { divideCommand = value; }
        }

        public CalculatorViewModel()
        {
            AddCommand = new RelayCommand(Addition, CanAdd);
            SubCommand = new RelayCommand(Substraction, CanSub);
            MultiplyCommand = new RelayCommand(Multiplication, CanMultiply);
            DivideCommand = new RelayCommand(Division, CanDivide);
        }

        public bool CanAdd(object obj)
        {
            //return true;
            if (double.Parse(FirstNum)!=0 && double.Parse(SecondNum) != 0)
                return true;
            return false;
        }

        public void Addition(object obj)
        {
            Result = "Addition=" + (double.Parse(FirstNum) + double.Parse(SecondNum)).ToString();
            OnPropertyChanged("Result");
        }

        public bool CanSub(object obj)
        {
            //return true;
            if (double.Parse(FirstNum) != 0 && double.Parse(SecondNum) != 0)
                return true;
            return false;
        }

        public void Substraction(object obj)
        {
            Result = "Substraction=" + (double.Parse(FirstNum) - double.Parse(SecondNum)).ToString();
            OnPropertyChanged("Result");
        }

        public bool CanMultiply(object obj)
        {
            //return true;
            if (double.Parse(FirstNum) != 0 && double.Parse(SecondNum) != 0)
                return true;
            return false;
        }

        public void Multiplication(object obj)
        {
            Result = "Multiplication=" + (double.Parse(FirstNum) * double.Parse(SecondNum)).ToString();
            OnPropertyChanged("Result");
        }

        public bool CanDivide(object obj)
        {
            //return true;
            if (double.Parse(FirstNum) != 0 && double.Parse(SecondNum) != 0)
                return true;
            return false;
        }

        public void Division(object obj)
        {
            Result = "Division=" + (double.Parse(FirstNum) / double.Parse(SecondNum)).ToString();
            OnPropertyChanged("Result");
        }
        #endregion
    }
}
