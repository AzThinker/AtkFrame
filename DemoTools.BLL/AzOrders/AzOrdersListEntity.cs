using Atk.DataPortal.Core;
using System;
       
//订单列表类
namespace DemoTools.BLL.DemoNorthwind
{
   /// <summary>
   /// 订单  列表类
   /// </summary>
   [Serializable]
  public   class AzOrdersListEntity : BusinessListBase<AzOrdersEntity>, IBusinessFetch
  {


	#region  构造部分
	
	/// <summary>
	/// 数据操作接口
	/// </summary>
        [NonSerialized]
        private IAzOrdersDal _dbaccess;

        public AzOrdersListEntity(IAzOrdersDal dbaccess)
        {
            _dbaccess = dbaccess;
        }

        /// <summary>
        /// 当由WCF访问时,不会调用构造方法,因此需重建数据层访问
        /// </summary>
        /// <param name="workContext">Autoface容器上下文</param>
        /// <returns>数据操作接口</returns>
        private IAzOrdersDal CheckworkContext()
        {
            if (_dbaccess == null)
            {
                _dbaccess = this.WorkContext.Resolve<IAzOrdersDal>();
            }
            return _dbaccess;
        }
        #endregion

        #region  业务方法

	         /// <summary>
        /// 获取 订单 列表 
        /// </summary>
        /// <param name="Criteria">列表参数</param>
        /// <param name="context">访问上下文</param>
	/// <param name="workContext">工作上下文</param>
	public void DataPortal_Fetch()
        {
	    //访问实际数据
            CheckworkContext().DB_FetchList(this);
        }

	#endregion
        }
  }