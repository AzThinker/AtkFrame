namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 业务类数据门户上下文
    /// </summary>
    public interface IBusinessBaseContext
    {
        /// <summary>
        /// 数据门户上下文，携带数据访问信息
        /// </summary>
        DataPortalContext Context { get; set; }

        /// <summary>
        /// 数据门户上下文，携带IOC上下文，用于WCF工作环境
        /// </summary>
        DataPortalWorkContext WorkContext { get; set; }
    }
}
