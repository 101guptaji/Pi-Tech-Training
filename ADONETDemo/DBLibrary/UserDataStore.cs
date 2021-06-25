using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class UserDataStore
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataReader reader = null;

        public UserDataStore(string connStr)
        {
            connection = new SqlConnection(connStr);
        }

        public bool ValidateUserConnect(UserData us)
        {
            
            try
            {
                string sql;
                sql = "Select * from userdata where username=@user and password=@pass";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("user", us.UserName);
                command.Parameters.AddWithValue("pass", us.Password);
               
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }

        public bool ValidateUserDisconn(UserData ud)
        {
            try
            {
                string sql = "Select * from userdata";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "userdata");

                DataTable table = ds.Tables["userdata"];

                //string express = "username='admin' and password='123'";

                string express = $"username='{ud.UserName}' and password='{ud.Password}'";

                DataRow[] row1 = table.Select(express);

                if (row1.Length > 0)
                    return true;
                //foreach (DataRow row in ds.Tables["userdata"].Rows)
                //{
                //    if (row["username"].Equals($"'{ud.UserName}'") && row["password"].Equals($"'{ud.Password}'"))
                //        return true;
                //}
                return false;
            }
            catch (SqlException)
            {
                throw;
            }
            

        }
    }
}
