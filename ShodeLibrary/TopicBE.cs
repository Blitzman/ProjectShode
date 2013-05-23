using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Liesbeth
 */
namespace ShodeLibrary
{

    public class TopicBE
    {
        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string code;
        private string name;
        private string description;

        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public TopicBE()
        {
            code = "";
            name = "";
            description = "";
        }
        public TopicBE(string name, string description)
        {
            code = generateCode();

            this.name = name;
            this.description = description;
        }


        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public void create()
        {
            TopicDAC topicDAC = new TopicDAC();
            topicDAC.insertTopic(this);
        }

        public void update()
        {
            TopicDAC topicDAC = new TopicDAC();
            topicDAC.updateTopic(this);
        }

        public void delete()
        {
            TopicDAC topicDAC = new TopicDAC();
            topicDAC.deleteTopic(code);
        }

        private static string generateCode()
        {
            string newCode = "";
            //Randomize a new project code
            return newCode;
        }


        /* ****************************************************************** */
        /* Properties                                                         */
        /* ****************************************************************** */
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
    }
}
