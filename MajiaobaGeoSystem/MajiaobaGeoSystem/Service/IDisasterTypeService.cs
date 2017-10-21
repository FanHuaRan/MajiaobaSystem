using MajiaobaGeoSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.Service
{
    /// <summary>
    /// DisasterType服务
    /// 2017/10/20 fhr
    /// </summary>
    public interface IDisasterTypeService
    {
        void FindOne(int id,Action<DisasterType, Exception> callback);

        void FindAll(Action<IEnumerable<DisasterType>, Exception> callback);

    }
}
