﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the data access component of the developments. This class will allow
    /// performing CRUD operations directly with the database so it will be
    /// an intermediate layer between the business entity of the development and
    /// the raw database.
    /// </summary>
    public class DevelopmentDAC
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
        public DevelopmentDAC()
        {
            // Gets the string connection from a unique location (Web.config file)
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Development Insertion.
        /// Inserts the given development in the database building the adequate
        /// query and handling the possible SQL errors that can occur when inserting.
        /// </summary>
        /// <param name="contribution">The development to be inserted.</param>
        /// <returns>A string which contains an error/success message.</returns>
        public string insert(DevelopmentBE development)
        {
            string result = "The development has been succesfully added!";
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO developments (project, usr, date, gitbranch, ups) " +
                    "VALUES ('" + development.Project.Code + "','" + development.User.Email +
                    "','" + development.Date.ToString("dd/MM/yyyy") + "','" + development.GitBranch + 
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

        /// <summary>
        /// Total Number of Developments Getter.
        /// This is a statistical function which obtains the total number of 
        /// developments that have been made.
        /// </summary>
        /// <returns>The total number of developments.</returns>
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

        /// <summary>
        /// Development Update.
        /// Updates the database register which matches the given
        /// development replacing all the database fields with
        /// the ones of the provided development.
        /// </summary>
        /// <param name="contribution">The development that will be used to 
        ///     update the register.</param>
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

        /// <summary>
        /// Development Removal
        /// Deletes a development from the database given all the required
        /// files to identify the development.
        /// </summary>
        /// <param name="contribution">The development that will be removed.</param>
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

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private string connection;
    }
    
}
