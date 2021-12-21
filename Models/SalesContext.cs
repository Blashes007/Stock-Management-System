using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class SalesContext
    {
        public string connectionString { get; set; }

        public SalesContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public void addNewBill()
        {
            DateTime date = DateTime.Now;
            string conDate = date.ToString("yyyy-MM-dd");
            string insertQuery = "Insert into SalesBillCount (salesDate) values ('"+conDate+"') ";
            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }


        }
        public int billNo()
        {
            
            int billNo=0;
            String query = "Select pBillNo from SalesBillCount ORDER BY pBillNo DESC Limit 1";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        billNo = Convert.ToInt32(reader["pBillNo"]);
                    }
                    conn.Close();
                }
                return billNo;
            }

        }
        public void insert(Sales obj)
        {
            String insertQuery = "insert into Sales(billNo,customerId,productId,quantity,unitPrice) values('" + obj.billNo + "'," + obj.customerId + "," + obj.productId + ",'" + obj.quantity + "',"+obj.unitPrice+")";

            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public List<Sales> getSalesDetails()
        {
            List<Sales> list = new List<Sales>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select billNo, customerId, customer.customerName, productId, product.name, quantity, unitPrice from Sales join customer on customer.id = sales.customerId join product on product.id = sales.productId", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Sales()
                        {
                           billNo = Convert.ToInt32(reader["billNo"]),
                           customerId = Convert.ToInt32(reader["customerId"]),
                           customerName = reader["customerName"].ToString(),
                           productId = Convert.ToInt32(reader["productId"]),
                           productName = reader["name"].ToString(),
                           quantity = Convert.ToInt32(reader["quantity"]),
                           unitPrice = Convert.ToDouble(reader["unitPrice"]),
                           total = Convert.ToInt32(reader["quantity"]) * Convert.ToDouble(reader["unitPrice"])

                        });
                    }
                    conn.Close();
                }

            }
            return list;

        }
        public void delete(int id,int productId)
        {
            System.Diagnostics.Debug.WriteLine("value  is" + id);

            String deleteQuery = "Delete from Sales where billNo='" + id + "' and productId='"+productId+"'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void update(Sales obj)
        {
            System.Diagnostics.Debug.WriteLine("value  is" + obj.billNo);
            System.Diagnostics.Debug.WriteLine("value  is" + obj.productId);
            String updateQuery = "update sales set quantity='"+obj.quantity+"',unitPrice='"+obj.unitPrice+"',customerId='"+obj.customerId+"' where billNo='"+obj.billNo+"' and productId='"+obj.productId+"'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public List<Sales> searchProduct(string productSearch)
        {
            List<Sales> list = new List<Sales>();
            using (MySqlConnection conn = GetConnection())
            {
                //int id;
                bool isInt = int.TryParse(productSearch, out int id);
                if (isInt)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("Select billNo, customerId, customer.customerName, productId, product.name, quantity, unitPrice from Sales join customer on customer.id = sales.customerId join product on product.id = sales.productId where billNo='" + id + "'", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Sales()
                            {
                                billNo = Convert.ToInt32(reader["billNo"]),
                                customerId = Convert.ToInt32(reader["customerId"]),
                                customerName = reader["customerName"].ToString(),
                                productId = Convert.ToInt32(reader["productId"]),
                                productName = reader["name"].ToString(),
                                quantity = Convert.ToInt32(reader["quantity"]),
                                unitPrice = Convert.ToDouble(reader["unitPrice"]),
                                total = Convert.ToInt32(reader["quantity"]) * Convert.ToDouble(reader["unitPrice"])
                            });
                        }
                        conn.Close();
                    }
                }
                


            }
            return list;
        }



    }
}
