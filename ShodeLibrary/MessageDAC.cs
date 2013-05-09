using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Pablo
 */
namespace ShodeLibrary
{
    public class MessageDAC
    {
    	//* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */

    	public MessageDAC()
    	{
			// Gets the string connection from a unique location
    	}


         /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */

    	/* Inserts a new message */
    	public string insertMessage(MessageBE m)
    	{
            string code = "";
            // Do stuff here
            return code;
    	}


    	/* Deletes the message for the specified user. If both users have
         * deleted it, it is removed from database. */
    	public bool deleteMessage(MessageBE m, UserBE u = null)
    	{
            bool deleted = false;
            // Do stuff here
            return deleted;
    	}


    	/* Gets the list of message that compound a conversation. */
    	public List<MessageBE> getConversation(MessageBE m)
    	{
            List<MessageBE> messages = new List<MessageBE>();
            // Do stuff here
            return messages;
    	}


    	/* Gets messages by DateTime */
    	public List<MessageBE> getMessageDate(DateTime d)
    	{
            List<MessageBE> messages = new List<MessageBE>();
            // Do stuff here
            return messages;
    	}

        /* Gets all messages */
        public List<MessageBE> getAllMessages()
        {
            List<MessageBE> messages = new List<MessageBE>();
            // Do stuff here
            return messages;
        }


    	/* Gets a single message by its code */
    	public MessageBE getMessage(string code)
    	{
            MessageBE message = null;
            // Do stuff here
            return message;
    	}

    	/* If addresee is NULL, gets the list of sent messages by sender.
         * If sender is NULL, gets the list of received messages by addresee.
         * If anyone is NULL, gets the list of messages traded by sender and addressee. */
    	public List<MessageBE> getMessages(UserBE sender, UserBE addressee)
    	{
            List<MessageBE> messages = new List<MessageBE>();
            // Do stuff here
            return messages;
    	}

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string connection;
    }
}
