using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFAssignment
{
    public class NetStockConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            decimal netStock = 0;
            if(values[0]!=null && values[1]!=null)
            {
                netStock = decimal.Parse(values[0].ToString()) *decimal.Parse(values[1].ToString());
            }
            return netStock.ToString(parameter as string, culture);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
