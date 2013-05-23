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
            SqlConnection c = new SqlConnection(connection);
            c.Open();
            SqlCommand com;
                
            if (m.OriginalMessage != null)
            {
                com = new SqlCommand("INSERT INTO Messages (code, issue, body, isread, deleted_sender, deleted_reader, original)" +
                    "VALUES ('" + m.code.ToString() + "','" + m.Subject + "','" + m.Message + "','" + m.Read.ToString() + "','" +
                    m.DelSender.ToString() + "','" + m.DelAddressee.ToString() + "','" + m.OriginalMessage.code + "')", c);
            }
            else
            {
                com = new SqlCommand("INSERT INTO Messages (code, issue, body, isread, deleted_sender, deleted_reader, original)" +
                    "VALUES ('" + m.code.ToString() + "','" + m.Subject + "','" + m.Message + "','" + m.Read.ToString() + "','" +
                    m.DelSender.ToString() + "','" + m.DelAddressee.ToString() + "', NULL)", c);
            }

            com.ExecuteNonQuery();
            c.Close();
    	}


    	/* Deletes the message for the specified user. If both users have
         * deleted it, it is removed from database. */
    	public bool deleteMessage(MessageBE m, UserBE u = null)
    	{
            bool deleted = false;

            bool delSend = false, delAddr = false;
            String sender = "", addressee = "";

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT sender, addressee, " +
                "deleted_sender, deleted_reader FROM Messages WHERE code = " + m.code.ToString() + "', 0)", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                sender = dr["sender"].ToString();
                addressee = dr["addressee"].ToString();
                delSend = bool.Parse(dr["deleted_sender"].ToString());
                delAddr = bool.Parse(dr["deleted_reader"].ToString());
            }

            if (u.Email == sender)
            {
                m.DelSender = true;
                deleted = true;

                if (delAddr == true)
                {
                    com = new SqlCommand("DELETE FROM Messages WHERE code = " + m.code.ToString() + "', 0)", c);
                    com.ExecuteNonQuery();
                }
                else
                {
                    com = new SqlCommand("UPDATE Messages SET deleted_sender = TRUE WHERE code = " + m.code.ToString() + "', 0)", c);
                    com.ExecuteNonQuery();
                }
            }
            else if (u.Email == addressee)
            {
                m.DelAddressee = true;
                deleted = true;

                if (delSend == true)
                {
                    com = new SqlCommand("DELETE FROM Messages WHERE code = " + m.code.ToString() + "', 0)", c);
                    com.ExecuteNonQuery();
                }
                else
                {
                    com = new SqlCommand("UPDATE Messages SET deleted_reader = TRUE WHERE code = " + m.code.ToString() + "', 0)", c);
                    com.ExecuteNonQuery();
                }
            }

            c.Close();

            return deleted;
    	}


    	/* Gets the list of message that compound a conversation. */
    	public List<MessageBE> getConversation(MessageBE m)
    	{
            List<MessageBE> messages = new List<MessageBE>();

            if (m.OriginalMessage != null)
            {
                MessageBE message = getMessage(m.code);
                MessageBE tempM = message.OriginalMessage;

                do
                {
                    messages.Add(tempM);
                    tempM = tempM.OriginalMessage;

                } while (tempM != null);
            }

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
            SqlCommand com = new SqlCommand("SELECT * FROM Messages WHERE date='" + d.ToString() + "'", c);
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
                tempM.OriginalMessage = getMessage(int.Parse(dr["original"].ToString()));

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
            SqlCommand com = new SqlCommand("SELECT * FROM Messages", c);
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
                tempM.OriginalMessage = getMessage(int.Parse(dr["original"].ToString()));

                messages.Add(tempM);
            }

            c.Close();

            return messages;
        }


    	/* Gets a single message by its code */
    	public MessageBE getMessage(int code)
    	{
            MessageBE message = null;

            if (code == null)
            {
                UserDAC user = new UserDAC();

                SqlConnection c = new SqlConnection(connection);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Messages WHERE code='" + code.ToString() + "'", c);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    message.code = int.Parse(dr["code"].ToString());
                    message.Sender = user.getUser(dr["sender"].ToString());
                    message.Addressee = user.getUser(dr["addressee"].ToString());
                    message.Subject = dr["issue"].ToString();
                    message.Message = dr["body"].ToString();
                    message.Date = DateTime.Parse(dr["date"].ToString());
                    message.Read = bool.Parse(dr["isread"].ToString());
                    message.DelSender = bool.Parse(dr["deleted_sender"].ToString());
                    message.DelAddressee = bool.Parse(dr["deleted_reader"].ToString());
                    message.OriginalMessage = getMessage(int.Parse(dr["original"].ToString()));
                }

                c.Close();
            }

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
                    com = new SqlCommand("SELECT * FROM Messages WHERE addressee='" + addressee.Email + "'", c);
                }
                else if (addressee == null)
                {
                    com = new SqlCommand("SELECT * FROM Messages WHERE sender='" + sender.Email + "'", c);
                }
                else
                {
                    com = new SqlCommand("SELECT * FROM Messages WHERE sender='" + sender.Email + "' and addressee='" + addressee.Email + "'", c);
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
                    tempM.OriginalMessage = getMessage(int.Parse(dr["original"].ToString()));

                    messages.Add(tempM);
                }

                c.Close();
            }

            return messages;
    	}

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string connection;
    }
}
