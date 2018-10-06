using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atk.DataPortal.Core;
using SqlRepoEx;
using SqlRepoEx.Abstractions;

namespace Atk.SqlRepoExBLL
{
    public class SqlRepoExHandle<TEntity> where TEntity : BusinessEditBase, new()
    {
        private readonly IRepository<TEntity> repository;

        public SqlRepoExHandle(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public TEntity DB_ExecuteQuerySql(TEntity entity)
        {
            return repository.ExecuteQuerySql().WithSql(entity.Criteria.SqlRepoExStatement).Go().ToList().FirstOrDefault();
        }

        public void DB_ExecuteNonQuerySql(TEntity entity)
        {
            repository.ExecuteNonQuerySql().WithSql(entity.Criteria.SqlRepoExStatement).Go();
        }


        public BusinessListBase<TEntity> DB_ExecuteQuerySqlList(BusinessListBase<TEntity> entity)
        {
            var azItem = repository.ExecuteQuerySql().WithSql(entity.Criteria.SqlRepoExStatement).Go().ToList();
            entity.Clear();
            entity.AddRange(azItem);
            return entity;
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
