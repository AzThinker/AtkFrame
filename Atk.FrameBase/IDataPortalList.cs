using Atk.DataPortal;
using Atk.DataPortal.Core;
using System;
using System.Threading.Tasks;

namespace Atk.DataPortal
{
    /// <summary>
    /// 列表数据门户
    /// </summary>
    /// <typeparam name="Es">列表类</typeparam>
    /// <typeparam name="E">业务类</typeparam>
    public interface IDataPortalList<Es, E>
        where Es : BusinessListBase<E>
        where E : BusinessBase
    {
        /// <summary>
        /// 获取列表业务
        /// </summary>
        /// <param name="obj">传入参数</param>
        /// <returns>列表业务</returns>
        Es FetchList(Es obj);

        /// <summary>
        /// 获取列表业务
        /// </summary>
        /// <param name="obj">传入参数</param>
        /// <returns>列表业务</returns>
        Es SpFetchList(Es obj);

        /// <summary>
        /// 批量保存操作
        /// </summary>
        /// <param name="obj">要保存的业务集</param>
        /// <returns>操作状态</returns>
        OperateState BatchSave(Es obj);
    }
}
