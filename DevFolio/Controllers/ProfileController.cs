using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProfileController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        [Authorize]
        public ActionResult ProfileList()
        {
            var value = db.TblProfile.ToList();
            return View(value);
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreateProfil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProfil(TblProfile p)
        {
            db.TblProfile.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }
        public ActionResult DeleteProfile(int id)
        {
            var value = db.TblProfile.Find(id);
            db.TblProfile.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }
        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var value = db.TblProfile.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProfile(TblProfile p)
        {
            var value = db.TblProfile.Find(p.ProfileID);
            value.NameSurname = p.NameSurname;
            value.Title = p.Title;
            value.Email = p.Email;
            value.Phone = p.Phone;
            value.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }
    }
}