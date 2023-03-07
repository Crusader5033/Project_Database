using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{
    public class Order_Details
    {
        private int id;
        private int order_id;
        private int product_id;
        private int amount;
        private bool payed;

        public int Id { get => id; set => id = value; }
        public int Order_id { get => order_id; set => order_id = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public int Amount { get => amount; set => amount = value; }
        public bool Payed { get => payed; set => payed = value; }

        public Order_Details() 
        {
           
        }

        public Order_Details(int order_id,int product_id,int amount,bool payed) 
        {
            this.order_id = order_id;
            this.product_id = product_id;
            this.amount = amount;
            this.payed = payed; 
        }
        public void AddDetails()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("INSERT INTO order_details (order_id,product_id,amount,payed) VALUES (@Order_id, @Product_id,@amount,@Payed)", conn))
            {


                command.Parameters.Add(new SqlParameter("@Order_id", this.order_id));
                command.Parameters.Add(new SqlParameter("@Product_id", this.product_id));
                command.Parameters.Add(new SqlParameter("@Amount", this.Amount));
                command.Parameters.Add(new SqlParameter("@Payed", this.Payed));

                command.ExecuteNonQuery();



            }
        }

        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM order_details WHERE order_id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
                this.Id = 0;
            }
        }
        public void UpdateAmount(int newData, int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("UPDATE order_details SET amount=@newData WHERE id=@OldData", conn))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@OldData", id);
                command.ExecuteNonQuery();

            }
        }









    }
}
