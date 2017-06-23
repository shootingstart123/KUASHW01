using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Web.Controllers
{
    public class ParkController : Controller
    {
        // GET: Park
        [HttpGet]
        public ActionResult Create(string seat,string date,string type)
        {
            ViewBag.s = seat;
            ViewBag.d = date;
            ViewBag.t = type;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Park_Database.Model.Park_User Pget,string s,string d , string t)
        {
            Park_Database.Service.Park_User_Service dbu = new Park_Database.Service.Park_User_Service();
            Park_Database.Service.Park_Time_Service dbt = new Park_Database.Service.Park_Time_Service();

            Park_Database.Model.Park_User PU = new Park_Database.Model.Park_User();
            Park_Database.Model.Park_Time PT = new Park_Database.Model.Park_Time();
            Park_Web.Models.Park_Ok PK = new Park_Web.Models.Park_Ok();

            DateTime da;

            da = DateTime.Parse(d);
            if (t == "1")  //月租
                da=da.AddMonths(1);
            else if (t == "2") //年租
                da=da.AddYears(1);

            Pget.User_Createtime = DateTime.Now;
            dbu.Create(Pget);

            PT.Time_Carname = Pget.User_Carname;
            PT.Time_Seat = s;
            PT.Time_Start = d;
            PT.Time_End = da.ToString("yyyy-MM-dd HH:mm");
            PT.Time_Createtime = DateTime.Now;
            dbt.Create(PT);

            if (t == "0")
                PK.Ok_Type = "日租型";
            else if (t == "1")
                PK.Ok_Type = "月租型";
            else if (t == "2")
                PK.Ok_Type = "年租型";
            PK.Ok_Seat = s;
            PK.Ok_Carname = Pget.User_Carname;
            PK.Ok_Name = Pget.User_Name;
            PK.Ok_Password = Pget.User_Password;
            PK.Ok_Start = d;
            PK.Ok_End = da.ToString("yyyy-MM-dd HH:mm");

            return RedirectToAction("ok","Park",PK);
        }
        public ActionResult ok(Park_Web.Models.Park_Ok PK)
        {

            return View(PK);
        }
    }
}