using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Database.Model
{
    public class Park_Member
    {
        public string Member_ID { get; set; }
        public string Member_Carname { get; set; }
        public string Member_Name { get; set; }
        public string Member_Password { get; set; }
        public DateTime Member_Createtime { get; set; }
    }
}
