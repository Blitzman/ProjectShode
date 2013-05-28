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
            code = -1;
            creationDate = new DateTime();
            expirationDate = new DateTime();
            state = ProjectState.Closed;
            credit = 0.0f;
            lastVersion = new DateTime();
            gitDir = "";
        }

        public ProjectBE(string title, string description,
                            UserBE creator, int code,
                            DateTime creationDate, DateTime expirationDate,
                            float credit, DateTime lastVersion,
                            string gitDir) 
        {
            this.code = code;
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
            projectDAC.insert(this);
        }

        public void update ()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            projectDAC.update(this);
        }

        public void delete()
        {
            ProjectDAC projectDAC = new ProjectDAC();
            projectDAC.delete(code);
        }

        public ProjectBE getByCode()
        {
            ProjectDAC dac = new ProjectDAC();
            return dac.getProject(this.code);
        }

        /* ****************************************************************** */
        /* Properties                                                         */
        /* ****************************************************************** */
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
        private int code;
        string title;
        private string description;
        private UserBE creator;
        private DateTime creationDate;
        private DateTime expirationDate;
        private ProjectState state;
        private float credit;
        private DateTime lastVersion;
        private string gitDir;
    }
}
