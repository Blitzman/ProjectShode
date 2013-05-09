using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Albert García
 */
namespace ShodeLibrary
{
    public class ProjectDAC
    {
        /* ****************************************************************** */
        /* Constructors                                                       */
        /* ****************************************************************** */
        public ProjectDAC()
        {
            // Get the connection from a fixed source
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public string insertProject(ProjectBE project)
        {
            string code = "";
            // Do Stuff here (Query)
            return code;
        }

        public ProjectBE getProject(string code)
        {
            ProjectBE project = new ProjectBE();
            // Do Stuff here (Query)
            return project;
        }

        public List<ProjectBE> getAllProjects ()
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        public List<ProjectBE> getTopProjets(int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        public List<ProjectBE> getNewProjets(int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        public List<ProjectBE> getExpiringSoonProjects(int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        public List<ProjectBE> getProjetsByCreator(UserBE creator, int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        public List<ProjectBE> getProjetsByDeveloper(UserBE developer, int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        public List<ProjectBE> getProjetsByContributor(UserBE contributor, int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        public void updateProject(ProjectBE project)
        {
            // Do Stuff here (Query)
        }

        public void deleteProject(string code)
        {
            // Do Stuff here (Query)
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
         private String connection;
    }
}
