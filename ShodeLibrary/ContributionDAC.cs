using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ShodeLibrary
{
    public class ContributionDAC
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public ContributionDAC()
        {
            // Gets the string connection from a unique location
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public string insert(ContributionBE contribution)
        {
            string result = "The contribution has been succesfully added!";
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO contributions (project, usr, date, amount) " +
                    "VALUES ('" + contribution.Project.Code + "','" + contribution.Contributor.Email +
                    "','" + contribution.Date.ToString("dd/mm/yyyy") + "'," + contribution.Amount.ToString() + ")", c);

                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                    result = "ERROR: A contribution has already been made today for that project.";
            }
            finally
            {
                c.Close();
            }

            return result;
        }

        public void update(ContributionBE contribution)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE contributions " +
                "SET project='" + contribution.Project.Code + "', usr='" + contribution.Contributor.Email +
                "', date='" + contribution.Date.ToString("dd/mm/yyyy") + "', amount=" + contribution.Amount.ToString(), c);

            com.ExecuteNonQuery();
            c.Close();
        }

        public void delete(ContributionBE contribution)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("DELETE FROM contributions WHERE " +
                "project='" + contribution.Project.Code + "' AND usr='" + contribution.Contributor.Email +
                "' AND date='" + contribution.Date.ToString("dd/mm/yyyy") + "'", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string connection;
    }
}
