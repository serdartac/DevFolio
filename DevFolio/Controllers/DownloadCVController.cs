using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class DownloadCVController : Controller
    {

        public FilePathResult DownloadCV()
        {
            string dosyaYolu = Server.MapPath("~/CV/Cv.pdf");
            string dosyaTuru = "application/pdf";
            return File(dosyaYolu, dosyaTuru, "Cv.pdf");
        }
    }
}