using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ShodeLibrary
{
    public class MessageDAC
    {
        //* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */

        public MessageDAC()
        {
            connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\ShodeDatabase.mdf;User Instance=true";
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
                "','" + m.Date.ToString("dd/MM/yyyy") + "','" + read + "','" + delSend + "','" + delAddr + "','" + m.ConversCode.ToString() + "')", c);

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

        /* Deletes the message for the specified user. If both users have
         * deleted it, it is removed from database. */
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


        /* Gets the list of message that compound a conversation. */
        public List<MessageBE> getConversation(MessageBE m)
        {
            List<MessageBE> messages = new List<MessageBE>();

            /*if (m.OriginalMessage != null)
            {
                MessageBE message = getMessage(m.code);
                MessageBE tempM = message.OriginalMessage;

                do
                {
                    messages.Add(tempM);
                    tempM = tempM.OriginalMessage;

                } while (tempM != null);
            }*/

            return messages;
        }


        /* Gets messages by DateTime */
        public List<MessageBE> getMessageDate(DateTime d)
        {
            List<MessageBE> messages = new List<MessageBE>();
            MessageBE tempM = new MessageBE();
            UserDAC user = new UserDAC();

            SqlConnection c = new SqlConnection(connection);
            c.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM message WHERE date='" + d.ToString() + "'", c);
            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                tempM = new MessageBE();
                tempM.code = int.Parse(dr["code"].ToString());
                tempM.Sender = user.getUser(dr["sender"].ToString());
                tempM.Addressee = user.getUser(dr["addressee"].ToString());
                tempM.Subject = dr["issue"].ToString();
                tempM.Message = dr["body"].ToString();
                tempM.Date = DateTime.Parse(dr["date"].ToString());
                tempM.Read = bool.Parse(dr["isread"].ToString());
                tempM.DelSender = bool.Parse(dr["deleted_sender"].ToString());
                tempM.DelAddressee = bool.Parse(dr["deleted_reader"].ToString());
                //tempM.OriginalMessage = getMessage(int.Parse(dr["original"].ToString()));

                messages.Add(tempM);
            }

            c.Close();

            return messages;
        }

        /* Gets all messages */
        public List<MessageBE> getAllMessages()
        {
            List<MessageBE> messages = new List<MessageBE>();
            MessageBE tempM = new MessageBE();
            UserDAC user = new UserDAC();

            SqlConnection c = new SqlConnection(connection);
            c.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM message", c);
            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                tempM = new MessageBE();
                tempM.code = int.Parse(dr["code"].ToString());
                tempM.Sender = user.getUser(dr["sender"].ToString());
                tempM.Addressee = user.getUser(dr["addressee"].ToString());
                tempM.Subject = dr["issue"].ToString();
                tempM.Message = dr["body"].ToString();
                tempM.Date = DateTime.Parse(dr["date"].ToString());
                tempM.Read = bool.Parse(dr["isread"].ToString());
                tempM.DelSender = bool.Parse(dr["deleted_sender"].ToString());
                tempM.DelAddressee = bool.Parse(dr["deleted_reader"].ToString());
                //tempM.OriginalMessage = getMessage(int.Parse(dr["original"].ToString()));

                messages.Add(tempM);
            }

            c.Close();

            return messages;
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

        /* If addresee is NULL, gets the list of sent messages by sender.
         * If sender is NULL, gets the list of received messages by addresee.
         * If anyone is NULL, gets the list of messages traded by sender and addressee. */
        public List<MessageBE> getMessages(UserBE sender, UserBE addressee)
        {
            List<MessageBE> messages = new List<MessageBE>();
            if (sender == null && addressee == null)
            {
                MessageBE tempM = new MessageBE();
                UserDAC user = new UserDAC();

                SqlConnection c = new SqlConnection(connection);
                c.Open();
                SqlCommand com;

                if (sender == null)
                {
                    com = new SqlCommand("SELECT * FROM message WHERE addressee='" + addressee.Email + "'", c);
                }
                else if (addressee == null)
                {
                    com = new SqlCommand("SELECT * FROM message WHERE sender='" + sender.Email + "'", c);
                }
                else
                {
                    com = new SqlCommand("SELECT * FROM message WHERE sender='" + sender.Email + "' and addressee='" + addressee.Email + "'", c);
                }
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    tempM = new MessageBE();
                    tempM.code = int.Parse(dr["code"].ToString());
                    tempM.Sender = user.getUser(dr["sender"].ToString());
                    tempM.Addressee = user.getUser(dr["addressee"].ToString());
                    tempM.Subject = dr["issue"].ToString();
                    tempM.Message = dr["body"].ToString();
                    tempM.Date = DateTime.Parse(dr["date"].ToString());
                    tempM.Read = bool.Parse(dr["isread"].ToString());
                    tempM.DelSender = bool.Parse(dr["deleted_sender"].ToString());
                    tempM.DelAddressee = bool.Parse(dr["deleted_reader"].ToString());
                    //tempM.OriginalMessage = getMessage(int.Parse(dr["original"].ToString()));

                    messages.Add(tempM);
                }

                c.Close();
            }

            return messages;
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private static string connection;
    }
}
