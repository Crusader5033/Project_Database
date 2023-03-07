using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Project_Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

           string cont = "y";



          

            while (cont == "y")
                {
            Console.WriteLine("Choose operation : \n");
            Console.WriteLine(" 0.Exit \n 1.Add entry\n 2.Remove entry \n 3.Update entry  ");
            int operation = 0;
            

            while (true)
            {
                try
                {
                    Console.WriteLine("Type answer: ");
                    operation = Convert.ToInt32(Console.ReadLine());// vyber operace

                    Console.WriteLine();
                    break;
                }
                catch (System.FormatException)
                {
                    Console.Write("Only whole numbers!!! ");
                    Console.WriteLine();
                }
            }



                switch (operation)
                {

                    case 0:
                        cont= "n";


                        break;





                    case 1:

                        Console.WriteLine("What do you want to add? : \n");
                        Console.WriteLine(" 0.Return\n 1.Customer\n 2.Developer \n 3.Order \n 4.Product");
                        int choice = 0;
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Type answer: ");
                                choice = Convert.ToInt32(Console.ReadLine());// vyber tabulky
                                switch (choice)
                                {
                                    case 1:

                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Type whole name: ");
                                                string name = (Console.ReadLine());
                                                Console.WriteLine("Type whole address: ");
                                                string address = (Console.ReadLine());
                                                Console.WriteLine("Type email: ");
                                                string email = (Console.ReadLine());
                                                Customer c = new Customer(name, address, email);
                                                c.AddCustomer();
                                                Console.WriteLine("Want to continue? y/n ");
                                                cont = (Console.ReadLine());


                                                break;
                                            }
                                            catch (Exception e)
                                            {

                                                Console.WriteLine(e + " \n Try it all again!!! \n(Dont forget @ in email)");
                                            }

                                        }



                                        break;







                                    case 2:
                                        while (true)
                                        {
                                         try
                                        {
                                            Console.WriteLine("Type surname: ");
                                            string name = (Console.ReadLine());
                                            Console.WriteLine("Type country: ");
                                            string country = (Console.ReadLine());

                                            Developer d = new Developer(name, country);
                                            d.AddDeveloper();
                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());


                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        }
                                        }
                                       


                                        break;

                                    case 3:

                                        while (true) {
                                            try
                                        {
                                            Console.WriteLine("Type name of customer making order: ");
                                            string name = (Console.ReadLine());
                                            Order o = new Order();
                                            int cust_id = o.GetCustID(name);
                                            Console.WriteLine("Id of customer: " + cust_id);
                                            int orderId=o.AddOrder(cust_id);
                                           


                                            Console.WriteLine("Type name of product that you want in order: ");
                                            name = (Console.ReadLine());
                                            Product p = new Product();
                                            int product_id = p.GetProductID(name);


                                            Console.WriteLine("No. of products: ");
                                            int amount = int.Parse(Console.ReadLine());

                                            Console.WriteLine("is it already payed?(Use true or false) : ");
                                            bool payed = bool.Parse(Console.ReadLine());

                                            Order_Details od = new Order_Details(orderId, product_id, amount, payed);
                                            od.AddDetails();
                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());


                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        } }
                                       


                                        break;




                                    case 4:

                                        while (true)
                                        {
                                            try
                                        {
                                            Console.WriteLine("Type name of developer: ");
                                            string nameDev = (Console.ReadLine());
                                            Product p = new Product();
                                            int dev_id = p.GetDevID(nameDev);


                                            Console.WriteLine("Type name of product : ");
                                            string name = (Console.ReadLine());

                                            Console.WriteLine("Price of product: ");
                                            decimal price = decimal.Parse(Console.ReadLine());
                                            Product p1 = new Product(name, price);
                                            p1.AddProduct(dev_id);




                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());


                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        }

                                        }
                                       

                                        break;

                                }


                                break;
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine(e);
                            }

                        }


                        break;

                    case 2:
                        Console.WriteLine("What do you want to remove? : \n");
                        Console.WriteLine(" 0.Return\n 1.Customer\n 2.Developer \n 3.Order \n 4.Product");
                        choice = 0;
                        while (true)
                        {

                            try
                            {
                                Console.WriteLine("Type answer: ");
                                choice = Convert.ToInt32(Console.ReadLine());// vyber tabulky

                                switch (choice)
                                {

                                    case 1:
                                        while (true)
                                        {
                                            try
                                        {
                                            Console.WriteLine("Type whole name: ");
                                            string name = (Console.ReadLine());

                                            Customer c = new Customer();
                                            int id = c.GetCustomerID(name);
                                            c.Delete(id);

                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());


                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        }

                                        }
                                       


                                        break;

                                    case 2:
                                        while (true)
                                        {
                                            try
                                        {
                                            Console.WriteLine("Type  name: ");
                                            string name = (Console.ReadLine());

                                            Developer d = new Developer();
                                            int id = d.GetDeveloperID(name);
                                            d.Delete(id);

                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());


                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        }

                                        }
                                       


                                        break;

                                    case 3:

                                        while (true)
                                        {
                                            try
                                        {
                                            Console.WriteLine("Type id of order: ");
                                            int id = int.Parse(Console.ReadLine());
                                            Order o = new Order();
                                            Order_Details od = new Order_Details();
                                            od.Delete(id);
                                            o.Delete(id);

                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());


                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        }

                                        }
                                       


                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            try
                                        {
                                            Console.WriteLine("Type name of product: ");
                                            string name = (Console.ReadLine());
                                            Product p = new Product();
                                            int id = p.GetProductID(name);
                                            p.Delete(id);

                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());



                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        }


                                        }
                                        

                                        break;

                                }
                                break;

                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }





                        }

                        break;






                    case 3:
                        Console.WriteLine("What do you want to update? : \n");
                        Console.WriteLine(" 0.Return\n 1.Customer\n 2.Developer \n 3.Order \n 4.Product");
                        
                        
                        while (true)
                        {

                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Type answer: ");
                                    choice = Convert.ToInt32(Console.ReadLine());// vyber operace

                                    Console.WriteLine();
                                    break;
                                }
                                catch (System.FormatException)
                                {
                                    Console.Write("Only whole numbers!!! ");
                                    Console.WriteLine();
                                }
                            }

                            try
                            {
                                switch (choice)
                                {
                                    case 1:
                                        while (true)
                                        {
                                            try
                                            {
                                                Customer c = new Customer();
                                                Console.WriteLine("What do you want to update:1.Name 2.Address: ");
                                                int dec = Convert.ToInt32(Console.ReadLine());// vyber operace
                                                Console.WriteLine();
                                                if (dec == 1)
                                                { Console.WriteLine("Type old  name of customer: ");
                                                    string oldName = (Console.ReadLine());
                                                    Console.WriteLine("Type new full name of customer: ");
                                                    string name = (Console.ReadLine());

                                                    c.UpdateCustomerName(name, oldName);

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Type old  address of customer: ");
                                                    string oldAddress = (Console.ReadLine());
                                                    Console.WriteLine("Type new full address of customer: ");
                                                    string address = (Console.ReadLine());
                                                    c.UpdateCustomerAddress(address, oldAddress);

                                                }









                                                Console.WriteLine("Want to continue? y/n ");
                                                cont = (Console.ReadLine());



                                                break;
                                            }
                                            catch (Exception e)
                                            {

                                                Console.WriteLine(e);
                                            }
                                        }


                                        break;

                                    case 2:

                                        while (true)
                                        {
                                            try
                                            {
                                                Developer d = new Developer();
                                                Console.WriteLine("What do you want to update:1.Name 2.Country: ");
                                                int dec = Convert.ToInt32(Console.ReadLine());// vyber operace
                                                Console.WriteLine();
                                                if (dec == 1)
                                                {
                                                    Console.WriteLine("Type old  name of developer: ");
                                                    string oldName = (Console.ReadLine());
                                                    Console.WriteLine("Type new full name of developer: ");
                                                    string name = (Console.ReadLine());

                                                    d.UpdateDeveloperName(name, oldName);

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Type name of developer: ");
                                                    string oldName = (Console.ReadLine());
                                                    Console.WriteLine("Type new country of developer: ");
                                                    string newCountry = (Console.ReadLine());
                                                    d.UpdateDeveloperCountry(newCountry, oldName);

                                                }









                                                Console.WriteLine("Want to continue? y/n ");
                                                cont = (Console.ReadLine());



                                                break;
                                            }
                                            catch (Exception e)
                                            {

                                                Console.WriteLine(e);
                                            }
                                        }


                                        break;

                                    case 3:
                                        while (true)
                                        { 
                                            try
                                        {
                                            Order o = new Order();
                                            Console.WriteLine("Type old  customer for this order: ");
                                            string oldName = (Console.ReadLine());
                                            int oldId = o.GetCustID(oldName);
                                            Console.WriteLine("Type new  customer for this order: ");
                                            string name = (Console.ReadLine());

                                            int id = o.GetCustID(name);

                                            o.UpdateOrderCustomer(id, oldId);



                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());



                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        }

                                        }
                                       


                                        break;


                                    case 4:
                                        while (true)
                                        { 
                                            try
                                        {
                                            Console.WriteLine("Type old  name of product: ");
                                            string oldName = (Console.ReadLine());
                                            Console.WriteLine("Type new full name of product: ");
                                            string name = (Console.ReadLine());
                                            Product p = new Product();
                                            p.UpdateProductName(name, oldName);
                                            int id = p.GetProductID(name);

                                            Console.WriteLine("Type new price: ");
                                            double price = double.Parse(Console.ReadLine());
                                            p.UpdateProductPrice(price, id);


                                            Console.WriteLine("Want to continue? y/n ");
                                            cont = (Console.ReadLine());



                                            break;
                                        }
                                        catch (Exception e)
                                        {

                                            Console.WriteLine(e);
                                        }

                                        }
                                       


                                        break;






                                }

                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }


                            break;


                        }

                        break;
                }



            }
        }
    }
}

