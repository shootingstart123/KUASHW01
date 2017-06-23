using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Database.Service
{
    public class Park_Member_Service
    {
        private const string _connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Park_Member;Integrated Security=True";
        public List<Park_Database.Model.Park_Member> LoadAll()
        {
            List<Park_Database.Model.Park_Member> result = new List<Park_Database.Model.Park_Member>();
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = "Select * from Park_Member";
            var reader = command.ExecuteReader();


            while (reader.Read())
            {
                Park_Database.Model.Park_Member item = new Park_Database.Model.Park_Member();
                item.Member_ID = reader["Member_ID"].ToString();
                item.Member_Carname = reader["Member_Carname"].ToString();
                item.Member_Name = reader["Member_Name"].ToString();
                item.Member_Password = reader["Member_Password"].ToString();
                item.Member_Createtime = DateTime.Parse(reader["Member_Createtime"].ToString());
                result.Add(item);
            }

            connection.Close();
            return result;
        }

        public void Create(Park_Database.Model.Park_Member CP)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Park_Member(Member_ID,Member_Carname,Member_Name, Member_Password, Member_Createtime)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')
", CP.Member_ID,CP.Member_Carname, CP.Member_Name, CP.Member_Password, CP.Member_Createtime.ToString("yyyy-MM-dd HH:mm"));
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
