
using Atk.DataPortal;
using Atk.DataPortal.Client;
using Atk.DataPortal.Core;

namespace Atk.DataPortal
{
    /// <summary>
    /// 数据门户访问泛型类
    /// </summary>
    /// <typeparam name="E">业务类型</typeparam>
    public class DataPortal<E> : IDataPortal<E>
        where E : BusinessBase, IBusinessBaseContext
    {

        /// <summary>
        /// 增加操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>操作结果</returns>
        public OperateState Insert(E obj)
        {

            if (obj.Context.IsWcf)
            {
                return new WcfProxy<E>().Insert(obj);
            }
            else
            {
                return LocalProxy<E>.Insert(obj);
            }

        }

        /// <summary>
        /// 获取操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>业务类</returns>
        public E Fetch(E obj)
        {

            if (obj.Context.IsWcf)
            {
                return new WcfProxy<E>().Fetch(obj);
            }
            else
            {
                return LocalProxy<E>.Fetch(obj);
            }

        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>操作结果</returns>

        public OperateState Update(E obj)
        {

            if (obj.Context.IsWcf)
            {
                return new WcfProxy<E>().Update(obj);
            }
            else
            {
                return LocalProxy<E>.Update(obj);
            }

        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>操作结果</returns>
        public OperateState Execute(E obj)
        {
            if (obj.Context.IsWcf)
            {
                return new WcfProxy<E>().Execute(obj);
            }
            else
            {
                return LocalProxy<E>.Execute(obj);
            }
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>操作结果</returns>
        public OperateState Delete(E obj)
        {
            if (obj.Context.IsWcf)
            {
                return new WcfProxy<E>().Delete(obj);
            }
            else
            {
                return LocalProxy<E>.Delete(obj);
            }
        }


    }
}
