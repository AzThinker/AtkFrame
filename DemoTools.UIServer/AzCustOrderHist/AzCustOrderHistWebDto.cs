using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.UiServer;
using System;
using System.ComponentModel.DataAnnotations;
using DemoTools.BLL.DemoNorthwind;

// AzCustOrderHist UI的Dto类
namespace DemoTools.UIServer.DemoNorthwind
{
    /// <summary>
    /// AzCustOrderHist   UI的Dto类
    /// </summary>
    public sealed class  AzCustOrderHistWebDto:BaseUISpDto<AzCustOrderHistWebDto,AzCustOrderHistEntity>
    {
        #region  属性定义
        /// <summary>
        /// 中文名称
        /// </summary>
        [ScaffoldColumn(false)]
        public static string DisplayDescription { get; set; }
	
        	/// <summary>
	///ProductName
	/// </summary>
	[Display(Name ="ProductName")]
	public string ProductName { get;set;}
	/// <summary>
	///Total
	/// </summary>
	[Display(Name ="Total")]
	public int? Total { get;set;}
 

        #endregion

	#region   操作执行属性定义(为存储过程中参数组成)

			/// <summary>
		/// @CustomerID_simpCN
		///</summary>
		public string P_CustomerID { get; set;}



	#endregion

        #region 构造方法

        /// <summary>
        /// AzCustOrderHist 构造方法
        /// </summary>
        public  AzCustOrderHistWebDto(ILifetimeScope lc): base()
        {
            _lc = lc;
            Power = new Power();
            DisplayDescription = "AzCustOrderHist"; 
	    		//字段属性无默认初始化
        }
	#endregion

	#region  属性拷贝
	
	/// <summary>
        /// 由BLL类型转换成UI的Dto类型
        /// </summary>
        /// <param name="item">BLL类型</param>
	public override AzCustOrderHistWebDto CopyToOut(AzCustOrderHistEntity item)
        {
            		#region  类赋值
		this.ProductName = item.ProductName;//ProductName
		this.Total = item.Total;//Total
		#endregion

            return this;
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
		ProductName = this.ProductName,//ProductName
		Total = this.Total,//Total
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

       	#endregion
    }


  }
