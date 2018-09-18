using Atk.DataPortal.Core;
using Autofac;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Atk.DataPortal.UiServer
{
    /// <summary>
    /// UI数据迁移对象
    /// </summary>
    public abstract class BaseUIDto<D, E> : BaseEntity, IComparable<D>
        where D : BaseUIDto<D, E>
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
        [XmlIgnoreAttribute]
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

        public void SetLifetimeScope(ILifetimeScope lc)
        {
            _lc = lc;
        }




        /// <summary>
        /// 记录状态
        /// </summary>
        [XmlIgnoreAttribute]
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
        /// BLL类到UI-DTO拷贝
        /// </summary>
        /// <param name="initem">BLL类</param>
        /// <returns>UI-DTO类</returns>
        public abstract D CopyToOut(E initem);

        /// <summary>
        /// UI-DTO至BLL类拷贝
        /// </summary>
        /// <returns>BLL类实例</returns>
        public abstract E CopyToIn();

        /// <summary>
        /// Json拷贝
        /// </summary>
        /// <returns>返回结果</returns>
        public abstract object JsonCopy();

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="other">要比较的对象</param>
        /// <returns>相等为 0 其它值为不等</returns>
        public abstract int CompareTo(D other);


        /// <summary>
        /// 读写操作
        /// </summary>
        [ScaffoldColumn(false)]
        [XmlIgnoreAttribute]
        public RecordOperater Op { get; set; }


    }
}
