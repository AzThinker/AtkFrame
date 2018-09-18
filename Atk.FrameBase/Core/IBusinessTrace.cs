namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 此接口会被BLL各业务类继承
    /// 因此也作为所有BLL的顶级接口
    /// </summary>
    public interface IBusinessTrace
    {
        /// <summary>
        /// 路踪路径，用于检查数据来源
        /// </summary>
        string AccessPath { get; set; }


        /// <summary>
        /// 访问地址
        /// </summary>
        string AccessAddress { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        OperateState State { get; set; }
    }
}
