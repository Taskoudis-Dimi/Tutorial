using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Lesson1.DataAccess
{
    public class SqlConnector
    {        
        SqlConnection con = new SqlConnection();
        public DataTable table = new DataTable();
        
        public SqlConnector()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Tutorial"].ConnectionString;
        }

        public void retrieveData(string command)
        {
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                adapter.Fill(table);

            }
            catch(Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        public void commandExc(string command)
        {
            try
            {
                con.Open();
                SqlCommand sqlcomm = new SqlCommand(command, con);

                int rowInfected = sqlcomm.ExecuteNonQuery();
                if (rowInfected > 0)
                {
                    Console.WriteLine("Success to connect with db!");
                }
                else
                {
                    Console.WriteLine("Fail to connect with db!");
                }
            }
            catch(Exception ex)
            {

            }
        }


    }
    
}

