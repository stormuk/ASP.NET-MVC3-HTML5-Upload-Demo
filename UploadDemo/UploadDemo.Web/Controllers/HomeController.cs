using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase myfile)
        {

            var foo = myfile;

            if (myfile.ContentLength > 0)
            {
                // Save file
                var fileName = myfile.FileName;
                var path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), fileName);
                myfile.SaveAs(path);

                return Content("ok");
            }

            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 500;
            return Content("no file selected");
        }
    }
}
