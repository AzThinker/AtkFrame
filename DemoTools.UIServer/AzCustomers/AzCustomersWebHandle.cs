using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.WebCore.Infrastructure;
using Autofac;
using DemoTools.BLL.DemoNorthwind;
 

// 《客户》 UI操作数据方法
namespace DemoTools.UIServer.DemoNorthwind
{

    /// <summary>
    /// 客户 UIServer模块注册
    /// </summary>
    public class AzCustomers_UI_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzCustomersWebDto>();
            moduleBuilder.RegisterType<AzCustomersListWebDto>();
            moduleBuilder.RegisterType<AzCustomersWebHandle>();
        }
    }

    /// <summary>
    /// 《客户》UI操作数据方法
    /// </summary>
    public sealed class  AzCustomersWebHandle:BusinessBaseHandle<AzCustomersListEntity,
	 AzCustomersEntity,
	 AzCustomersListWebDto ,
	 AzCustomersWebDto>
    {

        /// <summary>
        /// 《客户》WebHandle 构造方法
        /// </summary>
        public AzCustomersWebHandle(ILifetimeScope lc,
            IDataPortal<AzCustomersEntity> dataportal,
            IDataPortalList<AzCustomersListEntity, AzCustomersEntity> dataportallist,
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
        /// 获取《客户》WebHandle 实例
        /// </summary>  
        public static AzCustomersWebHandle GetWebHandle()
        {
           return   EngineContext.Current.Resolve<AzCustomersWebHandle>();
        }
        #endregion


     }
  }
