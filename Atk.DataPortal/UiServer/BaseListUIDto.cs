using Atk.DataPortal.Core;
using Autofac;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Atk.DataPortal.UiServer
{
    /// <summary>
    /// UI服务列表类DTO
    /// </summary>
    /// <typeparam name="D">UI服务DTO类</typeparam>
    /// <typeparam name="E">BLL业务类</typeparam>
    public abstract class BaseListUIDto<D, E> : List<D>
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

        /// <summary>
        /// 记录状态
        /// </summary>
        [XmlIgnoreAttribute]
        private OperateState _state;

        /// <summary>
        /// 记录状态
        /// </summary>
        [ScaffoldColumn(false)]

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
        [XmlIgnoreAttribute]
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
        [XmlIgnoreAttribute]
        private string _accessAddress;

        /// <summary>
        /// 访问地址
        /// </summary>
         public string GetAccessAddress()
        {
            return _accessAddress;
        }

        /// <summary>
        /// BLL向UI服务拷贝
        /// </summary>
        /// <typeparam name="Ds">UI服务列表灰</typeparam>
        /// <typeparam name="Es">BLL业务列表类</typeparam>
        /// <param name="items">BLL业务列表实例</param>
        /// <returns>UI服务列表实例</returns>
        public virtual Ds BizListCopyOut<Ds, Es>(Es items)
            where Ds : BaseListUIDto<D, E>
            where Es : BusinessListBase<E>
        {
            Ds result = _lc.Resolve<Ds>();
            result.Clear();
            foreach (var item in items)
            {

                var uitem = _lc.Resolve<D>();
                uitem.State = items.State;

                result.Add(uitem.CopyToOut(item));
            }
            result.TotalCount = items.TotalCount;
            result._accessAddress = items.AccessAddress;
            result._accessPath = items.AccessPath;
            return result;
        }

        /// <summary>
        /// UI服务向BLL拷贝
        /// </summary>
        /// <typeparam name="Ds">UI服务列表灰</typeparam>
        /// <typeparam name="Es">BLL业务列表类</typeparam>
        /// <param name="items">UI服务列表实例</param>
        /// <returns>BLL列表实例</returns>
        public virtual Es ListCopyIn<Ds, Es>(Ds items)
            where Ds : BaseListUIDto<D, E>
            where Es : BusinessListBase<E>
        {
            Es result = _lc.Resolve<Es>();
            result.Clear();
            foreach (var item in items)
            {

                var uitem = _lc.Resolve<D>();
                result.Add(item.CopyToIn());
            }
            result.TotalCount = items.TotalCount;
            return result;
        }

        /// <summary>
        /// 批量保存，UI服务向BLL拷贝
        /// </summary>
        /// <typeparam name="Ds">UI服务列表灰</typeparam>
        /// <typeparam name="Es">BLL业务列表类</typeparam>
        /// <param name="bizInsertList">增加集</param>
        /// <param name="bizUpdateList">更新集</param>
        /// <param name="bizDeleteList">删除集</param>
        /// <returns>BLL业务列表实例</returns>
        public virtual Es ListSave<Ds, Es>(Ds bizInsertList, Ds bizUpdateList, Ds bizDeleteList)
            where Ds : BaseListUIDto<D, E>
            where Es : BusinessListBase<E>
        {
            Es result = _lc.Resolve<Es>();
            foreach (var item in bizInsertList)
            {
                var additem = item.CopyToIn();
                additem.Op = RecordOperater.Insert;
                result.Add(additem);
            }
            foreach (var item in bizUpdateList)
            {
                var additem = item.CopyToIn();
                additem.Op = RecordOperater.Updata;
                result.Add(additem);
            }

            foreach (var item in bizDeleteList)
            {
                var additem = item.CopyToIn();
                additem.Op = RecordOperater.Delete;
                result.Add(additem);
            }
            return result;
        }

        /// <summary>
        /// 批量保存，UI服务向BLL拷贝
        /// </summary>
        /// <typeparam name="Es">BLL业务列表类</typeparam>
        /// <param name="bizInsertList">增加集</param>
        /// <param name="bizUpdateList">更新集</param>
        /// <param name="bizDeleteList">删除集</param>
        /// <returns>BLL业务列表实例</returns>
        public virtual Es ListSave<Es>(List<D> bizInsertList, List<D> bizUpdateList, List<D> bizDeleteList) where Es : BusinessListBase<E>
        {
            Es result = _lc.Resolve<Es>();
            foreach (var item in bizInsertList)
            {
                var additem = item.CopyToIn();
                additem.Op = RecordOperater.Insert;
                result.Add(additem);
            }
            foreach (var item in bizUpdateList)
            {
                var additem = item.CopyToIn();
                additem.Op = RecordOperater.Updata;
                result.Add(additem);
            }

            foreach (var item in bizDeleteList)
            {
                var additem = item.CopyToIn();
                additem.Op = RecordOperater.Delete;
                result.Add(additem);
            }
            return result;
        }



    }
}
