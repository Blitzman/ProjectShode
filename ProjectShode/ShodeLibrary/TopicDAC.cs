using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Liesbeth
 */
namespace ShodeLibrary
{
    public class TopicDAC
    {

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string connection;

        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public TopicDAC()
        {
            // Gets the string connection from a unique location
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public string insertTopic(TopicBE topic)
        {
            string code = "";
            // Do stuff here
            return code;
        }

        public TopicBE getTopic(string code)
        {
            TopicBE topic= new TopicBE();
            // Do stuff here
            return topic;
        }

        public List<TopicBE> getAllTopics ()
        {
            List<TopicBE> topics = new List<TopicBE>();
            // Do stuff here
            return topics;
        }

        public List<TopicBE> getTopicsByDescription(string description)
        {
             List<TopicBE> topics = new List<TopicBE>();
            // Do stuff here
            return topics;
        }

        public void updateTopic(TopicBE topic)
        {
            // Do stuff here
        }
        
        public void deleteTopic(string code)
        {
            // Do stuff here
        }

    }
    
}
