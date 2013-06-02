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
    public class MessageBE
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
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


        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */

        /* Sends a new message */
        public void sendMessage()
        {
            this.Mcode = generateCode();
            this.conversCode = generateConversCode();
            messageDAC.insertMessage(this);
        }

        /* Sends a new message replying the one passed as parameter. */
        public void replyMessage(MessageBE Original)
        {
            this.Mcode = generateCode();
            this.conversCode = Original.ConversCode;
            messageDAC.insertMessage(this);
        }

        /* Removes a message from the list of the specified user. */
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


        /* Opens a message and tags it as read. */
        public void openMessage()
        {
            if (!this.Read)
            {
                MessageDAC aux = new MessageDAC();
                Read = aux.readMessage(this);
            }
        }

        /* Returns a dataset with the message chain before or after this message */
        public DataSet showConversation(String where)
        {
            if (where == "Before")
                return messageDAC.getConversationBefore(this);
            else
                return messageDAC.getConversationAfter(this);
        }

        /* Generates the code for the following message */
        private static int generateCode()
        {
            int newCode = MessageDAC.getCodeDB("code");

            return newCode;
        }

        /* If we are not replying, we need to generate a new conversation code */
        private static int generateConversCode()
        {
            int newCode = MessageDAC.getCodeDB("convers_code");

            return newCode;
        }

        /* ****************************************************************** */
        /* Properties                                                         */
        /* ****************************************************************** */
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


        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
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
