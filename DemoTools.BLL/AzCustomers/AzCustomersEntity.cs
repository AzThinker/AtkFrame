using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using System;

// 客户 业务类
namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// 客户 业务类
    /// </summary>
   [Serializable]
   public sealed class AzCustomersEntity:BusinessEditBase , IBusinessInsert, IBusinessUpdate, IBusinessDelete, IBusinessFetch
   {
     
        #region  业务属性定义

        	/// <summary>
	///CustomerID_simpCN
	/// </summary>
	public string CustomerID { get;set;}
	/// <summary>
	///CompanyName_simpCN
	/// </summary>
	public string CompanyName { get;set;}
	/// <summary>
	///ContactName_simpCN
	/// </summary>
	public string ContactName { get;set;}
	/// <summary>
	///ContactTitle_simpCN
	/// </summary>
	public string ContactTitle { get;set;}
	/// <summary>
	///Address_simpCN
	/// </summary>
	public string Address { get;set;}
	/// <summary>
	///City_simpCN
	/// </summary>
	public string City { get;set;}
	/// <summary>
	///Region_simpCN
	/// </summary>
	public string Region { get;set;}
	/// <summary>
	///PostalCode_simpCN
	/// </summary>
	public string PostalCode { get;set;}
	/// <summary>
	///Country_simpCN
	/// </summary>
	public string Country { get;set;}
	/// <summary>
	///Phone_simpCN
	/// </summary>
	public string Phone { get;set;}
	/// <summary>
	///Fax_simpCN
	/// </summary>
	public string Fax { get;set;}
 

        #endregion
       
	#region 构造部分 
 
	/// <summary>
	/// 数据操作接口
	/// </summary>
        [NonSerialized]
        private IAzCustomersDal _dbaccess;

        public AzCustomersEntity(IAzCustomersDal dbaccess)
        {
           _dbaccess = dbaccess;
        }

        /// <summary>
        /// 当由WCF访问时,不会调用构造方法,因此需重建数据层访问
        /// </summary>
        /// <param name="workContext">Autoface容器上下文</param>
        /// <returns>数据操作接口</returns>
        private IAzCustomersDal CheckworkContext()
        {
            if (_dbaccess == null)
            {
                _dbaccess = this.WorkContext.Resolve<IAzCustomersDal>();
            }
            return _dbaccess;
        }
        #endregion

        #region  实现数据操作

			
	/// <summary>
        /// 新增 客户 
        /// </summary>
        public void DataPortal_Insert()
        {
	     CheckworkContext().DB_Insert(this);
        }
	        /// <summary>
        /// 更新 客户 
        /// </summary>
        public void DataPortal_Update()
        {
            CheckworkContext().DB_Update(this);
        }



		/// <summary>
        /// 删除 客户 
        /// </summary>
       public void DataPortal_Delete()
        {
             CheckworkContext().DB_Delete(this);
        }

	
	/// <summary>
        /// 查询 客户 
        /// </summary>
	public void DataPortal_Fetch()
        {
            CheckworkContext().DB_Fetch(this);
        }


        #endregion
 }
}