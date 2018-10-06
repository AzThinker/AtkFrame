using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using Autofac;
using DemoTools.BLL.DemoNorthwind;
using SqlRepoEx.Abstractions;
using Module = Autofac.Module;

// <summary>
// SQL Server 2008 数据访问层
// 不支持SQL Server 2000
// </summary>
namespace DemoTools.DB.DemoNorthwind
{

    /// <summary>
    /// 此处实现 Autofac Module用于《客户》相关类注册用,
    /// 此处只注册业务类。
    /// 由于WCF的存在,业务层,数据访问层可能和IIS布署不在同一台服务器上
    /// 因而其他层的类,不应在此出现。
    /// </summary>
    public class AzCustomers_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzCustomersEntity>();
            moduleBuilder.RegisterType<AzCustomersListEntity>();
            moduleBuilder.RegisterType<AzCustomers_DB>().As<IAzCustomersDal>();
        }
    }


    /// <summary>
    /// 此处实现 客户 数据访问 IAzCustomersDal 接口
    /// </summary>
    public class AzCustomers_DB : IAzCustomersDal
    {

        private ILifetimeScope _lc;
        protected IRepository<AzCustomersEntity> repository;

        public AzCustomers_DB(ILifetimeScope lc)
        {
            _lc = lc;

        }

        /// <summary>
        /// 增加 客户
        /// </summary>
        /// <param name="azItem">业务类</param>
        /// <param name="context">上下文</param>
        public void DB_Insert(AzCustomersEntity azItem)
        {
            azItem = repository.ExecuteQuerySql().WithSql(azItem.Criteria.SqlRepoExStatement).Go().ToList().FirstOrDefault();
        }
        /// <summary>
        /// 更新 客户
        /// </summary>
        /// <param name="azItem">业务类</param>
        public void DB_Update(AzCustomersEntity azItem)
        {
            azItem = repository.ExecuteQuerySql().WithSql(azItem.Criteria.SqlRepoExStatement).Go().ToList().FirstOrDefault();

        }
        /// <summary>
        /// 删除 客户 时
        /// </summary>
        /// <param name="azItem">删除项目</param>
        public void DB_Delete(AzCustomersEntity azItem)
        {
            repository.ExecuteNonQuerySql().WithSql(azItem.Criteria.SqlRepoExStatement).Go();
        }
        /// <summary>
        /// 查询单个记录
        /// </summary>
        /// <param name="azItem">项目（也是传入参出）</param>
        public void DB_Fetch(AzCustomersEntity azItem)
        {
            azItem = repository.ExecuteQuerySql().WithSql(azItem.Criteria.SqlRepoExStatement).Go().ToList().FirstOrDefault();
        }


        /// <summary>
        /// 获取分页异步查询列表
        /// </summary>
        /// <param name="azItems">项目列表（也是传入参出）</param>
        public void DB_FetchList(AzCustomersListEntity azItems)
        {
            var azItem = repository.ExecuteQuerySql().WithSql(azItems.Criteria.SqlRepoExStatement).Go().ToList();
            azItems.AddRange(azItem);
        }


    }




}