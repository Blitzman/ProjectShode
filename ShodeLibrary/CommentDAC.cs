using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ShodeLibrary
{
    /// <summary>
    /// This is the data access component of the commentaries. This class will allow
    /// performing CRUD operations directly with the database so it will be
    /// an intermediate layer between the business entity and the database.
    /// </summary>
    public class CommentDAC
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
        public CommentDAC()
        {
            // Gets the string connection from a unique location
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
        }

        // /////////////////////////////////////////////////////////////////////
        // Methods /////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Comment Insertion.
        /// Inserts the given comment in the database.
        /// </summary>
        /// <param name="comment">The comment to be inserted.</param>
        public void insertComment(CommentBE comment)
        {
            SqlConnection c = new SqlConnection(connection);
            c.Open();
            SqlCommand com;
            com = new SqlCommand("Insert into comments (project, usr, date, comment)" +
                "values ('" + comment.Project.Code + "', '" + comment.Writer.Email + "', '" +
                comment.Date.ToString("G") + "', '" + comment.Content + "')", c);

            com.ExecuteNonQuery();
            c.Close();
        }

        /* /// <returns>A string which contains an error/success message.</returns> */
        /*public string insertComment (CommentBE comment) {
            String result = "The comment has been successfully added!";
            SqlConnection c = new SqlConnection(connection);
            try
            {
                c.Open();

                SqlParameter project = new SqlParameter();
                project.ParameterName = "@project";
                project.Value = comment.Project.Code;
                SqlParameter usr = new SqlParameter();
                usr.ParameterName = "@usr";
                usr.Value = comment.Writer.Email;
                SqlParameter date = new SqlParameter();
                date.ParameterName = "@date";
                date.Value = comment.Date.ToString("G");
                SqlParameter content = new SqlParameter();
                content.ParameterName = "@comment";
                content.Value = comment.Content;

                SqlCommand com = new SqlCommand("Insert into comments (project, usr, date, comment)" +
                    "values (@project, @usr, @date, @comment)", c);

                com.Parameters.Add(project);
                com.Parameters.Add(usr);
                com.Parameters.Add(date);
                com.Parameters.Add(comment);

                com.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                //TODO

            }
            catch (Exception e)
            {
                // Show message box
            }
            finally
            {
                c.Close();
            }

            return result;
        }*/

        /*
         * It returns a comment given a code. If the code
         * does not exist an empty comment will be returned.
         */
        public CommentBE getComment()
        {
            CommentBE comment = new CommentBE();
            //TODO
            return comment;
        }

        /*
         * Obtain the top three commentarties in a given project.
         */
        public List<CommentBE> getTopCommentsProject(ProjectBE project)
        {
            List<CommentBE> topComments = new List<CommentBE>();
            //TODO
            return topComments;
        }

        /*
         * Method for obtaining all the comments a given user has written in
         * a determined project.
         */
        public List<CommentBE> getCommentsInProjectBy(ProjectBE project, UserBE user)
        {
            List<CommentBE> comments = new List<CommentBE>();
            //TODO
            return comments;
        }

        /*
         * Update, in general, a comment.
         */
        public void update(CommentBE comment)
        {
            //TODO
        }

        /*
         * It is possible to edit the comment content.
         */
        public void updateContentComment(string code, string content)
        {
            //TODO
        }

        /*
         * Delete the given comment.
         */
        public void deleteComment(CommentBE comment)
        {
            //TODO
        }

        /// <summary>
        /// Project Comments getter.
        /// This method get the comments written in a given project.
        /// Those comments are returned in a data set in order to ease the
        /// task of showing it in gridviews.
        /// </summary>
        /// <param name="project">The project we want to get comments from.</param>
        /// <returns>A data set with the comments.</returns>
        public static DataSet getProjectComments(ProjectBE project)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select nickname, date, comment from users, comments" +
                " where project=" + project.Code + " and comments.usr=users.email", c);
            da.Fill(d, "comments");
            c.Close();

            return d;
        }

        // /////////////////////////////////////////////////////////////////////
        // Fields //////////////////////////////////////////////////////////////
        // /////////////////////////////////////////////////////////////////////
        private string connection;
    }
}
