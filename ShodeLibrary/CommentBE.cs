using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Brayan
 */
namespace ShodeLibrary
{
    /// <summary>
    /// This is the business entity of the prohect comments. We can perform
    /// the CRUD operations by communicating with the determined
    /// data access component.
    /// </summary>
    public class CommentBE
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new comment business entity with "empty" values.
        /// </summary>
        public CommentBE()
        {
            writer = new UserBE();
            project = new ProjectBE();
            date = DateTime.Now;
            content = "";
        }

        /// <summary>
        /// Auxiliary Constructor.
        /// Creates a new comment business entity initializing its fields with
        /// the provided ones.
        /// </summary>
        /// <param name="writer">The writer of the comment.</param>
        /// <param name="project">The project which is being commented.</param>
        /// <param name="creation_date">The date when the comment was submitted.</param>
        /// <param name="content">The comment body.</param>
        public CommentBE(UserBE writer, ProjectBE project, DateTime creation_date,
            string content)
        {
            this.writer = writer;
            this.project = project;
            this.date = creation_date;
            this.content = content;
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Comment Creation.
        /// Uses the comment data access component to insert the current
        /// comment in the database.
        /// </summary>
        public void create()
        {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.insertComment(this);
        }

        /// <summary>
        /// Comment Update.
        /// Uses the comment data access component to update the register
        /// of the database which holds the current comment data with
        /// the actual information.
        /// </summary>
        public void update()
        {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.update(this);
        }

        /// <summary>
        /// Comment Deletion.
        /// If the comment exists, it deletes the current comment from 
        /// the database using the comment data access component.
        /// </summary>
        public void delete()
        {
            CommentDAC commentDAC = new CommentDAC();
            commentDAC.deleteComment(this);
        }

        // /////////////////////////////////////////////////////////////////////
        // Properties //////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        public UserBE Writer
        {
            get { return writer; }
            set { writer = value; }
        }

        public ProjectBE Project
        {
            get { return project; }
            set { project = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private UserBE writer;
        private ProjectBE project;
        private DateTime date;
        private string content;

        private CommentDAC commentCAD;
    }
}