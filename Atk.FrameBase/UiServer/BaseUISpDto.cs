using Autofac;
using Atk.DataPortal.Core;
using System.Xml.Serialization;

namespace Atk.DataPortal.UiServer
{

    /// <summary>
    /// UI数据迁移对象基类
    /// </summary>
    /// <typeparam name="D">UI-DTO</typeparam>
    /// <typeparam name="E">BLL业务类</typeparam>
    public abstract class BaseUISpDto<D, E> : BaseEntity
        where D : BaseUISpDto<D, E>
        where E : BusinessBase
    {
        /// <summary>
        /// IOC容器
        /// </summary>
       [XmlIgnoreAttribute]
        protected ILifetimeScope _lc;

        /// <summary>
        /// 权限
        /// </summary>
        private Power _power;

        /// <summary>
        /// 权限
        /// </summary>
        [XmlIgnoreAttribute]
        public Power Power
        {
            get { return _power; }
            set { _power = value; }
        }

        /// <summary>
        /// 记录状态
        /// </summary>
        private OperateState _state;

        /// <summary>
        /// 记录状态
        /// </summary>
        [XmlIgnoreAttribute]
        public OperateState State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// BLL拷贝出
        /// </summary>
        /// <param name="initem">BLL业务实例</param>
        /// <returns>UI-DTO实例</returns>
        public abstract D CopyToOut(E initem);

        /// <summary>
        /// JSON拷贝
        /// </summary>
        /// <returns>Json对象</returns>
        public abstract object JsonCopy();

    }
}
