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
    public class MessageDAC
    {
        //* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */

        public MessageDAC()
        {
        }


        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */

        /* Inserts a new message */
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

        /* Updates the field isRead of the passed message in order to know that the message
         * has been opened. */
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

        /* Deletes the message for the specified user. If both users have
         * deleted it, it is removed from database. */
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


        /* Gets the dataset of messages that compound the conversation before the passed message. */
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

        /* Gets the dataset of messages that compound the conversation after the passed message. */
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


        /* Gets a single message by its code */
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

        /* Gets the dataset with the messages sent by the passed user in the
         * specified order. */
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

        /* Gets the dataset with the messages received by the passed user in the
         * specified order. */
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

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */

        private static string connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\ShodeDatabase.mdf;User Instance=true";
    }
}
