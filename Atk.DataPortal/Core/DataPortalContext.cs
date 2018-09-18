using System;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 在客户端和服务器之间提供一致的上下文信息数据门户对象。
    /// </summary>
    [Serializable]
    public class DataPortalContext
    {

        private string _dbConnectionString;

        /// <summary>
        /// 数据库访问
        /// </summary>
        public string DbConnectionString
        {
            get { return _dbConnectionString; }
            set { _dbConnectionString = value; }
        }

        private bool cnnIsEncryption;

        private string _dbConnectionKey;

        /// <summary>
        /// 数据访问Key
        /// </summary>
        public string DbConnectionKey
        {
            get { return _dbConnectionKey; }
            set { _dbConnectionKey = value; }
        }

        /// <summary>
        /// system.serviceModel中client 的 endpoint name属性。
        /// </summary>
        private string _bizEndPointName;

        /// <summary>
        /// system.serviceModel中client 的 endpoint name属性。
        /// </summary>
        public string EndPointName
        {
            get { return _bizEndPointName; }
            set { _bizEndPointName = value; }
        }

        /// <summary>
        /// 是否为WCF服务
        /// </summary>
        private bool _isWcf;

        /// <summary>
        /// 是否为WCF服务
        /// </summary>
        public bool IsWcf
        {
            get { return _isWcf; }
            set { _isWcf = value; }
        }

        private bool _isTransaction;

        /// <summary>
        /// 是否启动事务
        /// </summary>
        public bool IsTransaction
        {
            get { return _isTransaction; }
            set { _isTransaction = value; }
        }

        public bool CnnIsEncryption { get => cnnIsEncryption; set => cnnIsEncryption = value; }

        /// <summary>
        /// 构造方法
        /// </summary>
        public DataPortalContext()
        {
            EndPointName = string.Empty;
            DbConnectionString = string.Empty;
            DbConnectionKey = string.Empty;
            IsWcf = false;
            IsTransaction = false;
        }
    }
}
