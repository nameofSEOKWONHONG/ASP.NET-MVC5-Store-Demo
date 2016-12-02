using Store.Model;
using Store.Service;
using Store.Web.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers {
	public class HomeController : Controller {
		private readonly ICategoryService categoryService;
		private readonly IGadgetService gadgetService;

		public HomeController(ICategoryService categoryService,
			IGadgetService gadgetService) {
				this.categoryService = categoryService;
				this.gadgetService = gadgetService;
		}

		public ActionResult Index(string category = null) {
			IEnumerable<CategoryViewModel> viewModelGadgets;
			IEnumerable<Category> categories;

			categories = categoryService.GetCategories(category).ToList();

			viewModelGadgets = AutoMapper.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
			return View(viewModelGadgets);
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}