namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 列表类上下文接口
    /// </summary>
    public interface IBusinessListContext : IBusinessBaseContext
    {
        /// <summary>
        /// 业务参数
        /// </summary>
        BusinessListCriteria Criteria { get; set; }
    }
}
