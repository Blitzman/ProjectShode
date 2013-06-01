using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the business entity of the users. This class allows a single
    /// user to perform CRUD operations by communicating with the determined
    /// data access component for the user.
    /// </summary>
    public class UserBE
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new UserBE filling all the fields with empty values.
        /// </summary>
        public UserBE()
        {
            name = "";
            lastName = "";
            email = "";
            nickname = "";
            password = "";
        }

        /// <summary>
        /// Auxiliary Constructor.
        /// Creates a new UserBE filling all the fields with the specified values.
        /// </summary>
        /// <param name="name">The actual name of the user.</param>
        /// <param name="lastName">The surname of the user.</param>
        /// <param name="email">The mail address of the user.</param>
        /// <param name="nickname">The username or nickname of the user.</param>
        /// <param name="password">The user password.</param>
        public UserBE(string name, string lastName, string address,
                        string zipcode, string email, string nickname,
                        string password)
        {
            this.name = name;
            this.lastName = lastName;
            this.email = email;
            this.nickname = nickname;
            this.password = CreateHash(password);
        }

        /// <summary>
        /// Copy Constructor.
        /// Creates a new UserBE filling all the fields with the values of the
        /// provided user ones.
        /// </summary>
        /// <param name="user">The user whose fields will be copied.</param>
        public UserBE(UserBE user)
        {
            this.name = user.name;
            this.lastName = user.lastName;
            this.email = user.email;
            this.nickname = user.nickname;
            this.credit = user.credit;
            this.profilePicture = user.profilePicture;
            this.password = user.password;
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// User Creation.
        /// This method inserts or creates the current user in the database, the
        /// user is supposed to be new (at least no primary key or alternate key
        /// duplicates) otherwise the insertion won't be performed and an error
        /// message will be returned.
        /// </summary>
        /// <returns>A string containing the error or success message when
        ///     inserting the new user in the database. </returns>
        public string create()
        {
            string result = "";

            UserDAC userDAC = new UserDAC();
            result = userDAC.insert(this);

            return result;
        }

        /// <summary>
        /// User Update.
        /// This method updates the current user in the database by using the
        /// function provided by the data access component. Since no error is
        /// possible, nothing is returned.
        /// </summary>
        public void update()
        {
            UserDAC userDAC = new UserDAC();
            userDAC.update(this);
        }

        /// <summary>
        /// User Removal.
        /// This method uses the data access component to remove the current
        /// user from the database. No error is possible so nothing is returned.
        /// </summary>
        public void delete()
        {
            UserDAC userDAC = new UserDAC();
            userDAC.delete(email);
        }

        /// <summary>
        /// User Authentication.
        /// This method uses the data access component to verify that the
        /// current user exists in the database and authenticate it in case
        /// the user exists by comparing passwords. If authenticated,
        /// the current user gets all the fields from the obtained user.
        /// </summary>
        /// <returns>True if the has been properly authenticated and false 
        ///     otherwise (no matter what reason).</returns>
        public bool verifyUser()
        {
            bool verified = false;

            UserDAC userDAC = new UserDAC();
            // Obtain the full user with the same nickname from the database.
            UserBE authUser = userDAC.getByNick(nickname);

            string auxiliar = authUser.Password;
            

            // Compare the nicknames, taking into account that if the user
            // is not present in the database the fields will be empty
            // and then the nicknames will not match. Compare the
            // passwords to authenticate.
            if (authUser.nickname == nickname && ValidatePassword(password, authUser.password))
            {
                this.Name = authUser.Name;
                this.LastName = authUser.LastName;
                this.Email = authUser.Email;
                this.Credit = authUser.Credit;
                this.ProfilePicture = authUser.ProfilePicture;

                verified = true;
            }

            return verified;
        }

        /// <summary>
        /// User Retrieval.
        /// Retrieves an user from the database using the current user nickname.
        /// </summary>
        /// <returns>The full user recovered from the DB.</returns>
        public UserBE getUserByNick()
        {
            UserDAC userDAC = new UserDAC();
            return userDAC.getByNick(nickname);
        }

        /// <summary>
        /// User Retrieval.
        /// Retrieves an user from the database using the current user email.
        /// </summary>
        /// <returns>The full user recovered from the DB.</returns>
        public UserBE getUserByEmail()
        {
            UserDAC userDAC = new UserDAC();
            return userDAC.getUser(this.Email);
        }


        /// <summary>
        /// Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        public static string CreateHash(string password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTES];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTES);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="goodHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePassword(string password, string goodHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            string[] split = goodHash.Split(delimiter);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        
        /// Computes the PBKDF2-SHA1 hash of a password.
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        // /////////////////////////////////////////////////////////////////////
        // Properties //////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
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
        public float Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private string name;
        private string lastName;
        private string email;
        private string nickname;
        private string profilePicture;
        private string password;
        private float credit;


        //Constants for the criptography of the passwords
        //Don't change the constants if there is in the BD
        public const int SALT_BYTES = 24;
        public const int HASH_BYTES = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;
    }
}
