using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;

/*
 * Task performed by Pablo
 */
namespace ShodeLibrary
{
    /// This is the business entity of the messages. Messages are sent between users.
    /// This class allows a single user to perform CRUD operations by communicating with the determined
    /// data access component for the user. 
    /// </summary>
    public class MessageBE
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new comment filling all the fields with empty values.
        /// </summary>
        public MessageBE()
        {
            this.messageDAC = new MessageDAC();

            this.read = false;
            this.delAddressee = false;
            this.delSender = false;
            this.Sender = null;
            this.Addressee = null;
            this.Subject = "";
            this.Message = "";
        }

        /// <summary>
        /// Auxiliary Constructor.
        /// Creates a new commet filling all the fields with the specified values.
        /// </summary>
        /// <param name="sender">The user who sends the message.</param>
        /// <param name="addressee">The user who will receive the message.</param>
        /// <param name="date">The date when the message is sent.</param>
        /// <param name="subject">The message subject.</param>
        /// <param name="message">The message body.</param>
        public MessageBE(UserBE sender, UserBE addressee, DateTime date,
                        string subject, string message)
        {
            this.messageDAC = new MessageDAC();

            this.read = false;
            this.delAddressee = false;
            this.delSender = false;
            this.Sender = sender;
            this.Addressee = addressee;
            this.Date = date;
            this.Subject = subject;
            this.Message = message;
        }


        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Message Creation.
        /// This method inserts or creates the message in the database. We generate
        /// a unique code for it and then using the DAC it is inserted.
        /// </summary>
        public void sendMessage()
        {
            this.Mcode = generateCode();
            this.conversCode = generateConversCode();
            messageDAC.insertMessage(this);
        }

        /// <summary>
        /// Message Reply Creation.
        /// This method inserts or creates the message reply in the database. We generate
        /// a unique code for it and then using the DAC it is inserted. It is similar
        /// to the previous method.
        /// </summary>
        public void replyMessage(MessageBE Original)
        {
            this.Mcode = generateCode();
            this.conversCode = Original.ConversCode;
            messageDAC.insertMessage(this);
        }

        /// <summary>
        /// Message Delete.
        /// This method deletes a message from the list of the specified user
        /// in the database.
        /// </summary>
        public void removeMessage(UserBE u)
        {
            if (this.Sender != null && this.Addressee != null)
            {
                if (u.Email == this.Sender.Email && u.Email == this.Addressee.Email)
                {
                    delSender = messageDAC.deleteMessage(this, u);
                    delAddressee = delSender;
                }
                else if (u.Email == this.Sender.Email)
                {
                    delSender = messageDAC.deleteMessage(this, u);
                }
                else if (u.Email == this.Addressee.Email)
                {
                    delAddressee = messageDAC.deleteMessage(this, u);
                }
                else
                {
                    //Error
                }
            }
        }


        /// <summary>
        /// Message opened.
        /// This method opens a message. When it is open we can read it
        /// and its state changes.
        /// </summary>
        public void openMessage()
        {
            if (!this.Read)
            {
                MessageDAC aux = new MessageDAC();
                Read = aux.readMessage(this);
            }
        }

        /// <summary>
        /// Show Conversation.
        /// This method retuns the message chain before or after this message.
        /// </summary>
        /// <returns>A dataset is returned so it is easy to put this
        /// information in a gridview.</returns>
        public DataSet showConversation(String where)
        {
            if (where == "Before")
                return messageDAC.getConversationBefore(this);
            else
                return messageDAC.getConversationAfter(this);
        }

        /// <summary>
        /// Code generation.
        /// Static method we use to generate unique codes.
        /// </summary>
        /// <returns>The new code is returned.</returns>
        private static int generateCode()
        {
            int newCode = MessageDAC.getCodeDB("code");

            return newCode;
        }

        /// <summary>
        /// If we are not replying a message, we need to generate
        /// a new conversation code
        /// </summary>
        /// <returns>The new code is returned.</returns>
        private static int generateConversCode()
        {
            int newCode = MessageDAC.getCodeDB("convers_code");

            return newCode;
        }

        // /////////////////////////////////////////////////////////////////////
        // Properties //////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        public int code
        {
            get { return Mcode; }
            set { Mcode = value; }
        }
        public UserBE Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        public UserBE Addressee
        {
            get { return addressee; }
            set { addressee = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public bool Read
        {
            get { return read; }
            set { read = value; }
        }
        public bool DelSender
        {
            get { return delSender; }
            set { delSender = value; }
        }
        public bool DelAddressee
        {
            get { return delAddressee; }
            set { delAddressee = value; }
        }
        public int ConversCode
        {
            get { return conversCode; }
            set { conversCode = value; }
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private int Mcode;
        private UserBE sender;
        private UserBE addressee;
        private DateTime date;
        private string subject;
        private string message;
        private bool read;
        private bool delSender;
        private bool delAddressee;
        private int conversCode;

        private MessageDAC messageDAC;
    }
}
