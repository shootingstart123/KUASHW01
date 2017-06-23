using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Park_cmd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Park_Database.Model.Park_User> PU = new List<Park_Database.Model.Park_User>();
            var dbu = new Park_Database.Service.Park_User_Service();
            var dba = new Park_Database.Service.Park_Area_Service();
            var dbs = new Park_Database.Service.Park_Seats_Service();
            var dbt = new Park_Database.Service.Park_Time_Service();
            var dbr = new Park_Database.Service.Park_Root_Service();
            // Create_User(dbu);
            //Show_User(dbu);
            //Create_Area(dba);
            //Show_Area(dba);
            //Create_Seats(dbs);
            //Show_Seats(dbs);
            // Create_Time(dbt);
            //Show_Time(dbt);
            Create_Root(dbr);
            Show_Root(dbr);
            Console.ReadKey();
        }
        public static  void Create_User(Park_Database.Service.Park_User_Service db)
        {
            var carname = "MAC-7122";
            var name = "Li";
            var password = "789";
            var createtime = DateTime.Now;
            Park_Database.Model.Park_User PU = new Park_Database.Model.Park_User();
            PU.User_Carname = carname;
            PU.User_Name = name;
            PU.User_Password = password;
            PU.User_Createtime = (createtime);
            db.Create(PU);
            Console.WriteLine("使用者資料創建完成");
        }
        public static void Show_User(Park_Database.Service.Park_User_Service db)
        {
            List<Park_Database.Model.Park_User> PU = new List<Park_Database.Model.Park_User>();
            PU = db.LoadAll();
            int count = 1;
            Console.WriteLine("共有" + PU.Count + "筆使用者資料");
            PU.ForEach(x => {
                Console.WriteLine("第" + (count++) + "筆" + "資料");
                Console.WriteLine("\t車牌:" + x.User_Carname);
                Console.WriteLine("\t名字:" + x.User_Name);
                Console.WriteLine("\t密碼:" + x.User_Password);
                Console.WriteLine("\t創建日期:" + x.User_Createtime);
                Console.WriteLine();
            });
        }
        public static void Create_Area(Park_Database.Service.Park_Area_Service db)
        {
            Park_Database.Model.Park_Area PA = new Park_Database.Model.Park_Area();
            
            var Name = "D";
            var Num = "5";
            var Createtime = DateTime.Now;
            PA.Area_Name = Name;
            PA.Area_Num = Num;
            PA.Area_Createtime = (Createtime);

            db.Create(PA);
            
            Console.WriteLine("區域資料創建完成");
        }
        public static void Show_Area(Park_Database.Service.Park_Area_Service db)
        {
            List<Park_Database.Model.Park_Area> PA = new List<Park_Database.Model.Park_Area>();
            PA = db.LoadAll();
            int count = 1;
            Console.WriteLine("共有" + PA.Count + "筆區域資料");
            PA.ForEach(x =>
            {
                Console.WriteLine("\t第" + (count++) + "筆資料");
                Console.WriteLine("\t區域名稱:" + x.Area_Name);
                Console.WriteLine("\t區域數量:" + x.Area_Num);
                Console.WriteLine("\t建立時間:"  + x.Area_Createtime.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine();
            });
        }
        public static void Create_Seats(Park_Database.Service.Park_Seats_Service db)
        {
            Park_Database.Model.Park_Seats PS = new Park_Database.Model.Park_Seats();


            PS.Seats_Area = "B";
            for(int i = 1; i < 11; i++)
            {
                PS.Seats_Num =PS.Seats_Area + i.ToString("00");
                db.Create(PS);
            }


            Console.WriteLine("區域位置資料創建完成");
        }
        public static void Show_Seats(Park_Database.Service.Park_Seats_Service db)
        {
            List<Park_Database.Model.Park_Seats> PS = new List<Park_Database.Model.Park_Seats>();
            PS = db.LoadAll();
            int count = 1;
            Console.WriteLine("共有" + PS.Count + "筆區域位置資料");
            PS.ForEach(x =>
            {
                Console.WriteLine("\t第" + (count++) + "筆資料");
                Console.WriteLine("\t區域座號:" + x.Seats_Num);
                Console.WriteLine("\t所在區域:" + x.Seats_Area);
                Console.WriteLine();
            });
        }
        public static void Create_Time(Park_Database.Service.Park_Time_Service db)
        {
            Park_Database.Model.Park_Time PT = new Park_Database.Model.Park_Time();

            var carname = "MAX-7222";
            var seats = "A02";
            var start = "2017-01-01";
            var end = "2017-01-01";
            var Createtime = DateTime.Now;
            PT.Time_Carname = carname;
            PT.Time_Seat = seats;
            PT.Time_Start = start;
            PT.Time_End = end;
            PT.Time_Createtime = (Createtime);

            db.Create(PT);

            Console.WriteLine("區域資料創建完成");
        }
        //public static void Show_Time(Park_Database.Service.Park_Time_Service db)
        //{
        //    List<Park_Database.Model.Park_Time> PT = new List<Park_Database.Model.Park_Time>();
        //    PT = db.LoadAll();
        //    int count = 1;
        //    Console.WriteLine("共有" + PT.Count + "筆區域資料");
        //    PT.ForEach(x =>
        //    {
        //        Console.WriteLine("\t第" + (count++) + "筆資料");
        //        Console.WriteLine("\t車牌:" + x.Time_Carname);
        //        Console.WriteLine("\t座號:" + x.Time_Seat);
        //        Console.WriteLine("\t開始時間:" + x.Time_Start);
        //        Console.WriteLine("\t結束時間:" + x.Time_End);
        //        Console.WriteLine("\t建立時間:" + x.Time_Createtime.ToString("yyyy-MM-dd HH:mm:ss"));
        //        Console.WriteLine();
        //    });
        //}
        public static void Create_Member(Park_Database.Service.Park_Member_Service db)
        {
            var ID = "root01";
            var carname = "MAC-7122";
            var name = "Tsai";
            var password = "root01";
            var createtime = DateTime.Now;
            Park_Database.Model.Park_Member PM = new Park_Database.Model.Park_Member();
            PM.Member_ID = ID;
            PM.Member_Carname = carname;
            PM.Member_Name = name;
            PM.Member_Password = password;
            PM.Member_Createtime = (createtime);
            db.Create(PM);
            Console.WriteLine("使用者資料創建完成");
        }
        public static void Show_Member(Park_Database.Service.Park_Member_Service db)
        {
            List<Park_Database.Model.Park_Member> PM = new List<Park_Database.Model.Park_Member>();
            PM = db.LoadAll();
            int count = 1;
            Console.WriteLine("共有" + PM.Count + "筆使用者資料");
            PM.ForEach(x => {
                Console.WriteLine("第" + (count++) + "筆" + "資料");
                Console.WriteLine("\t會員ID:" + x.Member_ID);
                Console.WriteLine("\t車牌:" + x.Member_Carname);
                Console.WriteLine("\t名字:" + x.Member_Name);
                Console.WriteLine("\t密碼:" + x.Member_Password);
                Console.WriteLine("\t創建日期:" + x.Member_Createtime);
                Console.WriteLine();
            });
        }
        public static void Create_Root(Park_Database.Service.Park_Root_Service db)
        {
            var ID = "root01";
            var password = "rootA01";
            var Authority = "1";
            Park_Database.Model.Park_Root PR = new Park_Database.Model.Park_Root();
            PR.Root_ID = ID;
            PR.Root_Password = password;
            PR.Root_Authority = Authority;
            db.Create(PR);
            Console.WriteLine("使用者資料創建完成");
        }
        public static void Show_Root(Park_Database.Service.Park_Root_Service db)
        {
            List<Park_Database.Model.Park_Root> PR = new List<Park_Database.Model.Park_Root>();
            PR = db.LoadAll();
            int count = 1;
            Console.WriteLine("共有" + PR.Count + "筆使用者資料");
            PR.ForEach(x => {
                Console.WriteLine("第" + (count++) + "筆" + "資料");
                Console.WriteLine("\t會員ID:" + x.Root_ID);
                Console.WriteLine("\t密碼:" + x.Root_Password);
                Console.WriteLine("\t權限:" + x.Root_Authority);
                Console.WriteLine();
            });
        }
    }
}
