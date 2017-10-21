using MajiaobaGeoSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.Repository
{
    /// <summary>
    /// 仓库基础实现
    /// IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T>:IRepository<T> where T:class
    {

        public IEnumerable<T> FindAll()
        {
            return DapperSimpleUtil.QueryAllByExtension<T>();
        }

        public T FindById(object id)
        {
            return DapperSimpleUtil.QueryByIdExtension<T>(id);
        }

        public IEnumerable<T> FindBySQL(string sql, object objectParam)
        {
           return DapperSimpleUtil.Query<T>(sql, objectParam);
        }

        public IEnumerable<T> FindByPredicate(object predicate)
        {
            return DapperSimpleUtil.QueryByPredicateExtension<T>(predicate);
        }

        public dynamic Save(T obj)
        {
            return DapperSimpleUtil.SaveByExtension<T>(obj);
        }

        public void Update(T obj)
        {
             DapperSimpleUtil.UpdateByExtension<T>(obj);
        }

        public void Delete(T obj)
        {
            DapperSimpleUtil.DeleteEntity<T>(obj);
        }

        public void DeleteById(object id)
        {
            DapperSimpleUtil.DeleteEntityById<T>(id);
        }
    }
}
