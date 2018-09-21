using Autofac;
using DemoTools.UIServer.DemoNorthwind;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webdiyer.WebControls.AspNetCore;


// 客户 控制器
namespace DemoTools.WebUI.DemoNorthwind.Controllers
{
    /// <summary>
    /// 客户
    /// </summary>
    public class AzCustomersController : Controller
    {

        private readonly AzCustomersWebHandle _handle = AzCustomersWebHandle.GetWebHandle();

        private ILifetimeScope _lc;

        public AzCustomersController(ILifetimeScope lc)
        {
            _lc = lc;
        }

        /// <summary>
        /// 返回 客户 列表
        /// 异步调用数据,其异步部分明细View没有Controller只有View
        /// </summary>

        public IActionResult Index(int pageindex = 1)
        {
            var bizExp = _handle.GetExp();
            bizExp.LookPage(pageindex, 20);
            var model = _handle.GetList(bizExp);
            model.PageSize = 20;
            model.CurrentPageIndex = pageindex;
            string xrh = Request.Headers["X-Requested-With"];
            if (!string.IsNullOrEmpty(xrh) && xrh.Equals("XMLHttpRequest", System.StringComparison.OrdinalIgnoreCase))
            {
                return PartialView("DetailsPage", model);
            }
            return View(model);
        }

        /// <summary>
        /// 增加客户
        /// </summary>

        public ActionResult Create()
        {

            var model = _handle.GetNew();
            return View(model);
        }

        /// <summary>
        /// 增加保存客户
        /// </summary>

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreatePost(AzCustomersWebDto model)
        {
            if (ModelState.IsValid)
            {
                _handle.Insert(model);//按增加保存 
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// 编辑客户
        /// </summary>

        public IActionResult Edit(string Id)
        {
            var bizExp = _handle.GetExp();
            bizExp.AddAndWhere(s => s.CustomerID == Id);
            var model = _handle.Get(bizExp);

            return View(model);
        }

        /// <summary>
        ///  保存编辑的客户
        /// </summary>

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult EditPost(AzCustomersWebDto model)
        {
            if (ModelState.IsValid)
            {
                _handle.Update(model);//按增加保存 
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// 显示客户单个记录
        /// </summary>

        public IActionResult Details(string Id)
        {
            var bizExp = _handle.GetExp();
            bizExp.AddAndWhere(s => s.CustomerID == Id);
            var model = _handle.Get(bizExp);
            return View(model);
        }


        /// <summary>
        /// 独立页面删除客户
        /// </summary>

        public ActionResult Delete(string Id)
        {
            var bizExp = _handle.GetExp();
            bizExp.AddAndWhere(s => s.CustomerID == Id);
            var model = _handle.Get(bizExp); ;
            return View(model);
        }

        /// <summary>
        /// 独立页面删除客户
        /// </summary>

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(AzCustomersWebDto model)
        {
            _handle.Delete(model);
            return RedirectToAction("IndexPage");
        }

    }
}
