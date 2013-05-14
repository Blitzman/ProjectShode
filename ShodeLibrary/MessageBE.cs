using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            this.OriginalMessage = null;
            this.Mcode = 0;
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
            this.OriginalMessage = null;
            this.Mcode = codes;
            codes++;
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
            OriginalMessage = null;
            messageDAC.insertMessage(this);
        }

        /* Sends a new message replying the one passed as parameter. */
        public void replyMessage(MessageBE Original)
        {
            OriginalMessage = Original;
            messageDAC.insertMessage(this);
        }

        /* Removes a message from the list of the specified user. */
        public void removeMessage(UserBE u)
        {
            if (u == this.Sender)
            {
                delSender = messageDAC.deleteMessage(this, u);
            }
            else if (u == this.Addressee)
            {
                delAddressee = messageDAC.deleteMessage(this, u);
            }
            else
            {
                //Error message or exception.
            }
        }


        /* Opens a message and tags it as read. */
        public void openMessage()
        {
            read = true;

            //Show the message.
        }

        /* Shows all the message chain made by replying */
        public void showConversation()
        {
            messageDAC.getConversation(this);

            //Show the MessageBE array returned by getConversation.
        }


        /* Show the messages sent by the user passed as parameter */
        public void showSentMessages(UserBE u)
        {
            messageDAC.getMessages(u, null);

            //Show the MessageBE array returned by getMessages.
        }

        /* Show the messages received by the user passed as parameter */
        public void showReceivedMessages(UserBE u)
        {
            messageDAC.getMessages(null, u);

            //Show the MessageBE array returned by getMessages.
        }

        private static string generateCode()
        {
            string newCode = "";
            //Randomize a new message code
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
        public MessageBE OriginalMessage
        {
            get { return OriginalMessage; }
            set { OriginalMessage = value; }
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

        private MessageDAC messageDAC;

        private static int codes = 0;
    }
}
