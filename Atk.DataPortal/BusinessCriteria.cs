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
    public class BusinessCriteria<E> : CriteriaBase, IBusinessBaseContext, IBusinessTrace where E : BusinessBase, new()
    {
        private string accessPath;
        private string accessAddress;
        private OperateState state;
        private DataPortalWorkContext workContext;
        private DataPortalContext context;

        public BusinessCriteria()
        {

        }



        public DataPortalContext Context { get => context; set => context = value; }
        public DataPortalWorkContext WorkContext { get => workContext; set => workContext = value; }

        public string AccessAddress { get => accessAddress; set => accessAddress = value; }
        public OperateState State { get => state; set => state = value; }
        public string AccessPath { get => accessPath; set => accessPath = value; }



        /// <summary>
        /// 参数类创建方法
        /// </summary>
        /// <typeparam name="U">UI服务DTO类</typeparam>
        /// <param name="znExp">表达式类</param>
        /// <returns>已经创建的参数类</returns>
        public BusinessCriteria<E> BusinessCriteriaCreate(IClauseBuilder clauseBuilder)
        {
            BusinessCriteria<E> restult = new BusinessCriteria<E>();
            if (clauseBuilder != null)
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                restult.SqlRepoExStatement = clauseBuilder.Sql();
                restult.ParameterDefinition = javaScriptSerializer.Serialize(new ParameterDefinition[] { });
            }
            return restult;

        }


        public BusinessCriteria<E> BusinessCriteriaCreate<U>(IClauseBuilder clauseBuilder, ParameterDefinition[] parameterDefinitions)
        {
            BusinessCriteria<E> restult = new BusinessCriteria<E>();
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
