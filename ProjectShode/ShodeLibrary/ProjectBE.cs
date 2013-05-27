using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShodeLibrary
{
    public enum ProjectState { Active, Closed, Inactive };

    public class ProjectBE
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public ProjectBE()
        {
            title = "";
            description = "";
            creator = null;
            code = "";
            creationDate = new DateTime();
            expirationDate = new DateTime();
            state = ProjectState.Closed;
            credit = 0.0f;
            lastVersion = new DateTime();
            gitDir = "";
        }

        public ProjectBE(string title, string description,
                            UserBE creator, string code,
                            DateTime creationDate, DateTime expirationDate,
                            float credit, DateTime lastVersion,
                            string gitDir) 
        {
            this.code = generateCode();
            this.state = ProjectState.Active;

            this.title = title;
            this.description = description;
            this.creator = creator;
            this.credit = credit;
            this.creationDate = creationDate;
            this.expirationDate = expirationDate;
            this.lastVersion = lastVersion;
            this.gitDir = gitDir;
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public void create ()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            projectDAC.insertProject(this);
        }

        public void update ()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            projectDAC.updateProject(this);
        }

        public void delete()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            projectDAC.deleteProject(code);
        }

        private static string generateCode()
        {
            string newCode = "";
            // Randomize the code generation based on the DDBB
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
        public string Code
        {
            get { return code; }
            set { code = value; }
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
        public float Credit
        {
            get { return credit; }
            set { credit = value; }
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

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        string title;
        private string description;
        private UserBE creator;
        private string code;
        private DateTime creationDate;
        private DateTime expirationDate;
        private ProjectState state;
        private float credit;
        private DateTime lastVersion;
        private string gitDir;
    }
}
