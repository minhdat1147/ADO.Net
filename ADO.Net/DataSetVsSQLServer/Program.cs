using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataSetVsSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                // tao bang Customer
                DataTable Customer = new DataTable("Customer");
                DataColumn CustomerId = new DataColumn("Id", typeof(Int32));
                Customer.Columns.Add(CustomerId);
                DataColumn CustomerName = new DataColumn("Name", typeof(String));
                Customer.Columns.Add(CustomerName);
                DataColumn CustomerMobile = new DataColumn("Mobile", typeof(int));
                Customer.Columns.Add(CustomerMobile);
                Customer.Rows.Add(101, "Minh Dat", 0907876260);
                Customer.Rows.Add(102, "Kim Thao", 0345692872);
                // bang Order
                DataTable Orders = new DataTable("Orders");
                DataColumn OrderId = new DataColumn("Id", typeof(Int32));
                Orders.Columns.Add(OrderId);
                DataColumn CustId = new DataColumn("CustomerId", typeof(Int32));
                Orders.Columns.Add(CustId);
                DataColumn OrderAmount = new DataColumn("Amount", typeof(Int32));
                Orders.Columns.Add(OrderAmount);

                Orders.Rows.Add(10001, 101, 200000);
                Orders.Rows.Add(10002, 102, 3000000);

                //Tao moi 1 intance DataSet
                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(Customer);
                dataSet.Tables.Add(Orders);
                Console.WriteLine("Du lieu trong bang Customer");
                foreach(DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine(row["Id"]+", "+row["Name"]+", "+row["Mobile"]);
                }
                Console.WriteLine("Du lieu trong bang order");
                foreach(DataRow row in dataSet.Tables["Orders"].Rows)
                {
                    Console.WriteLine(row["Id"] + ", " + row["CustomerId"] + ", " + row["Amount"]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Loi!!!"+e);
            }
            Console.ReadKey();
        }
    }
}
