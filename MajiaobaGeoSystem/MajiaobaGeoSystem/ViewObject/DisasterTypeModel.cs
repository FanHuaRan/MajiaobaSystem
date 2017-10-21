using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MajiaobaGeoSystem.ViewObject
{
      /// <summary>
      /// 灾害类型视图模型
      /// 2017/10/21 fhr
      /// </summary>
    public class DisasterTypeModel : ObservableObject
      {
          private int disasterTypeId { get; set; }

          private string typeName { get; set; }
          public int DisasterTypeId
          {
              get
              {
                  return disasterTypeId;
              }
              set
              {
                  if (value != disasterTypeId)
                  {
                      this.disasterTypeId = value;
                      RaisePropertyChanged<int>(() => DisasterTypeId);
                  }
              }
          }

          public string TypeName
          {
              get
              {
                  return typeName;
              }
              set
              {
                  if (value != typeName)
                  {
                      this.typeName = value;
                      RaisePropertyChanged<string>(() => TypeName);
                  }
              }
          }
      }
}
