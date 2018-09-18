using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.WebCore.Infrastructure;
using Autofac;
using DemoTools.BLL.DemoNorthwind;
 

// 《订单》 UI操作数据方法
namespace DemoTools.UIServer.DemoNorthwind
{

    /// <summary>
    /// 订单 UIServer模块注册
    /// </summary>
    public class AzOrders_UI_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzOrdersWebDto>();
            moduleBuilder.RegisterType<AzOrdersListWebDto>();
            moduleBuilder.RegisterType<AzOrdersWebHandle>();
        }
    }

    /// <summary>
    /// 《订单》UI操作数据方法
    /// </summary>
    public sealed class  AzOrdersWebHandle:BusinessBaseHandle<AzOrdersListEntity,
	 AzOrdersEntity,
	 AzOrdersListWebDto ,
	 AzOrdersWebDto>
    {

        /// <summary>
        /// 《订单》WebHandle 构造方法
        /// </summary>
        public AzOrdersWebHandle(ILifetimeScope lc,
            IDataPortal<AzOrdersEntity> dataportal,
            IDataPortalList<AzOrdersListEntity, AzOrdersEntity> dataportallist,
            DataPortalWorkContext workcontext,
            Power power)
        {
            _lc = lc;
            _dataportal = dataportal;
            _dataportallist = dataportallist;
            _dataportalcontext = DataSettingsHelper.GetCurrentDataSetting("FniCnn");
            _workcontext = workcontext;
            _power = power;
        }

        #region  
 
        /// <summary>
        /// 获取《订单》WebHandle 实例
        /// </summary>  
        public static AzOrdersWebHandle GetWebHandle()
        {
           return   EngineContext.Current.Resolve<AzOrdersWebHandle>();
        }
        #endregion


     }
  }
