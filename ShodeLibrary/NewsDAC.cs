using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

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
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public string insertNews(NewsBE newsitem)
        {
            string result = "The project has been created!";

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("INSERT INTO news ()" +
                "VALUES ('" + project.Title + "','" + project.Description + "','" + project.ExpirationDate.ToString("dd/MM/yyyy") + "','" +
                project.CreationDate.ToString("dd/MM/yyyy") + "'," + "1" + "," + project.Credit + ",'" + project.LastVersion.ToString("dd/MM/yyyy") +
                "'," + project.Credit + ",'" + project.GitDir + "','" + project.Creator.Email + "')", c);

            com.ExecuteNonQuery();
            c.Close();

            return result;
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

        public List<NewsBE> getNewsByTopic(DevelopmentBE author)
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
