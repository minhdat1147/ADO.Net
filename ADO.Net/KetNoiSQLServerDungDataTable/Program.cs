using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace KetNoiSQLServerDungDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Program().Retrieve();
            //new Program().Delete();
            new Program().Remove();
            Console.ReadKey();
        }
        public void Retrieve()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Student", con);
                con.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["Id"] + "  " + row["Name"] + "  " + row["Email"] + "  " + row["Mobile"]);
                }
                Console.WriteLine();
                Console.WriteLine("Dữ lieu bang copy");
                DataTable copyDataTable = dt.Copy();
                if(copyDataTable != null)
                {
                    foreach(DataRow row in copyDataTable.Rows)
                    {
                        Console.WriteLine(row["Id"] + "  " + row["Name"] + "  " + row["Email"] + "  " + row["Mobile"]);
                    }    
                }
                Console.WriteLine();
                Console.WriteLine("Du lieu bang Clone");
                DataTable cloneDataTable = dt.Clone();
                if(cloneDataTable.Rows.Count>0)
                {
                    foreach (DataRow row in cloneDataTable.Rows)
                    {
                        Console.WriteLine(row["Id"] + "  " + row["Name"] + "  " + row["Email"] + "  " + row["Mobile"]);
                    }
                }
                else
                {
                    Console.WriteLine("Du lieu trong bang clone dang trong, hay them du lieu vao bang");
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
        public void Delete()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select *from Student", con);
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("bang du lieu truoc khi bi xoa");
                foreach(DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["Id"] + "  " + row["Name"] + "  " + row["Email"] + "  " + row["Mobile"]);
                }
                Console.WriteLine();
                foreach(DataRow row in dt.Rows)
                {
                   if(Convert.ToInt32(row["Id"]) == 101)
                    {
                        row.Delete();
                        Console.WriteLine("Hoc sinh co ID = 101 da duoc xoa !!!");
                    } 
                   
                }
                dt.AcceptChanges();
                Console.WriteLine();
                Console.WriteLine("-----bang du lieu sau khi Delete-----");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["Id"] + "  " + row["Name"] + "  " + row["Email"] + "  " + row["Mobile"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi!!!"+e);
            }
            finally
            {
                con.Close();
            }
        }
        public void Remove()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Student", con);
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("Bang du lieu khi chua duoc xoa");
                foreach(DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["id"] + ", " + row["Name"] + ", " + row["Email"] + ", " + row["Mobile"]);
                }
                Console.WriteLine();
                Console.WriteLine("Du lieu sau khi xoa");
                foreach(DataRow row in dt.Select())
                {
                    if(Convert.ToInt32(row["Id"]) == 102)
                    {
                        dt.Rows.Remove(row);
                        Console.WriteLine("Du lieu co id = 102 da duoc xoa");
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["id"] + ", " + row["Name"] + ", " + row["Email"] + ", " + row["Mobile"]);
                }
            }
            catch (Exception e)
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
