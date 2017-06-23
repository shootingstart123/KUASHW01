using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Rent()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Year()
        {
            Park_Database.Service.Park_Area_Service db = new Park_Database.Service.Park_Area_Service();
            var list = db.LoadAll();
            List<SelectListItem> items = new List<SelectListItem>();
            int i = 0;
            foreach (var item in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Area_Name,
                    Value = (i++).ToString(),
                });
            }
            ViewBag.Map_area = items;
            return View();
        }
        [HttpPost]
        public ActionResult Year(Park_Web.Models.Park_DateArea PY)
        {
            DateTime dt, now;
            if (PY.Park_DateArea_Date == null)
            {
                return RedirectToAction("Year");
            }

            dt = DateTime.Parse(PY.Park_DateArea_Date);

            now = DateTime.Now;

            if (dt < now)
            {
                return RedirectToAction("Year");
            }

            return RedirectToAction("YearP", "ParkingLot", PY);
        }
        [HttpGet]
        public ActionResult Month()
        {
            Park_Database.Service.Park_Area_Service db = new Park_Database.Service.Park_Area_Service();
            var list = db.LoadAll();
            List<SelectListItem> items = new List<SelectListItem>();
            int i = 0;
            foreach (var item in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Area_Name,
                    Value = (i++).ToString(),
                });
            }
            ViewBag.Map_area = items;
            return View();
        }
        [HttpPost]
        public ActionResult Month(Park_Web.Models.Park_DateArea PM)
        {
            DateTime dt, now;
            if (PM.Park_DateArea_Date == null)
            {
                return RedirectToAction("Month");
            }

            dt = DateTime.Parse(PM.Park_DateArea_Date);
            
            now = DateTime.Now;

            if (dt < now)
            {
                return RedirectToAction("Month");
            }

            return RedirectToAction("MonthP", "ParkingLot", PM);
        }
        [HttpGet]
        public ActionResult Day()
        {
            Park_Database.Service.Park_Area_Service db = new Park_Database.Service.Park_Area_Service();
            var list = db.LoadAll();
            List<SelectListItem> items = new List<SelectListItem>();
            int i = 0;
            foreach (var item in list)
            {
                items.Add(new SelectListItem()
                {
                    Text = item.Area_Name,
                    Value = (i++).ToString(),
                });
            }
            ViewBag.Map_area = items;
            return View();
        }
        [HttpPost]
        public ActionResult Day(Park_Web.Models.Park_DateArea PD)
        {
            DateTime dt,now;

            if (PD.Park_DateArea_Date == null)
            {
                return RedirectToAction("Day");
            }

            dt = DateTime.Parse(PD.Park_DateArea_Date);
            now = DateTime.Now;

            if (dt < now)
            {
                return RedirectToAction("Day");
            }
           
            return RedirectToAction("DayP", "ParkingLot",PD);
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Park_Web.Models.Park_Rootweb PRW)
        {
            Park_Database.Service.Park_Root_Service db = new Park_Database.Service.Park_Root_Service();
            List<Park_Database.Model.Park_Root> rl = new List<Park_Database.Model.Park_Root>();
            rl = db.LoadAll();
            //Park_Web.Models.Park_Rootweb rw = new Park_Web.Models.Park_Rootweb();
            string a="";
            bool f = false;
            rl.ForEach(x =>  {
                if (PRW.Rootweb_ID == x.Root_ID && PRW.Rootweb_Password == x.Root_Password) {
                    string Admin = x.Root_Authority;
                    f = true;
                    PRW.Rootweb_Authority = x.Root_Authority;
                }             
            });
            if (!f)
            {
                return RedirectToAction("Login", "Home");
            }

            return RedirectToAction("Phome","Manager",PRW);
        }
    }
}