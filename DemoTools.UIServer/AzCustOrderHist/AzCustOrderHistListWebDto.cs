using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.UiServer;
using System.ComponentModel.DataAnnotations;
using Webdiyer.WebControls.AspNetCore;
using DemoTools.BLL.DemoNorthwind;

// AzCustOrderHist  WEB UI列表类
namespace  DemoTools.UIServer.DemoNorthwind
{
    /// <summary>
    /// AzCustOrderHist  WEB UI列表类
    /// </summary>
    public sealed class AzCustOrderHistListWebDto :BaseListUISpDto<AzCustOrderHistWebDto,AzCustOrderHistListWebDto,AzCustOrderHistEntity,AzCustOrderHistListEntity>, IPagedList
    {
        #region 属性定义
	/// <summary>
        /// 显示名称
        /// </summary>
        [ScaffoldColumn(false)]
        public static string DisplayDescription { get; set; }
        public int CurrentPageIndex { get; set; }
        private int pageSize;
        public int TotalItemCount
        {
            get { return this.TotalCount; }
            set { this.TotalCount = value; }
        }

        public int PageSize { get => pageSize; set => pageSize = value; }

	#endregion

	#region   操作执行属性定义(为存储过程中参数组成)

			/// <summary>
		/// @CustomerID_simpCN
		///</summary>
		public string P_CustomerID { get; set;}



	#endregion

	#region 构造方法
        /// <summary>
        ///《AzCustOrderHist》 构造方法
        /// </summary>
        public AzCustOrderHistListWebDto(ILifetimeScope lc): base()
        {
	   _lc = lc;
           DisplayDescription = "AzCustOrderHist";
	   Power = new Power();
        }
	#endregion

		/// <summary>
        /// 由Dto类型转换成BLL类型进行保存操作
        /// </summary>
        /// <param name="item">UI的Dto类型</param>
	public override AzCustOrderHistListEntity CopyToIn()
        {
		var data =_lc.Resolve<AzCustOrderHistListEntity>();
				#region  类赋值
		data.P_CustomerID = this.P_CustomerID;//@CustomerID_simpCN
		#endregion

		return data;
        }
    }
}