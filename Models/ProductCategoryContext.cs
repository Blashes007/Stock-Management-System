using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class ProductCategoryContext
    {
        public string connectionString { get; set; }
        public ProductCategoryContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public List<ProductCategory> getCategories()
        {
            List < ProductCategory > list = new List<ProductCategory>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ProductCatagory", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProductCategory()
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            name = reader["productName"].ToString()
                        }) ;
                    }
                    conn.Close();
                } 
              
            }
            return list;
        }
        public void insert(ProductCategory obj)
        {
            String insertQuery = "insert into productCatagory(productName) values('" + obj.name + "')";

            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void delete(int id)
        {
            String deleteQuery = "Delete from productCatagory where id='"+id+"'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public ProductCategory loadUpdate(int id)
        {
            ProductCategory obj = new ProductCategory();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ProductCatagory where id ='"+id+"'", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.id = Convert.ToInt32(reader["Id"]);
                        obj.name = reader["productName"].ToString();

                    }
                    conn.Close();
                }

            }
            return obj;
        }
        public void update( ProductCategory obj)
        {
           
            String updateQuery = "update productCatagory set productName = '" + obj.name + "' where id='" + obj.id + "'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public List<ProductCategory> searchCatagories(string empSearch)
        {
            List<ProductCategory> list = new List<ProductCategory>();
            using (MySqlConnection conn = GetConnection())
            {

                bool isInt = int.TryParse(empSearch, out int id);
                if (isInt)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from ProductCatagory where id='"+id+"'", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductCategory()
                            {
                                id = Convert.ToInt32(reader["Id"]),
                                name = reader["productName"].ToString()
                            });
                        }
                        conn.Close();
                    }
                }
                else
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from ProductCatagory where productName like '%" + empSearch + "%'", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductCategory()
                            {
                                id = Convert.ToInt32(reader["Id"]),
                                name = reader["productName"].ToString()
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
