using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Sergiu
 */
namespace ShodeLibrary
{
    public class UserBE
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public UserBE()
        {
            name = "";
            lastName = "";
            address = "";
            zipcode = "";
            email = "";
            nickname = "";
            password = "";
        }

        public UserBE(string name, string lastName, string address,
                        string zipcode, string email, string nickname,
                        string password)
        {
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.zipcode = zipcode;
            this.email = email;
            this.nickname = nickname;
            this.password = password;
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public void create()
        {
            UserDAC userDAC = new UserDAC();
            userDAC.insertUser(this);
        }

        public void update()
        {
            UserDAC userDAC = new UserDAC();
            userDAC.updateUser(this);
        }

        public void delete()
        {
            UserDAC userDAC = new UserDAC();
            userDAC.deleteUser(email);
        }

        /* ****************************************************************** */
        /* Properties                                                         */
        /* ****************************************************************** */
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public DateTime LastConnection
        {
            get { return lastConnection; }
            set { lastConnection = value; }
        }
        public int Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string name;
        private string lastName;
        private string address;
        private string zipcode;
        private string email;
        private string nickname;
        private string profilePicture;
        private string password;
        private DateTime lastConnection;
        private int credit;
    }
}
