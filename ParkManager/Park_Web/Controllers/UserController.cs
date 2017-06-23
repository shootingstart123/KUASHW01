using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult U_Search(string search = "")
        {
            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();
            List<Park_Database.Model.Park_Time> pt = new List<Park_Database.Model.Park_Time>();
            List<Park_Database.Model.Park_Time> p = new List<Park_Database.Model.Park_Time>();
            if (!string.IsNullOrEmpty(search))
            {
                if (search != "")
                {
                    pt = dt.LoadAll();
                    /*
                    pt = pt
                        .Where(x =>
                        x.Time_Carname.Contains(search))
                        .ToList();*/
                    pt.ForEach(x =>{
                        if (x.Time_Carname == search)
                        {
                            p.Add(x);
                        }
                    });
                }
            }
            ViewBag.Search = search;
            return View(p);

        }
    }
}