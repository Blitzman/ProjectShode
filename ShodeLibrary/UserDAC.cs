using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Configuration;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the data access component of the users. This class will allow
    /// performing CRUD operations directly with the database so it will be
    /// an intermediate layer between the business entity of the user and
    /// the raw database.s
    /// </summary>
    public class UserDAC
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new user data access component by initializing the field
        /// which holds the connection string to the database connection string
        /// value which is stored in the Web.config file.
        /// </summary>
        public UserDAC()
        {
            // Get the connection string from a fixed location (Web.config file)
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// User Insertion.
        /// Inserts the given user in the database building the adequate query
        /// and handling the possible SQL errors that can occur when performing
        /// the query. 
        /// </summary>
        /// <param name="user">The user to be inserted.</param>
        /// <returns>A string which contains an error/success message.</returns>
        public string insert(UserBE user)
        {
            // We will be using the connected access model.

            string result = "The user has been succesfully created!";
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            try
            {
                SqlCommand com = new SqlCommand("INSERT INTO Users (name, last_name, email, nickname, password, credit)" +
                    "VALUES ('" + user.Name + "','" + user.LastName + "','" + user.Email + "','" + user.Nickname + "','" +
                    user.Password + "', " + user.Credit.ToString() + ")", c);

                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // We capture the SQLException and inspect the content of the
                // exception message to produce an informative but not security
                // compromising error that will be shown to the user.

                if (ex.Message.Contains("PRIMARY KEY"))
                    result = "ERROR: The email is already registered.";
                else if (ex.Message.Contains("UNIQUE KEY"))
                    result = "ERROR: The username is already registered.";
                else
                    result = "ERROR: An error occurred, try again later.";
            }
            finally
            {
                c.Close();
            }

            return result;
        }

        /// <summary>
        /// User Getter by Email.
        /// Fetchs an user from the database using a given email to obtain
        /// the desired user.
        /// </summary>
        /// <param name="email">The email of the requested user.</param>
        /// <returns>An empty user if the user wasn't found and a full user
        /// with all the required one fields if found.</returns>
        public UserBE getUser(String email)
        {
            UserBE user = new UserBE();

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM Users WHERE email='" + email + "'", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                user.Name = dr["name"].ToString();
                user.LastName = dr["last_name"].ToString();
                user.Email = dr["email"].ToString();
                user.Nickname = dr["nickname"].ToString();
                user.Password = dr["password"].ToString();
                user.Credit = Int32.Parse(dr["credit"].ToString());
            }

            c.Close();
            return user;
        }

        /// <summary>
        /// User Getter by Nickname.
        /// Fetchs an user from the database using a given nickname to obtain
        /// the desired user.
        /// </summary>
        /// <param name="nickname">The nickname of the requested user.</param>
        /// <returns>An empty user if the user wasn't found and a full user
        /// with all the required one fields if found.</returns>
        public UserBE getByNick(string nickname)
        {
            // We will be using the connected access model.

            UserBE user = new UserBE();

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM Users WHERE nickname='" + nickname + "'", c);

            SqlDataReader dr = com.ExecuteReader();

            // If the query returned no rows, we will not enter in the loop
            // and the user will remain empty.
            while (dr.Read())
            {
                user.Name = dr["name"].ToString();
                user.LastName = dr["last_name"].ToString();
                user.Email = dr["email"].ToString();
                user.Nickname = dr["nickname"].ToString();
                user.Password = dr["password"].ToString();
                user.Credit = Int32.Parse(dr["credit"].ToString());
            }

            c.Close();
            return user;
        }

        /// <summary>
        /// User Counter.
        /// Queries the database to obtain the total number of users.
        /// </summary>
        /// <returns>The total number of users in the database.</returns>
        public int getUserCount()
        {
            int userCount = 0;

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT count(*) total FROM users", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                userCount = Int32.Parse(dr["total"].ToString());
            }

            c.Close();

            return userCount;
        }

        /// <summary>
        /// User Update.
        /// Updates the database register whose email matches the given
        /// user one and updates all the fields in the database with
        /// the ones of the provided user.
        /// </summary>
        /// <param name="updatedUser">The source user to perform the update.</param>
        public void update(UserBE updatedUser)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE Users " +
                "SET name='" + updatedUser.Name + "', last_name='" + updatedUser.LastName + "'," +
                " email='" + updatedUser.Email + "', nickname='" + updatedUser.Nickname + "'," +
                " password='" + updatedUser.Password + "', credit=" + updatedUser.Credit.ToString() +
                " WHERE email='" + updatedUser.Email + "'", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        /// <summary>
        /// User Deletion.
        /// Deletes a user from the database using the given email
        /// to identify the user which has to be removed.
        /// </summary>
        /// <param name="email">The email of the user that will be deleted.</param>
        public void delete(string email)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("DELETE FROM Users WHERE email ='" + email + "'", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private String connection;
    }
}
