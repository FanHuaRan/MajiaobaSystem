using MajiaobaGeoSystem.DomainModel;
using MajiaobaGeoSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.Service
{
    /// <summary>
    /// DisasterPoint服务实现
    /// 2017/10/20 fhr
    /// </summary>
    public class DisasterPointService:IDisasterPointService
    {
        private readonly IRepository<DisasterPoint> disasterPointRepository;
       
        public void FindOne(int id, Action<DisasterPoint, Exception> callback)
        {
            try
            {
                var point = disasterPointRepository.FindById(id);
                callback(point, null);
            }
            catch(Exception e)
            {
                callback(null, e);
            }
        }

        public void FindAll(Action<IEnumerable<DisasterPoint>, Exception> callback)
        {
            try
            {
                var points = disasterPointRepository.FindAll();
                callback(points, null);
            }
            catch (Exception e)
            {
                callback(null, e);
            }
        }

        public void Save(DisasterPoint point, Action<DisasterPoint, Exception> callback)
        {
            Exception err = null;
            try
            {
                point.DisasterPointId=disasterPointRepository.Save(point);
            }
            catch (Exception e)
            {
                err = e;
            }
            callback(point, err);
        } 

        public void Update(DisasterPoint point, Action<DisasterPoint, Exception> callback)
        {
            Exception err = null;
            try
            {
               disasterPointRepository.Update(point);
            }
            catch (Exception e)
            {
                err = e;
            }
            callback(point, err);
        }

        public void Delete(int id, Action<int, Exception> callback)
        {
            Exception err = null;
            try
            {
                disasterPointRepository.DeleteById(id);
            }
            catch (Exception e)
            {
                err = e;
            }
            callback(id, err);
        }
        public DisasterPointService(IRepository<DisasterPoint> disasterPointRepository)
        {
            this.disasterPointRepository = disasterPointRepository;
        }
    }
}
