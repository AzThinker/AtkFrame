using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using System;

// AzCustOrderHist有返回结果存储过程业务类
namespace DemoTools.BLL.DemoNorthwind
{
    /// <summary>
    /// AzCustOrderHist 业务类
    /// </summary>
   [Serializable]
   public sealed  class AzCustOrderHistEntity :BusinessBase
   {
        #region  业务属性定义

        	/// <summary>
	///ProductName
	/// </summary>
	public string ProductName { get;set;}
	/// <summary>
	///Total
	/// </summary>
	public int? Total { get;set;}
 

        #endregion
    }
}