using Atk.DataPortal;
using Atk.DataPortal.Core;
using System;
using System.Threading.Tasks;

namespace Atk.DataPortal
{
    /// <summary>
    /// 数据门接口，业务类
    /// </summary>
    /// <typeparam name="E">业务类型</typeparam>
    public interface IDataPortal<E>
      where E : BusinessBase, IBusinessBaseContext
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>操作状态</returns>
        OperateState Insert(E obj);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>操作状态</returns>
        OperateState Delete(E obj);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>操作状态</returns>
        OperateState Update(E obj);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="obj">业务实例，可携带传入参数</param>
        /// <returns>查询结果</returns>
        E Fetch(E obj);


        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="obj">业务实例</param>
        /// <returns>操作状态</returns>
        OperateState Execute(E obj);
    }
}
