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
    /// 此处实现 Autofac Module用于《AzCustOrderHist》相关类注册用,
    /// 此处只注册业务类。
    /// 由于WCF的存在,业务层,数据访问层可能和IIS布署不在同一台服务器上
    /// 因而其他层的类,不应在此出现。
    /// </summary>
    public class AzCustOrderHist_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzCustOrderHistEntity>();
            moduleBuilder.RegisterType<AzCustOrderHistListEntity>();
            moduleBuilder.RegisterType<AzCustOrderHist_DB>().As<IAzCustOrderHistDal>();
        }
    }

    /// <summary>
    /// 此处实现 AzCustOrderHist 存储过程数据访问  IAzCustOrderHistDal 接口
    /// </summary>
    public   class AzCustOrderHist_DB  :IAzCustOrderHistDal
    {

        private ILifetimeScope _lc;

        public AzCustOrderHist_DB(ILifetimeScope lc)
        {
            _lc = lc;

        }
    	 
        /// <summary>
        /// 数据访问
        /// </summary>
        /// <param name="azItem">调用列表类</param>
       public   void DB_SpFetch(AzCustOrderHistListEntity azItem) 
        {
	    OperateState state = new OperateState();
            try
            {
                using (SqlConnection cn = new SqlConnection(azItem.Context.DbConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("CustOrderHist", cn))
                    {
		       cmd.CommandType = CommandType.StoredProcedure;
		       #region 数据参数

                       		SqlParameter param_CustomerID = new SqlParameter();
		param_CustomerID.ParameterName ="@CustomerID";
		if (azItem.P_CustomerID==null)
		{param_CustomerID.Value =System.DBNull.Value;}
	else
		{param_CustomerID.Value =azItem.P_CustomerID;};
		param_CustomerID.Direction = ParameterDirection.Input;
		param_CustomerID.Size = 10;
		param_CustomerID.SqlDbType = SqlDbType.NChar;
		cmd.Parameters.Add(param_CustomerID);




		       #endregion
		        using (SqlDataReader azDataReader = cmd.ExecuteReader())
                         {
                            while (azDataReader.Read())
				{
				   var vItem = _lc.Resolve<AzCustOrderHistEntity>();
				   	#region  类赋值
			vItem.ProductName=(string)azDataReader["ProductName"];//ProductName
			vItem.Total=azDataReader["Total"] is DBNull ? null : (int?)azDataReader["Total"];//Total
	#endregion

				   azItem.Add(vItem);
				}
				
                         }
                      }
               
                 }
            }
            catch (Exception e)
            {
                state.Error.Add("存储过程数据库查询", e.Message);
                azItem.State = state;
               
            }
	    state.AffectedRows = azItem.Count;
            azItem.TotalCount = azItem.Count;
            azItem.State = state;
      }
   }
}