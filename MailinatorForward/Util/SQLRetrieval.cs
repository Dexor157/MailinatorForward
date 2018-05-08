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
        public String GetEmail(int id)
        {
            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            string connectionString = String.Format("Data Source=intrideo-can-test-sql.database.windows.net;" +
                                            "Initial Catalog=intrideo-can-test-db;" +
                                            "user id={0};" +
                                            "password={1}", username, password);
            string queryString = "SELECT [ApplicantId],[Email]FROM[dbo].[Applicants]";


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
                        if((int)reader[0] == id) {
                            
                            return (String)reader[1];
                        }
                        
                        
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Console.ReadLine();
            }

            return "DATANOTFOUND";
        }
    }
}

