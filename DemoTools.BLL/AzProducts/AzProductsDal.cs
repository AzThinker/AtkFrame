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
    /// 此处实现 Autofac Module用于《产品》相关类注册用,
    /// 此处只注册业务类。
    /// 由于WCF的存在,业务层,数据访问层可能和IIS布署不在同一台服务器上
    /// 因而其他层的类,不应在此出现。
    /// </summary>
    public class AzProducts_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzProductsEntity>();
            moduleBuilder.RegisterType<AzProductsListEntity>();
            moduleBuilder.RegisterType<AzProducts_DB>().As<IAzProductsDal>();
        }
    }


    /// <summary>
    /// 此处实现 产品 数据访问 IAzProductsDal 接口
    /// </summary>
    public   class AzProducts_DB  :IAzProductsDal
    {
	
        private ILifetimeScope _lc;

        public AzProducts_DB(ILifetimeScope lc)
        {
            _lc = lc;

        }

		        /// <summary>
        /// 增加 产品
        /// </summary>
        /// <param name="azItem">业务类</param>
	/// <param name="context">上下文</param>
        public void DB_Insert(AzProductsEntity azItem) 
         {
	    #region 初始化数据
	    OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
	    #endregion
              if (string.IsNullOrEmpty(azItem.Criteria.InsertSql))
            {
	       		#region  增加SQL语句字串
		azStrBuilder.Append(" Insert Into Products(");
		azStrBuilder.Append("[ProductName],[SupplierID],[CategoryID],[QuantityPerUnit],[UnitPrice],[UnitsInStock]");
azStrBuilder.Append(",[UnitsOnOrder],[ReorderLevel],[Discontinued])");		azStrBuilder.Append(" Values( ");
		azStrBuilder.Append("@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock");
azStrBuilder.Append(",@UnitsOnOrder,@ReorderLevel,@Discontinued)");		azStrBuilder.Append(";select @getautouid = SCOPE_IDENTITY()"); 
		#endregion

	    }
            else
            {
	      azStrBuilder.Append(" Insert Into   Products ");
              azStrBuilder.Append(azItem.Criteria.InsertSql);
	      		azStrBuilder.Append(";select @getautouid = SCOPE_IDENTITY()"); 
	    }
            using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                {
		    #region 数据参数
		    SqlParameter param =null;

                    			param = new SqlParameter();
		param.SqlDbType = SqlDbType.Int;
		param.ParameterName = "@getautouid";
		param.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@ProductName";
		param.Value=azItem.ProductName;
		param.Size = 40;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@SupplierID";
		if (azItem.SupplierID==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.SupplierID;};
		param.SqlDbType = SqlDbType.Int;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@CategoryID";
		if (azItem.CategoryID==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.CategoryID;};
		param.SqlDbType = SqlDbType.Int;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@QuantityPerUnit";
		if (azItem.QuantityPerUnit==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.QuantityPerUnit;};
		param.Size = 20;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@UnitPrice";
		if (azItem.UnitPrice==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.UnitPrice;};
		param.SqlDbType = SqlDbType.Money;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@UnitsInStock";
		if (azItem.UnitsInStock==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.UnitsInStock;};
		param.SqlDbType = SqlDbType.SmallInt;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@UnitsOnOrder";
		if (azItem.UnitsOnOrder==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.UnitsOnOrder;};
		param.SqlDbType = SqlDbType.SmallInt;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@ReorderLevel";
		if (azItem.ReorderLevel==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.ReorderLevel;};
		param.SqlDbType = SqlDbType.SmallInt;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Discontinued";
		param.Value=azItem.Discontinued;
		param.SqlDbType = SqlDbType.Bit;
		cmd.Parameters.Add(param);



		    #endregion

                    int c = cmd.ExecuteNonQuery();
                    if (c == 0)
                    {
                        state.Error.Add("数据库增加", "没有记录增加");

                    }
		    			if (c>0)
				{
				azItem.ProductID=(int)cmd.Parameters["@getautouid"].Value;
				}


		    state.AffectedRows = c;
                    azItem.State= state;
                };
	       }
           }
	        /// <summary>
        /// 更新 产品
        /// </summary>
        /// <param name="azItem">业务类</param>
        public void DB_Update(AzProductsEntity azItem) 
         {
	    #region 初始化数据
	    OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
	    #endregion

            if (string.IsNullOrEmpty(azItem.Criteria.UpdateSql))
            {
	        		#region  更新SQL语句字串
		azStrBuilder.Append("Update [a0] Set "); 
		azStrBuilder.Append("[a0].[ProductName]=@ProductName,[a0].[SupplierID]=@SupplierID,[a0].[CategoryID]=@CategoryID,[a0].[QuantityPerUnit]=@QuantityPerUnit,[a0].[UnitPrice]=@UnitPrice,[a0].[UnitsInStock]=@UnitsInStock");
		azStrBuilder.Append(",[a0].[UnitsOnOrder]=@UnitsOnOrder,[a0].[ReorderLevel]=@ReorderLevel,[a0].[Discontinued]=@Discontinued From Products As [a0]");
	#endregion


            }
	    else
	    {
                azStrBuilder.Append(" Update [a0] Set ");
                azStrBuilder.Append(azItem.Criteria.UpdateSql);
		azStrBuilder.Append(" From  Products As [a0] ");
	    }
	    //单记录操作
	    bool isoneupdate = string.IsNullOrWhiteSpace(azItem.Criteria.QueryWhere);
	    //启用了事务并且是多记录操作时，才使用事务
            bool istran = azItem.Context.IsTransaction && !isoneupdate;
           if (isoneupdate) 
	    { 
	        //无条件传入时,以关键字段更新
		azStrBuilder.Append(" 		Where [a0].[ProductID]=@ProductID ");
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
                        azTransaction = cn.BeginTransaction("AzProductsEntity_update_tran");

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
		param.ParameterName = "@ProductID";
		param.Value=azItem.ProductID;
		param.SqlDbType = SqlDbType.Int;
		cmd.Parameters.Add(param);

		     }

                    			param = new SqlParameter();
		param.SqlDbType = SqlDbType.Int;
		param.ParameterName = "@getautouid";
		param.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@ProductName";
		param.Value=azItem.ProductName;
		param.Size = 40;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@SupplierID";
		if (azItem.SupplierID==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.SupplierID;};
		param.SqlDbType = SqlDbType.Int;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@CategoryID";
		if (azItem.CategoryID==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.CategoryID;};
		param.SqlDbType = SqlDbType.Int;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@QuantityPerUnit";
		if (azItem.QuantityPerUnit==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.QuantityPerUnit;};
		param.Size = 20;
		param.SqlDbType = SqlDbType.NVarChar;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@UnitPrice";
		if (azItem.UnitPrice==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.UnitPrice;};
		param.SqlDbType = SqlDbType.Money;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@UnitsInStock";
		if (azItem.UnitsInStock==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.UnitsInStock;};
		param.SqlDbType = SqlDbType.SmallInt;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@UnitsOnOrder";
		if (azItem.UnitsOnOrder==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.UnitsOnOrder;};
		param.SqlDbType = SqlDbType.SmallInt;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@ReorderLevel";
		if (azItem.ReorderLevel==null)
		 {param.Value = System.DBNull.Value;}
		else
		{ param.Value=azItem.ReorderLevel;};
		param.SqlDbType = SqlDbType.SmallInt;
		cmd.Parameters.Add(param);


			param = new SqlParameter();
		param.ParameterName = "@Discontinued";
		param.Value=azItem.Discontinued;
		param.SqlDbType = SqlDbType.Bit;
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
        /// 删除 产品 时
        /// </summary>
        /// <param name="azItem">删除项目</param>
	public void DB_Delete(AzProductsEntity azItem)
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
		azStrBuilder.Append(" Delete [a0] From Products  As [a0] 		Where [a0].[ProductID]=@ProductID ");
	    } else
	    {
		azStrBuilder.Append(" Delete [a0] From Products  As [a0] ");
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
                        azTransaction = cn.BeginTransaction("AzProductsEntity_Delete_tran");

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
		param.ParameterName = "@ProductID";
		param.Value=azItem.ProductID;
		param.SqlDbType = SqlDbType.Int;
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
        public void  DB_Fetch(AzProductsEntity azItem)
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
			azStrBuilder.Append("[a0].[ProductID],[a0].[ProductName],[a0].[SupplierID],[a0].[CategoryID],[a0].[QuantityPerUnit],[a0].[UnitPrice]");
		azStrBuilder.Append(",[a0].[UnitsInStock],[a0].[UnitsOnOrder],[a0].[ReorderLevel],[a0].[Discontinued]");

			azStrBuilder.Append(" FROM  Products [a0] ");
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
			azItem.ProductID=(int)azDataReader["ProductID"];//ProductID_simpCN
			azItem.ProductName=(string)azDataReader["ProductName"];//ProductName_simpCN
			azItem.SupplierID=azDataReader["SupplierID"] is DBNull ? null : (int?)azDataReader["SupplierID"];//SupplierID_simpCN
			azItem.CategoryID=azDataReader["CategoryID"] is DBNull ? null : (int?)azDataReader["CategoryID"];//CategoryID_simpCN
			azItem.QuantityPerUnit=azDataReader["QuantityPerUnit"] is DBNull ? null : (string)azDataReader["QuantityPerUnit"];//QuantityPerUnit_simpCN
			azItem.UnitPrice=azDataReader["UnitPrice"] is DBNull ? null : (decimal?)azDataReader["UnitPrice"];//UnitPrice_simpCN
			azItem.UnitsInStock=azDataReader["UnitsInStock"] is DBNull ? null : (short?)azDataReader["UnitsInStock"];//UnitsInStock_simpCN
			azItem.UnitsOnOrder=azDataReader["UnitsOnOrder"] is DBNull ? null : (short?)azDataReader["UnitsOnOrder"];//UnitsOnOrder_simpCN
			azItem.ReorderLevel=azDataReader["ReorderLevel"] is DBNull ? null : (short?)azDataReader["ReorderLevel"];//ReorderLevel_simpCN
			azItem.Discontinued=(bool)azDataReader["Discontinued"];//Discontinued_simpCN
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
         public void DB_FetchList(AzProductsListEntity azItems)
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
		aisbcount.Append(" FROM dbo.Products a0");
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
                        aiorder = " order by [ProductID]";
                    }
                    azStrBuilder.Append(" SELECT  Top(" + aiRows.ToString() + ") ");
		    azStrBuilder.Append("[ProductID],[ProductName],[SupplierID],[CategoryID],[QuantityPerUnit],[UnitPrice]");
		azStrBuilder.Append(",[UnitsInStock],[UnitsOnOrder],[ReorderLevel],[Discontinued]");

                    azStrBuilder.Append("  From (SELECT     ");
		    azStrBuilder.Append("[a0].[ProductID],[a0].[ProductName],[a0].[SupplierID],[a0].[CategoryID],[a0].[QuantityPerUnit],[a0].[UnitPrice]");
		azStrBuilder.Append(",[a0].[UnitsInStock],[a0].[UnitsOnOrder],[a0].[ReorderLevel],[a0].[Discontinued]");

                    azStrBuilder.Append(" ,row_number() OVER (" + aiorder + ") AS [row_number]");
		    azStrBuilder.Append(" FROM  Products As [a0]");
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
		    azStrBuilder.Append("[a0].[ProductID],[a0].[ProductName],[a0].[SupplierID],[a0].[CategoryID],[a0].[QuantityPerUnit],[a0].[UnitPrice]");
		azStrBuilder.Append(",[a0].[UnitsInStock],[a0].[UnitsOnOrder],[a0].[ReorderLevel],[a0].[Discontinued]");

		    azStrBuilder.Append(" FROM  Products As [a0] ");
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
                           var vItem = _lc.Resolve<AzProductsEntity>();
                           	#region  类赋值
			vItem.ProductID=(int)azDataReader["ProductID"];//ProductID_simpCN
			vItem.ProductName=(string)azDataReader["ProductName"];//ProductName_simpCN
			vItem.SupplierID=azDataReader["SupplierID"] is DBNull ? null : (int?)azDataReader["SupplierID"];//SupplierID_simpCN
			vItem.CategoryID=azDataReader["CategoryID"] is DBNull ? null : (int?)azDataReader["CategoryID"];//CategoryID_simpCN
			vItem.QuantityPerUnit=azDataReader["QuantityPerUnit"] is DBNull ? null : (string)azDataReader["QuantityPerUnit"];//QuantityPerUnit_simpCN
			vItem.UnitPrice=azDataReader["UnitPrice"] is DBNull ? null : (decimal?)azDataReader["UnitPrice"];//UnitPrice_simpCN
			vItem.UnitsInStock=azDataReader["UnitsInStock"] is DBNull ? null : (short?)azDataReader["UnitsInStock"];//UnitsInStock_simpCN
			vItem.UnitsOnOrder=azDataReader["UnitsOnOrder"] is DBNull ? null : (short?)azDataReader["UnitsOnOrder"];//UnitsOnOrder_simpCN
			vItem.ReorderLevel=azDataReader["ReorderLevel"] is DBNull ? null : (short?)azDataReader["ReorderLevel"];//ReorderLevel_simpCN
			vItem.Discontinued=(bool)azDataReader["Discontinued"];//Discontinued_simpCN
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