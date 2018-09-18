using System;

namespace Atk.DataPortal.Core
{
    /// <summary>
    /// 参数基类
    /// </summary>
    [Serializable]
    public abstract class CriteriaBase : ICriteria
    {


        /// <summary>
        /// 查询条件时的where 语句
        /// </summary>
        private string _queryWhere;

        /// <summary>
        /// 查询条件时的where 语句
        /// </summary>
        public string QueryWhere
        {
            get { return _queryWhere; }
            protected set { _queryWhere = value; }
        }

        /// <summary>
        /// 查询条件的Orderby语句
        /// </summary>
        private string _queryOrder;

        /// <summary>
        /// 查询条件的Orderby语句
        /// </summary>
        public string QueryOrder
        {
            get { return _queryOrder; }
            protected set { _queryOrder = value; }
        }



        private string _updateSql;

        private string _insertSql;

        /// <summary>
        /// 增加语句
        /// </summary>
        public string InsertSql
        {
            get { return _insertSql; }
            protected set { _insertSql = value; }
        }

        /// <summary>
        /// 更新字段语句
        /// </summary>
        public string UpdateSql
        {
            get { return _updateSql; }
            protected set { _updateSql = value; }
        }


        private string _accessFetch;

        /// <summary>
        /// 附加查询语句
        /// </summary>
        public string AccessFetch
        {
            get { return _accessFetch; }
            set { _accessFetch = value; }
        }


        private string _accessFetchList;

        /// <summary>
        /// 险加列表查询语句
        /// </summary>
        public string AccessFetchList
        {
            get { return _accessFetchList; }
            set { _accessFetchList = value; }
        }


        /// <summary>
        /// 参数基类
        /// </summary>
        public CriteriaBase()
        {
            InsertSql = string.Empty;
            UpdateSql = string.Empty;
            QueryWhere = string.Empty;
            QueryOrder = string.Empty;
            AccessFetch = string.Empty;
            AccessFetchList = string.Empty;
        }

    }


}
