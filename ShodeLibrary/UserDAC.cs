using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Sergiu
 */
namespace ShodeLibrary
{
    class UserDAC
    {

        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public UserDAC()
        {
            // Gets the string connection from a unique location
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */

        //Method that creates a new user of type UserBe
        public void insertUser(UserBE user)
        {

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
            //Code for updating an user of the DB, with new user data.
        }

        public void deleteUser(string email)
        {
            //Code for deleting the user with the specified email.
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private String connection;
    }
}
