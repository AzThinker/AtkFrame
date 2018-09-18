using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.DataPortal.UiServer;
using Autofac;
using System;
using System.ComponentModel.DataAnnotations;
using DemoTools.BLL.DemoNorthwind;

// 订单 UI的Dto类
namespace DemoTools.UIServer.DemoNorthwind
{
    /// <summary>
    /// 订单   UI的Dto类
    /// </summary>
    public  class  AzOrdersWebDto:BaseUIDto<AzOrdersWebDto,AzOrdersEntity>, IComparable<AzOrdersWebDto>
    {
        #region  属性定义
        /// <summary>
        /// 中文名称
        /// </summary>
        [ScaffoldColumn(false)]
        public static string DisplayDescription { get; set; }
	
        	/// <summary>
	///OrderID_simpCN
	/// </summary>
	[Display(Name ="OrderID_simpCN")]
	public int OrderID { get;set;}
	/// <summary>
	///CustomerID_simpCN
	/// </summary>
	[Display(Name ="CustomerID_simpCN")]
	public string CustomerID { get;set;}
	/// <summary>
	///EmployeeID_simpCN
	/// </summary>
	[Display(Name ="EmployeeID_simpCN")]
	public int? EmployeeID { get;set;}
	/// <summary>
	///OrderDate_simpCN
	/// </summary>
	[Display(Name ="OrderDate_simpCN")]
	public DateTime? OrderDate { get;set;}
	/// <summary>
	///RequiredDate_simpCN
	/// </summary>
	[Display(Name ="RequiredDate_simpCN")]
	public DateTime? RequiredDate { get;set;}
	/// <summary>
	///ShippedDate_simpCN
	/// </summary>
	[Display(Name ="ShippedDate_simpCN")]
	public DateTime? ShippedDate { get;set;}
	/// <summary>
	///ShipVia_simpCN
	/// </summary>
	[Display(Name ="ShipVia_simpCN")]
	public int? ShipVia { get;set;}
	/// <summary>
	///Freight_simpCN
	/// </summary>
	[Display(Name ="Freight_simpCN")]
	public decimal? Freight { get;set;}
	/// <summary>
	///ShipName_simpCN
	/// </summary>
	[Display(Name ="ShipName_simpCN")]
	public string ShipName { get;set;}
	/// <summary>
	///ShipAddress_simpCN
	/// </summary>
	[Display(Name ="ShipAddress_simpCN")]
	public string ShipAddress { get;set;}
	/// <summary>
	///ShipCity_simpCN
	/// </summary>
	[Display(Name ="ShipCity_simpCN")]
	public string ShipCity { get;set;}
	/// <summary>
	///ShipRegion_simpCN
	/// </summary>
	[Display(Name ="ShipRegion_simpCN")]
	public string ShipRegion { get;set;}
	/// <summary>
	///ShipPostalCode_simpCN
	/// </summary>
	[Display(Name ="ShipPostalCode_simpCN")]
	public string ShipPostalCode { get;set;}
	/// <summary>
	///ShipCountry_simpCN
	/// </summary>
	[Display(Name ="ShipCountry_simpCN")]
	public string ShipCountry { get;set;}
 

        #endregion

        #region 构造方法

        /// <summary>
        /// 订单 构造方法
        /// </summary>
        public  AzOrdersWebDto(ILifetimeScope lc): base()
        {
            _lc = lc;
            Power = new Power();
            Op = RecordOperater.Updata;
            DisplayDescription = "订单"; 
	    
        }

	/// <summary>
        /// 订单 构造方法
        /// </summary>
        public  AzOrdersWebDto(): base()
        {
            Power = new Power();
            Op = RecordOperater.Updata;
            DisplayDescription = "订单"; 
	    
        }
	#endregion

	#region  属性拷贝
	
	/// <summary>
        /// 由BLL类型转换成UI的Dto类型
        /// </summary>
        /// <param name="item">BLL类型</param>
	public override AzOrdersWebDto CopyToOut(AzOrdersEntity item)
        {
            		#region  类赋值
		this.OrderID = item.OrderID;//OrderID_simpCN
		this.CustomerID = item.CustomerID;//CustomerID_simpCN
		this.EmployeeID = item.EmployeeID;//EmployeeID_simpCN
		this.OrderDate = item.OrderDate;//OrderDate_simpCN
		this.RequiredDate = item.RequiredDate;//RequiredDate_simpCN
		this.ShippedDate = item.ShippedDate;//ShippedDate_simpCN
		this.ShipVia = item.ShipVia;//ShipVia_simpCN
		this.Freight = item.Freight;//Freight_simpCN
		this.ShipName = item.ShipName;//ShipName_simpCN
		this.ShipAddress = item.ShipAddress;//ShipAddress_simpCN
		this.ShipCity = item.ShipCity;//ShipCity_simpCN
		this.ShipRegion = item.ShipRegion;//ShipRegion_simpCN
		this.ShipPostalCode = item.ShipPostalCode;//ShipPostalCode_simpCN
		this.ShipCountry = item.ShipCountry;//ShipCountry_simpCN
		#endregion

	    this.SetAccessAddress(item.AccessAddress);
            this.SetAccessPath(item.AccessPath);
            return this;
        }

	/// <summary>
        /// 由Dto类型转换成BLL类型进行保存操作
        /// </summary>
        /// <param name="item">UI的Dto类型</param>
	public override AzOrdersEntity CopyToIn()
        {
		var data =_lc.Resolve<AzOrdersEntity>();
				#region  类赋值
		data.OrderID = this.OrderID;//OrderID_simpCN
		data.CustomerID = this.CustomerID;//CustomerID_simpCN
		data.EmployeeID = this.EmployeeID;//EmployeeID_simpCN
		data.OrderDate = this.OrderDate;//OrderDate_simpCN
		data.RequiredDate = this.RequiredDate;//RequiredDate_simpCN
		data.ShippedDate = this.ShippedDate;//ShippedDate_simpCN
		data.ShipVia = this.ShipVia;//ShipVia_simpCN
		data.Freight = this.Freight;//Freight_simpCN
		data.ShipName = this.ShipName;//ShipName_simpCN
		data.ShipAddress = this.ShipAddress;//ShipAddress_simpCN
		data.ShipCity = this.ShipCity;//ShipCity_simpCN
		data.ShipRegion = this.ShipRegion;//ShipRegion_simpCN
		data.ShipPostalCode = this.ShipPostalCode;//ShipPostalCode_simpCN
		data.ShipCountry = this.ShipCountry;//ShipCountry_simpCN
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
		OrderID = this.OrderID,//OrderID_simpCN
		CustomerID = this.CustomerID,//CustomerID_simpCN
		EmployeeID = this.EmployeeID,//EmployeeID_simpCN
		OrderDate = this.OrderDate,//OrderDate_simpCN
		RequiredDate = this.RequiredDate,//RequiredDate_simpCN
		ShippedDate = this.ShippedDate,//ShippedDate_simpCN
		ShipVia = this.ShipVia,//ShipVia_simpCN
		Freight = this.Freight,//Freight_simpCN
		ShipName = this.ShipName,//ShipName_simpCN
		ShipAddress = this.ShipAddress,//ShipAddress_simpCN
		ShipCity = this.ShipCity,//ShipCity_simpCN
		ShipRegion = this.ShipRegion,//ShipRegion_simpCN
		ShipPostalCode = this.ShipPostalCode,//ShipPostalCode_simpCN
		ShipCountry = this.ShipCountry,//ShipCountry_simpCN
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
        public override int CompareTo(AzOrdersWebDto other)
        {
            if (other == null) return 1;
            if (this.OrderID==other.OrderID)
                return 0;
            else return 1;

        }
       	#endregion
    }


  }
