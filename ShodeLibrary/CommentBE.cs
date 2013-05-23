using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Brayan
 */
namespace ShodeLibrary {
    /*
     * This class represents a comment in a project's profile. Users can
     * write about their opinion and give an assessment to the project. 
     * These commentaries can be also assessed by other users.
     */
    public class CommentBE {
        public CommentBE() {
            code = "";
            writer = new UserBE();
            project = new ProjectBE();
            title = "";
            content = "";
            projectAssessment = -1;
        }
        /*
         * Default constructor. We do not receive a commentAssesment because
         * it is a new comment so it can not have assessments before being created.
         * The date is also not necesary. We will assign it.
         */
        public CommentBE (UserBE writer, ProjectBE project, string title, 
            string content, int projectAssessment) {

                code = generateCode();

                this.writer = writer;
                this.project = project;
                this.title = title;
                this.content = content;
                this.projectAssessment = projectAssessment;
        }

        public void create () {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.createComment(this);
        }

        public void update () {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.update(this);
        }

        public void delete () {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.deleteComment(code);
        }

        private static string generateCode()
        {
            string newCode = "";
            //Randomize a new project code
            return newCode;
        }

        /*
         * Getters & Setters.
         * TODO: Setters could call commentDAC methods to
         * update the comment attribute.
         */
        public string Code {
            get { return code; }
            set { code=value; }
        }

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

        public string Title {
            get { return title; }
            set { title=value; }
        }

        public string Content {
            get {return content; }
            set { content=value; }
        }

        public int ProjectAssessment {
            get { return projectAssessment; }
            set { projectAssessment=value; }
        } 

        public int CommentAssessment {
            get { return commentAssessment; }
            set { commentAssessment=value; }
        } 

        /*
         * Properties.
         */
        private string code;
        private UserBE writer;
        private ProjectBE project;
        private DateTime date;
        private string title;
        private string content;
        private int projectAssessment;    //Assessment: leave it as a number or positive/negative assesment?
        private int commentAssessment;
        private CommentDAC commentCAD;
    }
}