using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Albert García
 */
namespace ShodeLibrary
{
    public class ContributionDAC
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public ContributionDAC()
        {
            // Get the connection from a fixed source
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public void insertContribution(ContributionBE contribution)
        {
            //Do stuff
        }

        public void deleteContribution(ContributionBE contribution)
        {
            //Do stuff
        }

        public void updateContribution(ContributionBE contribution)
        {
            //Do stuff
        }

        public List<ContributionBE> getContributionsByProject(string projectCode)
        {
            List<ContributionBE> contributions = new List<ContributionBE>();
            //Do stuff
            return contributions;
        }

        public List<ContributionBE> getContributionsByContributor(string contributorMail)
        {
            List<ContributionBE> contributions = new List<ContributionBE>();
            //Do stuff
            return contributions;
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
        private string connection;
    }
}
