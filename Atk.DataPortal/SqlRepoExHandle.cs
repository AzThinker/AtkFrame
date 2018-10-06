using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atk.DataPortal.Core;
using SqlRepoEx;
using SqlRepoEx.Abstractions;

namespace Atk.DataPortal
{
    public class SqlRepoExHandle<TEntity> where TEntity : BusinessBase, new()
    {
        private readonly IRepository<TEntity> repository;

        public SqlRepoExHandle(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public TEntity DB_ExecuteQuerySql(BusinessCriteria<TEntity> businessCriteria)
        {
            return repository.ExecuteQuerySql().WithSql(businessCriteria.SqlRepoExStatement).Go().ToList().FirstOrDefault();
        }

        public void DB_ExecuteNonQuerySql(BusinessCriteria<TEntity> businessCriteria)
        {
            repository.ExecuteNonQuerySql().WithSql(businessCriteria.SqlRepoExStatement).Go();
        }


        public BusinessListBase<TEntity> DB_ExecuteQuerySqlList(BusinessCriteria<TEntity> businessCriteria)
        {
            BusinessListBase<TEntity> entities = new BusinessListBase<TEntity>();
            var azItem = repository.ExecuteQuerySql().WithSql(businessCriteria.SqlRepoExStatement).Go().ToList();
            entities.Clear();
            entities.AddRange(azItem);
            return entities;
        }

        public BusinessListBase<TEntity> DB_ExecuteQueryProcedure(string FunctionName, ParameterDefinition[] parameterDefinitions)
        {
            var azItem = new BusinessListBase<TEntity>();
            var result = repository.ExecuteQueryProcedure().WithName(FunctionName).WithParameters(parameterDefinitions).Go();
            azItem.AddRange(azItem);
            return azItem;
        }

    }
}
