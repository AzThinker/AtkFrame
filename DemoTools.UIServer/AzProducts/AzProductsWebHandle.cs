using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.WebCore.Infrastructure;
using Autofac;
using DemoTools.BLL.DemoNorthwind;
 

// 《产品》 UI操作数据方法
namespace DemoTools.UIServer.DemoNorthwind
{

    /// <summary>
    /// 产品 UIServer模块注册
    /// </summary>
    public class AzProducts_UI_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzProductsWebDto>();
            moduleBuilder.RegisterType<AzProductsListWebDto>();
            moduleBuilder.RegisterType<AzProductsWebHandle>();
        }
    }

    /// <summary>
    /// 《产品》UI操作数据方法
    /// </summary>
    public sealed class  AzProductsWebHandle:BusinessBaseHandle<AzProductsListEntity,
	 AzProductsEntity,
	 AzProductsListWebDto ,
	 AzProductsWebDto>
    {

        /// <summary>
        /// 《产品》WebHandle 构造方法
        /// </summary>
        public AzProductsWebHandle(ILifetimeScope lc,
            IDataPortal<AzProductsEntity> dataportal,
            IDataPortalList<AzProductsListEntity, AzProductsEntity> dataportallist,
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
        /// 获取《产品》WebHandle 实例
        /// </summary>  
        public static AzProductsWebHandle GetWebHandle()
        {
           return   EngineContext.Current.Resolve<AzProductsWebHandle>();
        }
        #endregion


     }
  }
