using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

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
        public string insertNews(NewsBE news)
        {
            string result = "The news item has been created!";

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("INSERT INTO news (code, title, content, public_date, creator)" +
                "VALUES ('" + news.Code+ "','" + news.Title+ "','" + news.Content + "','" + news.PublicationDate.ToString("dd/MM/yyyy") + "','" +  news.Author + "',')", c);

            com.ExecuteNonQuery();
            c.Close();

            return result;
        }

        public NewsBE getNews(int code)
        {
            NewsBE news = new NewsBE();

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM news WHERE code='" + code + "'", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                news.Code = Int32.Parse(dr["code"].ToString());
                news.Title = dr["title"].ToString();
                news.Content = dr["content"].ToString();
                news.PublicationDate = DateTime.ParseExact(dr["public_date"].ToString(), "dd/MM/yyyy", null);
                news.Author = new UserBE();
                news.Author.Nickname = dr["creator"].ToString();

                
            }

            c.Close();
            return news;
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

        public void update(NewsBE news)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE newss " +
                "SET title='" + news.Title + "', content='" + news.Content +
                " WHERE code='" + news.Code + "'", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        public void delete(int code)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("DELETE FROM news WHERE code =" + code.ToString() + "", c);

            com.ExecuteNonQuery();
            c.Close();
        }
    }
    
}
