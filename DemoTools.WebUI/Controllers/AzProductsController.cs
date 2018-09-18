using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Webdiyer.WebControls.AspNetCore;
using DemoTools.UIServer.DemoNorthwind;


// 产品 控制器
namespace DemoTools.WebUI.DemoNorthwind.Controllers
 {
        /// <summary>
        /// 产品
        /// </summary>
    public class AzProductsController  :Controller
     {
       
       private readonly AzProductsWebHandle _handle = AzProductsWebHandle.GetWebHandle();

	private ILifetimeScope _lc;

        public AzProductsController(ILifetimeScope lc)
        {
            _lc = lc;
        }

              /// <summary>
       /// 返回 产品 列表
       /// 异步调用数据,其异步部分明细View没有Controller只有View
       /// </summary>
       
       public IActionResult Index(int pageindex=1)
        {
	    var bizExp = _handle.GetExp();
	    bizExp.LookPage(pageindex,20);
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
      /// 增加产品
      /// </summary>
      
      public ActionResult Create()
        {
          
          var model = _handle.GetNew();
          return View(model);
        }

        /// <summary>
        /// 增加保存产品
        /// </summary>
	
        [HttpPost,ValidateAntiForgeryToken]
       [ActionName("Create")]
       public IActionResult CreatePost(AzProductsWebDto model)
        {
           if (ModelState.IsValid)
             {
                _handle.Insert(model);//按增加保存 
                return RedirectToAction("Index");
             } 
           
           return View(model);
        }
      
               /// <summary>
        /// 编辑产品
        /// </summary>
       
       public IActionResult Edit(int Id)
        {
	   var bizExp = _handle.GetExp();
	   bizExp.AddAndWhere(s => s.ProductID==Id);
	   var model = _handle.Get(bizExp);
           
           return View(model);
        }

        /// <summary>
        ///  保存编辑的产品
        /// </summary>
       
       [HttpPost,ValidateAntiForgeryToken]
       [ActionName("Edit")]
       public IActionResult EditPost(AzProductsWebDto model)
        {
           if (ModelState.IsValid)
             {
                _handle.Update(model);//按增加保存 
                return RedirectToAction("Index");
             } 
               
              return View(model);
        }
        
              /// <summary>
       /// 显示产品单个记录
       /// </summary>
       
       public IActionResult Details(int Id)
        {
	   var bizExp = _handle.GetExp();
	   bizExp.AddAndWhere(s => s.ProductID==Id);
	   var model = _handle.Get(bizExp);
           return View(model);
        }


               /// <summary>
        /// 独立页面删除产品
        /// </summary>
	
       public ActionResult Delete(int Id)
        {
	  var bizExp = _handle.GetExp();
	  bizExp.AddAndWhere(s => s.ProductID==Id);
          var model = _handle.Get(bizExp);;
          return View(model);
        }

        /// <summary>
        /// 独立页面删除产品
        /// </summary>
	
       [HttpPost, ActionName("Delete")]
       public IActionResult DeleteConfirmed(AzProductsWebDto model)
        {
	     _handle.Delete(model);
             return RedirectToAction("IndexPage");
        } 

    }
   }
