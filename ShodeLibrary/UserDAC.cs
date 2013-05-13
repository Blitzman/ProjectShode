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
                user.Credit = Int32.Parse(dr["credits"].ToString());
            }

            c.Close();
            return user;
        }

        //Getter for the user using his nickname
        public UserBE getUserByNick(String nickname)
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
                user.Credit = Int32.Parse(dr["credits"].ToString());
            }

            c.Close();
            return user;
        }

        //Getter for all the users.
        public List<UserBE> getAllUsers()
        {
            List<UserBE> users = new List<UserBE>();

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM Users WHERE nickname='" + nickname + "'", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                UserBE user = new UserBE();
                user.Name = dr["name"].ToString();
                user.LastName = dr["last_name"].ToString();
                user.Email = dr["email"].ToString();
                user.Nickname = dr["nickname"].ToString();
                user.Password = dr["password"].ToString();
                user.Credit = Int32.Parse(dr["credits"].ToString());
                users.Add(user);
            }

            c.Close();

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
                " WHERE email='" + updatedUser.Email + "'", c);

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
