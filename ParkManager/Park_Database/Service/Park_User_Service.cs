using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Database.Service
{
    public class Park_User_Service
    {
        private const string _connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Park_User;Integrated Security=True";
        public List<Park_Database.Model.Park_User> LoadAll()
        {
            List<Park_Database.Model.Park_User> result = new List<Park_Database.Model.Park_User>();
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = "Select * from Park_User";
            var reader = command.ExecuteReader();


            while (reader.Read())
            {
                Park_Database.Model.Park_User item = new Park_Database.Model.Park_User();
                item.User_Carname = reader["User_Carname"].ToString();
                item.User_Name = reader["User_Name"].ToString();
                item.User_Password = reader["User_Password"].ToString();
                item.User_Createtime = DateTime.Parse(reader["User_Createtime"].ToString());
                result.Add(item);
            }

            connection.Close();
            return result;
        }

        public void Create(Park_Database.Model.Park_User CP)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Park_User(User_Carname,User_Name, User_Password, User_Createtime)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}')
", CP.User_Carname ,CP.User_Name, CP.User_Password, CP.User_Createtime.ToString("yyyy-MM-dd HH:mm"));
                command.ExecuteNonQuery();
            
            connection.Close();
        }
    }
}
