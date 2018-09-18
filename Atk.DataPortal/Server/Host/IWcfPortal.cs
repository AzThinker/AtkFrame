//-----------------------------------------------------------------------
// <copyright file="IWcfPortal.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: http://www.lhotka.net/cslanet/
// </copyright>
// <summary>Defines the service contract for the WCF data</summary>
//-----------------------------------------------------------------------
using System;
using System.ServiceModel;
using Atk.DataPortal.Server.Hosts.WcfChannel;
using System.Threading.Tasks;


namespace Atk.ServerHosts
{
    /// <summary>
    /// WCF数据门户服务契约的定义
    /// </summary>

    [ServiceContract(Namespace = "http://www.athinker.doit/WcfDataPortal", ConfigurationName = "WcfService.IWcfPortal")]
    public interface IWcfPortal
    {
        /// <summary>
        /// 创建新的业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationContract]
        [UseNetDataContract]
        Task<WcfResponse> Insert(InsertRequest request);

        /// <summary>
        /// 获取的业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationContract]
        [UseNetDataContract]
        Task<WcfResponse> Fetch(FetchRequest request);

        /// <summary>
        /// 更新业务对象操作
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationContract]
        [UseNetDataContract]
        Task<WcfResponse> Update(UpdateRequest request);

        /// <summary>
        /// 删除批定业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationContract]
        [UseNetDataContract]
        Task<WcfResponse> Delete(DeleteRequest request);



        /// <summary>
        /// 更新业务对象操作
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationContract]
        [UseNetDataContract]
        Task<WcfResponse> Execute(ExecuteRequest request);




        /// <summary>
        /// 获取的存储过程查询业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationContract]
        [UseNetDataContract]
        Task<WcfResponse> SpFetch(SpFetchRequest request);


        /// <summary>
        /// 获取的存储过程查询业务对象
        /// </summary>
        /// <param name="request">请求参数对象</param>
        [OperationContract]
        [UseNetDataContract]
        Task<WcfResponse> BatchSave(BatchSaveRequest request);

    }
}