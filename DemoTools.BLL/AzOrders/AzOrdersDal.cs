using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using Autofac;
using DemoTools.BLL.DemoNorthwind;
using Module = Autofac.Module;

// <summary>
// SQL Server 2008 数据访问层
// 不支持SQL Server 2000
// </summary>
namespace DemoTools.DB.DemoNorthwind
{

    /// <summary>
    /// 此处实现 Autofac Module用于《订单》相关类注册用,
    /// 此处只注册业务类。
    /// 由于WCF的存在,业务层,数据访问层可能和IIS布署不在同一台服务器上
    /// 因而其他层的类,不应在此出现。
    /// </summary>
    public class AzOrders_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzOrdersEntity>();
            moduleBuilder.RegisterType<AzOrdersListEntity>();
            moduleBuilder.RegisterType<AzOrders_DB>().As<IAzOrdersDal>();
        }
    }


    /// <summary>
    /// 此处实现 订单 数据访问 IAzOrdersDal 接口
    /// </summary>
    public class AzOrders_DB : IAzOrdersDal
    {

        private ILifetimeScope _lc;

        public AzOrders_DB(ILifetimeScope lc)
        {
            _lc = lc;

        }

        /// <summary>
        /// 增加 订单
        /// </summary>
        /// <param name="azItem">业务类</param>
        /// <param name="context">上下文</param>
        public void DB_Insert(AzOrdersEntity azItem)
        {
            #region 初始化数据
            OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
            #endregion
            if (string.IsNullOrEmpty(azItem.Criteria.InsertSql))
            {
                #region  增加SQL语句字串
                azStrBuilder.Append(" Insert Into Orders(");
                azStrBuilder.Append("[CustomerID],[EmployeeID],[OrderDate],[RequiredDate],[ShippedDate],[ShipVia]");
                azStrBuilder.Append(",[Freight],[ShipName],[ShipAddress],[ShipCity],[ShipRegion]");
                azStrBuilder.Append(",[ShipPostalCode],[ShipCountry])"); azStrBuilder.Append(" Values( ");
                azStrBuilder.Append("@CustomerID,@EmployeeID,@OrderDate,@RequiredDate,@ShippedDate,@ShipVia");
                azStrBuilder.Append(",@Freight,@ShipName,@ShipAddress,@ShipCity,@ShipRegion");
                azStrBuilder.Append(",@ShipPostalCode,@ShipCountry)"); azStrBuilder.Append(";select @getautouid = SCOPE_IDENTITY()");
                #endregion

            }
            else
            {
                azStrBuilder.Append(" Insert Into   Orders ");
                azStrBuilder.Append(azItem.Criteria.InsertSql);
                azStrBuilder.Append(";select @getautouid = SCOPE_IDENTITY()");
            }
            using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                {
                    #region 数据参数
                    SqlParameter param = null;

                    param = new SqlParameter();
                    param.SqlDbType = SqlDbType.Int;
                    param.ParameterName = "@getautouid";
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@CustomerID";
                    if (azItem.CustomerID == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.CustomerID; };
                    param.Size = 5;
                    param.SqlDbType = SqlDbType.NChar;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@EmployeeID";
                    if (azItem.EmployeeID == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.EmployeeID; };
                    param.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@OrderDate";
                    if (azItem.OrderDate == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.OrderDate; };
                    param.SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@RequiredDate";
                    if (azItem.RequiredDate == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.RequiredDate; };
                    param.SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@ShippedDate";
                    if (azItem.ShippedDate == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.ShippedDate; };
                    param.SqlDbType = SqlDbType.DateTime;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@ShipVia";
                    if (azItem.ShipVia == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.ShipVia; };
                    param.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@Freight";
                    if (azItem.Freight == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.Freight; };
                    param.SqlDbType = SqlDbType.Money;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@ShipName";
                    if (azItem.ShipName == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.ShipName; };
                    param.Size = 40;
                    param.SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@ShipAddress";
                    if (azItem.ShipAddress == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.ShipAddress; };
                    param.Size = 60;
                    param.SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@ShipCity";
                    if (azItem.ShipCity == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.ShipCity; };
                    param.Size = 15;
                    param.SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@ShipRegion";
                    if (azItem.ShipRegion == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.ShipRegion; };
                    param.Size = 15;
                    param.SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@ShipPostalCode";
                    if (azItem.ShipPostalCode == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.ShipPostalCode; };
                    param.Size = 10;
                    param.SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@ShipCountry";
                    if (azItem.ShipCountry == null)
                    { param.Value = System.DBNull.Value; }
                    else
                    { param.Value = azItem.ShipCountry; };
                    param.Size = 15;
                    param.SqlDbType = SqlDbType.NVarChar;
                    cmd.Parameters.Add(param);



                    #endregion

                    int c = cmd.ExecuteNonQuery();
                    if (c == 0)
                    {
                        state.Error.Add("数据库增加", "没有记录增加");

                    }
                    if (c > 0)
                    {
                        azItem.OrderID = (int)cmd.Parameters["@getautouid"].Value;
                    }


                    state.AffectedRows = c;
                    azItem.State = state;
                };
            }
        }
        /// <summary>
        /// 更新 订单
        /// </summary>
        /// <param name="azItem">业务类</param>
        public void DB_Update(AzOrdersEntity azItem)
        {
            #region 初始化数据
            OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
            #endregion

            if (string.IsNullOrEmpty(azItem.Criteria.UpdateSql))
            {
                #region  更新SQL语句字串
                azStrBuilder.Append("Update [a0] Set ");
                azStrBuilder.Append("[a0].[CustomerID]=@CustomerID,[a0].[EmployeeID]=@EmployeeID,[a0].[OrderDate]=@OrderDate,[a0].[RequiredDate]=@RequiredDate,[a0].[ShippedDate]=@ShippedDate,[a0].[ShipVia]=@ShipVia");
                azStrBuilder.Append(",[a0].[Freight]=@Freight,[a0].[ShipName]=@ShipName,[a0].[ShipAddress]=@ShipAddress,[a0].[ShipCity]=@ShipCity,[a0].[ShipRegion]=@ShipRegion");
                azStrBuilder.Append(",[a0].[ShipPostalCode]=@ShipPostalCode,[a0].[ShipCountry]=@ShipCountry From Orders As [a0]");
                #endregion


            }
            else
            {
                azStrBuilder.Append(" Update [a0] Set ");
                azStrBuilder.Append(azItem.Criteria.UpdateSql);
                azStrBuilder.Append(" From  Orders As [a0] ");
            }
            //单记录操作
            bool isoneupdate = string.IsNullOrWhiteSpace(azItem.Criteria.QueryWhere);
            //启用了事务并且是多记录操作时，才使用事务
            bool istran = azItem.Context.IsTransaction && !isoneupdate;
            if (isoneupdate)
            {
                //无条件传入时,以关键字段更新
                azStrBuilder.Append(" 		Where [a0].[OrderID]=@OrderID ");
            }
            else
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
                        azTransaction = cn.BeginTransaction("AzOrdersEntity_update_tran");

                    }
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                    {
                        #region 数据参数
                        SqlParameter param = null;

                        if (isoneupdate)
                        {
                            //无条件传入时,以关键字段值为条件进行更新
                            param = new SqlParameter();
                            param.ParameterName = "@OrderID";
                            param.Value = azItem.OrderID;
                            param.SqlDbType = SqlDbType.Int;
                            cmd.Parameters.Add(param);

                        }

                        param = new SqlParameter();
                        param.SqlDbType = SqlDbType.Int;
                        param.ParameterName = "@getautouid";
                        param.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@CustomerID";
                        if (azItem.CustomerID == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.CustomerID; };
                        param.Size = 5;
                        param.SqlDbType = SqlDbType.NChar;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@EmployeeID";
                        if (azItem.EmployeeID == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.EmployeeID; };
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@OrderDate";
                        if (azItem.OrderDate == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.OrderDate; };
                        param.SqlDbType = SqlDbType.DateTime;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@RequiredDate";
                        if (azItem.RequiredDate == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.RequiredDate; };
                        param.SqlDbType = SqlDbType.DateTime;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@ShippedDate";
                        if (azItem.ShippedDate == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.ShippedDate; };
                        param.SqlDbType = SqlDbType.DateTime;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@ShipVia";
                        if (azItem.ShipVia == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.ShipVia; };
                        param.SqlDbType = SqlDbType.Int;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@Freight";
                        if (azItem.Freight == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.Freight; };
                        param.SqlDbType = SqlDbType.Money;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@ShipName";
                        if (azItem.ShipName == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.ShipName; };
                        param.Size = 40;
                        param.SqlDbType = SqlDbType.NVarChar;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@ShipAddress";
                        if (azItem.ShipAddress == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.ShipAddress; };
                        param.Size = 60;
                        param.SqlDbType = SqlDbType.NVarChar;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@ShipCity";
                        if (azItem.ShipCity == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.ShipCity; };
                        param.Size = 15;
                        param.SqlDbType = SqlDbType.NVarChar;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@ShipRegion";
                        if (azItem.ShipRegion == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.ShipRegion; };
                        param.Size = 15;
                        param.SqlDbType = SqlDbType.NVarChar;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@ShipPostalCode";
                        if (azItem.ShipPostalCode == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.ShipPostalCode; };
                        param.Size = 10;
                        param.SqlDbType = SqlDbType.NVarChar;
                        cmd.Parameters.Add(param);


                        param = new SqlParameter();
                        param.ParameterName = "@ShipCountry";
                        if (azItem.ShipCountry == null)
                        { param.Value = System.DBNull.Value; }
                        else
                        { param.Value = azItem.ShipCountry; };
                        param.Size = 15;
                        param.SqlDbType = SqlDbType.NVarChar;
                        cmd.Parameters.Add(param);




                        #endregion
                        int c = cmd.ExecuteNonQuery();
                        if (c == 0)
                        {
                            state.Error.Add("数据库更新", "没有记录更新");

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
        /// 删除 订单 时
        /// </summary>
        /// <param name="azItem">删除项目</param>
        public void DB_Delete(AzOrdersEntity azItem)
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
                azStrBuilder.Append(" Delete [a0] From Orders  As [a0] 		Where [a0].[OrderID]=@OrderID ");
            }
            else
            {
                azStrBuilder.Append(" Delete [a0] From Orders  As [a0] ");
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
                        azTransaction = cn.BeginTransaction("AzOrdersEntity_Delete_tran");

                    }
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(azStrBuilder.ToString(), cn))
                    {
                        #region 数据参数
                        if (isoneupdate)
                        {
                            //无条件传入时,以关键字段值为条件进行删除
                            SqlParameter param = null;
                            param = new SqlParameter();
                            param.ParameterName = "@OrderID";
                            param.Value = azItem.OrderID;
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
        public void DB_Fetch(AzOrdersEntity azItem)
        {
            #region 初始化数据
            OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
            bool IsaccessDirect = !string.IsNullOrWhiteSpace(azItem.Criteria.AccessFetch);
            #endregion

            try
            {
                using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
                {
                    #region 数据访问
                    #region 查询SQL语句

                    azStrBuilder.Append("SELECT TOP (1) ");
                    azStrBuilder.Append("[a0].[OrderID],[a0].[CustomerID],[a0].[EmployeeID],[a0].[OrderDate],[a0].[RequiredDate],[a0].[ShippedDate]");
                    azStrBuilder.Append(",[a0].[ShipVia],[a0].[Freight],[a0].[ShipName],[a0].[ShipAddress],[a0].[ShipCity]");
                    azStrBuilder.Append(",[a0].[ShipRegion],[a0].[ShipPostalCode],[a0].[ShipCountry]");

                    azStrBuilder.Append(" FROM  Orders [a0] ");
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
                                azItem.OrderID = (int)azDataReader["OrderID"];//OrderID_simpCN
                                azItem.CustomerID = azDataReader["CustomerID"] is DBNull ? null : (string)azDataReader["CustomerID"];//CustomerID_simpCN
                                azItem.EmployeeID = azDataReader["EmployeeID"] is DBNull ? null : (int?)azDataReader["EmployeeID"];//EmployeeID_simpCN
                                azItem.OrderDate = azDataReader["OrderDate"] is DBNull ? null : (DateTime?)azDataReader["OrderDate"];//OrderDate_simpCN
                                azItem.RequiredDate = azDataReader["RequiredDate"] is DBNull ? null : (DateTime?)azDataReader["RequiredDate"];//RequiredDate_simpCN
                                azItem.ShippedDate = azDataReader["ShippedDate"] is DBNull ? null : (DateTime?)azDataReader["ShippedDate"];//ShippedDate_simpCN
                                azItem.ShipVia = azDataReader["ShipVia"] is DBNull ? null : (int?)azDataReader["ShipVia"];//ShipVia_simpCN
                                azItem.Freight = azDataReader["Freight"] is DBNull ? null : (decimal?)azDataReader["Freight"];//Freight_simpCN
                                azItem.ShipName = azDataReader["ShipName"] is DBNull ? null : (string)azDataReader["ShipName"];//ShipName_simpCN
                                azItem.ShipAddress = azDataReader["ShipAddress"] is DBNull ? null : (string)azDataReader["ShipAddress"];//ShipAddress_simpCN
                                azItem.ShipCity = azDataReader["ShipCity"] is DBNull ? null : (string)azDataReader["ShipCity"];//ShipCity_simpCN
                                azItem.ShipRegion = azDataReader["ShipRegion"] is DBNull ? null : (string)azDataReader["ShipRegion"];//ShipRegion_simpCN
                                azItem.ShipPostalCode = azDataReader["ShipPostalCode"] is DBNull ? null : (string)azDataReader["ShipPostalCode"];//ShipPostalCode_simpCN
                                azItem.ShipCountry = azDataReader["ShipCountry"] is DBNull ? null : (string)azDataReader["ShipCountry"];//ShipCountry_simpCN
                                #endregion

                                state.AffectedRows = 1;
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
        public void DB_FetchList(AzOrdersListEntity azItems)
        {
            #region 初始化数据
            OperateState state = new OperateState();
            StringBuilder azStrBuilder = new StringBuilder();
            StringBuilder aisbcount = new StringBuilder();
            int RCount = 0; //记录总数
            int aiPage = -1; int aiRows = -1;
            aiPage = azItems.Criteria.CurrentPage;
            aiRows = azItems.Criteria.QueryRows;
            bool IsaccessDirect = !string.IsNullOrWhiteSpace(azItems.Criteria.AccessFetchList);
            #endregion

            #region 数据访问
            using (SqlConnection cn = new SqlConnection(azItems.Context.DbConnectionString))
            {
                #region 数据记录总数查询
                aisbcount.Append(" SELECT COUNT(*) AS AiCount");
                aisbcount.Append(" FROM dbo.Orders a0");
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
                        {
                            RCount = (int)azDataReader["AiCount"];
                        }
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
                        aiorder = " order by [OrderID]";
                    }
                    azStrBuilder.Append(" SELECT  Top(" + aiRows.ToString() + ") ");
                    azStrBuilder.Append("[OrderID],[CustomerID],[EmployeeID],[OrderDate],[RequiredDate],[ShippedDate]");
                    azStrBuilder.Append(",[ShipVia],[Freight],[ShipName],[ShipAddress],[ShipCity]");
                    azStrBuilder.Append(",[ShipRegion],[ShipPostalCode],[ShipCountry]");

                    azStrBuilder.Append("  From (SELECT     ");
                    azStrBuilder.Append("[a0].[OrderID],[a0].[CustomerID],[a0].[EmployeeID],[a0].[OrderDate],[a0].[RequiredDate],[a0].[ShippedDate]");
                    azStrBuilder.Append(",[a0].[ShipVia],[a0].[Freight],[a0].[ShipName],[a0].[ShipAddress],[a0].[ShipCity]");
                    azStrBuilder.Append(",[a0].[ShipRegion],[a0].[ShipPostalCode],[a0].[ShipCountry]");

                    azStrBuilder.Append(" ,row_number() OVER (" + aiorder + ") AS [row_number]");
                    azStrBuilder.Append(" FROM  Orders As [a0]");
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
                    azStrBuilder.Append("[a0].[OrderID],[a0].[CustomerID],[a0].[EmployeeID],[a0].[OrderDate],[a0].[RequiredDate],[a0].[ShippedDate]");
                    azStrBuilder.Append(",[a0].[ShipVia],[a0].[Freight],[a0].[ShipName],[a0].[ShipAddress],[a0].[ShipCity]");
                    azStrBuilder.Append(",[a0].[ShipRegion],[a0].[ShipPostalCode],[a0].[ShipCountry]");

                    azStrBuilder.Append(" FROM  Orders As [a0] ");
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
                            var vItem = _lc.Resolve<AzOrdersEntity>();
                            #region  类赋值
                            vItem.OrderID = (int)azDataReader["OrderID"];//OrderID_simpCN
                            vItem.CustomerID = azDataReader["CustomerID"] is DBNull ? null : (string)azDataReader["CustomerID"];//CustomerID_simpCN
                            vItem.EmployeeID = azDataReader["EmployeeID"] is DBNull ? null : (int?)azDataReader["EmployeeID"];//EmployeeID_simpCN
                            vItem.OrderDate = azDataReader["OrderDate"] is DBNull ? null : (DateTime?)azDataReader["OrderDate"];//OrderDate_simpCN
                            vItem.RequiredDate = azDataReader["RequiredDate"] is DBNull ? null : (DateTime?)azDataReader["RequiredDate"];//RequiredDate_simpCN
                            vItem.ShippedDate = azDataReader["ShippedDate"] is DBNull ? null : (DateTime?)azDataReader["ShippedDate"];//ShippedDate_simpCN
                            vItem.ShipVia = azDataReader["ShipVia"] is DBNull ? null : (int?)azDataReader["ShipVia"];//ShipVia_simpCN
                            vItem.Freight = azDataReader["Freight"] is DBNull ? null : (decimal?)azDataReader["Freight"];//Freight_simpCN
                            vItem.ShipName = azDataReader["ShipName"] is DBNull ? null : (string)azDataReader["ShipName"];//ShipName_simpCN
                            vItem.ShipAddress = azDataReader["ShipAddress"] is DBNull ? null : (string)azDataReader["ShipAddress"];//ShipAddress_simpCN
                            vItem.ShipCity = azDataReader["ShipCity"] is DBNull ? null : (string)azDataReader["ShipCity"];//ShipCity_simpCN
                            vItem.ShipRegion = azDataReader["ShipRegion"] is DBNull ? null : (string)azDataReader["ShipRegion"];//ShipRegion_simpCN
                            vItem.ShipPostalCode = azDataReader["ShipPostalCode"] is DBNull ? null : (string)azDataReader["ShipPostalCode"];//ShipPostalCode_simpCN
                            vItem.ShipCountry = azDataReader["ShipCountry"] is DBNull ? null : (string)azDataReader["ShipCountry"];//ShipCountry_simpCN
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