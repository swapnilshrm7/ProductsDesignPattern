using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace FactorySolid
{
    class Repository : IRepository
    {
        SqlConnection connectionObject;
        SqlConnection connectionObject2;
        SqlConnectionStringBuilder builder;
        void setUpConnection()
        {
            connectionObject = new SqlConnection();
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.UserID = "sa";
            builder.Password = "test123!@#";
            builder.InitialCatalog = "AllProductsDatabase";
        }
        public int BookItemById(string x, int id)
        {
            try
            {
                Logging.Instance.Log("Inside Book function", "C:\\LogFile.txt");
                using (connectionObject = new SqlConnection(builder.ConnectionString))
                {
                    connectionObject.Open();
                    String command = "select * from " + x + " where Id = " + id;
                    SqlCommand cmd = new SqlCommand(command, connectionObject);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["IsBooked"].ToString());
                            if (reader["IsBooked"].ToString() == "False")
                            {
                                Execute(x, id, 2);
                                Console.WriteLine("Booked Successfully!");
                                return Convert.ToInt32(reader["Price"]);
                            }
                            else
                            {
                                Console.WriteLine("Product Already Booked , Check again later..");
                                Logging.Instance.Log("Exiting Book function , product already booked", "C:\\LogFile.txt");
                                Logging.Instance.Log("product already booked", "C:\\SaveFile.txt");
                                return 0;
                            }
                            return 0;
                        }
                    }
                    return 0;
                }
            }
            catch (Exception e)
            {
                Logging.Instance.Log("Entry to Catch Block", "C:\\LogFile.txt");

                Console.WriteLine(e.Message);
                Logging.Instance.Log("Exiting Catch Block", "C:\\LogFile.txt");
                return 0;
            }
        }
        public void SaveItemById(string x, int id)
        {
            try
            {
                Logging.Instance.Log("Inside save function", "C:\\LogFile.txt");
                using (connectionObject = new SqlConnection(builder.ConnectionString))
                {
                    connectionObject.Open();
                    String command = "select * from " + x + " where Id = " + id;
                    SqlCommand cmd = new SqlCommand(command, connectionObject);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["IsBooked"].ToString());
                            if (reader["IsBooked"].ToString() == "False")
                            {
                                Execute(x, id, 1);
                                Console.WriteLine("Saved Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Product Already Saved");
                                Logging.Instance.Log("Exiting save function , product already saved", "C:\\LogFile.txt");
                                Logging.Instance.Log("product already saved", "C:\\SaveFile.txt");
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Logging.Instance.Log("Entry to Catch Block", "C:\\LogFile.txt");

                Console.WriteLine(e.Message);
                Logging.Instance.Log("Exiting Catch Block", "C:\\LogFile.txt");
            }
        }
        public void Execute(string x,int id,int BookOrSave)
        {
            SqlConnection connectionObject = new SqlConnection();
            try
            {
                if (BookOrSave == 1)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "localhost";
                    builder.UserID = "sa";
                    builder.Password = "test123!@#";
                    builder.InitialCatalog = "AllProductsDatabase";
                    using (connectionObject = new SqlConnection(builder.ConnectionString))
                    {
                        connectionObject.Open();
                        String command = "update " + x + " SET IsSaved = 1 where Id = " + id;
                        SqlCommand cmd = new SqlCommand(command, connectionObject);
                        cmd.ExecuteNonQuery();
                        connectionObject.Close();
                    }
                }
                else
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "localhost";
                    builder.UserID = "sa";
                    builder.Password = "test123!@#";
                    builder.InitialCatalog = "AllProductsDatabase";
                    using (connectionObject = new SqlConnection(builder.ConnectionString))
                    {
                        connectionObject.Open();
                        String command = "update " + x + " SET IsBooked = 1 where Id = " + id;
                        SqlCommand cmd = new SqlCommand(command, connectionObject);
                        cmd.ExecuteNonQuery();
                        connectionObject.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Logging.Instance.Write
                Console.WriteLine(e.Message);
                //Logging.Instance.Log("Exiting Catch Block");
            }
        }
        public void GetAllProducts(string x)
        {
            try
            {
                Logging.Instance.Log("Inside fetch all products function", "C:\\LogFile.txt");
                setUpConnection();
                using (connectionObject = new SqlConnection(builder.ConnectionString))
                {
                    connectionObject.Open();
                    String command = "select * from " + x;
                    SqlCommand cmd = new SqlCommand(command, connectionObject);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.Write(" id : {0} | Name : {1}", reader["Id"].ToString(), reader["Name"].ToString());
                            if (x == "AirProducts")
                                Console.Write(" |  Departure : {0} |  Arrival : {1}", reader["DepartureTime"].ToString(), reader["ArrivalTime"].ToString());
                            else if (x == "ActivityProducts")
                                Console.Write("  | Start Time : {0} |  Total Time : {1}", reader["StartTime"].ToString(), reader["TotalTime"].ToString());
                            else if (x == "HotelProducts")
                                Console.Write(" |  Room Type : {0} |  CheckIn Time : {1} |  CheckOut Time : {2} |  Rating : {3}", reader["RoomType"].ToString(), reader["CheckIn"].ToString(), reader["CheckOut"].ToString(), reader["Rating"].ToString());
                            else if (x == "CarProducts")
                                Console.Write("  | Start Time : {0} |  End Time : {1}", reader["StartTime"].ToString(), reader["EndTime"].ToString());
                            Console.WriteLine(" |  Price : {0}", reader["Price"].ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logging.Instance.Log("Entry to Catch Block", "C:\\LogFile.txt");

                Console.WriteLine(e.Message);
                Logging.Instance.Log("Exiting Catch Block", "C:\\LogFile.txt");
            }
        }

        public int GetAllBookedProducts()
        {
            try
            {
                Logging.Instance.Log("Inside get all booked products function", "C:\\LogFile.txt");
                int total = 0;
                setUpConnection();
                using (connectionObject = new SqlConnection(builder.ConnectionString))
                {
                    connectionObject.Open();
                    String command = "select * from ActivityProducts where IsBooked = 1";
                    SqlCommand cmd = new SqlCommand(command, connectionObject);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Name : {0} Price : {1}", reader["Name"].ToString(), (Convert.ToInt32(reader["Price"])+80).ToString());
                            total+= Convert.ToInt32(reader["Price"]) + 80;
                        }
                    }
                    command = "select * from CarProducts where IsBooked = 1";
                    cmd = new SqlCommand(command, connectionObject);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Name : {0} Price : {1}", reader["Name"].ToString(), (Convert.ToInt32(reader["Price"]) + 150).ToString());
                            total += Convert.ToInt32(reader["Price"]) + 150;
                        }
                    }
                    command = "select * from AirProducts where IsBooked = 1";
                    cmd = new SqlCommand(command, connectionObject);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Name : {0} Price : {1}", reader["Name"].ToString(), (Convert.ToInt32(reader["Price"]) + 200).ToString());
                            total += Convert.ToInt32(reader["Price"]) + 200;
                        }
                    }
                    command = "select * from HotelProducts where IsBooked = 1";
                    cmd = new SqlCommand(command, connectionObject);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Name : {0} Price : {1}", reader["Name"].ToString(), (Convert.ToInt32(reader["Price"]) + 300).ToString());
                            total += Convert.ToInt32(reader["Price"]) + 300;
                        }
                    }
                    return total;
                }
            }
            catch (Exception e)
            {
                Logging.Instance.Log("Entry to Catch Block", "C:\\LogFile.txt");

                Console.WriteLine(e.Message);
                Logging.Instance.Log("Exiting Catch Block", "C:\\LogFile.txt");
                return 0;
            }
        }
    }
}
