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
        private string _sqlRepoExStatement;

        /// <summary>
        /// 查询条件时的where 语句
        /// </summary>
        public string SqlRepoExStatement
        {
            get { return _sqlRepoExStatement; }
            protected set { _sqlRepoExStatement = value; }
        }

        /// <summary>
        /// 一个Josn字串，存储过程的参数
        /// </summary>
        public string ParameterDefinition { get => parameterDefinition; set => parameterDefinition = value; }

        private string parameterDefinition;

        /// <summary>
        /// 参数基类
        /// </summary>
        public CriteriaBase()
        {
            SqlRepoExStatement = string.Empty;
        }

    }


}
