//-----------------------------------------------------------------------
// <copyright file="WcfPortal.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Exposes server-side DataPortal functionality</summary>
//-----------------------------------------------------------------------
using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.DataPortal.Server;
using Atk.DataPortal.Server.Hosts.WcfChannel;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading.Tasks;

namespace Atk.ServerHosts
{

    /// <summary>
    /// 通过WCF暴露服务端数据门户功能
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfPortal : IWcfPortal
    {
        /// <summary>
        /// 数据门户上下文，用于业务反转（IOC）
        /// </summary>
        public static DataPortalWorkContext workcontext { get; set; }

        /// <summary>
        /// 创建新的业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public async Task<WcfResponse> Insert(InsertRequest request)
        {
            DataPortalForWCF portal = new DataPortalForWCF();
            try
            {
                object obj = request.Object;

                if (obj is IBusinessBaseContext)
                {
                    (obj as IBusinessBaseContext).WorkContext = workcontext;
                }

                var resultwcf = await portal.Insert(obj);
                return new WcfResponse(resultwcf.State);
            }
            catch (Exception ex)
            {
                return new WcfResponse(OperateState.FailState(ex.Message));
            }
        }

        /// <summary>
        /// 获取的业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public async Task<WcfResponse> Fetch(FetchRequest request)
        {
            DataPortalForWCF portal = new DataPortalForWCF();
            object result;
            try
            {
                result = await portal.Fetch(request.ObjectType, request.Criteria, request.Context, workcontext);
            }
            catch (Exception ex)
            {
                result = new DataPortalResult(OperateState.FailState(ex.Message));
            }
            return new WcfResponse(result);
        }

        /// <summary>
        /// 更新业务对象操作
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public async Task<WcfResponse> Update(UpdateRequest request)
        {
            DataPortalForWCF portal = new DataPortalForWCF();
            try
            {
                object obj = request.Object;

                if (obj is IBusinessBaseContext)
                {
                    (obj as IBusinessBaseContext).WorkContext = workcontext;
                }

                var resultwcf = await portal.Update(obj);
                return new WcfResponse(resultwcf.State);
            }
            catch (Exception ex)
            {
                return new WcfResponse(OperateState.FailState(ex.Message));
            }
        }

        /// <summary>
        /// 删除批定业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public async Task<WcfResponse> Delete(DeleteRequest request)
        {
            DataPortalForWCF portal = new DataPortalForWCF();
            try
            {
                var resultwcf = await portal.Delete(request.ObjectType, request.Criteria, request.Context, workcontext);
                return new WcfResponse(resultwcf.State);
            }
            catch (Exception ex)
            {
                return new WcfResponse(OperateState.FailState(ex.Message));
            }
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <returns>执行结果</returns>
        public async Task<WcfResponse> Execute(ExecuteRequest request)
        {
            DataPortalForWCF portal = new DataPortalForWCF();
            try
            {
                object obj = request.Object;

                if (obj is IBusinessBaseContext)
                {
                    (obj as IBusinessBaseContext).WorkContext = workcontext;
                }
                var resultwcf = await portal.Execute(request.Object);
                return new WcfResponse(resultwcf.State);
            }
            catch (Exception ex)
            {
                return new WcfResponse(OperateState.FailState(ex.Message));
            }
        }


        /// <summary>
        /// 获取的业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public async Task<WcfResponse> SpFetch(SpFetchRequest request)
        {
            DataPortalForWCF portal = new DataPortalForWCF();
            object result;
            try
            {
                object obj = request.Object;

                if (obj is IBusinessListContext)
                {
                    (obj as IBusinessListContext).WorkContext = workcontext;
                }
                result = await portal.SpFetch(request.Object);
            }
            catch (Exception ex)
            {
                result = new DataPortalResult(OperateState.FailState(ex.Message));
            }
            return new WcfResponse(result);
        }



        /// <summary>
        /// 获取的业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public async Task<WcfResponse> BatchSave(BatchSaveRequest request)
        {
            DataPortalForWCF portal = new DataPortalForWCF();
            try
            {
                var resultwcf = await portal.BatchSave(request.ObjectType, request.Criteria, request.Context, workcontext);
                return new WcfResponse(resultwcf.State);
            }
            catch (Exception ex)
            {
                return new WcfResponse(OperateState.FailState(ex.Message));
            }

        }
    }
}