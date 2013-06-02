using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the business entity of the contributions. This class allows a single
    /// contribution to perform CRUD operations by communicating with the determined
    /// data access component for the contribution.
    /// </summary>
    public class ContributionBE
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new contribution business entity with "empty" values.
        /// </summary>
        public ContributionBE()
        {
            contributor = new UserBE();
            project = new ProjectBE();
            amount = 0;
            date = DateTime.Now;
        }

        /// <summary>
        /// Auxiliary Constructor.
        /// Creates a new contribution business entity filling the fields
        /// with the provided ones.
        /// </summary>
        /// <param name="contributor">The user that performed the contribution.</param>
        /// <param name="project">The destination project of the contribution</param>
        /// <param name="amount">The amount of credits contributed.</param>
        /// <param name="date">The date when the contribution was made.</param>
        public ContributionBE(UserBE contributor, ProjectBE project, int amount, DateTime date)
        {
            this.contributor = contributor;
            this.project = project;
            this.amount = amount;
            this.date = date;
        }

        /// <summary>
        /// Copy Constructor.
        /// Creates a new contribution business entity by copying the fields
        /// of another contribution BE.
        /// </summary>
        /// <param name="contribution">The source contribution.</param>
        public ContributionBE(ContributionBE contribution)
        {
            this.contributor = contribution.contributor;
            this.project = contribution.project;
            this.amount = contribution.amount;
            this.date = contribution.date;
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Contribution Creation.
        /// Uses the contribution data access component to insert the current
        /// contribution in the database.
        /// </summary>
        public void create()
        {
            ContributionDAC contributionDAC = new ContributionDAC();
            contributionDAC.insert(this);
        }

        /// <summary>
        /// Contribution Update.
        /// Uses the contribution data access component to update the register
        /// of the database which holds the current contribution data with
        /// the actual values of the current contribution.
        /// </summary>
        public void update()
        {
            ContributionDAC contributionDAC = new ContributionDAC();
            contributionDAC.update(this);
        }

        /// <summary>
        /// Contribution Deletion.
        /// Deletes the current contribution from the database if it exists
        /// using the contribution data access component.
        /// </summary>
        public void delete()
        {
            ContributionDAC contributionDAC = new ContributionDAC();
            contributionDAC.delete(this);
        }

        // /////////////////////////////////////////////////////////////////////
        // Properties //////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
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
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private UserBE contributor;
        private ProjectBE project;
        private int amount;
        private DateTime date;
    }
}