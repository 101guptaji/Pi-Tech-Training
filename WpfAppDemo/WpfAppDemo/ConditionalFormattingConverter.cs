using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfAppDemo
{
    class ConditionalFormattingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var condValue= ConfigurationManager.AppSettings["formatValue"];
            if (value!=null)
            {
                decimal units = decimal.Parse(value.ToString());
                if (units < decimal.Parse(condValue))
                    return true;
                else
                    return false;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
