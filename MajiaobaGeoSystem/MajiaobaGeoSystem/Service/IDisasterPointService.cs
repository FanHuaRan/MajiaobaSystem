using MajiaobaGeoSystem.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.Service
{
    /// <summary>
    /// DisasterPoint服务
    /// 2017/10/20 fhr
    /// </summary>
    public interface IDisasterPointService
    {
        void FindOne(int id,Action<DisasterPoint, Exception> callback);

        void FindAll(Action<IEnumerable<DisasterPoint>, Exception> callback);

        void Save(DisasterPoint point, Action<DisasterPoint, Exception> callback);

        void Update(DisasterPoint point, Action<DisasterPoint, Exception> callback);

        void Delete(int id, Action<int, Exception> callback);
    }
}
