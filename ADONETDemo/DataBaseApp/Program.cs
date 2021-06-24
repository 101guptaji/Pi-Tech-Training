using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataBaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------Disconnected Data: Dept table--------");
            DisconnectedData();

            Console.WriteLine("\n\n---------Connected Data: Emp Table--------");
            ConnectedData();

            Console.ReadLine();
        }

        static void DisconnectedData()
        {

            // SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=training; integrated security=true;");
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["trainingConnStr"].ConnectionString);
            string sql = "select * from dept";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "dept");

            //------dispaly data on console
            foreach (DataRow row in ds.Tables["dept"].Rows)
            {
                Console.WriteLine($"DeptNo: {row["deptno"]} \t DeptName: {row["dname"]} \t Location: {row["loc"]}");
            }
        }

        static void ConnectedData()
        {
            // SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=training; integrated security=true;");

            //After configuration the string in App.config
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["trainingConnStr"].ConnectionString);
            
            string sql = "select * from emp";

            SqlCommand command= new SqlCommand(sql, connection);

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine($"EmpName: {reader["ename"]} \t Salary: {reader["sal"]}");

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e) //not neccessary just for handle any other exception
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }
    }
}
