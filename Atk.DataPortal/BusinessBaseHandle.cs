using Atk.CustomExpression;
using Atk.DataPortal.Core;
using Atk.DataPortal.UiServer;
using Autofac;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Script.Serialization;


namespace Atk.DataPortal
{

    /// <summary>
    /// 通用执行基类
    /// </summary>
    /// <typeparam name="Es">BLL列表类</typeparam>
    /// <typeparam name="E">BLL类</typeparam>
    /// <typeparam name="Ds">UI服务列表类</typeparam>
    /// <typeparam name="D">UI服务DTO类</typeparam>
    public abstract class BusinessBaseHandle<Es, E, Ds, D>
        where Es : BusinessListBase<E>
        where E : BusinessBase
        where D : BaseUIDto<D, E>
        where Ds : BaseListUIDto<D, E>
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
        /// 数据门
        /// </summary>
        protected IDataPortal<E> _dataportal;

        /// <summary>
        /// 列表数据门
        /// </summary>
        protected IDataPortalList<Es, E> _dataportallist;


        /// <summary>
        /// 设置基本权限
        /// </summary>
        /// <param name="power">基本权限</param>
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
        /// 上下文附加
        /// </summary>
        /// <param name="bllitem">业务类</param>
        protected virtual void ApplyContext(E bllitem)
        {
            bllitem.Context = _dataportalcontext;
            bllitem.WorkContext = _workcontext;
        }

        /// <summary>
        /// 列表类上下文附加
        /// </summary>
        /// <param name="bllitems">列表类型</param>

        protected virtual void ApplyContext(Es bllitems)
        {
            bllitems.Context = _dataportalcontext;
            bllitems.WorkContext = _workcontext;
        }

        /// <summary>
        /// 返回类操作
        /// </summary>
        /// <param name="item">UI-DTO</param>
        /// <param name="dataportalhandle">操作类型</param>
        /// <param name="znexp">表达式</param>
        /// <returns>UI-DTO</returns>
        protected virtual D ItemHandle(D item, Func<E, E> dataportalhandle, ExpConditions<D> znexp)
        {
            E bllitem = item.CopyToIn();
            ApplyContext(bllitem);
            bllitem.Criteria = BusinessCriteria.BusinessCriteriaCreate(znexp);
            bllitem = dataportalhandle(bllitem);
            return item.CopyToOut(bllitem);
        }

        /// <summary>
        /// 返状态操作
        /// </summary>
        /// <param name="item">操作项目</param>
        /// <param name="dataportalhandle">操作</param>
        /// <param name="znexp">参数表达式</param>
        /// <returns>操作结果</returns>
        protected virtual OperateState ItemHandleState(D item, Func<E, OperateState> dataportalhandle, ExpConditions<D> znexp)
        {
            E bllitem = item.CopyToIn();
            ApplyContext(bllitem);
            bllitem.Criteria = BusinessCriteria.BusinessCriteriaCreate(znexp);
            return dataportalhandle(bllitem);
        }

        #endregion

        #region 增加

        /// <summary>
        /// 同步增加
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <param name="znexp">条件表达式</param>
        /// <returns>增加结果</returns>
        public virtual OperateState Insert(D item, ExpConditions<D> znexp)
        {
            if (!_power.Create)
            {

                return OperateState.FailState("没有增加记录权限！");
            }

            return ItemHandleState(item, _dataportal.Insert, znexp);


        }


        /// <summary>
        /// 同步增加（无传入条件）
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <returns>增加结果</returns>
        public virtual OperateState Insert(D item)
        {
            var znexp = new ExpConditions<D>();
            return Insert(item, znexp);
        }

        #endregion

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <param name="znexp">条件表达式</param>
        /// <returns>更新结果</returns>
        public virtual OperateState Update(D item, ExpConditions<D> znexp)
        {
            if (!_power.Edit)
            {
                return OperateState.FailState("没有编辑记录权限！");
            }
            //强制清除条件，以使记录更新为当前记录，而非批量更新
            znexp.ClearWhere();
            return ItemHandleState(item, _dataportal.Update, znexp);
        }

        /// <summary>
        /// 更新（无传入条件，程序以关键字段值作为更新条件）
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <returns>更新结果</returns>
        public virtual OperateState Update(D item)
        {
            var znexp = new ExpConditions<D>();
            return Update(item, znexp);
        }



        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <param name="znexp">条件表达式</param>
        /// <returns>更新结果</returns>
        public virtual OperateState BatchUpdate(D item, ExpConditions<D> znexp)
        {
            if (!_power.Edit)
            {
                return OperateState.FailState("没有编辑记录权限！");
            }
            return ItemHandleState(item, _dataportal.Update, znexp);
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <param name="znexp">条件表达式</param>
        /// <returns>删除结果</returns>
        public virtual OperateState Delete(D item, ExpConditions<D> znexp)
        {
            if (!_power.Delete)
            {
                return OperateState.FailState("没有删除记录权限！");
            }
            //强制清除条件，以使记录更新为当前记录，而非批量更新
            znexp.ClearWhere();
            return ItemHandleState(item, _dataportal.Delete, znexp);
        }

        /// <summary>
        /// 删除（无传入条件，程序以关键字段值作为删除条件）
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <returns>删除结果</returns>
        public virtual OperateState Delete(D item)
        {
            var znexp = new ExpConditions<D>();
            return Delete(item, znexp);
        }

        /// <summary>
        /// 表达式删除
        /// </summary>
        /// <param name="znexp">条件表达式</param>
        /// <returns>删除结果</returns>
        public virtual OperateState Delete(ExpConditions<D> znexp)
        {
            var item = _lc.Resolve<D>();
            return Delete(item, znexp);
        }



        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="item">传入UI的业务类实例，用着传入条件携带者</param>
        /// <param name="znexp">条件表达式</param>
        /// <returns>删除结果</returns>
        public virtual OperateState BatchDelete(D item, ExpConditions<D> znexp)
        {
            if (!_power.Delete)
            {
                return OperateState.FailState("没有删除记录权限！");
            }
            return ItemHandleState(item, _dataportal.Delete, znexp);
        }


        #endregion

        #region 查询


        /// <summary>
        /// 获取单个业务类
        /// </summary>
        /// <param name="znexp">条件表达式</param>
        /// <returns>查询结果</returns>
        public virtual D Get(ExpConditions<D> znexp)
        {
            D item = _lc.Resolve<D>();
            if (!_power.Get)
            {
                item.State.Error.Add("权限", "没有操作权限");
                return item;
            }

            return ItemHandle(item, _dataportal.Fetch, znexp);
        }


        /// <summary>
        /// 获取单个业务类，返回第一条记录
        /// </summary>
        /// <returns>查询结果</returns>
        public virtual D Get()
        {
            ExpConditions<D> znexp = new ExpConditions<D>();
            return Get(znexp);
        }

        #endregion

        #region 列表查询
        /// <summary>
        /// 获取一组业务
        /// </summary>
        /// <param name="znexp">条件表达式</param>
        /// <returns>查询结果</returns>
        public virtual Ds GetList(ExpConditions<D> znexp)
        {
            Ds result = _lc.Resolve<Ds>();
            Es initems = _lc.Resolve<Es>();

            if (!_power.Get)
            {
                result.State.Error.Add("权限", "没有操作权限");
                return result;
            }
            ApplyContext(initems);
            initems.Criteria = BusinessListCriteria.BusinessCriteriaCreate(znexp);

            var updateitems = _dataportallist.FetchList(initems);


            return result.BizListCopyOut<Ds, Es>(updateitems);
        }

        /// <summary>
        /// 获取一组业务
        /// </summary>
        /// <returns>查询结果</returns>
        public virtual Ds GetList()
        {
            ExpConditions<D> znexp = new ExpConditions<D>();
            return GetList(znexp);
        }

        #endregion

        #region 批量更新

        /// <summary>
        /// 同步批量更新操作
        /// </summary>
        /// <param name="items">传入UI的业务类实例，用着传入条件携带者</param>
        /// <param name="znexp">条件表达式</param>
        /// <returns>操作结果</returns>
        public virtual OperateState BatchSave(Ds items, ExpConditions<D> znexp)
        {
            Ds bizInsertList = _lc.Resolve<Ds>();
            Ds bizUpdateList = _lc.Resolve<Ds>();
            Ds bizDeleteList = _lc.Resolve<Ds>();
            foreach (var item in items)
            {
                switch (item.Op)
                {
                    case RecordOperater.Insert:

                        if (!_power.Create)
                        {

                            return OperateState.FailState("没有增加记录权限！");
                        }
                        bizInsertList.Add(item);
                        break;
                    case RecordOperater.Updata:

                        if (!_power.Edit)
                        {

                            return OperateState.FailState("没有编辑记录权限！");
                        }
                        bizUpdateList.Add(item);
                        break;
                    case RecordOperater.Delete:

                        if (!_power.Delete)
                        {

                            return OperateState.FailState("没有删除记录权限！");
                        }
                        bizDeleteList.Add(item);
                        break;

                }
            }
            //如果在删除表中，则从更新列表中删除
            if (bizDeleteList.Count > 0 && bizUpdateList.Count > 0)
            {
                foreach (var item in bizDeleteList)
                {
                    foreach (var uitem in bizUpdateList)
                    {
                        if (uitem.CompareTo(item) > 0)
                        {
                            bizUpdateList.Remove(uitem);
                        }
                    }

                }
            }

            var updateitems = bizInsertList.ListSave<Es>(bizInsertList, bizUpdateList, bizDeleteList);
            if (updateitems.Count < 1)
            {
                return OperateState.FailState("没有要更新的记录");
            }

            ApplyContext(updateitems);
            updateitems.Criteria = BusinessListCriteria.BusinessCriteriaCreate<D>(znexp);
            return _dataportallist.BatchSave(updateitems);
        }





        /// <summary>
        /// 批量更新操作  josn格式 适用于JQ easy UI
        /// </summary>
        /// <param name="formItem">表单值表</param>
        /// <param name="znexp">条件表达式</param>
        /// <returns>操作结果</returns>
        public virtual string BatchSave(NameValueCollection formItem, ExpConditions<D> znexp)
        {
            var bizinserted = formItem["inserted"];
            var bizupdated = formItem["updated"];
            var bizdeleted = formItem["deleted"];
            if (string.IsNullOrEmpty(bizinserted + bizupdated + bizdeleted))
            {
                return "没有要更新的记录";
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<D> listdeleted = js.Deserialize<List<D>>(bizdeleted);
            List<D> listinserted = js.Deserialize<List<D>>(bizinserted);
            List<D> listupdated = js.Deserialize<List<D>>(bizupdated);

            //如果在删除表中，则从更新列表中删除
            if (listdeleted.Count > 0 && listupdated.Count > 0)
            {
                foreach (var item in listdeleted)
                {
                    foreach (var uitem in listupdated)
                    {
                        if (uitem.CompareTo(item) > 0)
                        {
                            listupdated.Remove(uitem);
                        }
                    }

                }
            }
            var ulist = _lc.Resolve<Ds>();
            var items = ulist.ListSave<Es>(listinserted, listupdated, listdeleted);
            if (items.Count < 1)
            {
                return "没有要更新的记录";
            }

            ApplyContext(items);
            items.Criteria = BusinessListCriteria.BusinessCriteriaCreate<D>(znexp);
            OperateState state = _dataportallist.BatchSave(items);
            if (state.IsSuccess)
            {
                return "ok";
            }
            else
            {
                return "error";
            }
        }

        #endregion

        #region 特列格式 数据操作方法

        /// <summary>
        /// Josn 格式
        /// </summary>
        /// <param name="znexp">条件表达式</param>
        /// <returns>查询结果</returns>
        public virtual JsonObjectResult GetJsonList(ExpConditions<D> znexp)
        {
            Ds esitems = GetList(znexp);
            BusinessListCriteria criteria = BusinessListCriteria.BusinessCriteriaCreate<D>(znexp);
            List<object> result = new List<object>();
            foreach (var item in esitems)
            {
                result.Add(item.JsonCopy());
            }
            return JsonObjectResult.Get(result, esitems.TotalCount, criteria.CurrentPage, criteria.QueryRows);


        }


        /// <summary>
        /// Josn 格式
        /// </summary>
        /// <returns>Josn查询结果</returns>
        public virtual JsonObjectResult GetJsonList()
        {
            return GetJsonList(new ExpConditions<D>());
        }

        /// <summary>
        /// 获取XML格式数据
        /// </summary>
        /// <param name="znexp">条件表达式</param>
        /// <returns>XML格式数据</returns>
        public virtual string GetXmlList(ExpConditions<D> znexp)
        {

            return XmlUtil.Serializer(typeof(List<D>), GetList(znexp));
        }

        /// <summary>
        /// 获取XML格式数据
        /// </summary>
        /// <returns>XML格式数据</returns>
        public virtual string GetXmlList()
        {

            return GetXmlList(new ExpConditions<D>());
        }

        #endregion

        #region  获取指定条件的记录数
        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="znexp">条件表达式</param>
        /// <returns>记录数</returns>
        public virtual int GetListCount(ExpConditions<D> znexp)
        {
            znexp.LookPage(-1, -1);
            return GetList(znexp).TotalCount;
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <returns>记录数</returns>
        public virtual int GetListCount()
        {
            return GetListCount(new ExpConditions<D>());
        }

        /// <summary>
        /// 获取当前UI业务类表达式
        /// </summary>
        /// <returns>UI业务类表达式</returns>
        public ExpConditions<D> GetExp()
        {
            return new ExpConditions<D>();
        }

        /// <summary>
        /// 获得一个新业务类
        /// </summary>
        /// <returns>新业务类</returns>
        public D GetNew()
        {
            return _lc.Resolve<D>();
        }

        /// <summary>
        /// 获取一个新的列表业务类
        /// </summary>
        /// <returns>新的列表业务类</returns>
        public Ds GetNewList()
        {
            return _lc.Resolve<Ds>();
        }

        #endregion
    }
}
