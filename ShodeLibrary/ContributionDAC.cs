﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
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
        /// query and handling the possible SQL errors that can occur when performing
        /// the query. 
        /// </summary>
        /// <param name="contribution">The contribution to be inserted.</param>
        /// <returns>A string which contains an error/success message.</returns>
        public string insert(ContributionBE contribution)
        {
            // We will be using the connected access model.

            string result = "The contribution has been succesfully added!";

            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();

                SqlParameter project = new SqlParameter();
                project.ParameterName = "@project";
                project.Value = contribution.Project.Code;
                SqlParameter usr = new SqlParameter();
                usr.ParameterName = "@usr";
                usr.Value = contribution.Contributor.Email;
                SqlParameter date = new SqlParameter();
                date.ParameterName = "@date";
                date.Value = contribution.Date.ToString("G");
                SqlParameter amount = new SqlParameter();
                amount.ParameterName = "@amount";
                amount.Value = contribution.Amount.ToString();

                SqlCommand com = new SqlCommand("INSERT INTO contributions (project, usr, date, amount)" +
                    "VALUES (@project, @usr, @date, @amount)", c);

                com.Parameters.Add(project);
                com.Parameters.Add(usr);
                com.Parameters.Add(date);
                com.Parameters.Add(amount);

                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                    result = "ERROR: A contribution has already been made today for that project.";
            }
            catch (Exception exg)
            {
                result = "ERROR: Unknown error, try it again later...";
            }
            finally
            {
                c.Close();
            }

            return result;
        }

        /// <summary>
        /// Contributions Amount Getter.
        /// This is an statistical method which gets the amount of
        /// credits that have been contributed if we sum up all the
        /// contributions.
        /// </summary>
        /// <returns>The total amount of credits contributed.</returns>
        public int getTotalAmountInContributions()
        {
            // We will be using the connected access model.

            int amount = 0;

            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("SELECT count(*) total FROM contributions", c);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    amount = Int32.Parse(dr["total"].ToString());
                }
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

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

            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("SELECT count(*) total FROM contributions", c);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    contributionCount = Int32.Parse(dr["total"].ToString());
                }

            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

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

            try
            {
                c.Open();

                SqlParameter project = new SqlParameter();
                project.ParameterName = "@project";
                project.Value = contribution.Project.Code;
                SqlParameter usr = new SqlParameter();
                usr.ParameterName = "@usr";
                usr.Value = contribution.Contributor.Email;
                SqlParameter date = new SqlParameter();
                date.ParameterName = "@date";
                date.Value = contribution.Date.ToString("dd/MM/yyyy");
                SqlParameter amount = new SqlParameter();
                amount.ParameterName = "@amount";
                amount.Value = contribution.Amount.ToString();

                SqlCommand com = new SqlCommand("UPDATE contributions " +
                    "SET project=@project, usr=@usr, date=@date, amount=@amount " +
                    "WHERE project=@project AND usr=@usr AND date=@date", c);

                com.Parameters.Add(project);
                com.Parameters.Add(usr);
                com.Parameters.Add(date);
                com.Parameters.Add(amount);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }
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

            try
            {
                c.Open();

                SqlParameter project = new SqlParameter();
                project.ParameterName = "@project";
                project.Value = contribution.Project.Code;
                SqlParameter usr = new SqlParameter();
                usr.ParameterName = "@usr";
                usr.Value = contribution.Contributor.Email;
                SqlParameter date = new SqlParameter();
                date.ParameterName = "@date";
                date.Value = contribution.Date.ToString("dd/MM/yyyy");

                SqlCommand com = new SqlCommand("DELETE FROM contributions " +
                    "WHERE project=@project AND usr=@usr AND date=@date", c);

                com.Parameters.Add(project);
                com.Parameters.Add(usr);
                com.Parameters.Add(date);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }
        }

        /// <summary>
        /// User Contributions Getter.
        /// This function obtains the contributions that have been made
        /// by a given user.
        /// </summary>
        /// <returns>Contributions in a DataSet.</returns>
        public static DataSet getUserContributions(String userEmail)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select code, title, date, amount from contributions, projects" +
                " where projects.code=contributions.project and usr='" +userEmail +
                "' order by date DESC", c);
            da.Fill(d, "contributions");
            c.Close();

            return d;
        }

        /// <summary>
        /// User Top Contributions Getter.
        /// This function obtains the top developments that have been made
        /// by a given user. The top ones are those with higher ammounts.
        /// </summary>
        /// <returns>Top 3 Developments in a DataSet.</returns>
        public static DataSet getUserTopContributions(String userEmail)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select top 3 code, title, date, amount from contributions, projects" +
                " where projects.code=contributions.project and usr='" + userEmail +
                "' order by amount DESC", c);
            da.Fill(d, "topContributions");
            c.Close();

            return d;
        }

        /// <summary>
        /// Total Number of User Developments Getter.
        /// This is a statistical function which obtains the total number of 
        /// developments that have been made by a given user.
        /// </summary>
        /// <returns>The total number of developments.</returns>
        public static int getTotalUserContributions(String userEmail)
        {
            int contributionCount = 0;

            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);

            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("SELECT count(*) total FROM contributions" +
                    " where contributions.usr='" + userEmail + "'", c);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    contributionCount = Int32.Parse(dr["total"].ToString());
                }

            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

            return contributionCount;
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private string connection;
    }
}
