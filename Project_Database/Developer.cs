using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{
    public class Developer
    {
        private int id;
        private string name;
        private string country;
      

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Country { get => country; set => country = value; }
    


        public Developer( string name, string country)
        {
           
            this.name = name;
            this.country = country;
           

        }

        public void AddDeveloper()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("INSERT INTO developers (name,country) VALUES (@Name, @Country)", conn))
            {


                command.Parameters.Add(new SqlParameter("@Name", this.Name));
                command.Parameters.Add(new SqlParameter("@Country", this.Country));
                command.ExecuteNonQuery();



            }
        }
        public void Delete(int id)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM developers WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
                this.Id = 0;
            }
        }

        public void UpdateDeveloperName(string newData, string oldData)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("UPDATE developers SET Name=@newData WHERE Name=@oldData", conn))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@oldData", oldData);
                command.ExecuteNonQuery();

            }
        }
        public void UpdateDeveloperCountry(string newData, string oldData)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("UPDATE developers SET Country=@newData WHERE Country=@oldData", conn))
            {
                command.Parameters.AddWithValue("@newData", newData);
                command.Parameters.AddWithValue("@oldData", oldData);
                command.ExecuteNonQuery();

            }
        }
        public Developer()
        {

        }

        public int GetDeveloperID(string name)
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
