using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class CustomerContext
    {
        public string connectionString { get; set; }
        public CustomerContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public List<Supplier> getCustomer()
        {
            List<Supplier> list = new List<Supplier>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Customer", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            list.Add(new Supplier()
                            {
                                id = Convert.ToInt32(reader["id"]),
                                name = reader["customerName"].ToString(),
                                email = reader["email"].ToString(),
                                phone = reader["phone"].ToString()
                            });
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                    conn.Close();
                }

            }
            return list;
        }
        public List<Supplier> searchCustomer(string empSearch)
        {
            List<Supplier> list = new List<Supplier>();
            using (MySqlConnection conn = GetConnection())
            {
                bool isInt = int.TryParse(empSearch, out int id);
                if (isInt)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from Customer where id='" + id + "'", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Supplier()
                            {
                                id = Convert.ToInt32(reader["id"]),
                                name = reader["customerName"].ToString(),
                                email = reader["email"].ToString(),
                                phone = reader["phone"].ToString()
                            });
                        }
                        conn.Close();
                    }
                }
                else
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from Customer where customerName like '%" + empSearch + "%'", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Supplier()
                            {
                                id = Convert.ToInt32(reader["id"]),
                                name = reader["customerName"].ToString(),
                                email = reader["email"].ToString(),
                                phone = reader["phone"].ToString()
                            });
                        }
                        conn.Close();
                    }
                }


            }
            return list;
        }
        public void insert(Supplier obj)
        {
            String insertQuery = "insert into Customer(customerName,email,phone) values('" + obj.name + "','" + obj.email + "','" + obj.phone + "')";

            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void update(Supplier obj)
        {

            String updateQuery = "update Customer set customerName = '" + obj.name + "', email='" + obj.email + "', phone='" + obj.phone + "' where id='" + obj.id + "'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void delete(int id)
        {
            String deleteQuery = "Delete from Customer where id='" + id + "'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
