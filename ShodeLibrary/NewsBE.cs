using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Liesbeth
 */
namespace ShodeLibrary
{

    public class NewsBE
    {
        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string title;
        private string content;
        private UserBE author;
        private string code;
        private DateTime publicationDate;
        private TopicBE topic;
        private ProjectBE project;

        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public NewsBE()
        {
            title = "";
            content = "";
            author = new UserBE();
            code = "";
            publicationDate = new DateTime();
            topic = new TopicBE();
            project = new ProjectBE();
        }

        public NewsBE(string title, string content,
                            UserBE author, DateTime publicationDate,
                            TopicBE topic, ProjectBE project)
        {
            code = generateCode();

            this.title = title;
            this.content = content;
            this.author = author;
            this.publicationDate = publicationDate; 
            this.topic = topic;
            this.project = project;
        }


        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public void create()
        {
            NewsDAC newsDAC = new NewsDAC();
            newsDAC.insertNews(this);
        }

        public void update()
        {
            NewsDAC newsDAC = new NewsDAC();
            newsDAC.updateNews(this);
        }

        public void delete()
        {
            NewsDAC newsDAC = new NewsDAC();
            newsDAC.deleteNews(code);
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
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public UserBE Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set { publicationDate = value; }
        }
        public TopicBE Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        public ProjectBE Project
        {
            get { return project; }
            set { project = value; }
        }
    }
}
