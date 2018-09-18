using Atk.DataPortal;
using Atk.DataPortal.Core;
using Autofac;
using DemoTools.BLL.DemoNorthwind;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Module = Autofac.Module;

// <summary>
// SQL Server 2008 数据访问层
// 不支持SQL Server 2000
// </summary>
namespace DemoTools.DB.DemoNorthwind
{

    /// <summary>
    /// 此处实现 Autofac Module用于《AzCustOrdersDetail》相关类注册用,
    /// 此处只注册业务类。
    /// 由于WCF的存在,业务层,数据访问层可能和IIS布署不在同一台服务器上
    /// 因而其他层的类,不应在此出现。
    /// </summary>
    public class AzCustOrdersDetail_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzCustOrdersDetailEntity>();
            moduleBuilder.RegisterType<AzCustOrdersDetail_DB>().As<IAzCustOrdersDetailDal>();
        }
    }

    /// <summary>
    /// 此处实现 AzCustOrdersDetail 执行操作 IAzCustOrdersDetailDal 接口
    /// </summary>
    public class AzCustOrdersDetail_DB : IAzCustOrdersDetailDal
    {

        /// <summary>
        /// 执行操作 AzCustOrdersDetail
        /// </summary>
        /// <param name="azItem">业务类</param>
        /// <param name="context">上下文</param>
        public void DB_Execute(AzCustOrdersDetailEntity azItem)
        {
            OperateState state = new OperateState();
            using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("CustOrdersDetail", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    #region 数据参数

                    SqlParameter param_OrderID = new SqlParameter();
                    param_OrderID.ParameterName = "@OrderID";
                    if (azItem.P_OrderID == null)
                    { param_OrderID.Value = System.DBNull.Value; }
                    else
                    { param_OrderID.Value = azItem.P_OrderID; };
                    param_OrderID.Direction = ParameterDirection.Input;
                    param_OrderID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(param_OrderID);




                    #endregion

                    try
                    {
                        state.AffectedRows = cmd.ExecuteNonQuery();

                    }
                    catch
                    {
                        state.Error.Add("执行操作", "没有正确执行!");
                    }
                    azItem.State = state;
                }
            }
        }
    }

}



