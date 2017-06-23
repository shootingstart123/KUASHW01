using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Database.Service
{
    public class Park_Seats_Service
    {
        private const string _connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Park_Seats;Integrated Security=True";
        public List<Park_Database.Model.Park_Seats> LoadAll()
        {
            List<Park_Database.Model.Park_Seats> result = new List<Park_Database.Model.Park_Seats>();
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = "Select * from Park_Seats";
            var reader = command.ExecuteReader();



            while (reader.Read())
            {
                Park_Database.Model.Park_Seats item = new Park_Database.Model.Park_Seats();
                item.Seats_Num = reader["Seats_Num"].ToString();
                item.Seats_Area = reader["Seats_Area"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }

        public void Create(Park_Database.Model.Park_Seats CP)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Park_Seats(Seats_Num,Seats_Area)
VALUES          (N'{0}',N'{1}')
", CP.Seats_Num, CP.Seats_Area);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
