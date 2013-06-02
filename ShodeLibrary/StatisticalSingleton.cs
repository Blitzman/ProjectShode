using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the singleton class of our application which is used to
    /// efficiently calculate the different statistics that we show in
    /// the header. It is efficient because only one instance is created
    /// and shared and what's more the DACs are instance only once when
    /// the singleton is created.
    /// 
    /// The class is sealed so it cannot be derived.
    /// </summary>
    public sealed class StatisticalSingleton
    {
        /// <summary>
        /// This readonly and static field ensures that only one instance of the
        /// singleton class will be created thanks to the static initialization,
        /// the private constructor and the readonly modifier.
        /// </summary>
        private static readonly StatisticalSingleton instance = new StatisticalSingleton();

        private static readonly ProjectDAC projectDAC = new ProjectDAC();
        private static readonly ContributionDAC contributionDAC = new ContributionDAC();
        private static readonly DevelopmentDAC developmentDAC = new DevelopmentDAC();

        /// <summary>
        /// The only constructor is private so no external instances will be
        /// created outside this class.
        /// </summary>
        private StatisticalSingleton() { }

        /// <summary>
        /// This is the getter for the readonly instance of the singleton object
        /// it returns the singleton which was created in the static initialization
        /// phase. Note that there is no setter.
        /// </summary>
        public static StatisticalSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Total Project Getter.
        /// Gets the number of projects in our database using
        /// the data access component of the projects.
        /// </summary>
        /// <returns>The total number of projects.</returns>
        public int getTotalProjects()
        {
            return projectDAC.getTotalProjects();
        }

        /// <summary>
        /// Total Contributions Getter.
        /// Gets the number of contributions in our database
        /// using the data acess component of the contributions.
        /// </summary>
        /// <returns>The total number of contributions.</returns>
        public int getTotalContributions()
        {
            return contributionDAC.getTotalContributions();
        }
        
        /// <summary>
        /// Total Credits in Projects Getter.
        /// Gets the accumulated credits in all the projects
        /// in the database.
        /// </summary>
        /// <returns>The total number of credits in projects.</returns>
        public int getTotalCreditsInProjects()
        {
            return projectDAC.getTotalCreditsInProjects();
        }

        /// <summary>
        /// Total Developments Getter.
        /// Gets the number of developments in our database
        /// using the data access component of the developments.
        /// </summary>
        /// <returns></returns>
        public int getTotalDevelopments()
        {
            return developmentDAC.getTotalDevelopments();
        }
    }
}
