using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MajiaobaGeoSystem.DataModel;

namespace MajiaobaGeoSystem.Service
{
      public interface IDataService
      {
            void GetData(Action<DataItem, Exception> callback);
      }
}
