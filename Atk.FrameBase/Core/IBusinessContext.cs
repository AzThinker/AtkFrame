namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 业务类上下文接口
    /// </summary>
    public interface IBusinessContext : IBusinessBaseContext
    {
        /// <summary>
        /// 业务参数
        /// </summary>
        BusinessCriteria Criteria { get; set; }
    }
}
