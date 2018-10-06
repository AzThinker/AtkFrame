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
    public abstract class BusinessBaseExecHandle<E>
        where E : BusinessBase
    {
        #region 构造方法

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
        #endregion
    }
}
