using Atk.DataPortal.Core;
using Atk.Tool.Cryptogram;
using System;
using System.Threading.Tasks;
namespace Atk.DataPortal.Server
{
    /// <summary>
    /// WCF实现服务器端DataPortal 
    /// 此处如果以对象传入，则由WCF服务的Autoface反转
    /// 如果是由类型传入，则由DataPortalWorkContext提供的上下文反转
    /// 由于传入的实例均为Object类型，因此方法调用采用反射方式
    /// </summary>
    internal sealed class DataPortalForWCF
    {
        public async Task<DataPortalResult> Insert(object obj)
        {
            obj.TraceSignWcf();
            try
            {
                if (obj is IBusinessContext)
                {
                    (obj as IBusinessContext).Context = GetDataPortalContext((obj as IBusinessContext).Context);
                }
                await Task.Run(() => (obj as IBusinessInsert).DataPortal_Insert());
                return new DataPortalResult((obj as IBusinessTrace).State);
            }

            catch
            {
                return new DataPortalResult(OperateState.FailState("DataPortal.Insert,服务端方法调用失败！"));

            }
        }

        private DataPortalContext GetDataPortalContext(DataPortalContext context)
        {

            var reult = DataSettingsHelper.GetCurrentDataSetting(context.DbConnectionKey);
            return reult;
        }



        public async Task<DataPortalResult> Fetch(Type objectType, object criteria, DataPortalContext context, DataPortalWorkContext workcontext)
        {
            var obj = workcontext.Resolve(objectType);
            context = GetDataPortalContext(context);
            if (obj is IBusinessContext)
            {
                (obj as IBusinessContext).Context = context;
                (obj as IBusinessContext).WorkContext = workcontext;
                (obj as IBusinessContext).Criteria = (BusinessCriteria)criteria;

            }
            else if (obj is IBusinessListContext)
            {
                (obj as IBusinessListContext).Context = context;
                (obj as IBusinessListContext).WorkContext = workcontext;
                (obj as IBusinessListContext).Criteria = (BusinessListCriteria)criteria;

            }
            obj.TraceSignPath("WCF-in:" + context.EndPointName);

            try
            {
                await Task.Run(() => (obj as IBusinessFetch).DataPortal_Fetch());
                return new DataPortalResult(obj);
            }

            catch
            {
                return new DataPortalResult(OperateState.FailState("DataPortal.Fetch,服务端方法调用失败！"));

            }
        }

        public async Task<DataPortalResult> Update(object obj)
        {

            obj.TraceSignWcf();
            try
            {
                if (obj is IBusinessContext)
                {
                    (obj as IBusinessContext).Context = GetDataPortalContext((obj as IBusinessContext).Context);
                }
                await Task.Run(() => (obj as IBusinessUpdate).DataPortal_Update());
                return new DataPortalResult((obj as IBusinessTrace).State);
            }

            catch
            {
                return new DataPortalResult(OperateState.FailState("DataPortal.Update,服务端方法调用失败！"));
            }
        }

        public async Task<DataPortalResult> Delete(Type objectType, object criteria, DataPortalContext context, DataPortalWorkContext workcontext)
        {
            //LateBoundObject obj = null;
            var obj = workcontext.Resolve(objectType);
            context = GetDataPortalContext(context);
            if (obj is IBusinessContext)
            {
                (obj as IBusinessContext).Context = context;
                (obj as IBusinessContext).WorkContext = workcontext;
                (obj as IBusinessContext).Criteria = (BusinessCriteria)criteria;

            }
            else if (obj is IBusinessListContext)
            {
                (obj as IBusinessListContext).Context = context;
                (obj as IBusinessListContext).WorkContext = workcontext;
                (obj as IBusinessListContext).Criteria = (BusinessListCriteria)criteria;

            }
            obj.TraceSignPath("WCF-in:" + context.EndPointName);
            try
            {
                await Task.Run(() => (obj as IBusinessDelete).DataPortal_Delete());
                return new DataPortalResult((obj as IBusinessTrace).State);
            }

            catch
            {
                return new DataPortalResult(OperateState.FailState("DataPortal.Delete,服务端方法调用失败！"));

            }
        }

        public async Task<DataPortalResult> Execute(object obj)
        {
            obj.TraceSignWcf();


            try
            {
                if (obj is IBusinessContext)
                {
                    (obj as IBusinessContext).Context = GetDataPortalContext((obj as IBusinessContext).Context);
                }

                await Task.Run(() => (obj as IBusinessExecute).DataPortal_Execute());

                obj.TraceSignWcf();
                return new DataPortalResult((obj as IBusinessTrace).State);
            }

            catch
            {
                return new DataPortalResult(OperateState.FailState("DataPortal.Execute,服务端方法调用失败！"));
            }
        }


        public async Task<DataPortalResult> SpFetch(object obj)
        {
            obj.TraceSignWcf();

            try
            {
                if (obj is IBusinessContext)
                {
                    (obj as IBusinessContext).Context = GetDataPortalContext((obj as IBusinessContext).Context);
                }
                await Task.Run(() => (obj as IBusinessSpFetch).DataPortal_SpFetch());
                obj.TraceSignWcf();
                return new DataPortalResult(obj);
            }

            catch
            {
                return new DataPortalResult(OperateState.FailState("DataPortal.Fetch,服务端方法调用失败！"));
            }
        }


        public async Task<DataPortalResult> BatchSave(Type objectType, object criteria, DataPortalContext context, DataPortalWorkContext workcontext)
        {
            var obj = workcontext.Resolve(objectType);
            context = GetDataPortalContext(context);
            if (obj is IBusinessContext)
            {
                (obj as IBusinessContext).Context = context;
                (obj as IBusinessContext).WorkContext = workcontext;
                (obj as IBusinessContext).Criteria = (BusinessCriteria)criteria;

            }
            else if (obj is IBusinessListContext)
            {
                (obj as IBusinessListContext).Context = context;
                (obj as IBusinessListContext).WorkContext = workcontext;
                (obj as IBusinessListContext).Criteria = (BusinessListCriteria)criteria;

            }
            obj.TraceSignPath("WCF-in:" + context.EndPointName);

            try
            {
                await Task.Run(() => (obj as IBusinessUpdate).DataPortal_Update());
                return new DataPortalResult((obj as IBusinessTrace).State);
            }
            catch
            {
                return new DataPortalResult(OperateState.FailState("DataPortal.BatchSave,服务端方法调用失败！"));
            }
        }
    }
}
