using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.DataPortal.UiServer;
using Atk.WebCore.Infrastructure;
using Autofac;
using System;
using System.ComponentModel.DataAnnotations;
using Webdiyer.WebControls.AspNetCore;
using DemoTools.BLL.DemoNorthwind;


// 客户  WEB UI列表类
namespace  DemoTools.UIServer.DemoNorthwind
{
    /// <summary>
    /// 客户  WEB UI列表类
    /// </summary>
    public sealed class AzCustomersListWebDto :BaseListUIDto<AzCustomersWebDto,AzCustomersEntity>, IPagedList
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

	#region 构造方法
        /// <summary>
        ///《客户》 构造方法
        /// </summary>
        public AzCustomersListWebDto(ILifetimeScope lc): base()
        {
	   _lc = lc;
           DisplayDescription = "客户";
	   Power = new Power();
        }
	#endregion
    }
}