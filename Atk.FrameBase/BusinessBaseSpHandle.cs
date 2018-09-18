using Atk.DataPortal.Core;
using Atk.DataPortal.UiServer;
using Autofac;
using System.Collections.Generic;

namespace Atk.DataPortal
{
    /// <summary>
    /// 存储过程查询类操作基类
    /// </summary>
    /// <typeparam name="Es">BLL列表类</typeparam>
    /// <typeparam name="E">BLL类</typeparam>
    /// <typeparam name="Ds">UI服务列表类</typeparam>
    /// <typeparam name="D">UI服务DTO类</typeparam>
    public abstract class BusinessBaseSpHandle<Es, E, Ds, D>
        where Es : BusinessListBase<E>
        where E : BusinessBase
        where D : BaseUISpDto<D, E>
        where Ds : BaseListUISpDto<D, Ds, E, Es>
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
        /// 基本权限
        /// </summary>
        protected Power _power;

        /// <summary>
        /// 数据门列表接口
        /// </summary>
        protected IDataPortalList<Es, E> _dataportallist;

        /// <summary>
        /// 基本权限
        /// </summary>
        /// <param name="power">基本权限</param>
        public void SetPower(Power power)
        {
            _power = power;
        }

        /// <summary>
        /// 工作上下文
        /// </summary>
        /// <param name="workcontext">工作上下文</param>
        public void SetWorkContext(DataPortalWorkContext workcontext)
        {
            _workcontext = workcontext;
        }

        /// <summary>
        /// 数据门上下文
        /// </summary>
        /// <param name="context">数据门上下文</param>
        public void SetDataPortalContext(DataPortalContext context)
        {
            _dataportalcontext = context;
        }

        /// <summary>
        /// 符加至数据门上下文
        /// </summary>
        /// <param name="bllitem">业务类</param>
        protected virtual void ApplyContext(E bllitem)
        {
            bllitem.Context = _dataportalcontext;
            bllitem.WorkContext = _workcontext;
        }

        /// <summary>
        /// 符加至数据门上下文
        /// </summary>
        /// <param name="bllitems">列表业务类</param>
        protected virtual void ApplyContext(Es bllitems)
        {
            bllitems.Context = _dataportalcontext;
            bllitems.WorkContext = _workcontext;
        }

        #endregion

        #region 列表查询

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Items">传入UI的业务类实例，用着传入条件携带者</param>
        /// <returns>查询结果</returns>
        public virtual Ds GetList(Ds Items)
        {
            Es initems = Items.CopyToIn();

            if (!_power.Get)
            {
                Items.State.Error.Add("权限", "没有操作权限");
                return Items;
            }


            ApplyContext(initems);

            var updateitems = _dataportallist.SpFetchList(initems);
            return Items.ListCopyOut(updateitems);
        }



        #endregion

        #region 特殊格式 数据操作方法

        /// <summary>
        /// Json格式 查询，行，页参数应该在存储过程参数中设置
        /// 这样在产生 Items 类时，就会有相应的页行属性，以此来获知如何分页
        /// </summary>
        /// <param name="Items">传入UI的业务类实例，用着传入条件携带者</param>
        /// <param name="Page">页</param>
        /// <param name="Row">行</param>
        /// <returns>返回结果</returns>
        public virtual JsonObjectResult GetJsonList(Ds Items, int Page = 0, int Row = 0)
        {

            Ds esitems = GetList(Items);
            List<object> result = new List<object>();
            foreach (var item in esitems)
            {
                result.Add(item.JsonCopy());
            }
            return JsonObjectResult.Get(result, esitems.TotalCount, Page, Row);


        }


        /// <summary>
        /// XML格式查询
        /// </summary>
        /// <param name="Items">传入UI的业务类实例，用着传入条件携带者</param>
        /// <returns>返回结果</returns>
        public virtual string GetXmlList(Ds Items)
        {

            return XmlUtil.Serializer(typeof(List<D>), GetList(Items));
        }

        #endregion
    }
}
