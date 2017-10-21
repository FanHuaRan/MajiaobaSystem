using MajiaobaGeoSystem.DomainModel;
using MajiaobaGeoSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.Repository
{
    public class DisasterPointRepository : IRepository<DisasterPoint>
    {
        private static readonly string QUERY_ALL = "select * from DisasterPoint";
        public IEnumerable<DisasterPoint> FindAll()
        {
            return DapperSimpleUtil.Query<DisasterPoint>(QUERY_ALL);
        }

        public DisasterPoint FindById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisasterPoint> FindBySQL(string sql, object objectParam)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisasterPoint> FindByPredicate(object predicate)
        {
            throw new NotImplementedException();
        }

        public dynamic Save(DisasterPoint obj)
        {
            throw new NotImplementedException();
        }

        public void Update(DisasterPoint obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(DisasterPoint obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
