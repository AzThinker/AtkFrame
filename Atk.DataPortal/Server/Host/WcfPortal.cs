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
    /// ͨ��WCF��¶����������Ż�����
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfPortal : IWcfPortal
    {
        /// <summary>
        /// �����Ż������ģ�����ҵ��ת��IOC��
        /// </summary>
        public static DataPortalWorkContext workcontext { get; set; }

        /// <summary>
        /// �����µ�ҵ�����
        /// </summary>
        /// <param name="request">�����������</param>
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
        /// ��ȡ��ҵ�����
        /// </summary>
        /// <param name="request">�����������</param>
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
        /// ����ҵ��������
        /// </summary>
        /// <param name="request">�����������</param>
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
        /// ɾ������ҵ�����
        /// </summary>
        /// <param name="request">�����������</param>
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
        /// ִ�в���
        /// </summary>
        /// <param name="request">�������</param>
        /// <returns>ִ�н��</returns>
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
        /// ��ȡ��ҵ�����
        /// </summary>
        /// <param name="request">�����������</param>
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
        /// ��ȡ��ҵ�����
        /// </summary>
        /// <param name="request">�����������</param>
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