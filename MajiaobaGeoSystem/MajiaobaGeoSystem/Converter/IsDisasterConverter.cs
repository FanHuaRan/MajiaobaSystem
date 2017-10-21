using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MajiaobaGeoSystem.Converter
{
   /// <summary>
   /// 灾害点/隐患点转换器
   /// 2017/10/21 fhr
   /// </summary>
    [ValueConversion(typeof(int), typeof(string))]
    class IsDisasterConverter : IValueConverter
    {
        private static readonly string DISASTER = "灾害点";
        private static readonly string HIDDEN = "隐患点";
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isDisaster = (int)value;
            return isDisaster == 1 ? DISASTER : HIDDEN;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == DISASTER)
            {
                return 1;
            }
            return 0;
        }
    }
}
