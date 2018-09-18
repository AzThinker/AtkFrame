using Atk.CustomExpression;
using Atk.DataPortal.Core;
using System;


namespace Atk.DataPortal
{
    /// <summary>
    /// 参数类，所有参数必需使用此类，或由此类派生的类
    /// </summary>
    [Serializable]
    public class BusinessCriteria : CriteriaBase
    {

        /// <summary>
        /// 参数类创建方法
        /// </summary>
        /// <typeparam name="U">UI服务DTO类</typeparam>
        /// <param name="znExp">表达式类</param>
        /// <returns>已经创建的参数类</returns>
        public static BusinessCriteria BusinessCriteriaCreate<U>(ExpConditions<U> znExp)
        {
            BusinessCriteria restult = new BusinessCriteria();
            if (znExp != null)
            {
                restult.InsertSql = znExp.InsertFields();

                restult.UpdateSql = znExp.UpdateFields();

                restult.QueryWhere = znExp.Where();

                restult.QueryOrder = znExp.OrderBy();

                restult.AccessFetch = znExp.AccessFetch;

                restult.AccessFetchList = znExp.AccessFetchList;
            }
            return restult;

        }
    }
}
