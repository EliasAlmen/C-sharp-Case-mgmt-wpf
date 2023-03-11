using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EC05_C_sharp_Case_mgmt_wpf.Helpers
{
    /// <summary>
    /// Found on the internet, convert bool value to string
    /// </summary>
    public class BooleanHelper : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case true:
                    return "Closed";
                case false:
                    return "Open";
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "Open";
                else
                    return "Closed";
            }
            return "no";
        }
    }
}
