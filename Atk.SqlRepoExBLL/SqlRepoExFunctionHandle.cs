using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlRepoEx;
using SqlRepoEx.Abstractions;

namespace Atk.SqlRepoExBLL
{
    public class SqlRepoExFunctionHandle
    {
        private readonly IRepository repository;
        public SqlRepoExFunctionHandle(IRepository repository)
        {
            this.repository = repository;
        }

        public ParameterDefinition[] Exec(string FunctionName, ParameterDefinition[] parameterDefinitions)
        {
            repository.ExecuteNonQueryProcedure().WithName(FunctionName).WithParameters(parameterDefinitions).Go();
            return parameterDefinitions;
        }
    }
}
