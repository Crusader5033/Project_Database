using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{
    public class Product
    {
        private int id;
        private int dev_id;
        private string name;
        private double price;



        public Product( string name, double price)
        {
            this.name = name;
            this.price = price;


        }
        public Product()
        {

        }

        public int Id { get => id; set => id = value; }
        public int Dev_id { get => dev_id; set => dev_id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }

        public void AddProduct(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("INSERT INTO products (dev_id,name,price) VALUES (@Dev_id, @Name,@Price)", conn))
            {


                command.Parameters.Add(new SqlParameter("@Dev_id", id));
                command.Parameters.Add(new SqlParameter("@Name", this.Name));
                command.Parameters.Add(new SqlParameter("@Price", this.Price));

                command.ExecuteNonQuery();



            }
        }
        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM products WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
                this.Id = 0;
            }
        }
        public void UpdateProductName(string newData, string oldData)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("UPDATE products SET name=@newData WHERE name=@OldData", conn))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@OldData", oldData);
                command.ExecuteNonQuery();

            }
        }
        public void UpdateProductPrice(double newData, int oldData)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("UPDATE products SET price=@newData WHERE id=@OldData", conn))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@OldData", oldData);
                command.ExecuteNonQuery();

            }
        }
        public int GetProductID(string name)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("Select id from products WHERE name=@name", conn))
            {
                command.Parameters.AddWithValue("@name", name);


                int id = (int)command.ExecuteScalar();
                return id;

            }
        }


            public int GetDevID(string name)
            {
                SqlConnection conn = DatabaseSingleton.GetInstance();


                using (SqlCommand command = new SqlCommand("Select id from developers WHERE name=@name", conn))
                {
                    command.Parameters.AddWithValue("@name", name);


                    int id = (int)command.ExecuteScalar();
                    return id;

                }





            }
        }
    }

