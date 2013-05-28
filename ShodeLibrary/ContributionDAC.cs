using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the data access component of the contributions. This class will allow
    /// performing CRUD operations directly with the database so it will be
    /// an intermediate layer between the business entity of the contribution and
    /// the raw database.
    /// </summary>
    public class ContributionDAC
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new data access component by initializing the field
        /// which holds the connection string to the database connection string
        /// value which is stored in the Web.config file.
        /// </summary>
        public ContributionDAC()
        {
            // Gets the string connection from a unique location (Web.config file)
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Contribution Insertion.
        /// Inserts the given contribution in the database building the adequate
        /// quer and handling the possible SQL errors that can occur when performing
        /// the query. 
        /// </summary>
        /// <param name="contribution">The contribution to be inserted.</param>
        /// <returns>A string which contains an error/success message.</returns>
        public string insert(ContributionBE contribution)
        {
            // We will be using the connected access model.

            string result = "The contribution has been succesfully added!";
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO contributions (project, usr, date, amount) " +
                    "VALUES ('" + contribution.Project.Code + "','" + contribution.Contributor.Email +
                    "','" + contribution.Date.ToString("dd/MM/yyyy") + "'," + contribution.Amount.ToString() + ")", c);

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

        /// <summary>
        /// Contributions Amount Getter.
        /// This is an statistical mehtod which gets the amount of
        /// credits that have been contributed if we sum up all the
        /// contributions.
        /// </summary>
        /// <returns>The total amount of credits contributed.</returns>
        public int getTotalAmountInContributions()
        {
            // We will be using the connected access model.

            int amount = 0;

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            // Change this!!!
            SqlCommand com = new SqlCommand("SELECT count(*) total FROM contributions", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                amount = Int32.Parse(dr["total"].ToString());
            }

            c.Close();

            return amount;
        }

        /// <summary>
        /// Total Contributions Getter.
        /// This is another statistical method which obtains the
        /// total amount of contributions that have been made.
        /// </summary>
        /// <returns>The total amount of contributions.</returns>
        public int getTotalContributions()
        {
            // We will be using the connected access model.

            int contributionCount = 0;

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT count(*) total FROM contributions", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                contributionCount = Int32.Parse(dr["total"].ToString());
            }

            c.Close();

            return contributionCount;
        }

        /// <summary>
        /// Contribution Update.
        /// Updates the database register which matches the given
        /// contribution replacing all the database fields with
        /// the ones of the provided contribution.
        /// </summary>
        /// <param name="contribution">The "source" contribution that will be updated.</param>
        public void update(ContributionBE contribution)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE contributions " +
                "SET project='" + contribution.Project.Code + "', usr='" + contribution.Contributor.Email +
                "', date='" + contribution.Date.ToString("dd/MM/yyyy") + "', amount=" + contribution.Amount.ToString(), c);

            com.ExecuteNonQuery();
            c.Close();
        }

        /// <summary>
        /// Contribution Deletion.
        /// Deletes a contribution from the database given all the needed
        /// details of the contribution to be deleted.
        /// </summary>
        /// <param name="contribution">The contribution that will be deleted.</param>
        public void delete(ContributionBE contribution)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("DELETE FROM contributions WHERE " +
                "project='" + contribution.Project.Code + "' AND usr='" + contribution.Contributor.Email +
                "' AND date='" + contribution.Date.ToString("dd/MM/yyyy") + "'", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private string connection;
    }
}
