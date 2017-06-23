using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Database.Model
{
    public class Park_User //訪客用
    {
        public string User_Carname { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public DateTime User_Createtime { get; set; }
    }
}
