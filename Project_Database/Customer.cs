using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{
    public class Customer 
    {
        private int id;
        private string name;
        private string address;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }

        public Customer() { }   

        public Customer( string name, string addres, string email)
        {
            
            this.name = name;
            this.address = addres;
            this.email = email;

        }

        public void AddCustomer()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("INSERT INTO customers (name,address,email) VALUES (@Name, @Address,@Email)", conn))
            {


                command.Parameters.Add(new SqlParameter("@Name", this.Name));
                command.Parameters.Add(new SqlParameter("@Address", this.Address));
                command.Parameters.Add(new SqlParameter("@Email", this.Email));
                command.ExecuteNonQuery();



            }
        }
        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM customers WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
                this.Id = 0;
            }
        }

        public void UpdateCustomerName(string newData, string oldData)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("UPDATE customers SET Name=@newData WHERE Name=@oldData", conn))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@oldData", oldData);
                command.ExecuteNonQuery();

            }
        }
        public void UpdateCustomerAddress(string newData, string oldData)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("UPDATE customers SET Address=@newData WHERE Address=@oldData", conn))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@oldData", oldData);
                command.ExecuteNonQuery();

            }
        }

        public int GetCustomerID(string name)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("Select id from customers WHERE name=@name", conn))
            {
                command.Parameters.AddWithValue("@name", name);


                int id = (int)command.ExecuteScalar();
                return id;

            }
        }








    }
}
