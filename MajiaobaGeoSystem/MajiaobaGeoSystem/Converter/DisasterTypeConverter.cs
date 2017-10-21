using MajiaobaGeoSystem.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MajiaobaGeoSystem.Service;
namespace MajiaobaGeoSystem.Converter
{
   [ValueConversion(typeof(int), typeof(string))]
    public class DisasterTypeConverter : IValueConverter
    {
       private static IEnumerable<DisasterTypeModel> DisasterTypeModels;
       static DisasterTypeConverter()
       {
                  var  typeService= ServiceLocator.Current.GetInstance<IDisasterTypeService>();
                  var typeModelConverter = ServiceLocator.Current.GetInstance<DisasterTypeModelConverter>();
                  typeService.FindAll((models, err) =>
                  {
                      var tmp=new List<DisasterTypeModel>();
                      //if (err != null)
                      //{
                      if (models != null)
                      {
                          foreach (var model in models)
                          {
                              tmp.Add(typeModelConverter.convert(model));
                          }
                      }
                      //}
                      DisasterTypeModels = tmp;
                  });
       }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var id = (int)value;
            var typeModel=DisasterTypeModels.Where(p => p.DisasterTypeId == id).FirstOrDefault();
            if (typeModel != null)
            {
                return typeModel.TypeName;
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var name = (string)value;
            var typeModel = DisasterTypeModels.Where(p => p.TypeName == name).FirstOrDefault();
            if (typeModel != null)
            {
                return typeModel.DisasterTypeId;
            }
            return 0;
        }
    }
}
