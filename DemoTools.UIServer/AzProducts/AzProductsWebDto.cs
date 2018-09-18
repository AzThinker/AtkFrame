using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.DataPortal.UiServer;
using Autofac;
using System;
using System.ComponentModel.DataAnnotations;
using DemoTools.BLL.DemoNorthwind;

// 产品 UI的Dto类
namespace DemoTools.UIServer.DemoNorthwind
{
    /// <summary>
    /// 产品   UI的Dto类
    /// </summary>
    public  class  AzProductsWebDto:BaseUIDto<AzProductsWebDto,AzProductsEntity>, IComparable<AzProductsWebDto>
    {
        #region  属性定义
        /// <summary>
        /// 中文名称
        /// </summary>
        [ScaffoldColumn(false)]
        public static string DisplayDescription { get; set; }
	
        	/// <summary>
	///ProductID_simpCN
	/// </summary>
	[Display(Name ="ProductID_simpCN")]
	public int ProductID { get;set;}
	/// <summary>
	///ProductName_simpCN
	/// </summary>
	[Display(Name ="ProductName_simpCN")]
	public string ProductName { get;set;}
	/// <summary>
	///SupplierID_simpCN
	/// </summary>
	[Display(Name ="SupplierID_simpCN")]
	public int? SupplierID { get;set;}
	/// <summary>
	///CategoryID_simpCN
	/// </summary>
	[Display(Name ="CategoryID_simpCN")]
	public int? CategoryID { get;set;}
	/// <summary>
	///QuantityPerUnit_simpCN
	/// </summary>
	[Display(Name ="QuantityPerUnit_simpCN")]
	public string QuantityPerUnit { get;set;}
	/// <summary>
	///UnitPrice_simpCN
	/// </summary>
	[Display(Name ="UnitPrice_simpCN")]
	public decimal? UnitPrice { get;set;}
	/// <summary>
	///UnitsInStock_simpCN
	/// </summary>
	[Display(Name ="UnitsInStock_simpCN")]
	public short? UnitsInStock { get;set;}
	/// <summary>
	///UnitsOnOrder_simpCN
	/// </summary>
	[Display(Name ="UnitsOnOrder_simpCN")]
	public short? UnitsOnOrder { get;set;}
	/// <summary>
	///ReorderLevel_simpCN
	/// </summary>
	[Display(Name ="ReorderLevel_simpCN")]
	public short? ReorderLevel { get;set;}
	/// <summary>
	///Discontinued_simpCN
	/// </summary>
	[Display(Name ="Discontinued_simpCN")]
	public bool Discontinued { get;set;}
 

        #endregion

        #region 构造方法

        /// <summary>
        /// 产品 构造方法
        /// </summary>
        public  AzProductsWebDto(ILifetimeScope lc): base()
        {
            _lc = lc;
            Power = new Power();
            Op = RecordOperater.Updata;
            DisplayDescription = "产品"; 
	    
        }

	/// <summary>
        /// 产品 构造方法
        /// </summary>
        public  AzProductsWebDto(): base()
        {
            Power = new Power();
            Op = RecordOperater.Updata;
            DisplayDescription = "产品"; 
	    
        }
	#endregion

	#region  属性拷贝
	
	/// <summary>
        /// 由BLL类型转换成UI的Dto类型
        /// </summary>
        /// <param name="item">BLL类型</param>
	public override AzProductsWebDto CopyToOut(AzProductsEntity item)
        {
            		#region  类赋值
		this.ProductID = item.ProductID;//ProductID_simpCN
		this.ProductName = item.ProductName;//ProductName_simpCN
		this.SupplierID = item.SupplierID;//SupplierID_simpCN
		this.CategoryID = item.CategoryID;//CategoryID_simpCN
		this.QuantityPerUnit = item.QuantityPerUnit;//QuantityPerUnit_simpCN
		this.UnitPrice = item.UnitPrice;//UnitPrice_simpCN
		this.UnitsInStock = item.UnitsInStock;//UnitsInStock_simpCN
		this.UnitsOnOrder = item.UnitsOnOrder;//UnitsOnOrder_simpCN
		this.ReorderLevel = item.ReorderLevel;//ReorderLevel_simpCN
		this.Discontinued = item.Discontinued;//Discontinued_simpCN
		#endregion

	    this.SetAccessAddress(item.AccessAddress);
            this.SetAccessPath(item.AccessPath);
            return this;
        }

	/// <summary>
        /// 由Dto类型转换成BLL类型进行保存操作
        /// </summary>
        /// <param name="item">UI的Dto类型</param>
	public override AzProductsEntity CopyToIn()
        {
		var data =_lc.Resolve<AzProductsEntity>();
				#region  类赋值
		data.ProductID = this.ProductID;//ProductID_simpCN
		data.ProductName = this.ProductName;//ProductName_simpCN
		data.SupplierID = this.SupplierID;//SupplierID_simpCN
		data.CategoryID = this.CategoryID;//CategoryID_simpCN
		data.QuantityPerUnit = this.QuantityPerUnit;//QuantityPerUnit_simpCN
		data.UnitPrice = this.UnitPrice;//UnitPrice_simpCN
		data.UnitsInStock = this.UnitsInStock;//UnitsInStock_simpCN
		data.UnitsOnOrder = this.UnitsOnOrder;//UnitsOnOrder_simpCN
		data.ReorderLevel = this.ReorderLevel;//ReorderLevel_simpCN
		data.Discontinued = this.Discontinued;//Discontinued_simpCN
		#endregion

		return data;
        }

        /// <summary>
        /// josn对象拷贝
        /// </summary>
        /// <returns></returns>
        public override object JsonCopy()
        {
            return new
            {
                		#region  类赋值
		ProductID = this.ProductID,//ProductID_simpCN
		ProductName = this.ProductName,//ProductName_simpCN
		SupplierID = this.SupplierID,//SupplierID_simpCN
		CategoryID = this.CategoryID,//CategoryID_simpCN
		QuantityPerUnit = this.QuantityPerUnit,//QuantityPerUnit_simpCN
		UnitPrice = this.UnitPrice,//UnitPrice_simpCN
		UnitsInStock = this.UnitsInStock,//UnitsInStock_simpCN
		UnitsOnOrder = this.UnitsOnOrder,//UnitsOnOrder_simpCN
		ReorderLevel = this.ReorderLevel,//ReorderLevel_simpCN
		Discontinued = this.Discontinued,//Discontinued_simpCN
		#endregion

                #region  类权限赋值
                AtkCheck = this.Power.Check,
                AtkCreate = this.Power.Create,
                AtkDelete = this.Power.Delete,
                AtkEdit = this.Power.Edit,
                AtkExport = this.Power.Export,
                AtkExportIn = this.Power.ExportIn,
                AtkGet = this.Power.Get,
                AtkReport = this.Power.Report
                #endregion
            };
        }

        /// <summary>
        /// 记录相同比较，用于批更新时，重复项目检查
        /// </summary>
        /// <param name="other">另一记录</param>
        /// <returns>相同返回为 0</returns>
        public override int CompareTo(AzProductsWebDto other)
        {
            if (other == null) return 1;
            if (this.ProductID==other.ProductID)
                return 0;
            else return 1;

        }
       	#endregion
    }


  }
