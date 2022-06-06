using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HomeLoan.Models;

namespace HomeLoan.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Registration()
        {
            UserRegistration usermodel = new UserRegistration();
            return View(usermodel);
        }

        [HttpPost]
        public ActionResult Registration(UserRegistration URegModel)
        {
            using(HomeLoanSiteEntities dbmodel = new HomeLoanSiteEntities())
            {

                if(dbmodel.UserRegistrations.Any(x => x.UserName == URegModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username Already Exists";
                    return View("Registration", URegModel);
                }
                dbmodel.UserRegistrations.Add(URegModel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfull";
            return View("Registration", new UserRegistration());
            
        }







        HomeLoanSiteEntities db = new HomeLoanSiteEntities();
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserRegistration UReg, string ReturnUrl)
        {
            var user = db.UserRegistrations.Where(x => x.UserName == UReg.UserName && x.Password == UReg.Password).Count();
            if (user>0)
            {
                FormsAuthentication.SetAuthCookie(UReg.UserName, true);
                return RedirectToAction("Application","LoanApplication");
               // return View();
            }
            else
            {
                return View(UReg);
            }
          
            //if (user > 0)
            //{
            //    return View();
            //}
            //else
            //{
            //    return View();
            //}

        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



        //public  bool IsValid(UserRegistration UReg)
        //{
        //    var user = db.UserRegistrations.Where(x => x.UserName == UReg.UserName && x.Password == UReg.Password);


        //    bool user1 = Convert.ToBoolean(user);
        //    return (user1);
        //    //return (Convert.ToBoolean(user));
        //    /* route.Id = Convert.ToInt32(res.FirstOrDefault());*/
        //}

    }
}