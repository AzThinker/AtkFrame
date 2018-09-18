using System;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 业务类批量更新操作类型
    /// </summary>
    [Flags]
    public enum RecordOperater : byte
    {

        /// <summary>
        /// 增加
        /// </summary>
        Insert,

        /// <summary>
        /// 更新
        /// </summary>
        Updata,

        /// <summary>
        /// 删除
        /// </summary>
        Delete,

        /// <summary>
        /// 无操作
        /// </summary>
        None

    }
}
