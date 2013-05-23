using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Liesbeth
 */
namespace ShodeLibrary
{
    public class NewsDAC
    {

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string connection;

        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public NewsDAC()
        {
            // Gets the string connection from a unique location
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public string insertNews(NewsBE newsitem)
        {
            string code = "";
            // Do stuff here
            return code;
        }

        public NewsBE getNews(string code)
        {
            NewsBE newsitem = new NewsBE();
            // Do stuff here
            return newsitem;
        }

        public List<NewsBE> getAllNews ()
        {
            List<NewsBE> newsitems = new List<NewsBE>();
            // Do stuff here
            return newsitems;
        }
        public List<NewsBE> getTopNews (int num)
        {
            List<NewsBE> newsitems = new List<NewsBE>();
            // Do stuff here
            return newsitems;
        }
        public List<NewsBE> getNewNews(int num)
        {
            List<NewsBE> newsitems = new List<NewsBE>();
            // Do stuff here
            return newsitems;
        }
        public List<NewsBE> getRecentlyUpdated(int num)
        {
            List<NewsBE> newsitems = new List<NewsBE>();
            // Do stuff here
            return newsitems;
        }
        public List<NewsBE> getNewsByAuthor(UserBE author)
        {
            List<NewsBE> newsitems = new List<NewsBE>();
            // Do stuff here
            return newsitems;
        }

        public List<NewsBE> getNewsByTopic(TopicBE author)
        {
            List<NewsBE> newsitems = new List<NewsBE>();
            // Do stuff here
            return newsitems;
        }

        public List<NewsBE> getNewsByTitleSearch(string title)
        {
             List<NewsBE> newsitems = new List<NewsBE>();
            // Do stuff here
            return newsitems;
        }

        public List<NewsBE> getNewsByContent(string content)
        {
            List<NewsBE> newsitems = new List<NewsBE>();
            // Do stuff here
            return newsitems;
        }

        public void updateNews(NewsBE news)
        {
            // Do stuff here
        }

        public void deleteNews(string code)
        {
            // Do stuff here
        }
    }
    
}
