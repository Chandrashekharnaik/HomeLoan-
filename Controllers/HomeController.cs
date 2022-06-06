using HomeLoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLoan.Controllers
{
    public class HomeController : Controller
    {
        HomeLoanSiteEntities db = new HomeLoanSiteEntities();
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(UserRegistration UReg, string ReturnUrl)
        //{
            
        //        return View();
            
        
        //}       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}