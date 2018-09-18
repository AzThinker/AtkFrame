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
    public class DataPortalList<Es, E> : IDataPortalList<Es, E>
        where Es : BusinessListBase<E>
        where E : BusinessBase
    {
        /// <summary>
        /// 获取操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>返回结果</returns>
        public Es FetchList(Es obj)
        {

            if (obj.Context.IsWcf)
            {

                return new WcfProxy<Es>().Fetch(obj);
            }
            else
            {
                return LocalProxy<Es>.Fetch(obj);
            }

        }


        /// <summary>
        /// 存储过程查询获取操作
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>返回结果</returns>
        public Es SpFetchList(Es obj)
        {

            if (obj.Context.IsWcf)
            {
                return new WcfProxy<Es>().SpFetch(obj);
            }
            else
            {
                return LocalProxy<Es>.SpFetch(obj);
            }

        }


        /// <summary>
        /// 更新操作,批更新
        /// </summary>
        /// <param name="obj">业务类</param>
        /// <returns>返回结果</returns>

        public OperateState BatchSave(Es obj)
        {

            if (obj.Context.IsWcf)
            {
                return new WcfProxy<Es>().BatchSave(obj);
            }
            else
            {
                return LocalProxy<Es>.Update(obj);
            }

        }
    }
}
