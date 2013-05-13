using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
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
            connection = "data source=.\\SQLEXPRESS;IntegratedSecurity=SSPI;AttachDBFilename=|DataDirectory|\\ShodeDatabase.mdf;UserInstance=true";
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */

        //Method that creates a new user of type UserBe
        public void insertUser(UserBE user)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("INSERT INTO Users (name, last_name, email, nickname, password, credits)" +
                "VALUES ('" + user.Name + "','" + user.LastName + "','" + user.Email + "','" + user.Nickname + "','" +
                user.Password + "', 0)", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        //Method that returns an user of type UserBE
        public UserBE getUser(String email)
        {
            UserBE user = new UserBE();
            //Code for recovering a DataSet type containing User data
            return user;
        }

        //Getter for the user using his nickname
        public UserBE getUserByNick(String nickname)
        {
            UserBE user = new UserBE();
            //Code for recovering an user passing its nickname as parrameter
            return user;
        }

        //Getter for the user using his zipcode
        public List<UserBE> getUserByZip(String zipcode)
        {
            List<UserBE> users = new List<UserBE>();
            //Code for recovering an user using his zipcode.
            return users;
        }

        //Getter for all the users.
        public List<UserBE> getAllUsers()
        {
            List<UserBE> users = new List<UserBE>();

            return users;
        }

        //Getter for the users with more credits.
        public List<UserBE> getTopUsersByCredit()
        {
            List<UserBE> users = new List<UserBE>();

            return users;
        }

        public void updateUser(UserBE updatedUser)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE Users " +
                "SET name='" + updatedUser.Name + "', last_name='" + updatedUser.LastName + "'," +
                " email='" + updatedUser.Email + "', nickname='" + updatedUser.Nickname + "'," +
                " password='" + updatedUser.Password + "', credits=" + updatedUser.Credit.ToString() +
                " WHERE email='" + updatedUser.Email + "')", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        public void deleteUser(string email)
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
