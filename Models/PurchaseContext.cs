using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class PurchaseContext
    {
        public string connectionString { get; set; }

        public PurchaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<Purchase> getPurchaseDetails()
        {
            List<Purchase> list = new List<Purchase>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select billNo,supplierId,productId,supplier.supplierName, product.name, quantity, unitPrice, DATE(purchaseDate) as purchaseDate from purchaseBill join Supplier on Supplier.id = purchaseBill.supplierId join Product on Product.id = purchaseBill.productId", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Purchase()
                        {
                            billNo = reader["billNo"].ToString(),
                            supplierName = reader["supplierName"].ToString(),
                            productName = reader["name"].ToString(),
                            quantity = Convert.ToInt32(reader["quantity"]),
                            unitPrice = Convert.ToDouble(reader["unitPrice"]),
                            purchaseDate = (reader["purchaseDate"]).ToString(),
                            total = Convert.ToInt32(reader["quantity"]) * Convert.ToDouble(reader["unitPrice"]),
                            supplierId = Convert.ToInt32(reader["supplierId"]),
                            productId = Convert.ToInt32(reader["productId"])

                        }) ;
                    }
                    conn.Close();
                }

            }
            return list;

        }
        public void insert(Purchase obj)
        {
            String insertQuery = "insert into PurchaseBill(billNo,supplierId,productId,quantity,unitPrice,purchaseDate) values('" + obj.billNo + "','" + obj.supplierName + "','" + obj.productName + "','" + obj.quantity + "','" + obj.unitPrice + "','" + obj.purchaseDate + "')";

            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void update(Purchase obj)
        {

            String updateQuery = "update PurchaseBill set  quantity='" + obj.quantity+ "',unitPrice='" + obj.unitPrice+ "',purchaseDate='" + obj.purchaseDate+ "' where billNo='" + obj.billNo+ "' and productId='"+obj.productId+"' ";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void delete(Purchase obj)
        {
            System.Diagnostics.Debug.WriteLine("value  is"+""+ obj.billNo);
            System.Diagnostics.Debug.WriteLine("value  is" + "" + obj.productId);
            string deleteQuery = "Delete from PurchaseBill where billNo = '" + obj.billNo + "' and productId='"+obj.productId+"'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public List<Purchase> searchProduct(string productSearch)
        {
            List<Purchase> list = new List<Purchase>();
            using (MySqlConnection conn = GetConnection())
            {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select billNo,supplierId,productId,supplier.supplierName, product.name, quantity, unitPrice, DATE(purchaseDate) as purchaseDate from purchaseBill join Supplier on Supplier.id = purchaseBill.supplierId join Product on Product.id = purchaseBill.productId where billNo='" + productSearch + "'", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Purchase()
                            {
                                billNo = reader["billNo"].ToString(),
                                supplierName = reader["supplierName"].ToString(),
                                productName = reader["name"].ToString(),
                                quantity = Convert.ToInt32(reader["quantity"]),
                                unitPrice = Convert.ToDouble(reader["unitPrice"]),
                                purchaseDate = (reader["purchaseDate"]).ToString(),
                                total = Convert.ToInt32(reader["quantity"]) * Convert.ToDouble(reader["unitPrice"]),
                                supplierId = Convert.ToInt32(reader["supplierId"]),
                                productId = Convert.ToInt32(reader["productId"])

                             });

                        }
                        conn.Close();
                    }
            }
            return list;
        }

    }
}
