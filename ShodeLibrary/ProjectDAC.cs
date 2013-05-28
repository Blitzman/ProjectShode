using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

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
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        /* ****************************************************************** */
        /* Methods                                                            */
        /* ****************************************************************** */
        public string insert(ProjectBE project)
        {
            string result = "The project has been created!";

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("INSERT INTO projects (title, description, deadline," +
                "creation_date, state, total_bank, last_partition, partition_bank, gitdir, creator)" +
                "VALUES ('" + project.Title + "','" + project.Description + "','" + project.ExpirationDate.ToString("dd/MM/yyyy") + "','" +
                project.CreationDate.ToString("dd/MM/yyyy") + "'," + "1" + "," + project.Credit + ",'" + project.LastVersion.ToString("dd/MM/yyyy") + 
                "'," + project.Credit + ",'" + project.GitDir + "','" + project.Creator.Email + "')", c);

            com.ExecuteNonQuery();
            c.Close();

            return result;
        }

        public int getTotalProjects()
        {
            int projectCount = 0;

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT count(*) total FROM projects", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                projectCount = Int32.Parse(dr["total"].ToString());
            }

            c.Close();

            return projectCount;
        }

        public ProjectBE getProject(string code)
        {
            ProjectBE project = new ProjectBE();

            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM projects WHERE code='" + code + "'", c);

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                project.Code = Int32.Parse(dr["code"].ToString());
                project.Title = dr["title"].ToString();
                project.Description = dr["description"].ToString();
                //project.ExpirationDate DEALING WITH DATETIMES
                //more datetimes
                project.State = (ProjectState)Int32.Parse(dr["state"].ToString());
                project.Credit = Int32.Parse(dr["total_bank"].ToString());
                project.GitDir = dr["gitdir"].ToString();
                project.Creator = new UserBE();
                project.Creator.Email = dr["creator"].ToString();
            }

            c.Close();
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

        public void update(ProjectBE project)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("UPDATE projects " +
                "SET code=" + project.Code.ToString() + ", title='" + project.Title + "', description='" + project.Description +
                "', state=" + project.State + ", total_bank=" + project.Credit + ", gitdir='" + project.GitDir + "', creator='" + project.Creator.Email + "' " +
                " WHERE code='" + project.Code + "'", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        public void delete(int code)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();

            SqlCommand com = new SqlCommand("DELETE FROM projects WHERE code =" + code.ToString() + "", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        /* ****************************************************************** */
        /* Fields                                                             */
        /* ****************************************************************** */
         private String connection;
    }
}
