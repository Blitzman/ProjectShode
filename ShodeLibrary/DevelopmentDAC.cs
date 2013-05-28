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
            string result = "The development has been succesfully added!";
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO developments (project, usr, date, gitbranch, ups) " +
                    "VALUES ('" + development.Project.Code + "','" + development.User.Email +
                    "','" + development.Date.ToString("dd/mm/yyyy") + "','" + development.GitBranch + 
                    "'," + development.Ups.ToString() + ")", c);

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

        public int getTotalDevelopments()
        {
            int developmentsCount = 0;

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT count(*) total FROM developments", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                developmentsCount = Int32.Parse(dr["total"].ToString());
            }

            c.Close();

            return developmentsCount;
        }

        public void update(DevelopmentBE development)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE developments " +
                "SET project='" + development.Project.Code + "', usr='" + development.User.Email +
                "', date='" + development.Date.ToString("dd/mm/yyyy") + "', gitbranch='" + development.GitBranch + 
                "', ups=" + development.Ups.ToString(), c);

            com.ExecuteNonQuery();
            c.Close();
        }
        
        public void delete(DevelopmentBE development)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("DELETE FROM developments WHERE " +
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
