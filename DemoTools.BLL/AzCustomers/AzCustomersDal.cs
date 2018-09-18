using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Module = Autofac.Module;
using DemoTools.BLL.DemoNorthwind;

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
    public   class AzCustomers_DB  :IAzCustomersDal
    {
	
        private ILifetimeScope _lc;

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
	    #region 初始化数据
	    OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
	    #endregion
              if (string.IsNullOrEmpty(azItem.Criteria.InsertSql))
            {
	       		#region  增加SQL语句字串
		azStrBuilder.Append(" Insert Into Customers(");
		azStrBuilder.Append("[CustomerID],[CompanyName],[ContactName],[ContactTitle],[Address],[City]");
		azStrBuilder.Append(",[Region],[PostalCode],[Country],[Phone],[Fax]");
		azStrBuilder.Append(")");
		azStrBuilder.Append(" Values( ");
		azStrBuilder.Append("@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City");
		azStrBuilder.Append(",@Region,@PostalCode,@Country,@Phone,@Fax");
		azStrBuilder.Append(")");

		#endregion

	    }
            else
            {
	      azStrBuilder.Append(" Insert Into   Customers ");
              azStrBuilder.Append(azItem.Criteria.InsertSql);
	      
	    }
            using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                {
		    #region 数据参数
		    SqlParameter param =null;

                    			param = new SqlParameter();
		param.ParameterName = "@CustomerID";
		param.Value=azItem.CustomerID;
		param.Size = 5;
		param.SqlDbType = SqlDbType.NChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@CompanyName";
		param.Value=azItem.CompanyName;
		param.Size = 40;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@ContactName";
		if (azItem.ContactName==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.ContactName;};
		param.Size = 30;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@ContactTitle";
		if (azItem.ContactTitle==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.ContactTitle;};
		param.Size = 30;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Address";
		if (azItem.Address==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Address;};
		param.Size = 60;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@City";
		if (azItem.City==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.City;};
		param.Size = 15;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Region";
		if (azItem.Region==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Region;};
		param.Size = 15;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@PostalCode";
		if (azItem.PostalCode==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.PostalCode;};
		param.Size = 10;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Country";
		if (azItem.Country==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Country;};
		param.Size = 15;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Phone";
		if (azItem.Phone==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Phone;};
		param.Size = 24;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Fax";
		if (azItem.Fax==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Fax;};
		param.Size = 24;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);



		    #endregion

                    int c = cmd.ExecuteNonQuery();
                    if (c == 0)
                    {
                        state.Error.Add("数据库增加", "没有记录增加");

                    }
		    
		    state.AffectedRows = c;
                    azItem.State= state;
                };
	       }
           }
	        /// <summary>
        /// 更新 客户
        /// </summary>
        /// <param name="azItem">业务类</param>
        public void DB_Update(AzCustomersEntity azItem) 
         {
	    #region 初始化数据
	    OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
	    #endregion

            if (string.IsNullOrEmpty(azItem.Criteria.UpdateSql))
            {
	        		#region  更新SQL语句字串
		azStrBuilder.Append("Update [a0] Set "); 
		azStrBuilder.Append("[a0].[CompanyName]=@CompanyName,[a0].[ContactName]=@ContactName,[a0].[ContactTitle]=@ContactTitle,[a0].[Address]=@Address,[a0].[City]=@City,[a0].[Region]=@Region");
		azStrBuilder.Append(",[a0].[PostalCode]=@PostalCode,[a0].[Country]=@Country,[a0].[Phone]=@Phone,[a0].[Fax]=@Fax From Customers As [a0]");
	#endregion


            }
	    else
	    {
                azStrBuilder.Append(" Update [a0] Set ");
                azStrBuilder.Append(azItem.Criteria.UpdateSql);
		azStrBuilder.Append(" From  Customers As [a0] ");
	    }
	    //单记录操作
	    bool isoneupdate = string.IsNullOrWhiteSpace(azItem.Criteria.QueryWhere);
	    //启用了事务并且是多记录操作时，才使用事务
            bool istran = azItem.Context.IsTransaction && !isoneupdate;
           if (isoneupdate) 
	    { 
	        //无条件传入时,以关键字段更新
		azStrBuilder.Append(" 		Where [a0].[CustomerID]=@CustomerID ");
	    } else
	    {
		azStrBuilder.Append(azItem.Criteria.QueryWhere);
		azStrBuilder.Append(azItem.Criteria.QueryOrder);
	    }
            using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
            {
	       SqlTransaction azTransaction = null;
                try
                {
                    if (istran)
                    {
                        azTransaction = cn.BeginTransaction("AzCustomersEntity_update_tran");

                    }
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                {
		    #region 数据参数
		    SqlParameter param =null;

		    if (isoneupdate) 
		     {
		       //无条件传入时,以关键字段值为条件进行更新
		       		param = new SqlParameter();
		param.ParameterName = "@CustomerID";
		param.Value=azItem.CustomerID;
		param.Size = 5;
		param.SqlDbType = SqlDbType.NChar;
		cmd.Parameters.Add(param);

		     }

                    			param = new SqlParameter();
		param.ParameterName = "@CustomerID";
		param.Value=azItem.CustomerID;
		param.Size = 5;
		param.SqlDbType = SqlDbType.NChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@CompanyName";
		param.Value=azItem.CompanyName;
		param.Size = 40;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@ContactName";
		if (azItem.ContactName==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.ContactName;};
		param.Size = 30;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@ContactTitle";
		if (azItem.ContactTitle==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.ContactTitle;};
		param.Size = 30;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Address";
		if (azItem.Address==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Address;};
		param.Size = 60;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@City";
		if (azItem.City==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.City;};
		param.Size = 15;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Region";
		if (azItem.Region==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Region;};
		param.Size = 15;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@PostalCode";
		if (azItem.PostalCode==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.PostalCode;};
		param.Size = 10;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Country";
		if (azItem.Country==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Country;};
		param.Size = 15;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Phone";
		if (azItem.Phone==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Phone;};
		param.Size = 24;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Fax";
		if (azItem.Fax==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.Fax;};
		param.Size = 24;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);




		    #endregion
                    int c = cmd.ExecuteNonQuery();
                    if (c == 0)
                    {
                        state.Error.Add("数据库更新", "没有记录更新");

                    }
		    state.AffectedRows = c;
                    azItem.State= state;
                };
             if (istran)
                    {
                        azTransaction.Commit();

                    }
                }
                catch
                {
                    if (istran)
                    {
                        azTransaction.Rollback();
                        state.Error.Add("数据库更新错误！", "没有记录更新");
                    }
                    else
                    {
                        state.Error.Add("数据库更新错误！", "更新记录错误");
                    }
                }
            }
        }
	        /// <summary>
        /// 删除 客户 时
        /// </summary>
        /// <param name="azItem">删除项目</param>
	public void DB_Delete(AzCustomersEntity azItem)
        {
	    #region 初始化数据
	    OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
	    #endregion
	    	    //单记录操作
	    bool isoneupdate = string.IsNullOrWhiteSpace(azItem.Criteria.QueryWhere);
	    //启用了事务并且是多记录操作时，才使用事务
            bool istran = azItem.Context.IsTransaction && !isoneupdate;
            if (isoneupdate) 
	    {
	        //无条件传入时,以关键字段值为条件进行删除
		azStrBuilder.Append(" Delete [a0] From Customers  As [a0] 		Where [a0].[CustomerID]=@CustomerID ");
	    } else
	    {
		azStrBuilder.Append(" Delete [a0] From Customers  As [a0] ");
		azStrBuilder.Append(azItem.Criteria.QueryWhere);
		azStrBuilder.Append(azItem.Criteria.QueryOrder);
	    }
            using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
            {
	    	SqlTransaction azTransaction = null;
                try
                {
                    if (istran)
                    {
                        azTransaction = cn.BeginTransaction("AzCustomersEntity_Delete_tran");

                    }
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                {
		    #region 数据参数
		    if (isoneupdate)
                    {
		     //无条件传入时,以关键字段值为条件进行删除
		     SqlParameter param =null;
                     		param = new SqlParameter();
		param.ParameterName = "@CustomerID";
		param.Value=azItem.CustomerID;
		param.Size = 5;
		param.SqlDbType = SqlDbType.NChar;
		cmd.Parameters.Add(param);

		    }
		    #endregion

                    int c = cmd.ExecuteNonQuery();
                    if (c == 0)
                    {
                        state.Error.Add("Delete", "没有记录删除");
                    }
		    state.AffectedRows = c;
                    azItem.State = state;
                };
             if (istran)
                    {
                        azTransaction.Commit();

                    }
                }
                catch
                {
                    if (istran)
                    {
                        azTransaction.Rollback();
                        state.Error.Add("数据库更新错误！", "没有记录删除");
                    }
                    else
                    {
                        state.Error.Add("数据库删除错误！", "删除记录错误");
                    }  
                }
            }
        }
	        /// <summary>
        /// 查询单个记录
        /// </summary>
        /// <param name="azItem">项目（也是传入参出）</param>
        public void  DB_Fetch(AzCustomersEntity azItem)
         {
	    #region 初始化数据
	    OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
	    bool IsaccessDirect=!string.IsNullOrWhiteSpace(azItem.Criteria.AccessFetch);
	    #endregion

            try
            {
                using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
                {
                    #region 数据访问
                    #region 查询SQL语句

			azStrBuilder.Append("SELECT TOP (1) ");
			azStrBuilder.Append("[a0].[CustomerID],[a0].[CompanyName],[a0].[ContactName],[a0].[ContactTitle],[a0].[Address],[a0].[City]");
azStrBuilder.Append(",[a0].[Region],[a0].[PostalCode],[a0].[Country],[a0].[Phone],[a0].[Fax]");

			azStrBuilder.Append(" FROM  Customers [a0] ");
                    if (IsaccessDirect)
                    { 
			
                        azStrBuilder.Append(azItem.Criteria.AccessFetch);
                    }
                    else
                    {
			azStrBuilder.Append(azItem.Criteria.QueryWhere);
			azStrBuilder.Append(azItem.Criteria.QueryOrder);
		    }
		    #endregion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                    {
                        using (SqlDataReader azDataReader = cmd.ExecuteReader())
                        {
                            if (azDataReader.HasRows)
                            {
                                azDataReader.Read();
                          
                                	#region  类赋值
			azItem.CustomerID=(string)azDataReader["CustomerID"];//CustomerID_simpCN
			azItem.CompanyName=(string)azDataReader["CompanyName"];//CompanyName_simpCN
			azItem.ContactName=azDataReader["ContactName"] is DBNull ? null : (string)azDataReader["ContactName"];//ContactName_simpCN
			azItem.ContactTitle=azDataReader["ContactTitle"] is DBNull ? null : (string)azDataReader["ContactTitle"];//ContactTitle_simpCN
			azItem.Address=azDataReader["Address"] is DBNull ? null : (string)azDataReader["Address"];//Address_simpCN
			azItem.City=azDataReader["City"] is DBNull ? null : (string)azDataReader["City"];//City_simpCN
			azItem.Region=azDataReader["Region"] is DBNull ? null : (string)azDataReader["Region"];//Region_simpCN
			azItem.PostalCode=azDataReader["PostalCode"] is DBNull ? null : (string)azDataReader["PostalCode"];//PostalCode_simpCN
			azItem.Country=azDataReader["Country"] is DBNull ? null : (string)azDataReader["Country"];//Country_simpCN
			azItem.Phone=azDataReader["Phone"] is DBNull ? null : (string)azDataReader["Phone"];//Phone_simpCN
			azItem.Fax=azDataReader["Fax"] is DBNull ? null : (string)azDataReader["Fax"];//Fax_simpCN
	#endregion

                                state.AffectedRows =1;  
                                azItem.State = state;
                            }
                            else
                            {
                                state.Error.Add("数据库查询", "当前查询没有记录");
                                azItem.State = state;
                            };
                        };
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                state.Error.Add("数据库查询", e.Message);
                azItem.State = state;
            }
	   }
	 

	        /// <summary>
        /// 获取分页异步查询列表
        /// </summary>
        /// <param name="azItems">项目列表（也是传入参出）</param>
         public void DB_FetchList(AzCustomersListEntity azItems)
         {
	    #region 初始化数据
	    OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
	    StringBuilder aisbcount = new StringBuilder();
	    int RCount = 0; //记录总数
	    int aiPage=-1; int aiRows=-1;
            aiPage = azItems.Criteria.CurrentPage;
            aiRows = azItems.Criteria.QueryRows;
	    bool IsaccessDirect=!string.IsNullOrWhiteSpace(azItems.Criteria.AccessFetchList);
	    #endregion

	    #region 数据访问
            using (SqlConnection cn = new SqlConnection(azItems.Context.DbConnectionString))
            {
	        #region 数据记录总数查询
                aisbcount.Append(" SELECT COUNT(*) AS AiCount");
		aisbcount.Append(" FROM dbo.Customers a0");
                if (IsaccessDirect)
                {
                    aisbcount.Append(azItems.Criteria.AccessFetchList);
                }
                else
                {
                    aisbcount.Append(azItems.Criteria.QueryWhere);
		}
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(aisbcount.ToString(), cn))
                {
                    using (SqlDataReader azDataReader = cmd.ExecuteReader())
                    {
                        if (azDataReader.Read())
                            RCount = (int)azDataReader["AiCount"];
                    }
                }
		//如果只查询记录数,而不查询记录时的返回
                if (aiPage == -1 && aiRows == -1)
                {
                    azItems.TotalCount = RCount;
                    azItems.State = state;
                }
                #endregion

                #region SQL
                if (aiPage + aiRows > 0)
                {
		   #region 需分页数据查询时
                    //当前不是有序表达式时
                    aiPage = aiPage > 0 ? aiPage : 1;
                    aiRows = aiRows > 0 ? aiRows : 20;
                    string aiorder = azItems.Criteria.QueryOrder;
                    if (string.IsNullOrWhiteSpace(aiorder))
                    {
                        aiorder = " order by [CustomerID]";
                    }
                    azStrBuilder.Append(" SELECT  Top(" + aiRows.ToString() + ") ");
		    azStrBuilder.Append("[CustomerID],[CompanyName],[ContactName],[ContactTitle],[Address],[City]");
azStrBuilder.Append(",[Region],[PostalCode],[Country],[Phone],[Fax]");

                    azStrBuilder.Append("  From (SELECT     ");
		    azStrBuilder.Append("[a0].[CustomerID],[a0].[CompanyName],[a0].[ContactName],[a0].[ContactTitle],[a0].[Address],[a0].[City]");
azStrBuilder.Append(",[a0].[Region],[a0].[PostalCode],[a0].[Country],[a0].[Phone],[a0].[Fax]");

                    azStrBuilder.Append(" ,row_number() OVER (" + aiorder + ") AS [row_number]");
		    azStrBuilder.Append(" FROM  Customers As [a0]");
                    if (IsaccessDirect)
                    {
	                azStrBuilder.Append(azItems.Criteria.AccessFetchList);
                    }
                    else
                    {
			azStrBuilder.Append(azItems.Criteria.QueryWhere);
		    }
                    azStrBuilder.Append(" ) as  aipagequery  ");
                    azStrBuilder.Append(" where row_number>" + ((aiPage - 1) * aiRows).ToString());
                    azStrBuilder.Append(aiorder);
		    #endregion
                }
                else
                {
		    //非分页记录时
                    azStrBuilder.Append(" SELECT  ");
		    azStrBuilder.Append("[a0].[CustomerID],[a0].[CompanyName],[a0].[ContactName],[a0].[ContactTitle],[a0].[Address],[a0].[City]");
azStrBuilder.Append(",[a0].[Region],[a0].[PostalCode],[a0].[Country],[a0].[Phone],[a0].[Fax]");

		    azStrBuilder.Append(" FROM  Customers As [a0] ");
                    if (IsaccessDirect)
                    {
			
                        azStrBuilder.Append(azItems.Criteria.AccessFetchList);
                    }
                    else
                    {
			azStrBuilder.Append(azItems.Criteria.QueryWhere);
			azStrBuilder.Append(azItems.Criteria.QueryOrder);
		    }
                }
                #endregion

                #region 数据拷贝
                using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                {
                    using (SqlDataReader azDataReader = cmd.ExecuteReader())
                    {
                        while (azDataReader.Read())
                        {
                           var vItem = _lc.Resolve<AzCustomersEntity>();
                           	#region  类赋值
			vItem.CustomerID=(string)azDataReader["CustomerID"];//CustomerID_simpCN
			vItem.CompanyName=(string)azDataReader["CompanyName"];//CompanyName_simpCN
			vItem.ContactName=azDataReader["ContactName"] is DBNull ? null : (string)azDataReader["ContactName"];//ContactName_simpCN
			vItem.ContactTitle=azDataReader["ContactTitle"] is DBNull ? null : (string)azDataReader["ContactTitle"];//ContactTitle_simpCN
			vItem.Address=azDataReader["Address"] is DBNull ? null : (string)azDataReader["Address"];//Address_simpCN
			vItem.City=azDataReader["City"] is DBNull ? null : (string)azDataReader["City"];//City_simpCN
			vItem.Region=azDataReader["Region"] is DBNull ? null : (string)azDataReader["Region"];//Region_simpCN
			vItem.PostalCode=azDataReader["PostalCode"] is DBNull ? null : (string)azDataReader["PostalCode"];//PostalCode_simpCN
			vItem.Country=azDataReader["Country"] is DBNull ? null : (string)azDataReader["Country"];//Country_simpCN
			vItem.Phone=azDataReader["Phone"] is DBNull ? null : (string)azDataReader["Phone"];//Phone_simpCN
			vItem.Fax=azDataReader["Fax"] is DBNull ? null : (string)azDataReader["Fax"];//Fax_simpCN
	#endregion

			   azItems.Add(vItem);
                        }
                    }
                };
		#endregion
            }
	    state.AffectedRows = azItems.Count;
            azItems.TotalCount = RCount;
            azItems.State = state;
	    #endregion
	  }


   }


   

}