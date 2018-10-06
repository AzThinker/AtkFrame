using System;
using Atk.CustomExpression;


namespace Atk.DataPortal
{
    /// <summary>
    ///  列表参数类，所有列表类参数必需使用此类，或由此类派生的类
    /// </summary>
    [Serializable]
    public class BusinessListCriteria : BusinessCriteria
    {
        /// <summary>
        /// 返回记录数限制 
        /// </summary>
        private int _queryRows;

        /// <summary>
        /// 列表参数类，返回记录数限制 
        /// </summary>
        public int QueryRows
        {
            get { return _queryRows; }
            private set { _queryRows = value; }
        }


        private int _currentPage;

        /// <summary>
        /// 当前页面
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

    }
}
