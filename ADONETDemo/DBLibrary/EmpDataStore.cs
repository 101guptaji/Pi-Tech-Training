using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DBLibrary
{
    public class EmpDataStore
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataReader reader = null;

        public EmpDataStore(string connStr)
        {
            connection = new SqlConnection(connStr);
        }

        //get all emp details
        public List<Emp> GetEmps()
        {
            try
            {
                string sql = "select empno,ename,hiredate,sal from emp";
                command = new SqlCommand(sql, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                reader = command.ExecuteReader();
                List<Emp> empList = new List<Emp>();

                while(reader.Read())
                {
                    Emp emp = new Emp();
                    emp.Empno = (int)reader["empno"];
                    emp.EmpName = reader["ename"].ToString();
                    emp.HireDate = reader["hiredate"] as DateTime?;
                    emp.Salary = reader["sal"] as decimal?;

                    empList.Add(emp);
                }
                return empList;
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

        //get emp info by empno
        public Emp GetEmps(int EmpNo)
        {
            try
            {
                //string sql = "select ename,hiredate,sal from emp where empno=" + EmpNo;
                //can cause sql injection so use parameter to sql

                string sql = "select ename,hiredate,sal from emp where empno= @eno";
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("eno", EmpNo);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                reader = command.ExecuteReader();
                
                Emp emp = null;

                if (reader.Read())
                {
                    emp = new Emp();
                    emp.Empno = EmpNo;
                    emp.EmpName = reader["ename"].ToString();
                    emp.HireDate = reader["hiredate"] as DateTime?;
                    emp.Salary = reader["sal"] as decimal?;
                }
                    return emp;
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

        public int DeleteEmpSql(int empno)
        {
            try
            {
               
                string sql = "delete from emp where empno=@eno";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("eno", empno);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                int count = command.ExecuteNonQuery();

                return count;
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

        public int UpdateEmpSql(Emp emp)
        {
            try
            {
                Emp emp2 =GetEmps(emp.Empno);
                string sql;
                sql = "update emp set ename=@ename, hiredate=@hire, sal=@sal where empno=@eno";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("eno", emp.Empno);
                command.Parameters.AddWithValue("ename", emp.EmpName ?? emp2.EmpName);
                command.Parameters.AddWithValue("hire", emp.HireDate ?? emp2.HireDate);
                command.Parameters.AddWithValue("sal", emp.Salary ?? emp2.Salary );

                foreach (SqlParameter item in command.Parameters)
                {
                    if (item.Value == null)
                    {
                        item.Value = DBNull.Value;
                    }
                }

                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                int count = command.ExecuteNonQuery();

                return count;
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

        //create method which insert emp record, take all require value from user
        public int InsertEmp(Emp emp)
        {
            try
            {
                string sql;
                sql = "insert into emp(empno, ename, hiredate, sal) values(@eno, @ename, @hire,@sal)";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("eno", emp.Empno);
                command.Parameters.AddWithValue("ename", emp.EmpName);
                command.Parameters.AddWithValue("hire", emp.HireDate);
                command.Parameters.AddWithValue("sal", emp.Salary);
                
                foreach (SqlParameter item in command.Parameters)
                {
                    if (item.Value == null)
                    {
                        item.Value = DBNull.Value;
                    }
                }

                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                int count=command.ExecuteNonQuery();

                return count;
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

        public int InsertEmp_SP(Emp emp)
        {
            try
            {
                
                command = new SqlCommand("INSERTEMP_SP", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("eno", emp.Empno);
                command.Parameters.AddWithValue("ename", emp.EmpName);
                command.Parameters.AddWithValue("hire", emp.HireDate);
                command.Parameters.AddWithValue("sal", emp.Salary);

                foreach (SqlParameter item in command.Parameters)
                {
                    if(item.Value==null)
                    {
                        item.Value = DBNull.Value;
                    }
                }
                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                int count = command.ExecuteNonQuery();

                return count;
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
    }
}
