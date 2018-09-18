using Atk.WebCore.Infrastructure;
using Autofac;
using DemoTools.UIServer.DemoNorthwind;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webdiyer.WebControls.AspNetCore;

// AzCustOrderHist  存储过程
namespace DemoTools.WebUI.DemoNorthwind.Controllers
{

    /// <summary>
    /// AzCustOrderHist  （存储过程）
    /// </summary>
    public class AzCustOrderHistController : Controller
    {
        private readonly AzCustOrderHistWebHandle _handle = AzCustOrderHistWebHandle.GetWebHandle();

        /// <summary>
        /// 返回AzCustOrderHist列表
        /// 异步调用数据,其异步部分明细View没有Controller只有View
        /// </summary>

        public IActionResult Index()
        {
            var paramItem = EngineContext.Current.Resolve<AzCustOrderHistListWebDto>();
            // 手动加入条件参数；
            paramItem.P_CustomerID = "ALFKI";
            var model = _handle.GetList(paramItem);
            return View(model);
        }

    }
}
