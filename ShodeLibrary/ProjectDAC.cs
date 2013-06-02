using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the data access component of the projects. This class will allow
    /// performing CRUD operations directly with the database so it will be
    /// an intermediate layer between the business entity of the project and
    /// the raw database.
    /// </summary>
    public class ProjectDAC
    {
        // /////////////////////////////////////////////////////////////////////
        // Constructors ////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default Constructor.
        /// Creates a new data access component by initializing the field
        /// which holds the connection string to the database connection string
        /// value which is stored in the Web.config file.
        /// </summary>
        public ProjectDAC()
        {
            // Get the connection from a fixed source
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Project Insertion.
        /// Inserts the given project in the database building the adequate
        /// query and handling the possible SQL errors that can occur when
        /// performing the query. 
        /// </summary>
        /// <param name="project">The project to be inserted.</param>
        /// <returns>A string which contains an error/success message.</returns>
        public string insert(ProjectBE project)
        {
            string result = "The project has been created!";

            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();

                SqlParameter title = new SqlParameter();
                title.ParameterName = "@title";
                title.Value = project.Title;
                SqlParameter description = new SqlParameter();
                description.ParameterName = "@description";
                description.Value = project.Description;
                SqlParameter total_bank = new SqlParameter();
                total_bank.ParameterName = "@total_bank";
                total_bank.Value = project.Credit.ToString();
                SqlParameter gitdir = new SqlParameter();
                gitdir.ParameterName = "@gitdir";
                gitdir.Value = project.GitDir;
                SqlParameter creator = new SqlParameter();
                creator.ParameterName = "@creator";
                creator.Value = project.Creator.Email;
                SqlParameter code = new SqlParameter();
                code.ParameterName = "@code";
                code.Value = project.Code.ToString();
                SqlParameter expiration_date = new SqlParameter();
                expiration_date.ParameterName = "@expiration_date";
                expiration_date.Value = project.ExpirationDate.ToString("dd/MM/yyyy");
                SqlParameter creation_date = new SqlParameter();
                creation_date.ParameterName = "@creation_date";
                creation_date.Value = project.CreationDate.ToString("dd/MM/yyyy");
                SqlParameter last_partition = new SqlParameter();
                last_partition.ParameterName = "@last_partition";
                last_partition.Value = project.LastVersion.ToString("dd/MM/yyyy");
                SqlParameter partition_bank = new SqlParameter();
                partition_bank.ParameterName = "@partition_bank";
                partition_bank.Value = project.PartitionCredit.ToString();

                SqlCommand com = new SqlCommand("INSERT INTO projects (title, description, deadline," +
                    "creation_date, state, total_bank, last_partition, partition_bank, gitdir, creator)" +
                    "VALUES (@title , @description , @expiration_date , @creation_date , 1 , @total_bank , @last_partition , @partition_bank , @gitdir , @creator)", c);

                com.Parameters.Add(title);
                com.Parameters.Add(description);
                com.Parameters.Add(expiration_date);
                com.Parameters.Add(creation_date);
                com.Parameters.Add(total_bank);
                com.Parameters.Add(last_partition);
                com.Parameters.Add(partition_bank);
                com.Parameters.Add(gitdir);
                com.Parameters.Add(creator);

                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                    result = "ERROR: A project has already that code.";
            }
            catch (Exception ex)
            {
                result = "ERROR: Unknown error, try it again later...";
            }
            finally
            {
                c.Close();
            }

            return result;
        }

        /// <summary>
        /// Total Projects Getter.
        /// This is another statistical method which obtains the
        /// total amount of projects that have been created.
        /// </summary>
        /// <returns>The total amount of projects.</returns>
        public int getTotalProjects()
        {
            int projectCount = 0;

            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("SELECT count(*) total FROM projects", c);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    projectCount = Int32.Parse(dr["total"].ToString());
                }
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

            return projectCount;
        }

        /// <summary>
        /// Project Getter.
        /// Fetchs a determined project from the database given its project code.
        /// </summary>
        /// <param name="projectCode">The code of the project to be fetched.</param>
        /// <returns>The fetched project if found, an empty one if not.</returns>
        public ProjectBE getProject(int projectCode)
        {
            ProjectBE project = new ProjectBE();

            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();

                SqlParameter code = new SqlParameter();
                code.ParameterName = "@code";
                code.Value = projectCode.ToString();

                SqlCommand com = new SqlCommand("SELECT * FROM projects WHERE code=@code", c);

                com.Parameters.Add(code);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    project.Code = Int32.Parse(dr["code"].ToString());
                    project.Title = dr["title"].ToString();
                    project.Description = dr["description"].ToString();
                    project.CreationDate = DateTime.ParseExact(dr["creation_date"].ToString(), "dd/MM/yyyy", null);
                    project.ExpirationDate = DateTime.ParseExact(dr["deadline"].ToString(), "dd/MM/yyyy", null);
                    project.State = (ProjectState)Int32.Parse(dr["state"].ToString());
                    project.Credit = Int32.Parse(dr["total_bank"].ToString());
                    project.GitDir = dr["gitdir"].ToString();
                    project.Creator = new UserBE();
                    project.Creator.Email = dr["creator"].ToString();
                }
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

            return project;
        }

        /// <summary>
        /// Total Credits in Project Getter.
        /// Queries the database to obtain the total amount of credits
        /// that all the projects accumulate.
        /// </summary>
        /// <returns>The total number of credits accumulated.</returns>
        public int getTotalCreditsInProjects()
        {
            int amount = 0;

            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT sum(total_bank) total FROM projects", c);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["total"].ToString() != "")
                        amount = Int32.Parse(dr["total"].ToString());
                }
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

            return amount;
        }

        /// <summary>
        /// All Projects Getter.
        /// Gets a list with all the projects in the database.
        /// </summary>
        /// <returns>The project list.</returns>
        public List<ProjectBE> getAllProjects ()
        {
            List<ProjectBE> projects = new List<ProjectBE>();

            ProjectBE project = new ProjectBE();

            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("SELECT * FROM projects", c);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    project.Code = Int32.Parse(dr["code"].ToString());
                    project.Title = dr["title"].ToString();
                    project.Description = dr["description"].ToString();
                    project.CreationDate = DateTime.ParseExact(dr["creation_date"].ToString(), "dd/MM/yyyy", null);
                    project.ExpirationDate = DateTime.ParseExact(dr["deadline"].ToString(), "dd/MM/yyyy", null);
                    project.State = (ProjectState)Int32.Parse(dr["state"].ToString());
                    project.Credit = Int32.Parse(dr["total_bank"].ToString());
                    project.GitDir = dr["gitdir"].ToString();
                    project.Creator = new UserBE();
                    project.Creator.Email = dr["creator"].ToString();
                    projects.Add(project);
                }
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

            return projects;
        }

        /// <summary>
        /// Last Code Getter.
        /// Gets the last inserted code.
        /// </summary>
        /// <returns>The last inserted code.</returns>
        public int lastCode()
        {
            int lastCode = 0;

            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT MAX(code) last_id FROM projects", c);

                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["last_id"].ToString() != "")
                        lastCode = Int32.Parse(dr["last_id"].ToString());
                }
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

            return lastCode;
        }

        // Not used yet
        public List<ProjectBE> getProjetsByCreator(UserBE creator, int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        // Not used yet
        public List<ProjectBE> getProjetsByDeveloper(UserBE developer, int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        // Not used yet
        public List<ProjectBE> getProjetsByContributor(UserBE contributor, int num)
        {
            List<ProjectBE> projects = new List<ProjectBE>();
            // Do Stuff here (Query)
            return projects;
        }

        /// <summary>
        /// Project Update.
        /// Updates the database register which matches the given
        /// project replacing all the database fields with
        /// the ones of the provided contribution.
        /// </summary>
        /// <param name="project">The "source" project that will be updated.</param>
        public void update(ProjectBE project)
        {
            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();

                SqlParameter title = new SqlParameter();
                title.ParameterName = "@title";
                title.Value = project.Title;
                SqlParameter description = new SqlParameter();
                description.ParameterName = "@description";
                description.Value = project.Description;
                SqlParameter total_bank = new SqlParameter();
                total_bank.ParameterName = "@total_bank";
                total_bank.Value = project.Credit.ToString();
                SqlParameter gitdir = new SqlParameter();
                gitdir.ParameterName = "@gitdir";
                gitdir.Value = project.GitDir;
                SqlParameter creator = new SqlParameter();
                creator.ParameterName = "@creator";
                creator.Value = project.Creator.Email;
                SqlParameter code = new SqlParameter();
                code.ParameterName = "@code";
                code.Value = project.Code.ToString();
                SqlParameter deadline = new SqlParameter();
                deadline.ParameterName = "@deadline";
                deadline.Value = project.ExpirationDate.ToString("dd/MM/yyyy");
                SqlParameter creation_date = new SqlParameter();
                creation_date.ParameterName = "@creation_date";
                creation_date.Value = project.CreationDate.ToString("dd/MM/yyyy");
                SqlParameter last_partition = new SqlParameter();
                last_partition.ParameterName = "@last_partition";
                last_partition.Value = project.LastVersion.ToString("dd/MM/yyyy");
                SqlParameter partition_bank = new SqlParameter();
                partition_bank.ParameterName = "@partition_bank";
                partition_bank.Value = project.PartitionCredit.ToString();

                SqlCommand com = new SqlCommand("UPDATE projects " +
                    "SET title=@title , description=@description , state=1, total_bank=@total_bank , creation_date=@creation_date ," +
                    "deadline=@deadline , last_partition=@last_partition , partition_bank=@partition_bank , gitdir=@gitdir , creator=@creator" +
                    " WHERE code=@code", c);

                com.Parameters.Add(title);
                com.Parameters.Add(description);
                com.Parameters.Add(total_bank);
                com.Parameters.Add(creation_date);
                com.Parameters.Add(deadline);
                com.Parameters.Add(last_partition);
                com.Parameters.Add(partition_bank);
                com.Parameters.Add(gitdir);
                com.Parameters.Add(creator);
                com.Parameters.Add(code);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        /// <summary>
        /// Project Delete.
        /// Removes a project from the database given the code of the project
        /// to be deleted.
        /// </summary>
        /// <param name="projectCode">The code of the project that will be deleted.</param>
        public void delete(int projectCode)
        {
            SqlConnection c = new SqlConnection(connection);

            try
            {
                c.Open();

                SqlParameter code = new SqlParameter();
                code.ParameterName = "@code";
                code.Value = projectCode.ToString();

                SqlCommand com = new SqlCommand("DELETE FROM projects WHERE code=@code", c);

                com.Parameters.Add(code);

                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }
        }

        public static DataSet getRecentProjects()
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select code, title, nickname, " +
                " creation_date, total_bank, state from projects, users where " + "projects.creator=users.email and " +
                "creation_date like '" + DateTime.Today.ToString("dd") + "%'", c);
            da.Fill(d, "projects");
            c.Close();

            return d;
        }

        public static DataSet searchProjects(String search)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select code, title, nickname, " +
                " creation_date, total_bank, state from projects, users " +
                " where title like '%" + search + "%' and projects.creator=users.email", c);
            da.Fill(d, "projects");
            c.Close();

            return d;
        }

        public static DataSet getPopularProjects()
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select code, title, nickname, " +
                " creation_date, total_bank, state from projects, users " +
                " where total_bank >=(select 0.9*max(total_bank) from projects) and projects.creator=users.email", c);
            da.Fill(d, "projects");
            c.Close();

            return d;
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
         private string connection;
    }
}
