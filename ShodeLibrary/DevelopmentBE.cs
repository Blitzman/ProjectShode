using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the business entity of the developments. This class allows a single
    /// development to perform CRUD operations by communicating with the determined
    /// data access component for the development.
    /// </summary>
    public class DevelopmentBE
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new development business entity with "empty" values.
        /// </summary>
        public DevelopmentBE()
        {
            project = new ProjectBE();
            user = new UserBE();
            date = DateTime.Now;
        }

        /// <summary>
        /// Auxiliary Constructor.
        /// Creates a new development business entity initializing its fields with
        /// the provided ones.
        /// </summary>
        /// <param name="project">The project of the development.</param>
        /// <param name="user">The user that makes the development.</param>
        /// <param name="date">The date when the development was submitted.</param>
        /// <param name="gitBranch">The git branch URL of the development.</param>
        /// <param name="ups">The number of upvotes (positive reviews).</param>
        public DevelopmentBE(ProjectBE project, UserBE user, DateTime date, string gitBranch, int ups)
        {
            this.project = project;
            this.user = user;
            this.date = date;
            this.gitBranch = gitBranch;
            this.ups = ups;
        }

        /// <summary>
        /// Copy Constructor.
        /// Creates a new development business entity by copying the fields
        /// of another development BE.
        /// </summary>
        /// <param name="development"></param>
        public DevelopmentBE(DevelopmentBE development)
        {
            this.project = development.project;
            this.user = development.user;
            this.date = development.date;
            this.gitBranch = development.gitBranch;
            this.ups = development.ups;
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Development Creation.
        /// Uses the development data access component to insert the current
        /// development in the database.
        /// </summary>
        public void create()
        {
            DevelopmentDAC developmentDAC = new DevelopmentDAC();
            developmentDAC.insert(this);
        }

        /// <summary>
        /// Development Update.
        /// Uses the development data access component to update the register
        /// of the database which holds the current development data with
        /// the actual values of the current development.
        /// </summary>
        public void update()
        {
            DevelopmentDAC developmentDAC = new DevelopmentDAC();
            developmentDAC.update(this);
        }

        /// <summary>
        /// Development Deletion.
        /// If the development exists, it deletes the current development from 
        /// the database using the development data access component.
        /// </summary>
        public void delete()
        {
            DevelopmentDAC developmentDAC = new DevelopmentDAC();
            developmentDAC.delete(this);
        }

        // /////////////////////////////////////////////////////////////////////
        // Properties //////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        public ProjectBE Project
        {
            get { return project; }
            set { project = value; }
        }

        public UserBE User
        {
            get { return user; }
            set { user = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string GitBranch
        {
            get { return gitBranch; }
            set { gitBranch = value; }
        }

        public int Ups
        {
            get { return ups; }
            set { ups = value; }
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private ProjectBE project;
        private UserBE user;
        private DateTime date;
        private string gitBranch;
        private int ups;
    }
}
