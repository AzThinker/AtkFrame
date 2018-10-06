
using Atk.DataPortal;
using Atk.DataPortal.Client;
using Atk.DataPortal.Core;

namespace Atk.DataPortal
{
    /// <summary>
    /// 数据门户访问泛型类
    /// </summary>
    /// <typeparam name="E">业务类型</typeparam>
    public class DataPortal<E> //: IDataPortal<E>
        where E : BusinessBase ,new()
    {

        /// <summary>
        /// 增加操作
        /// </summary>
        /// <param name="businessCriteria">业务类</param>
        /// <returns>操作结果</returns>
        public OperateState Insert(BusinessCriteria<E> businessCriteria)
        {

            if (businessCriteria.Context.IsWcf)
            {
                return new WcfProxy<BusinessCriteria<E>>().Insert(businessCriteria);
            }
            else
            {
                return LocalProxy<BusinessCriteria<E>>.Insert(businessCriteria);
            }

        }

        /// <summary>
        /// 获取操作
        /// </summary>
        /// <param name="businessCriteria">业务类</param>
        /// <returns>业务类</returns>
        public BusinessCriteria<E> Fetch(BusinessCriteria<E> businessCriteria)
        {

            if (businessCriteria.Context.IsWcf)
            {
                return new WcfProxy<BusinessCriteria<E>>().Fetch(businessCriteria);
            }
            else
            {
                return LocalProxy<BusinessCriteria<E>>.Fetch(businessCriteria);
            }

        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="businessCriteria">业务类</param>
        /// <returns>操作结果</returns>

        public OperateState Update(BusinessCriteria<E> businessCriteria)
        {

            if (businessCriteria.Context.IsWcf)
            {
                return new WcfProxy<BusinessCriteria<E>>().Update(businessCriteria);
            }
            else
            {
                return LocalProxy<BusinessCriteria<E>>.Update(businessCriteria);
            }

        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="businessCriteria">业务类</param>
        /// <returns>操作结果</returns>
        public OperateState Execute(BusinessCriteria<E> businessCriteria)
        {
            if (businessCriteria.Context.IsWcf)
            {
                return new WcfProxy<BusinessCriteria<E>>().Execute(businessCriteria);
            }
            else
            {
                return LocalProxy<BusinessCriteria<E>>.Execute(businessCriteria);
            }
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="businessCriteria">业务类</param>
        /// <returns>操作结果</returns>
        public OperateState Delete(BusinessCriteria<E> businessCriteria)
        {
            if (businessCriteria.Context.IsWcf)
            {
                return new WcfProxy<BusinessCriteria<E>>().Delete(businessCriteria);
            }
            else
            {
                return LocalProxy<BusinessCriteria<E>>.Delete(businessCriteria);
            }
        }


    }
}
