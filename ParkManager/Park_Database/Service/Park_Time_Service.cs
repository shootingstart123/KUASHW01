using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Database.Service
{
    public class Park_Time_Service
    {
        private const string _connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Park_Time;Integrated Security=True";
        public List<Park_Database.Model.Park_Time> LoadAll()
        {
            List<Park_Database.Model.Park_Time> result = new List<Park_Database.Model.Park_Time>();
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = "Select * from Park_Time";
            var reader = command.ExecuteReader();


            while (reader.Read())
            {
                Park_Database.Model.Park_Time item = new Park_Database.Model.Park_Time();
                item.Time_Carname = reader["Time_Carname"].ToString();
                item.Time_Seat = reader["Time_Seat"].ToString();
                item.Time_Start = reader["Time_Start"].ToString();
                item.Time_End = reader["Time_End"].ToString();
                item.Time_Createtime = DateTime.Parse(reader["Time_Createtime"].ToString());
                result.Add(item);
            }

            connection.Close();
            return result;
        }

        public void Create(Park_Database.Model.Park_Time CP)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Park_Time(Time_Carname,Time_Seat, Time_Start, Time_End,Time_Createtime)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')
", CP.Time_Carname, CP.Time_Seat, CP.Time_Start, CP.Time_End, CP.Time_Createtime.ToString("yyyy-MM-dd HH:mm"));
            command.ExecuteNonQuery();

            connection.Close();
        }
        public Park_Database.Model.Park_Time GetParkByID(string id)
        {
            Park_Database.Model.Park_Time result = new Park_Database.Model.Park_Time();

            var connection = new System.Data.SqlClient.SqlConnection(_connection);

            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select * from Park_Time
Where Time_Carname='{0}'", id);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Park_Database.Model.Park_Time item = new Park_Database.Model.Park_Time();
                item.Time_Carname = reader["Time_Carname"].ToString();
                item.Time_Seat = reader["Time_Seat"].ToString();
                item.Time_Start = reader["Time_Start"].ToString();
                item.Time_End = reader["Time_End"].ToString();
                item.Time_Createtime = DateTime.Parse(reader["Time_Createtime"].ToString());
                result = item;
            }
            connection.Close();
            return result;
        }
        public void Delete(string id)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
DELETE FROM Park_Time
Where Time_Carname='{0}'
", id);

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Park_Database.Model.Park_Time updatePark)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
UPDATE          Park_Time
SET             Time_Seat=N'{1}',Time_Start=N'{2}',Time_End=N'{3}'
Where           Time_Carname=N'{0}'
", updatePark.Time_Carname, updatePark.Time_Seat, updatePark.Time_Start, updatePark.Time_End);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
