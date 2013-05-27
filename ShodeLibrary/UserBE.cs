using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public UserBE(UserBE user)
        {
            this.name = user.name;
            this.lastName = user.lastName;
            this.address = user.address;
            this.zipcode = user.zipcode;
            this.email = user.email;
            this.nickname = user.nickname;
            this.credit = user.credit;
            this.lastConnection = user.lastConnection;
            this.profilePicture = user.profilePicture;
            this.password = user.password;
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public string create()
        {
            string result = "";
            UserDAC userDAC = new UserDAC();

            result = userDAC.insertUser(this);

            return result;
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

        public bool verifyUser()
        {
            UserDAC userDAC = new UserDAC();
            UserBE otro = userDAC.getUserByNick(nickname);

            if (otro.nickname == nickname && otro.password == password)
            {
                this.Name = otro.Name;
                this.LastName = otro.LastName;
                this.Zipcode = otro.Zipcode;
                this.Email = otro.Email;
                this.Address = otro.Address;
                this.Credit = otro.Credit;
                this.LastConnection = otro.LastConnection;
                this.ProfilePicture = otro.ProfilePicture;

                return true;
            }
            else
                return false;
        }

        public UserBE getUserByNick()
        {
            UserDAC userDAC = new UserDAC();
            return userDAC.getUserByNick(nickname);
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
        public float Credit
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
        private float credit;
    }
}
