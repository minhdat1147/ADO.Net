using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace StoredProcedure
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //new Program().Insert();
            //new Program().Update();
            new Program().Delete();
            Console.ReadKey();
        }
        public void Insert()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "spInsertStudent";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = con;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = 106;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = "Thai Minh Dattt";
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = "Thaidat072000@gmail.com";
                command.Parameters.Add("@Mobile", SqlDbType.Int).Value = 0908880562;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Them hoc sinh thanh cong");
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi!!!" + e);
            }
            finally
            {
                con.Close();
            }
        }
        public void Update()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spUpdateStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 105;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = "Dieu Linh";
                cmd.Parameters.Add("@Email",SqlDbType.VarChar).Value = "DieuLinh02@gmail.com";
                cmd.Parameters.Add("@Mobile",SqlDbType.Int).Value = 01239472840;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Sua du lieu thanh cong");

            }catch(Exception e)
            {
                Console.WriteLine("Loi!!!"+e);
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spDeleteStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 106;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Xoa Thanh cong");
            }catch(Exception e)
            {
                Console.WriteLine("Loi!!"+e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
