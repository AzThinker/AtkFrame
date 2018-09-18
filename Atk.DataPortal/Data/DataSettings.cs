using System;
using System.Collections.Generic;

namespace Atk.DataPortal
{
    /// <summary>
    /// 数据访问设置
    /// </summary>
    public partial class DataSettings
    {
        /// <summary>
        /// 设置的KEY
        /// </summary>
        public string SetName { get; set; }

        /// <summary>
        /// 数据库连接字串
        /// </summary>
        public string DataConnectionString { get; set; }

        /// <summary>
        /// 是否使用WCF访问
        /// </summary>
        public bool IsWcf { get; set; }

        /// <summary>
        /// 配置文件中的WCF终结点名称
        /// </summary>
        public string EndPointName { get; set; }

    }

}
