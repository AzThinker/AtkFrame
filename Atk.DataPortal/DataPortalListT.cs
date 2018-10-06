using Atk.DataPortal;
using Atk.DataPortal.Client;
using Atk.DataPortal.Core;

namespace Atk.DataPortal
{

    /// <summary>
    /// 数据门户访问泛型类
    /// </summary>
    /// <typeparam name="Es">BLL业务列表类型</typeparam>
    /// <typeparam name="E">BLL业务类型</typeparam>
    public class DataPortalList<Es, E> //: IDataPortalList<BusinessCriteria<E>, E>
                where E : BusinessBase, new()
    {
        /// <summary>
        /// 获取操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>返回结果</returns>
        public Es FetchList(BusinessCriteria<E> obj)
        {

            if (obj.Context.IsWcf)
            {

                return new WcfProxy<BusinessCriteria<E>>().Fetch(obj);
            }
            else
            {
                return LocalProxy<BusinessCriteria<E>>.Fetch(obj);
            }

        }


        /// <summary>
        /// 存储过程查询获取操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>返回结果</returns>
        public Es SpFetchList(BusinessCriteria<E> obj)
        {

            if (obj.Context.IsWcf)
            {
                return new WcfProxy<BusinessCriteria<E>>().SpFetch(obj);
            }
            else
            {
                return LocalProxy<BusinessCriteria<E>>.SpFetch(obj);
            }

        }


        /// <summary>
        /// 更新操作,批更新
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>返回结果</returns>

        public OperateState BatchSave(BusinessCriteria<E> obj)
        {

            if (obj.Context.IsWcf)
            {
                return new WcfProxy<BusinessCriteria<E>>().BatchSave(obj);
            }
            else
            {
                return LocalProxy<BusinessCriteria<E>>.Update(obj);
            }

        }
    }
}
