using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Database.Service
{
    public class Park_Area_Service
    {
        private const string _connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Park_Area;Integrated Security=True";
        public List<Park_Database.Model.Park_Area> LoadAll()
        {
            List<Park_Database.Model.Park_Area> result = new List<Park_Database.Model.Park_Area>();
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = "Select * from Park_Area";
            var reader = command.ExecuteReader();



            while (reader.Read())
            {
                Park_Database.Model.Park_Area item = new Park_Database.Model.Park_Area();
                item.Area_Name = reader["Area_Name"].ToString();
                item.Area_Num = reader["Area_Num"].ToString();
                item.Area_Createtime= DateTime.Parse(reader["Area_Createtime"].ToString());
                result.Add(item);
            }
            connection.Close();
            return result;
        }

        public void Create(Park_Database.Model.Park_Area CP)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Park_Area(Area_Name,Area_Num, Area_Createtime)
VALUES          (N'{0}',N'{1}',N'{2}')
", CP.Area_Name, CP.Area_Num, CP.Area_Createtime.ToString("yyyy-MM-dd HH:mm"));
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
