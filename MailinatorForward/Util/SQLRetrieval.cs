using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MailinatorForward.Util
{
    class SQLRetrieval
    {
        public User GetUser()
        {

            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            string connectionString = String.Format("Data Source=intrideo-can-test-sql.database.windows.net;" +
                                            "Initial Catalog=intrideo-can-test-db;" +
                                            "user id={0};" +
                                            "password={1}", username, password);

            string queryString = "SELECT [ApplicantId],[Email],[FirstName],[LastName]FROM[dbo].[Applicants]";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if(IsValidEmail((reader[1]).ToString())) {

                            return new User(
                                reader[2].ToString(),
                                reader[3].ToString(), 
                                reader[1].ToString(), 
                                int.Parse(reader[0].ToString())
                                );
                            
                        }
                        
                        
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("No user found");
            return new User("Notauser","Notauser","NULL",-1); ;
        }

        public User GetUser(int id)
        {

            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            string connectionString = String.Format("Data Source=intrideo-can-test-sql.database.windows.net;" +
                                            "Initial Catalog=intrideo-can-test-db;" +
                                            "user id={0};" +
                                            "password={1}", username, password);

            string queryString = "SELECT [ApplicantId],[Email],[FirstName],[LastName]FROM[dbo].[Applicants]";

            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (IsValidEmail((reader[1]).ToString()) && (int)reader[0] == id)
                        {

                            return new User(
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[1].ToString(),
                                int.Parse(reader[0].ToString())
                                );

                        }


                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("User not found");
            return new User("Notauser", "Notauser", "NULL", -1); ;
        }

        public Boolean IsValidEmail(string email) {

            if (email.Contains("@mailinator.com")) {
                return true;
            }
            else { return false; }

        }
    }
}

