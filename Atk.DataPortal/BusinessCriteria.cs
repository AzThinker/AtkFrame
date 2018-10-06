using System;
using System.Web.Script.Serialization;
using Atk.CustomExpression;
using Atk.DataPortal.Core;
using SqlRepoEx;
using SqlRepoEx.Abstractions;


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
        public static BusinessCriteria BusinessCriteriaCreate<U>(IClauseBuilder clauseBuilder)
        {
            BusinessCriteria restult = new BusinessCriteria();
            if (clauseBuilder != null)
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                restult.SqlRepoExStatement = clauseBuilder.Sql();
                restult.ParameterDefinition = javaScriptSerializer.Serialize(new ParameterDefinition[] { });
            }
            return restult;

        }


        public static BusinessCriteria BusinessCriteriaCreate<U>(IClauseBuilder clauseBuilder, ParameterDefinition[] parameterDefinitions)
        {
            BusinessCriteria restult = new BusinessCriteria();
            if (clauseBuilder != null)
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                restult.SqlRepoExStatement = clauseBuilder.Sql();
                restult.ParameterDefinition = javaScriptSerializer.Serialize(parameterDefinitions);

            }
            return restult;

        }
    }
}
