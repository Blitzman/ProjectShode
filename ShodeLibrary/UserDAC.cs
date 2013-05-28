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
    class UserDAC
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public UserDAC()
        {
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */

        //Method that creates a new user of type UserBe
        public string insert(UserBE user)
        {
            string result = "User has been succesfully created!";
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

        //Method that returns an user of type UserBE
        public UserBE getUser(String email)
        {
            UserBE user = new UserBE();

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM Users WHERE email='" + email + "'", c);

            SqlDataReader dr = com.ExecuteReader();

            while(dr.Read())
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

        //Getter for the user using his nickname
        public UserBE getByNick(String nickname)
        {
            UserBE user = new UserBE();

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM Users WHERE nickname='" + nickname + "'", c);

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

            Console.WriteLine(user.Nickname);

            c.Close();
            return user;
        }

        //Getter for all the users.
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

        public void delete(string email)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("DELETE FROM Users WHERE email ='" + email + "'", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private String connection;
    }
}
