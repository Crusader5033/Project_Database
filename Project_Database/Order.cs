using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{
    public class Order
    {
        private int id;
        private int cust_id;
        private DateTime date = DateTime.Now;



        

        public int Id { get => id; set => id = value; }
        public int Cust_id { get => cust_id; set => cust_id = value; }
        public DateTime Date { get => date; set => date = value; }

        public void AddOrder(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("INSERT INTO orders (cust_id,date) VALUES (@Cust_id, @Date)", conn))
            {


                command.Parameters.Add(new SqlParameter("@Cust_id",id));
                command.Parameters.Add(new SqlParameter("@Date", this.Date));
                command.ExecuteNonQuery();



            }
        }
        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM orders WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
                this.Id = 0;
            }
        }
        public void UpdateOrderCustomer(int newData, int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("UPDATE orders SET cust_id=@newData WHERE id=@id", conn))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

            }
        }

        public int GetCustID(string name)
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
