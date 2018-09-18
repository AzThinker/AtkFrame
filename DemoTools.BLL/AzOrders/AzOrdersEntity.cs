using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using System;

// 订单 业务类
namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 订单 业务类
    /// </summary>
   [Serializable]
   public sealed class AzOrdersEntity:BusinessEditBase , IBusinessInsert, IBusinessUpdate, IBusinessDelete, IBusinessFetch
   {
     
        #region  业务属性定义

        	/// <summary>
	///OrderID_simpCN
	/// </summary>
	public int OrderID { get;set;}
	/// <summary>
	///CustomerID_simpCN
	/// </summary>
	public string CustomerID { get;set;}
	/// <summary>
	///EmployeeID_simpCN
	/// </summary>
	public int? EmployeeID { get;set;}
	/// <summary>
	///OrderDate_simpCN
	/// </summary>
	public DateTime? OrderDate { get;set;}
	/// <summary>
	///RequiredDate_simpCN
	/// </summary>
	public DateTime? RequiredDate { get;set;}
	/// <summary>
	///ShippedDate_simpCN
	/// </summary>
	public DateTime? ShippedDate { get;set;}
	/// <summary>
	///ShipVia_simpCN
	/// </summary>
	public int? ShipVia { get;set;}
	/// <summary>
	///Freight_simpCN
	/// </summary>
	public decimal? Freight { get;set;}
	/// <summary>
	///ShipName_simpCN
	/// </summary>
	public string ShipName { get;set;}
	/// <summary>
	///ShipAddress_simpCN
	/// </summary>
	public string ShipAddress { get;set;}
	/// <summary>
	///ShipCity_simpCN
	/// </summary>
	public string ShipCity { get;set;}
	/// <summary>
	///ShipRegion_simpCN
	/// </summary>
	public string ShipRegion { get;set;}
	/// <summary>
	///ShipPostalCode_simpCN
	/// </summary>
	public string ShipPostalCode { get;set;}
	/// <summary>
	///ShipCountry_simpCN
	/// </summary>
	public string ShipCountry { get;set;}
 

        #endregion
       
	#region 构造部分 
 
	/// <summary>
	/// 数据操作接口
	/// </summary>
        [NonSerialized]
        private IAzOrdersDal _dbaccess;

        public AzOrdersEntity(IAzOrdersDal dbaccess)
        {
           _dbaccess = dbaccess;
        }

        /// <summary>
        /// 当由WCF访问时,不会调用构造方法,因此需重建数据层访问
        /// </summary>
        /// <param name="workContext">Autoface容器上下文</param>
        /// <returns>数据操作接口</returns>
        private IAzOrdersDal CheckworkContext()
        {
            if (_dbaccess == null)
            {
                _dbaccess = this.WorkContext.Resolve<IAzOrdersDal>();
            }
            return _dbaccess;
        }
        #endregion

        #region  实现数据操作

			
	/// <summary>
        /// 新增 订单 
        /// </summary>
        public void DataPortal_Insert()
        {
	     CheckworkContext().DB_Insert(this);
        }
	        /// <summary>
        /// 更新 订单 
        /// </summary>
        public void DataPortal_Update()
        {
            CheckworkContext().DB_Update(this);
        }



		/// <summary>
        /// 删除 订单 
        /// </summary>
       public void DataPortal_Delete()
        {
             CheckworkContext().DB_Delete(this);
        }

	
	/// <summary>
        /// 查询 订单 
        /// </summary>
	public void DataPortal_Fetch()
        {
            CheckworkContext().DB_Fetch(this);
        }


        #endregion
 }
}