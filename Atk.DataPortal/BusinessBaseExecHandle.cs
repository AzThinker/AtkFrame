using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.DataPortal.UiServer;
using Autofac;


namespace Atk.DataPortal
{
    /// <summary>
    /// 执行存储过程执行操作基类
    /// </summary>
    /// <typeparam name="E">BLL列表类</typeparam>
    /// <typeparam name="D">UI-DTO类</typeparam>
    public abstract class BusinessBaseExecHandle<E, D>
        where E : BusinessBase
        where D : BaseUIExecDto<E>
    {
        #region 构造方法

        /// <summary>
        /// IOC容器
        /// </summary>
        protected ILifetimeScope _lc;

        /// <summary>
        /// 数据门上下文
        /// </summary>
        protected DataPortalContext _dataportalcontext;

        /// <summary>
        /// 数据门上下文
        /// </summary>
        public DataPortalContext BizDataportalcontext
        {
            get { return _dataportalcontext; }
            set { _dataportalcontext = value; }
        }

        /// <summary>
        /// 数据门工作上下文
        /// </summary>
        protected DataPortalWorkContext _workcontext;

        /// <summary>
        /// 基本操作权限
        /// </summary>
        protected Power _power;

        /// <summary>
        /// 数据门
        /// </summary>
        protected IDataPortal<E> _dataportal;

        /// <summary>
        /// 设置基本操作权限
        /// </summary>
        /// <param name="power">基本操作权限</param>
        public void SetPower(Power power)
        {
            _power = power;
        }

        /// <summary>
        /// 设置工作上下文
        /// </summary>
        /// <param name="workcontext">工作上下文</param>
        public void SetWorkContext(DataPortalWorkContext workcontext)
        {
            _workcontext = workcontext;
        }

        /// <summary>
        /// 设置数据门上下文
        /// </summary>
        /// <param name="context">数据门上下文</param>
        public void SetDataPortalContext(DataPortalContext context)
        {
            _dataportalcontext = context;
        }

        /// <summary>
        /// 附加数据门上下文
        /// </summary>
        /// <param name="bllitem">BLL业务类</param>
        protected virtual void ApplyContext(E bllitem)
        {
            bllitem.Context = _dataportalcontext;
            bllitem.WorkContext = _workcontext;
        }

        /// <summary>
        /// 返状态操作
        /// </summary>
        /// <param name="item">UI服务DTO类</param>
        /// <returns>操作状态</returns>
        protected virtual OperateState ItemHandleState(D item)
        {
            E bllitem = item.CopyToIn();
            ApplyContext(bllitem);
            return _dataportal.Execute(bllitem);
        }

        #endregion

        #region 执行

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <returns>更新结果</returns>
        public virtual OperateState Execute(D item)
        {
            if (!_power.Execute)
            {
                return OperateState.FailState("没有编辑记录权限！");
            }
            //强制清除条件，以使记录更新为当前记录，而非批量更新
            return ItemHandleState(item);
        }

        #endregion
    }
}
