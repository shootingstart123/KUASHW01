using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_Database.Service
{
    public class Park_Root_Service
    {
        private const string _connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=Park_Root;Integrated Security=True";
        public List<Park_Database.Model.Park_Root> LoadAll()
        {
            List<Park_Database.Model.Park_Root> result = new List<Park_Database.Model.Park_Root>();
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = "Select * from Park_Root";
            var reader = command.ExecuteReader();



            while (reader.Read())
            {
                Park_Database.Model.Park_Root item = new Park_Database.Model.Park_Root();
                item.Root_ID = reader["Root_ID"].ToString();
                item.Root_Password = reader["Root_Password"].ToString();
                item.Root_Authority = reader["Root_Authority"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result;
        }

        public void Create(Park_Database.Model.Park_Root CP)
        {
            var connection = new System.Data.SqlClient.SqlConnection(_connection);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Park_Root(Root_ID,Root_Password, Root_Authority)
VALUES          (N'{0}',N'{1}',N'{2}')
", CP.Root_ID, CP.Root_Password, CP.Root_Authority);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
