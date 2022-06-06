using HomeLoan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLoan.Controllers
{
    public class LoanApplicationController : Controller
    {

       
        // GET: LoanApplication
        public ActionResult SaveFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveFile(HttpPostedFileBase file,HttpPostedFileBase file1,HttpPostedFileBase file2)
        {
            string path = Server.MapPath("~/App_Data/File");
            string fileName = Path.GetFileName(file.FileName);
            string fileName1 = Path.GetFileName(file1.FileName);
            string filename2 = Path.GetFileName(file2.FileName);

            string fullPath = Path.Combine(path, fileName);
            string combinepath = Path.Combine(path, fileName1);
            string combinepath1 = Path.Combine(path, filename2);

            file.SaveAs(fullPath);
            file1.SaveAs(combinepath);
            file2.SaveAs(combinepath1);
            if (file == null)
            {
                return View();
            }

            return RedirectToAction("LoanTracker");
        }


       [Authorize]
        public ActionResult Application()
        {

            LoanApplication Loanapp = new LoanApplication();

            return View(Loanapp);
        }


        [HttpPost]
        public ActionResult Application(LoanApplication LoanApp)
        {

            using (HomeLoanSiteEntities1 dbmodel = new HomeLoanSiteEntities1())
            {
                if(dbmodel.LoanApplications.Any(x=> x.PanNumber  == LoanApp.PanNumber))
                    {
                    ViewBag.DuplicateMessage = "Already Apllied on this PanNumber";
                    return View("Application", LoanApp);
                }
                dbmodel.LoanApplications.Add(LoanApp);
                try
                {
                   
                    dbmodel.SaveChanges();

                }
                catch (DbEntityValidationException dbEx)
                {

                    //Console.WriteLine(dbEx);
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                           


                            return  View("Application");
                        }
                    }
                }

            }
            ModelState.Clear();
                return RedirectToAction("SaveFile");
        }


        [Authorize]
        public ActionResult LoanTracker(LoanApplication loanapp)
        {
            using(HomeLoanSiteEntities1 dbmodel =new HomeLoanSiteEntities1())
            {
                var sql = (dbmodel.LoanApplications.Where(x => x.Verified == true).Count());

               
                if(sql >0 )
                {
                    ViewBag.DuplicateMessage = "Your application is verified sent for approval";
                    return View("LoanTracker");
                    var approval = (dbmodel.LoanApplications.Where(x => x.Approved == true).Count());
                    if (approval>0)
                    {
                        ViewBag.DuplicateMessage = "Your application is approved money will transfer soon";
                        return View("loanTracker");
                    }
                }
                else
                {
                    ViewBag.NewMessage = "Not Verified wait for verification";
                    return View("LoanTracker");
                }
                
            }
            return View();
        }


       






    }
}