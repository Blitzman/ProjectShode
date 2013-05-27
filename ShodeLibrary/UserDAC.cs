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
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */

        //Method that creates a new user of type UserBe
        public string insertUser(UserBE user)
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
                    result = "ERROR: The email is already registered";
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
                user.Credit = Int32.Parse(dr["credit"].ToString());
            }

            Console.WriteLine(user.Nickname);

            c.Close();
            return user;
        }

        //Getter for all the users.
        public List<UserBE> getAllUsers()
        {
            List<UserBE> users = new List<UserBE>();

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM Users", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                UserBE user = new UserBE();
                user.Name = dr["name"].ToString();
                user.LastName = dr["last_name"].ToString();
                user.Email = dr["email"].ToString();
                user.Nickname = dr["nickname"].ToString();
                user.Password = dr["password"].ToString();
                user.Credit = Int32.Parse(dr["credit"].ToString());
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
                " password='" + updatedUser.Password + "', credit=" + updatedUser.Credit.ToString() +
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
