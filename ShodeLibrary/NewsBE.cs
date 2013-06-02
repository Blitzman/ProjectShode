using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Liesbeth
 */
//Good BE
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
        private int code;
        private DateTime publicationDate;
        private DevelopmentBE topic;
        private ProjectBE project;

        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public NewsBE()
        {
            title = "";
            content = "";
            author = new UserBE();
            code = -1;
            publicationDate = new DateTime();
            topic = new DevelopmentBE();
            project = new ProjectBE();
        }

        public NewsBE(string title, string content, int code,
                            UserBE author, DateTime publicationDate,
                            DevelopmentBE topic, ProjectBE project)
        {
            this.code = code;
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
            newsDAC.update(this);
        }

        public void delete()
        {
            NewsDAC newsDAC = new NewsDAC();
            newsDAC.delete(code);
        }

        private static string generateCode()
        {
            string newCode = "";
            //Randomize a new project code
            return newCode;
        }

        public NewsBE getByCode(int code)
        {
            NewsDAC dac = new NewsDAC();
            return dac.getNews(code);
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
        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set { publicationDate = value; }
        }
        public DevelopmentBE Topic
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
