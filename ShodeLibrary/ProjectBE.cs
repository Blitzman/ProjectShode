using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace ShodeLibrary
{
    public enum ProjectState { Active, Closed, Inactive };

    public class ProjectBE
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new project business entity with "empty" values.
        /// </summary>
        public ProjectBE()
        {
            title = "";
            description = "";
            creator = null;
            code = -1;
            creationDate = new DateTime();
            expirationDate = new DateTime();
            state = ProjectState.Closed;
            credit = 0;
            partitionCredit = 0;
            lastVersion = new DateTime();
            gitDir = "";
        }

        /// <summary>
        /// Auxiliary Constructor.
        /// Creates a new project business entity filling the fields
        /// with the provided ones.
        /// </summary>
        /// <param name="title">The title of the project.</param>
        /// <param name="description">The description of the project.</param>
        /// <param name="creator">The user which created the project.</param>
        /// <param name="code">The code of the project.</param>
        /// <param name="creationDate">The creation date.</param>
        /// <param name="expirationDate">The deadline of the project.</param>
        /// <param name="credit">The amount of credits the project has.</param>
        /// <param name="partitionCredit">The amount of credits in the current partition.</param>
        /// <param name="lastVersion">The date of the last partition.</param>
        /// <param name="gitDir">The git directory of the project.</param>
        public ProjectBE(string title, string description,
                            UserBE creator, int code,
                            DateTime creationDate, DateTime expirationDate,
                            int credit, int partitionCredit, DateTime lastVersion,
                            string gitDir) 
        {
            this.code = code;
            this.state = ProjectState.Active;

            this.title = title;
            this.description = description;
            this.creator = creator;
            this.credit = credit;
            this.partitionCredit = partitionCredit;
            this.creationDate = creationDate;
            this.expirationDate = expirationDate;
            this.lastVersion = lastVersion;
            this.gitDir = gitDir;
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Project Creation.
        /// Uses the project data access component to insert the current
        /// project in the database.
        /// </summary>
        public void create ()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            projectDAC.insert(this);
        }

        /// <summary>
        /// Project Update.
        /// Uses the project data access component to update the register
        /// of the database which holds the current project data with
        /// the actual values of the current project.
        /// </summary>
        public void update ()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            projectDAC.update(this);
        }

        /// <summary>
        /// Project Deletion.
        /// Deletes the current project from the database if it exists
        /// using the project data access component.
        /// </summary>
        public void delete()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            projectDAC.delete(code);
        }

        /// <summary>
        /// By Code Fetcher.
        /// Uses the data access component to fetch a determined
        /// project from the database using the code of the
        /// current project.
        /// </summary>
        /// <returns>The fetched project.</returns>
        public ProjectBE getByCode()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            return projectDAC.getProject(this.code);
        }

        /// <summary>
        /// Last Code Getter.
        /// Gets the last created project code.
        /// </summary>
        /// <returns>The last project code.</returns>
        public int getLastCode()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            return projectDAC.lastCode();
        }


        public DataSet getComments()
        {
            return CommentDAC.getProjectComments(this);
        }

        // /////////////////////////////////////////////////////////////////////
        // Properties //////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public UserBE Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }
        public ProjectState State
        {
            get { return state; }
            set { state = value; }
        }
        public int Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        public int PartitionCredit
        {
            get { return partitionCredit; }
            set { partitionCredit = value; }
        }
        public DateTime LastVersion
        {
            get { return lastVersion; }
            set { lastVersion = value; }
        }
        public string GitDir
        {
            get { return gitDir; }
            set { gitDir = value; }
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        private int code;
        private string title;
        private string description;
        private UserBE creator;
        private DateTime creationDate;
        private DateTime expirationDate;
        private ProjectState state;
        private int credit;
        private int partitionCredit;
        private DateTime lastVersion;
        private string gitDir;
    }
}
