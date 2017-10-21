﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using System.Data;
using MySql.Data.MySqlClient;
namespace MajiaobaGeoSystem.Util
{
    /// <summary>
    /// Dapper数据访问封装
    /// 2017/04/13 fhr
    /// </summary>
    public class DapperSimpleUtil
    {
        #region 获取连接
        /// <summary>
        /// 获取已开启的数据库链接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection OpenConnection()
        {
            var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["majiaogeo"].ConnectionString.ToString());
            connection.Open();
            return connection;
        }
        #endregion
        #region 原生查询
        /// <summary>
        /// 泛型查询多个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static IEnumerable<T> Query<T>(string sql, object objectParam = null)
        {
            using (var connection = OpenConnection())
            {
                return connection.Query<T>(sql, objectParam);
            }
        }
        /// <summary>
        /// 通过匿名类型查询多个对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectParam"></param>
        /// <returns></returns>
        public static IEnumerable<dynamic> Query(string sql, object objectParam = null)
        {
            using (var connection = OpenConnection())
            {
                return connection.Query(sql, objectParam);
            }
        }
        /// <summary>
        /// 查询单个对象 泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="objectParam"></param>
        /// <returns></returns>
        public static T QuerySingle<T>(string sql, object objectParam = null)
        {
            using (var connection = OpenConnection())
            {
                return connection.QueryFirstOrDefault<T>(sql, objectParam);
            }
        }
        /// <summary>
        /// 查询单个对象 匿名类型
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectParam"></param>
        /// <returns></returns>
        public static dynamic QuerySingle(string sql, object objectParam = null)
        {
            using (var connection = OpenConnection())
            {
                return connection.QueryFirstOrDefault(sql, objectParam);
            }
        }
        /// <summary>
        /// 组合查询，多返回结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqls"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<dynamic>> MultiQuery(string[] sqls, object objectParam = null)
        {
            var sql = BuildSQL(sqls);
            using (var connection = OpenConnection())
            using (var multipleReader = connection.QueryMultiple(sql, objectParam))
            {
                var results = new List<IEnumerable<dynamic>>();
                for (int i = 0; i < sqls.Length; i++)
                {
                    results.Add(multipleReader.Read());
                }
                return results;
            }
        }
        #endregion
        #region 通用
        /// <summary>
        /// 执行sql语句
        /// 返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramsObject"></param>
        /// <returns></returns>
        public static int ExecuteSQL(string sql, object paramsObject = null)
        {
            using (var connection = OpenConnection())
            {
                return connection.Execute(sql, paramsObject);
            }
        }
        /// <summary>
        /// 多段sql执行事务
        /// </summary>
        /// <param name="sqls"></param>
        /// <param name="paramsObject"></param>
        /// <returns></returns>
        public static void ExecuteTransaction(List<string> sqls, object paramsObject = null)
        {
            using (var connection = OpenConnection())
            using (var tran = connection.BeginTransaction())
            {
                try
                {
                    foreach (var sql in sqls)
                    {
                        connection.Execute(sql, paramsObject);
                    }
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
        #endregion
        #region 原生Dapper的插入或者修改
        /// <summary>
        /// 执行一个对象的插入或者修改操作
        /// 返回主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="enity"></param>
        public static void ExecuteSingleUpdateOrInsert<T>(string sql, T enity)
        {
            using (var connection = OpenConnection())
            {
                connection.ExecuteScalar(sql, enity);
            }
        }
        /// <summary>
        /// 执行一个对象的插入或者修改操作
        /// 返回主键
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="enity"></param>
        public static void ExecuteSingleUpdateOrInsert(string sql, object enity)
        {
            using (var connection = OpenConnection())
            {
                connection.ExecuteScalar(sql, enity);
            }
        }
        /// <summary>
        /// 执行多个对象的插入或者修改 使用了事务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="enity"></param>
        public static void ExecuteUpdateOrInsert<T>(string sql, IEnumerable<T> enitys)
        {
            using (var connection = OpenConnection())
            using (var tran = connection.BeginTransaction())
            {
                try
                {
                    connection.Execute(sql, enitys);
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// 执行多个对象的插入或者修改 使用了事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="enitys"></param>
        /// <returns></returns>
        public static void ExecuteUpdateOrInsert(string sql, IEnumerable<object> enitys)
        {
            using (var connection = OpenConnection())
            using (var tran = connection.BeginTransaction())
            {
                try
                {
                    connection.Execute(sql, enitys);
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
        #endregion
        #region 扩展查询
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> QueryAllByExtension<T>() where T : class
        {
            using (var connection = OpenConnection())
            {
                return connection.GetList<T>().ToList<T>();
            }
        }
        /// <summary>
        /// 通过谓词查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> QueryByPredicateExtension<T>(object predicate) where T : class
        {
            using (var connection = OpenConnection())
            {
                return connection.GetList<T>(predicate);
            }
        }
        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T QueryByIdExtension<T>(object id) where T : class
        {
            using (var connection = OpenConnection())
            {
                return connection.Get<T>(id);
            }
        }
        #endregion
        #region 扩展插入
        /// <summary>
        /// 插入单个对象 返回主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static dynamic SaveByExtension<T>(T entity) where T : class
        {
            using (var connection = OpenConnection())
            {
                return connection.Insert(entity);
            }
        }
        /// <summary>
        /// 批量查入对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public static void SaveByExtension<T>(IEnumerable<T> entitys) where T : class
        {
            using (var connection = OpenConnection())
            using (var tran = connection.BeginTransaction())
            {
                connection.Insert(entitys, tran);
            }
        }
        #endregion
        #region 扩展修改
        /// <summary>
        /// Update单个对象 返回主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static dynamic UpdateByExtension<T>(T entity) where T : class
        {
            using (var connection = OpenConnection())
            {
                return connection.Update(entity);
            }
        }
        /// <summary>
        /// 批量Update对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public static void UpdateByExtension<T>(IEnumerable<T> entitys) where T : class
        {
            using (var connection = OpenConnection())
            using (var tran = connection.BeginTransaction())
            {
                connection.Update(entitys, tran);
            }
        }
        #endregion
        #region 扩展删除
        /// <summary>
        /// 根据对象来删除对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void DeleteEntity<T>(T entity) where T : class
        {
            using (var connection = OpenConnection())
            {
                connection.Delete<T>(entity);
            }
        }

        /// <summary>
        /// 根据对象ID删除对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public static void DeleteEntityById<T>(object id) where T : class
        {
            using (var connection = OpenConnection())
            {
                T obj = connection.Get<T>(id);
                connection.Delete<T>(obj);
            }
        }
        /// <summary>
        /// 根据对象集合批量删除对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void DeleteEntity<T>(IEnumerable<T> entitys) where T : class
        {
            using (var connection = OpenConnection())
            {
                foreach (var entity in entitys)
                {
                    connection.Delete<T>(entity);
                }
            }
        }

        /// <summary>
        /// 根据对象ID集合批量删除对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        public static void DeleteEntity<T>(IEnumerable<int> ids) where T : class
        {
            using (var connection = OpenConnection())
            {
                foreach (var id in ids)
                {
                    connection.Delete<T>(id);
                }
            }
        }
        #endregion
        #region 私有辅助方法
        /// <summary>
        /// 多段sql语句拼接为一句sql
        /// </summary>
        /// <param name="sqls"></param>
        /// <returns></returns>
        private static string BuildSQL(string[] sqls)
        {
            if (sqls == null || sqls.Length == 0)
            {
                throw new ArgumentException();
            }
            var sql = new StringBuilder("");
            for (var i = 0; i < sqls.Length; i++)
            {
                sql.Append(sqls[i]);
                if (i != sqls.Length - 1)
                {
                    sql.Append(";");
                }
            }
            return sql.ToString();
        }
        #endregion
    }
}
