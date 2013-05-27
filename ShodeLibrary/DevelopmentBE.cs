using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShodeLibrary
{
    public class DevelopmentBE
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public DevelopmentBE()
        {
            project = new ProjectBE();
            user = new UserBE();
            date = DateTime.Now;
        }

        public DevelopmentBE(ProjectBE project, UserBE user, DateTime date, string gitBranch, int ups)
        {
            this.project = project;
            this.user = user;
            this.date = date;
            this.gitBranch = gitBranch;
            this.ups = ups;
        }

        public DevelopmentBE(DevelopmentBE development)
        {
            this.project = development.project;
            this.user = development.user;
            this.date = development.date;
            this.gitBranch = development.gitBranch;
            this.ups = development.ups;
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public void create()
        {
            DevelopmentDAC developmentDAC = new DevelopmentDAC();
            developmentDAC.insert(this);
        }

        public void update()
        {
            DevelopmentDAC developmentDAC = new DevelopmentDAC();
            developmentDAC.update(this);
        }

        public void delete()
        {
            DevelopmentDAC developmentDAC = new DevelopmentDAC();
            developmentDAC.delete(this);
        }

        /* ****************************************************************** */
        /* Properties                                                         */
        /* ****************************************************************** */
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

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private ProjectBE project;
        private UserBE user;
        private DateTime date;
        private string gitBranch;
        private int ups;
    }
}
