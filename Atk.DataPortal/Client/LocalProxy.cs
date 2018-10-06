using System;
using System.Linq;
using Atk.DataPortal.Core;
using Atk.Tool.Cryptogram;
using SqlRepoEx.Core;

namespace Atk.DataPortal.Client
{
    /// <summary>
    /// 本地代理
    /// </summary>
    /// <typeparam name="T">业务类</typeparam>
    internal static class LocalProxy<T>
        where T : BusinessBase, new()
    {

        /// <summary>
        /// 增加操作
        /// </summary>
        /// <param name="insertStatement">业务实例</param>
        /// <returns>被创建实例</returns>
        public static T Insert(InsertStatementBase<T> insertStatement)
        {
            return insertStatement.Go();

        }



        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>查询结果实例</returns>
        public static T Fetch(SelectStatementBase<T> selectStatement)
        {
            return selectStatement.Go().ToList().FirstOrDefault();
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>查询结果实例</returns>
        public static BusinessListBase<T> FetchList(SelectStatementBase<T> selectStatement)
        {
            BusinessListBase<T> blist = new BusinessListBase<T>();
            var result = selectStatement.Go();
            blist.AddRange(result);
            return blist;
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>被更新实例</returns>
        public static int Update(UpdateStatementBase<T> updateStatement)
        {
            return updateStatement.Go();
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>操作实例（只是类实例，可携带删除操作结果）</returns>
        public static int Delete(DeleteStatementBase<T> deleteStatement)
        {
            return deleteStatement.Go();
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>命令实例（只是类实例，可携带操作结果）</returns>
        public static OperateState Execute(ExecuteNonQuerySqlStatement executeNonQuery)
        {
            obj.TraceSignPath("Local-in");
            obj = GetDataPortalContext(obj);
            if (obj is IBusinessExecute)
            {
                (obj as IBusinessExecute).DataPortal_Execute();
                obj.TraceSignLoacl();
                return obj.State;
            }
            else
            {
                throw new Exception("本地代理 Execute 方法调用失败");
            }
        }


        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>命令实例（只是类实例，可携带操作结果）</returns>
        public static T SpFetch(T obj)
        {
            obj.TraceSignPath("Local-in");
            obj = GetDataPortalContext(obj);
            if (obj is IBusinessSpFetch)
            {
                (obj as IBusinessSpFetch).DataPortal_SpFetch();
                obj.TraceSignLoacl();
                return obj;
            }
            else
            {
                throw new Exception("本地代理 SpFetch 方法调用失败");
            }
        }

    }
}
