using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfAppDemo
{
    public class CurrencyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal d = 0;
            if(value!=null)
            {
                d = (decimal)value;
            }
            return d.ToString(parameter as string, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object price = decimal.Parse(value as string, System.Globalization.NumberStyles.Currency, culture);
            return price;
        }
    }
}
