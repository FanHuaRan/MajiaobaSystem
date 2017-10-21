using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajiaobaGeoSystem.Repository
{
    /// <summary>
    /// 仓库基本接口
    /// 2017/10/20 fhr
    /// </summary>
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> FindAll();
        T FindById(object id);
        IEnumerable<T> FindBySQL(string sql, object objectParam);
        IEnumerable<T> FindByPredicate(object predicate);
        dynamic Save(T obj);
        void Update(T obj);
        void Delete(T obj);
        void DeleteById(object id);
    }
}
