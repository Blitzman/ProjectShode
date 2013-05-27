using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShodeLibrary
{
    public class ContributionBE
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public ContributionBE()
        {
            contributor = new UserBE();
            project = new ProjectBE();
            amount = 0.0f;
            date = DateTime.Now;
        }

        public ContributionBE(UserBE contributor, ProjectBE project, float amount, DateTime date)
        {
            this.contributor = contributor;
            this.project = project;
            this.amount = amount;
            this.date = date;
        }

        public ContributionBE(ContributionBE contribution)
        {
            this.contributor = contribution.contributor;
            this.project = contribution.project;
            this.amount = contribution.amount;
            this.date = contribution.date;
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public void create()
        {
            ContributionDAC contributionDAC = new ContributionDAC();
            contributionDAC.insertContribution(this);
        }

        public void update()
        {
            ContributionDAC contributionDAC = new ContributionDAC();
            contributionDAC.updateContribution(this);
        }

        public void delete()
        {
            ContributionDAC contributionDAC = new ContributionDAC();
            contributionDAC.deleteContribution(this);
        }

        /* ****************************************************************** */
        /* Properties                                                         */
        /* ****************************************************************** */
        public UserBE Contributor
        {
            get { return contributor; }
            set { contributor = value; }
        }
        public ProjectBE Project
        {
            get { return project; }
            set { project = value; }
        }
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private UserBE contributor;
        private ProjectBE project;
        private float amount;
        private DateTime date;
    }
}
