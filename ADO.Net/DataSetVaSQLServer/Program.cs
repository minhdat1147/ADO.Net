using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace DataSetVaSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Program().Retrieve();
            new Program().Retrieves();
            Console.ReadKey();
        }
        public void Retrieve()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Customers", con);
                con.Open();
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                Console.WriteLine("Danh sach bang Customers");
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine(row["Id"] + ", " + row["Name"] + ", " + row["Mobile"]);
                }
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
        public void Retrieves()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Customers; select *from Orders", con);
                con.Open();
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "Costomers";
                dataSet.Tables[1].TableName = "Orders";
                Console.WriteLine("Du lieu bang Costomers-------------------");
                foreach (DataRow row in dataSet.Tables["Costomers"].Rows)
                {
                    Console.WriteLine(row["Id"] + ", " + row["Name"] + ", " + row["Mobile"]);
                }
                Console.WriteLine();
                Console.WriteLine("Xuat du lieu bang Orders------------------");
                foreach(DataRow row in dataSet.Tables["Orders"].Rows)
                {
                    Console.WriteLine(row["ID"]+", "+row["CustomerId"]+", "+row["Amount"]);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Loi!!!"+e);
            }
            finally
            {
                con.Close();
            }
        }
    }

}
