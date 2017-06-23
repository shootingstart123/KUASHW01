using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park_Web.Controllers
{
    public class ParkingLotController : Controller
    {
        // GET: ParkingLot
        public ActionResult DayP(Park_Web.Models.Park_DateArea PDA)
        {
            Park_Database.Service.Park_Area_Service da = new Park_Database.Service.Park_Area_Service();
            Park_Database.Service.Park_Seats_Service ds = new Park_Database.Service.Park_Seats_Service();
            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();

            List<Park_Database.Model.Park_Area> PA = new List<Park_Database.Model.Park_Area>();
            List<Park_Database.Model.Park_Seats> PS = new List<Park_Database.Model.Park_Seats>();
            List<Park_Database.Model.Park_Time> PT = new List<Park_Database.Model.Park_Time>();
            List<Park_Web.Models.Park_SeatsStatus> PWS = new List<Park_Web.Models.Park_SeatsStatus>();

            PA = da.LoadAll();
            PS = ds.LoadAll();
            PT = dt.LoadAll();


            PS.ForEach(x=>{
                Park_Web.Models.Park_SeatsStatus item = new Park_Web.Models.Park_SeatsStatus();
                if (PA[int.Parse(PDA.Park_DateArea_Area)].Area_Name == x.Seats_Area)
                {
                    item.Park_SeatsStatus_Seat = x.Seats_Num;
                    PWS.Add(item);
                }
            });
            bool PTf = false;
            for(int i = 0; i < PWS.Count; i++)
            {
                PTf = false;
                for(int j = 0; j < PT.Count; j++)
                {
                    if(PWS[i].Park_SeatsStatus_Seat == PT[j].Time_Seat)
                    {
                        if (((DateTime.Parse(PT[j].Time_End) >= DateTime.Parse(PDA.Park_DateArea_Date))) && ((DateTime.Parse(PT[j].Time_Start) <= DateTime.Parse(PDA.Park_DateArea_Date))))
                        {
                            PWS[i].Park_SeatsStatus_Status = "1";
                            PTf = true;
                            break;
                        }
                    }
                }
                if(!PTf)
                 PWS[i].Park_SeatsStatus_Status = "0";
            }
            ViewBag.Date = PDA.Park_DateArea_Date;
            ViewBag.Area = PA[int.Parse(PDA.Park_DateArea_Area)].Area_Name;
            ViewBag.type = "0"; //0 日租型
            return View(PWS);
        }

        public ActionResult MonthP(Park_Web.Models.Park_DateArea PMA)
        {
            Park_Database.Service.Park_Area_Service da = new Park_Database.Service.Park_Area_Service();
            Park_Database.Service.Park_Seats_Service ds = new Park_Database.Service.Park_Seats_Service();
            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();

            List<Park_Database.Model.Park_Area> PA = new List<Park_Database.Model.Park_Area>();
            List<Park_Database.Model.Park_Seats> PS = new List<Park_Database.Model.Park_Seats>();
            List<Park_Database.Model.Park_Time> PT = new List<Park_Database.Model.Park_Time>();
            List<Park_Web.Models.Park_SeatsStatus> PWS = new List<Park_Web.Models.Park_SeatsStatus>();

            PA = da.LoadAll();
            PS = ds.LoadAll();
            PT = dt.LoadAll();


            PS.ForEach(x => {
                Park_Web.Models.Park_SeatsStatus item = new Park_Web.Models.Park_SeatsStatus();
                if (PA[int.Parse(PMA.Park_DateArea_Area)].Area_Name == x.Seats_Area)
                {
                    item.Park_SeatsStatus_Seat = x.Seats_Num;
                    PWS.Add(item);
                }
            });
            bool PTf = false;
            for (int i = 0; i < PWS.Count; i++)
            {
                PTf = false;
                for (int j = 0; j < PT.Count; j++)
                {
                    if (PWS[i].Park_SeatsStatus_Seat == PT[j].Time_Seat)
                    {
                        if (((DateTime.Parse(PT[j].Time_End) >= DateTime.Parse(PMA.Park_DateArea_Date))) && ((DateTime.Parse(PT[j].Time_Start) <= DateTime.Parse(PMA.Park_DateArea_Date))))
                        {
                            PWS[i].Park_SeatsStatus_Status = "1";
                            PTf = true;
                            break;
                        }
                    }
                }
                if (!PTf)
                    PWS[i].Park_SeatsStatus_Status = "0";
            }
            ViewBag.Date = PMA.Park_DateArea_Date;
            ViewBag.Area = PA[int.Parse(PMA.Park_DateArea_Area)].Area_Name;
            ViewBag.type = "1"; //0 日租型 1 月租型
            return View(PWS);
        }
        public ActionResult YearP(Park_Web.Models.Park_DateArea PMA)
        {
            Park_Database.Service.Park_Area_Service da = new Park_Database.Service.Park_Area_Service();
            Park_Database.Service.Park_Seats_Service ds = new Park_Database.Service.Park_Seats_Service();
            Park_Database.Service.Park_Time_Service dt = new Park_Database.Service.Park_Time_Service();

            List<Park_Database.Model.Park_Area> PA = new List<Park_Database.Model.Park_Area>();
            List<Park_Database.Model.Park_Seats> PS = new List<Park_Database.Model.Park_Seats>();
            List<Park_Database.Model.Park_Time> PT = new List<Park_Database.Model.Park_Time>();
            List<Park_Web.Models.Park_SeatsStatus> PWS = new List<Park_Web.Models.Park_SeatsStatus>();

            PA = da.LoadAll();
            PS = ds.LoadAll();
            PT = dt.LoadAll();


            PS.ForEach(x => {
                Park_Web.Models.Park_SeatsStatus item = new Park_Web.Models.Park_SeatsStatus();
                if (PA[int.Parse(PMA.Park_DateArea_Area)].Area_Name == x.Seats_Area)
                {
                    item.Park_SeatsStatus_Seat = x.Seats_Num;
                    PWS.Add(item);
                }
            });
            bool PTf = false;
            for (int i = 0; i < PWS.Count; i++)
            {
                PTf = false;
                for (int j = 0; j < PT.Count; j++)
                {
                    if (PWS[i].Park_SeatsStatus_Seat == PT[j].Time_Seat)
                    {
                        if (((DateTime.Parse(PT[j].Time_End) >= DateTime.Parse(PMA.Park_DateArea_Date))) && ((DateTime.Parse(PT[j].Time_Start) <= DateTime.Parse(PMA.Park_DateArea_Date))))
                        {
                            PWS[i].Park_SeatsStatus_Status = "1";
                            PTf = true;
                            break;
                        }
                    }
                }
                if (!PTf)
                    PWS[i].Park_SeatsStatus_Status = "0";
            }
            ViewBag.Date = PMA.Park_DateArea_Date;
            ViewBag.Area = PA[int.Parse(PMA.Park_DateArea_Area)].Area_Name;
            ViewBag.type = "2"; //0 日租型 1 月租型 2 年租型
            return View(PWS);
        }
    }
}