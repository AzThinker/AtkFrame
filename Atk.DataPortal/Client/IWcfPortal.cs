using Atk.DataPortal.Server.Hosts.WcfChannel;

namespace Atk.DataPortal.Client
{
    /// <summary>
    /// 客户端，服务契约
    /// 其中对Action的限定，是与服务契约一至的，如果服务契约改变
    /// 可通过类似于http://localhost/WcfPortal.svc?wsdl获取真实的元数据格式
    /// </summary>
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.athinker.doit/WcfDataPortal", ConfigurationName = "WcfClientPortal.IWcfPortal")]
    public interface IWcfPortal
    {


        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="request">增加参数类</param>
        /// <returns>操作结果</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/Insert", ReplyAction = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/InsertResponse")]
        [UseNetDataContract]
        System.Threading.Tasks.Task<WcfResponse> InsertAsync(InsertRequest request);


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request">参数据类</param>
        /// <returns>操作结果</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/Fetch", ReplyAction = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/FetchResponse")]
        [UseNetDataContract]
        System.Threading.Tasks.Task<WcfResponse> FetchAsync(FetchRequest request);


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request">参数据类</param>
        /// <returns>操作结果</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/Update", ReplyAction = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/UpdateResponse")]
        [UseNetDataContract]
        System.Threading.Tasks.Task<WcfResponse> UpdateAsync(UpdateRequest request);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request">参数据类</param>
        /// <returns>操作结果</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/Delete", ReplyAction = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/DeleteResponse")]
        [UseNetDataContract]
        System.Threading.Tasks.Task<WcfResponse> DeleteAsync(DeleteRequest request);

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="request">参数据类</param>
        /// <returns>操作结果</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/Execute", ReplyAction = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/ExecuteResponse")]
        [UseNetDataContract]
        System.Threading.Tasks.Task<WcfResponse> ExecuteAsync(ExecuteRequest request);


        /// <summary>
        /// 存储查询
        /// </summary>
        /// <param name="request">参数据类</param>
        /// <returns>操作结果</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/SpFetch", ReplyAction = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/SpFetchResponse")]
        [UseNetDataContract]
        System.Threading.Tasks.Task<WcfResponse> SpFetchAsync(SpFetchRequest request);

        /// <summary>
        /// 批更新
        /// </summary>
        /// <param name="request">参数据类</param>
        /// <returns>操作结果</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/BatchSave", ReplyAction = "http://www.athinker.doit/WcfDataPortal/IWcfPortal/BatchSaveResponse")]
        [UseNetDataContract]
        System.Threading.Tasks.Task<WcfResponse> BatchSaveAsync(BatchSaveRequest request);
    }
}
