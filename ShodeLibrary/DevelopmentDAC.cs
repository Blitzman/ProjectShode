using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ShodeLibrary
{
    public class DevelopmentDAC
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public DevelopmentDAC()
        {
            // Gets the string connection from a unique location
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public string insert(DevelopmentBE development)
        {
            string result = "User has been succesfully created!";
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO contributions (project, usr, date, amount) " +
                    "VALUES ('" + development.Project.Code + "','" + development.User.Email +
                    "','" + development.Date.ToString("dd/mm/yyyy") + "'," + development.Ups.ToString() + ")", c);

                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                    result = "ERROR: A development has already been made today for that project.";
            }
            finally
            {
                c.Close();
            }

            return result;
        }

        public void update(DevelopmentBE development)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE contributions " +
                "SET project='" + development.Project.Code + "', usr='" + development.User.Email +
                "', date='" + development.Date.ToString("dd/mm/yyyy") + "', amount=" + development.Ups.ToString(), c);

            com.ExecuteNonQuery();
            c.Close();
        }
        
        public void delete(DevelopmentBE development)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("DELETE FROM contributions WHERE " +
                "project='" + development.Project.Code + "' AND usr='" + development.User.Email +
                "' AND date='" + development.Date.ToString("dd/mm/yyyy") + "'", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string connection;
    }
    
}
