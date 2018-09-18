using Autofac;
using Atk.DataPortal;
using Atk.DataPortal.Core;
using Atk.WebCore.Infrastructure;
using DemoTools.BLL.DemoNorthwind;
 

// 《AzCustOrderHist》 UI操作数据方法
namespace DemoTools.UIServer.DemoNorthwind
{

    /// <summary>
    /// AzCustOrderHist UIServer模块注册
    /// </summary>
    public class AzCustOrderHist_UI_Module : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            moduleBuilder.RegisterType<AzCustOrderHistWebDto>();
            moduleBuilder.RegisterType<AzCustOrderHistListWebDto>();
            moduleBuilder.RegisterType<AzCustOrderHistWebHandle>();
        }
    }

    /// <summary>
    /// 《AzCustOrderHist》UI操作数据方法
    /// </summary>
    public sealed class  AzCustOrderHistWebHandle:BusinessBaseSpHandle<AzCustOrderHistListEntity,
	 AzCustOrderHistEntity,
	 AzCustOrderHistListWebDto ,
	 AzCustOrderHistWebDto>
    {

        /// <summary>
        /// 《AzCustOrderHist》WebHandle 构造方法
        /// </summary>
        public AzCustOrderHistWebHandle(ILifetimeScope lc,
            IDataPortalList<AzCustOrderHistListEntity, AzCustOrderHistEntity> dataportallist,
            DataPortalWorkContext workcontext,
            Power power)
        {
            _lc = lc;
            _dataportallist = dataportallist;
             _dataportalcontext = DataSettingsHelper.GetCurrentDataSetting("FniCnn");
            _workcontext = workcontext;
            _power = power;
        }

	#region  

        /// <summary>
        /// 获取《AzCustOrderHist》WebHandle 
        /// </summary>  
        public static AzCustOrderHistWebHandle GetWebHandle()
        {
           return   EngineContext.Current.Resolve<AzCustOrderHistWebHandle>();
        }
        #endregion


     }
  }
