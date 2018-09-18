using Atk.DataPortal.Core;
using Autofac;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Atk.DataPortal.UiServer
{
    /// <summary>
    /// UI存储过程列表DTO
    /// </summary>
    /// <typeparam name="D">UI服务DTO类</typeparam>
    /// <typeparam name="Ds">UI服务DTO列表类</typeparam>
    /// <typeparam name="E">BLL业务类</typeparam>
    /// <typeparam name="Es">BLL业务列表类</typeparam>
    public abstract class BaseListUISpDto<D, Ds, E, Es> : List<D>
        where D : BaseUISpDto<D, E>
        where E : BusinessBase
        where Es : BusinessListBase<E>
        where Ds : BaseListUISpDto<D, Ds, E, Es>
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
        /// 记录总数
        /// </summary>

        private int _totalCount;

        /// <summary>
        /// 记录状态
        /// </summary>
        [ScaffoldColumn(false)]
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        /// <summary>
        /// 路踪路径，用于检查数据来源
        /// </summary>
        private string _accessPath;



        /// <summary>
        /// 路踪路径，用于检查数据来源
        /// </summary>
        public string GetAccessPath()
        {
            return _accessPath;
        }

        /// <summary>
        /// 访问地址
        /// </summary>
        private string _accessAddress;

        /// <summary>
        /// 访问地址
        /// </summary>
        public string GetAccessAddress()
        {
            return _accessAddress;
        }

        /// <summary>
        /// BLL拷贝至UI-DTO方法
        /// </summary>
        /// <param name="items">BLL列表实例</param>
        /// <returns>UI服务列表实例</returns>
        public virtual Ds ListCopyOut(Es items)
        {
            Ds result = _lc.Resolve<Ds>();
            result.Clear();
            foreach (var item in items)
            {

                var uitem = _lc.Resolve<D>();
                result.Add(uitem.CopyToOut(item));
            }
            result.TotalCount = items.TotalCount;
            result._accessAddress = items.AccessAddress;
            result._accessPath = items.AccessPath;
            return result;
        }

        /// <summary>
        /// UI-DTO拷贝至BLL方法
        /// </summary>
        /// <returns>返回结果</returns>
        public abstract Es CopyToIn();

    }
}
