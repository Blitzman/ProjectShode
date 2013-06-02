using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ShodeLibrary
{    
    /// <summary>
    /// This is the data access component of the messages. This class will allow
    /// performing CRUD operations directly with the database so it will be
    /// an intermediate layer between the business entity and the raw database.
    /// </summary>
    public class MessageDAC
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new message data access component by initializing the field
        /// which holds the connection string to the database connection string
        /// value which is stored in the Web.config file.
        /// </summary>
        public MessageDAC()
        {
            // Get the connection string from a fixed location (Web.config file)
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Message Insertion.
        /// Inserts the given message in the database.
        /// </summary>
        /// <param name="m">The message to be inserted.</param>
        public void insertMessage(MessageBE m)
        {
            int read = 0; if (m.Read) read = 1;
            int delSend = 0; if (m.DelSender) delSend = 1;
            int delAddr = 0; if (m.DelAddressee) delAddr = 1;

            SqlConnection c = new SqlConnection(connection);
            c.Open();
            SqlCommand com;
            com = new SqlCommand("INSERT INTO message (code, issue, body, sender, addressee, date, isread, deleted_sender, deleted_reader, convers_code)" +
                "VALUES ('" + m.code.ToString() + "','" + m.Subject + "','" + m.Message + "','" + m.Sender.Email + "','" + m.Addressee.Email +
                "','" + m.Date.ToString("G") + "','" + read + "','" + delSend + "','" + delAddr + "','" + m.ConversCode.ToString() + "')", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        /* Obtains a unique code for a new message */
        /// <summary>
        /// DB code.
        /// We get a unique code from the db for a new message.
        /// </summary>
        /// <param name="codetype">Code type of the message.</param>
        /// <returns>It returns the integer code.</returns>
        public static int getCodeDB(String codeType)
        {
            int newCode = 0;

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT COUNT(*) AS n, MAX(" + codeType + ") AS code FROM message", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                if (dr["n"].ToString() != "0")
                {
                    newCode = int.Parse(dr["code"].ToString());
                }
            }

            newCode++;
            return newCode;
        }

        /// <summary>
        /// Message Reader.
        /// Updates the field isRead of the given message so we know that it has been opened.
        /// </summary>
        /// <param name="m">The message to be read.</param>
        /// <returns>It returns a boolean: true if we could read it.</returns>
        public bool readMessage(MessageBE m)
        {
            bool read = false;
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE message SET isread = 1 WHERE code = " + m.code.ToString(), c);
            com.ExecuteNonQuery();

            c.Close();
            return read;
        }

        /// <summary>
        /// Message Delete.
        /// Deletes the message for the specified user. If both users have deleted
        /// the message, it is removed from the database as we do not need it anymore.
        /// </summary>
        /// <param name="m">The message to be deleted.</param>
        /// <param name="u">The users who is deleting the message.</param>
        /// <returns>A boolean is returned.</returns>
        public bool deleteMessage(MessageBE m, UserBE u = null)
        {
            bool deleted = false;

            bool delSend = false, delAddre = false;
            int delSnd = 0, delAddr = 0;
            String sender = "", addressee = "";

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT sender, addressee, " +
                "deleted_sender, deleted_reader FROM message WHERE code = " + m.code.ToString(), c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                sender = dr["sender"].ToString();
                addressee = dr["addressee"].ToString();
                delSnd = int.Parse(dr["deleted_sender"].ToString());
                delAddr = int.Parse(dr["deleted_reader"].ToString());
            }

            dr.Close();

            if (delSnd == 1) delSend = true;
            if (delAddr == 1) delAddre = true;

            if (u.Email == sender)
            {
                m.DelSender = true;
                deleted = true;

                if (delAddre == true)
                {
                    com = new SqlCommand("DELETE FROM message WHERE code = " + m.code.ToString(), c);
                }
                else
                {
                    com = new SqlCommand("UPDATE message SET deleted_sender = 1 WHERE code = " + m.code.ToString(), c);
                }
                com.ExecuteNonQuery();
            }
            if (u.Email == addressee)
            {
                m.DelAddressee = true;
                deleted = true;

                if (delSend == true)
                {
                    com = new SqlCommand("DELETE FROM message WHERE code = " + m.code.ToString(), c);
                }
                else
                {
                    com = new SqlCommand("UPDATE message SET deleted_reader = 1 WHERE code = " + m.code.ToString(), c);
                }
                com.ExecuteNonQuery();
            }
            c.Close();

            return deleted;
        }


        /// <summary>
        /// Conversation Before.
        /// This method gets the datase of messages that compound the conversation
        /// before the given message.
        /// </summary>
        /// <param name="message">The reference message.</param>
        /// <returns>A datase is returned with the conversation.</returns>
        public DataSet getConversationBefore(MessageBE message)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("SELECT u1.nickname AS Sender, u2.nickname as Addressee, SUBSTRING(body, 1, 30) as Body, date as Date, code as Code, isRead as IsRead " +
                "FROM message, users u1, users u2 WHERE convers_code = " + message.ConversCode.ToString() + "AND code < " + message.code.ToString() +
                " AND u1.email = sender AND u2.email = addressee ORDER BY code ASC", c);
            da.Fill(d, "message");
            c.Close();

            return d;
        }

        /// <summary>
        /// Conversation After.
        /// This method gets the datase of messages that compound the conversation
        /// after the given message.
        /// </summary>
        /// <param name="message">The reference message.</param>
        /// <returns>A datase is returned with the conversation.</returns>
        public DataSet getConversationAfter(MessageBE message)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("SELECT u1.nickname AS Sender, u2.nickname as Addressee, SUBSTRING(body, 1, 30) as Body, date as Date, code as Code, isRead as IsRead " +
                "FROM message, users u1, users u2 WHERE convers_code = " + message.ConversCode.ToString() + "AND code > " + message.code.ToString() +
                " AND u1.email = sender AND u2.email = addressee ORDER BY code ASC", c);
            da.Fill(d, "message");
            c.Close();

            return d;
        }

        /// <summary>
        /// Message Getter.
        /// This method gets a message being given its code.
        /// </summary>
        /// <param name="code">The message code.</param>
        /// <returns>A MessageBE is returned.</returns>
        public static MessageBE getMessage(int code)
        {
            MessageBE message = new MessageBE();

            UserDAC user = new UserDAC();
            int read = 0, delSnd = 0, delAddr = 0;

            SqlConnection c = new SqlConnection(connection);
            c.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM message WHERE code= " + code.ToString(), c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                message.code = int.Parse(dr["code"].ToString());
                message.Sender = user.getUser(dr["sender"].ToString());
                message.Addressee = user.getUser(dr["addressee"].ToString());
                message.Subject = dr["issue"].ToString();
                message.Message = dr["body"].ToString();
                message.Date = DateTime.Parse(dr["date"].ToString());
                read = int.Parse(dr["isread"].ToString());
                delSnd = int.Parse(dr["deleted_sender"].ToString());
                delAddr = int.Parse(dr["deleted_reader"].ToString());
                message.ConversCode = int.Parse(dr["convers_code"].ToString());
            }

            message.Read = false;
            message.DelSender = false;
            message.DelAddressee = false;
            if (read == 1) message.Read = true;
            if (delSnd == 1) message.DelSender = true;
            if (delAddr == 1) message.DelAddressee = true;

            c.Close();

            return message;
        }

        /// <summary>
        /// Sent Message Getter.
        /// This method gets a dataset with the messages sent by the given user
        /// in the specified order.
        /// </summary>
        /// <param name="sender">The user.</param>
        /// <param name="order">The message ordering to be used.</param>
        /// <returns>A datased is returned with those comments.</returns>
        public static DataSet getSentMessages(UserBE sender, String order)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);

            SqlDataAdapter da = new SqlDataAdapter("SELECT nickname as Addressee, issue as Subject, date as Date, code as Code, isRead as IsRead FROM message, users WHERE sender = '" +
            sender.Email + "' AND deleted_sender = 0 AND email = addressee ORDER BY " + order, c);

            da.Fill(d, "message");
            c.Close();

            return d;
        }

        /// <summary>
        /// Received Message Getter.
        /// This method gets a dataset with the messages received by the given user
        /// in the specified order.
        /// </summary>
        /// <param name="sender">The user.</param>
        /// <param name="order">The message ordering to be used.</param>
        /// <returns>A datased is returned with those comments.</returns>
        public static DataSet getReceivedMessages(UserBE addressee, String order)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);

            SqlDataAdapter da = new SqlDataAdapter("SELECT nickname as Sender, issue as Subject, date as Date, code AS Code, isRead as IsRead FROM message, users WHERE addressee = '" +
                        addressee.Email + "' AND deleted_reader = 0 AND email = sender ORDER BY " + order, c);

            da.Fill(d, "message");
            c.Close();

            return d;
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private static String connection;
    }
}
