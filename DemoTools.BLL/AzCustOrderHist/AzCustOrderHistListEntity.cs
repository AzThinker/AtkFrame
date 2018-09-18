using Atk.DataPortal.Core;
using Autofac;
using System;
       
//AzCustOrderHist 有返回结果存储过程业务列表类
namespace DemoTools.BLL.DemoNorthwind
{
   /// <summary>
   /// AzCustOrderHist  查询类存储过程列表类
   /// 此类中以 P_ 开头的均是存储过程传入参数
   /// 类型本是参数容器及数据容器功能
   /// </summary>
   [Serializable]
  public   class AzCustOrderHistListEntity : BusinessListBase<AzCustOrderHistEntity>, IBusinessSpFetch
  {


	#region   操作执行属性定义(为存储过程中参数组成)

			/// <summary>
		/// @CustomerID_simpCN
		///</summary>
		public string P_CustomerID { get; set;}



	#endregion

	#region  构造部分
	
	/// <summary>
	/// 数据操作接口
	/// </summary>
        [NonSerialized]
        private IAzCustOrderHistDal _dbaccess;

        public AzCustOrderHistListEntity(ILifetimeScope lc, IAzCustOrderHistDal dbaccess)
        {
            _dbaccess = dbaccess;
        }

        /// <summary>
        /// 当由WCF访问时,不会调用构造方法,因此需重建数据层访问
        /// </summary>
        /// <param name="workContext">Autoface容器上下文</param>
        /// <returns>数据操作接口</returns>
        private IAzCustOrderHistDal CheckworkContext()
        {
            if (_dbaccess == null)
            {
                _dbaccess = this.WorkContext.Resolve<IAzCustOrderHistDal>();
            }
            return _dbaccess;
        }
        #endregion

        #region  业务方法

	/// <summary>
        /// 获取 AzCustOrderHist 列表 
        /// </summary>
	public void DataPortal_SpFetch()
        {
	    //访问实际数据
            CheckworkContext().DB_SpFetch(this);
        }

	#endregion
     }
  }