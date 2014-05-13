using System.Web.Mvc;
using AutofacExample.Core.Service;
using AutofacExample.Web.Models;

namespace AutofacExample.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Contacts = _dataService.GetAll();
            return View(model);
        }
    }
}