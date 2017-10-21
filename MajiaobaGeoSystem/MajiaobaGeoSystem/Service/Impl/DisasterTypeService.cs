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
    /// DisasterType服务实现
    /// 2017/10/20 fhr
    /// </summary>
    public class DisasterTypeService : IDisasterTypeService
    {
        private readonly IRepository<DisasterType> disasterTypeRepository;
        public void FindOne(int id,Action<DisasterType, Exception> callback)
        {
            try
            {
                var type = disasterTypeRepository.FindById(id);
                callback(type, null);
            }
            catch (Exception e)
            {
                callback(null, e);
            }
        }

        public void FindAll(Action<IEnumerable<DisasterType>, Exception> callback)
        {
            try
            {
                var types = disasterTypeRepository.FindAll();
                callback(types, null);
            }
            catch (Exception e)
            {
                callback(null, e);
            }
        }

        public DisasterTypeService(IRepository<DisasterType> disasterTypeRepository)
        {
            this.disasterTypeRepository = disasterTypeRepository;
        }
    }
}
