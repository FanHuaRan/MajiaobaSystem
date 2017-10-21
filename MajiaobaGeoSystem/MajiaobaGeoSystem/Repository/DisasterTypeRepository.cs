using MajiaobaGeoSystem.DomainModel;
using MajiaobaGeoSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.Repository
{
    public class DisasterTypeRepository : IRepository<DisasterType>
    {

        private static readonly string QUERY_ALL = "select * from DisasterType";
        public IEnumerable<DisasterType> FindAll()
        {
            return DapperSimpleUtil.Query<DisasterType>(QUERY_ALL);
        }

        DisasterType IRepository<DisasterType>.FindById(object id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DisasterType> IRepository<DisasterType>.FindBySQL(string sql, object objectParam)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DisasterType> IRepository<DisasterType>.FindByPredicate(object predicate)
        {
            throw new NotImplementedException();
        }

        dynamic IRepository<DisasterType>.Save(DisasterType obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<DisasterType>.Update(DisasterType obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<DisasterType>.Delete(DisasterType obj)
        {
            throw new NotImplementedException();
        }

        void IRepository<DisasterType>.DeleteById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
