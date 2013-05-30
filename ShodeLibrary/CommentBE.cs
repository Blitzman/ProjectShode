using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Brayan
 */
namespace ShodeLibrary {
    /*
     * This class represents a comment in a project's profile.
     */
    public class CommentBE {
        public CommentBE() {
            writer = new UserBE();
            project = new ProjectBE();
            date = DateTime.Now;
            content = "";
        }
        /*
         * Default constructor.
         * The date is also not necesary. We will assign it.
         */
        public CommentBE (UserBE writer, ProjectBE project, DateTime creation_date, 
            string content) {
                this.writer = writer;
                this.project = project;
                this.date = creation_date;
                this.content = content;
        }

        public void create () {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.insertComment(this);
        }

        public void update () {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.update(this);
        }

        public void delete () {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.deleteComment(this);
        }

        /*
         * Getters & Setters.
         * TODO: Setters could call commentDAC methods to
         * update the comment attribute.
         */
        public UserBE Writer {
            get { return writer; }
            set { writer=value; }
        }

        public ProjectBE Project {
            get { return project; }
            set { project=value; }
        }

        public DateTime Date {
            get { return date; }
            set { date=value; }
        }

        public string Content {
            get {return content; }
            set { content=value; }
        }

        /*
         * Properties.
         */
        private UserBE writer;
        private ProjectBE project;
        private DateTime date;
        private string content;

        private CommentDAC commentCAD;
    }
}