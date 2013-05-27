using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ShodeLibrary
{
    public class ContributionDAC
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public ContributionDAC()
        {
            // Gets the string connection from a unique location
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
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
