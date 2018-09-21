using System;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 业务对象抽象类
    /// </summary>
    [Serializable]
    public abstract class BusinessBase : IBusinessObject, IBusinessTrace, IBusinessContext
    {

        /// <summary>
        /// 路踪路径，用于检查数据来源
        /// </summary>
        private string _accessPath;

        /// <summary>
        /// 路踪路径，用于检查数据来源
        /// </summary>
        public string AccessPath
        {
            get { return _accessPath; }
            set { _accessPath = value; }
        }

        /// <summary>
        /// 访问地址
        /// </summary>
        private string _accessAddress;

        /// <summary>
        /// 访问地址
        /// </summary>
        public string AccessAddress
        {
            get { return _accessAddress; }
            set { _accessAddress = value; }
        }







        /// <summary>
        /// 业务对象抽象类
        /// </summary>
        public BusinessBase()
        {
            AccessPath = string.Empty;
            AccessAddress = string.Empty;
            Op = RecordOperater.Updata;
            State = new OperateState();
            Context = new DataPortalContext();
            Criteria = new BusinessCriteria();

        }

        /// <summary>
        /// 操作状态
        /// </summary>
        private OperateState _state;

        /// <summary>
        /// 操作状态（数据访问时操作附加信息）
        /// </summary>
        public OperateState State
        {
            get { return _state; }
            set { _state = value; }
        }


        private DataPortalContext _bizContext;

        /// <summary>
        /// 数据门户上下文，携带数据访问信息
        /// </summary>
        public DataPortalContext Context
        {
            get { return _bizContext; }
            set { _bizContext = value; }
        }

        private BusinessCriteria _bizCriteria;

        /// <summary>
        /// 业务参数
        /// </summary>
        public BusinessCriteria Criteria
        {
            get { return _bizCriteria; }
            set { _bizCriteria = value; }
        }

        [NonSerialized]
        private DataPortalWorkContext _bizWorkContext;

        /// <summary>
        /// 数据门户上下文，携带IOC上下文，用于WCF工作环境
        /// </summary>
        public DataPortalWorkContext WorkContext
        {
            get { return _bizWorkContext; }
            set { _bizWorkContext = value; }
        }


        /// <summary>
        /// 读写操作
        /// </summary>
        private RecordOperater _bizOp;

        /// <summary>
        /// 业务类批量更新操作类型
        /// </summary>
        public RecordOperater Op
        {
            get { return _bizOp; }
            set { _bizOp = value; }
        }
    }
}
