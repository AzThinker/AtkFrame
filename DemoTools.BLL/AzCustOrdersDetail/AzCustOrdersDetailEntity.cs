using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using System;

// AzCustOrdersDetail 操作执行类
namespace DemoTools.BLL.DemoNorthwind
{
   /// <summary>
   /// AzCustOrdersDetail  执行类存储过程列表类
   /// 此类中以 P_ 开头的均是存储过程传入参数
   /// 类型本是参数容器及数据容器功能
   /// </summary>
    [Serializable]
    public sealed class AzCustOrdersDetailEntity:BusinessBase, IBusinessExecute
    {
	#region   操作执行属性定义(为存储过程中参数组成)

			/// <summary>
		/// @OrderID_simpCN
		///</summary>
		public int? P_OrderID { get; set;}



	#endregion

	#region  构造部分 
	
	/// <summary>
	/// 数据操作接口
	/// </summary>
        [NonSerialized]
        private IAzCustOrdersDetailDal _dbaccess;

        public AzCustOrdersDetailEntity(IAzCustOrdersDetailDal dbaccess)
        {
            _dbaccess = dbaccess;
        }

        /// <summary>
        /// 当由WCF访问时,不会调用构造方法,因此需重建数据层访问
        /// </summary>
        /// <param name="workContext">Autoface容器上下文</param>
        /// <returns>数据操作接口</returns>
        private IAzCustOrdersDetailDal CheckworkContext()
        {
            if (_dbaccess == null)
            {
                _dbaccess = this.WorkContext.Resolve<IAzCustOrdersDetailDal>();
            }
            return _dbaccess;
        }
        #endregion

	#region  执行方法实现

	/// <summary>
        ///   AzCustOrdersDetail  操作执行
        /// </summary>
       public void DataPortal_Execute()
        {
             CheckworkContext().DB_Execute(this);
        }

	#endregion

    }


 }