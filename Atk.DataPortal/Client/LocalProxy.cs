using Atk.DataPortal.Core;
using Atk.Tool.Cryptogram;
using System;

namespace Atk.DataPortal.Client
{
    /// <summary>
    /// 本地代理
    /// </summary>
    /// <typeparam name="T">业务类</typeparam>
    internal static class LocalProxy<T>
        where T : IBusinessTrace
    {

        private static T GetDataPortalContext(T obj)
        {
            if (obj is IBusinessContext)
            {
                var context = (obj as IBusinessContext).Context;
                var reult = DataSettingsHelper.GetCurrentDataSetting(context.DbConnectionKey);
            
                (obj as IBusinessContext).Context = reult;
            }
            else
                if (obj is IBusinessListContext)
                {
                    var context = (obj as IBusinessListContext).Context;
                    var reult = DataSettingsHelper.GetCurrentDataSetting(context.DbConnectionKey);
                    (obj as IBusinessListContext).Context = reult;

                }

            return obj;
        }

        /// <summary>
        /// 增加操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>被创建实例</returns>
        public static OperateState Insert(T obj)
        {
            obj.TraceSignPath("Local-in");
            obj = GetDataPortalContext(obj);
            if (obj is IBusinessInsert)
            {
                (obj as IBusinessInsert).DataPortal_Insert();
                obj.TraceSignLoacl();
                return obj.State;
            }
            else
            {
                throw new Exception("本地代理 Insert 方法调用失败");
            }
        }



        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>查询结果实例</returns>
        public static T Fetch(T obj)
        {
            obj.TraceSignPath("Local-in");
            obj = GetDataPortalContext(obj);
            if (obj is IBusinessFetch)
            {
                (obj as IBusinessFetch).DataPortal_Fetch();

                obj.TraceSignLoacl();
                return obj;
            }
            else
            {
                throw new Exception("本地代理 Fetch 方法调用失败");
            }
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>被更新实例</returns>
        public static OperateState Update(T obj)
        {
            obj = GetDataPortalContext(obj);
            if (obj is IBusinessUpdate)
            {
                (obj as IBusinessUpdate).DataPortal_Update();
                obj.TraceSignLoacl();
                return obj.State;
            }
            else
            {
                throw new Exception("本地代理 Update 方法调用失败");
            }
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>操作实例（只是类实例，可携带删除操作结果）</returns>
        public static OperateState Delete(T obj)
        {
            obj.TraceSignPath("Local-in");
            obj = GetDataPortalContext(obj);
            if (obj is IBusinessDelete)
            {
                (obj as IBusinessDelete).DataPortal_Delete();
                obj.TraceSignLoacl();
                return obj.State;
            }
            else
            {
                throw new Exception("本地代理 Delete 方法调用失败");
            }
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>命令实例（只是类实例，可携带操作结果）</returns>
        public static OperateState Execute(T obj)
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


        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>被更新实例</returns>
        public static OperateState BatchSave(T obj)
        {
            obj = GetDataPortalContext(obj);
            if (obj is IBusinessUpdate)
            {
                (obj as IBusinessUpdate).DataPortal_Update();
                obj.TraceSignLoacl();
                return obj.State;
            }
            else
            {
                throw new Exception("本地代理 Update 方法调用失败");
            }
        }

    }
}
