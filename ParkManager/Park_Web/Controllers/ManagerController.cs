using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Web.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        [HttpGet]
        public ActionResult Phome(Park_Web.Models.Park_Rootweb PRW)
        {
            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();
            List<Park_Database.Model.Park_Time> PT = new List<Park_Database.Model.Park_Time>();
            PT = dt.LoadAll();
            ViewBag.Authority = PRW.Rootweb_Authority;
            return View(PT);
        }
        [HttpGet]
        public ActionResult Update(string id)
        {
            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();
            var model = dt.GetParkByID(id);
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult Update(Park_Database.Model.Park_Time P)
        {
            //if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            //{
            //    var File = Request.Files[0];
            //    string dir = string.Format("~/Content/Image/");
            //    var TrueDir = System.Web.Hosting.HostingEnvironment.MapPath(dir);
            //    if (!System.IO.Directory.Exists(TrueDir))
            //    {
            //        System.IO.Directory.CreateDirectory(TrueDir);
            //    }
            //    var SaveDir = System.IO.Path.Combine(TrueDir, File.FileName);
            //    File.SaveAs(SaveDir);
            //    P.area = this.Url.Content(System.IO.Path.Combine(dir, File.FileName));
            //    //System.Drawing.Image image = System.Drawing.Image.FromStream(File.InputStream);
            //}

            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();
            dt.Update(P);
            return RedirectToAction("Phome");
        }
        public ActionResult Delete(string id)
        {
            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();
            dt.Delete(id);
            return RedirectToAction("PHome");
        }
        public ActionResult Search(string search="")
        {
            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();
            var s = dt.LoadAll();
            if (!string.IsNullOrEmpty(search))
                s = s
                    .Where(x =>
                    x.Time_Carname.Contains(search) ||
                    x.Time_Seat.Contains(search) ||
                    x.Time_Start.Contains(search) ||
                    x.Time_End.Contains(search)) 
                    .ToList();
            ViewBag.Search = search;

            return View(s);
        }
    }
}