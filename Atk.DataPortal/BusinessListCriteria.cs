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

        /// <summary>
        /// 业务参数类创建
        /// </summary>
        /// <typeparam name="U">业务类（DTO）</typeparam>
        /// <param name="zaExp">表达式</param>
        /// <returns>业务参数类实例</returns>
        public new static BusinessListCriteria BusinessCriteriaCreate<U>(ExpConditions<U> zaExp)
        {
            BusinessListCriteria restult = new BusinessListCriteria();
            if (zaExp != null)
            {
                restult.InsertSql = zaExp.InsertFields();

                restult.UpdateSql = zaExp.UpdateFields();

                restult.QueryWhere = zaExp.Where();

                restult.QueryOrder = zaExp.OrderBy();

                restult.QueryRows = zaExp.Rows();

                restult.CurrentPage = zaExp.Page();

            }
            return restult;

        }


    }
}
