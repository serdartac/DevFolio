using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            var adminuserinfo = db.TblAdmin.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if(adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.Username, false);
                Session["Username"] = adminuserinfo.Username;
                return RedirectToAction("FeatureList", "Feature");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}