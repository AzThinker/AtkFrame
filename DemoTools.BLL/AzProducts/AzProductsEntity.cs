using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using System;

// 产品 业务类
namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 产品 业务类
    /// </summary>
   [Serializable]
   public sealed class AzProductsEntity:BusinessEditBase , IBusinessInsert, IBusinessUpdate, IBusinessDelete, IBusinessFetch
   {
     
        #region  业务属性定义

        	/// <summary>
	///ProductID_simpCN
	/// </summary>
	public int ProductID { get;set;}
	/// <summary>
	///ProductName_simpCN
	/// </summary>
	public string ProductName { get;set;}
	/// <summary>
	///SupplierID_simpCN
	/// </summary>
	public int? SupplierID { get;set;}
	/// <summary>
	///CategoryID_simpCN
	/// </summary>
	public int? CategoryID { get;set;}
	/// <summary>
	///QuantityPerUnit_simpCN
	/// </summary>
	public string QuantityPerUnit { get;set;}
	/// <summary>
	///UnitPrice_simpCN
	/// </summary>
	public decimal? UnitPrice { get;set;}
	/// <summary>
	///UnitsInStock_simpCN
	/// </summary>
	public short? UnitsInStock { get;set;}
	/// <summary>
	///UnitsOnOrder_simpCN
	/// </summary>
	public short? UnitsOnOrder { get;set;}
	/// <summary>
	///ReorderLevel_simpCN
	/// </summary>
	public short? ReorderLevel { get;set;}
	/// <summary>
	///Discontinued_simpCN
	/// </summary>
	public bool Discontinued { get;set;}
 

        #endregion
       
	#region 构造部分 
 
	/// <summary>
	/// 数据操作接口
	/// </summary>
        [NonSerialized]
        private IAzProductsDal _dbaccess;

        public AzProductsEntity(IAzProductsDal dbaccess)
        {
           _dbaccess = dbaccess;
        }

        /// <summary>
        /// 当由WCF访问时,不会调用构造方法,因此需重建数据层访问
        /// </summary>
        /// <param name="workContext">Autoface容器上下文</param>
        /// <returns>数据操作接口</returns>
        private IAzProductsDal CheckworkContext()
        {
            if (_dbaccess == null)
            {
                _dbaccess = this.WorkContext.Resolve<IAzProductsDal>();
            }
            return _dbaccess;
        }
        #endregion

        #region  实现数据操作

			
	/// <summary>
        /// 新增 产品 
        /// </summary>
        public void DataPortal_Insert()
        {
	     CheckworkContext().DB_Insert(this);
        }
	        /// <summary>
        /// 更新 产品 
        /// </summary>
        public void DataPortal_Update()
        {
            CheckworkContext().DB_Update(this);
        }



		/// <summary>
        /// 删除 产品 
        /// </summary>
       public void DataPortal_Delete()
        {
             CheckworkContext().DB_Delete(this);
        }

	
	/// <summary>
        /// 查询 产品 
        /// </summary>
	public void DataPortal_Fetch()
        {
            CheckworkContext().DB_Fetch(this);
        }


        #endregion
 }
}