using Atk.DataPortal.Core;
using Autofac;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Atk.DataPortal.UiServer
{
    /// <summary>
    /// UI执行类DTO基类
    /// </summary>
    /// <typeparam name="E">BLL业务类</typeparam>
    public abstract class BaseUIExecDto<E> where E : BusinessBase
    {
        /// <summary>
        /// IOC
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
        [ScaffoldColumn(false)]
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
        [ScaffoldColumn(false)]
        [XmlIgnoreAttribute]
        public OperateState State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// UI.DTO拷贝至BLL的方法
        /// </summary>
        /// <returns>返回结果</returns>
        public abstract E CopyToIn();
    }
}
