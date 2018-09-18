using System;
using System.Collections.Generic;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 业务对象抽象类
    /// </summary>
    [Serializable]
    public class BusinessListBase<D> : List<D>, IBusinessListObject, IBusinessTrace, IBusinessListContext
        where D : BusinessBase
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
        /// 所有记录数
        /// </summary>
        private int _totalCount;

        /// <summary>
        /// 所有记录数
        /// </summary>
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        /// <summary>
        /// 业务对象抽象类
        /// </summary>
        public BusinessListBase()
        {
            AccessAddress = string.Empty;
            AccessAddress = string.Empty;
            TotalCount = -1;
            State = new OperateState();
            Context = new DataPortalContext();
            Criteria = new BusinessListCriteria();

        }

        /// <summary>
        /// 操作状态
        /// </summary>
        private OperateState _state;

        /// <summary>
        /// 操作状态
        /// </summary>
        public OperateState State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// 数据门上下文
        /// </summary>
        private DataPortalContext _bizContext;

        /// <summary>
        /// 数据门上下文
        /// </summary>
        public DataPortalContext Context
        {
            get { return _bizContext; }
            set { _bizContext = value; }
        }

        /// <summary>
        /// 列表参数
        /// </summary>
        private BusinessListCriteria _bizCriteria;

        /// <summary>
        /// 列表参数
        /// </summary>
        public BusinessListCriteria Criteria
        {
            get { return _bizCriteria; }
            set { _bizCriteria = value; }
        }

        [NonSerialized]
        private DataPortalWorkContext _bizWorkContext;

        /// <summary>
        /// 数据门工作上下文
        /// </summary>
        public DataPortalWorkContext WorkContext
        {
            get { return _bizWorkContext; }
            set { _bizWorkContext = value; }
        }

    }
}
