using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ShodeLibrary {
    public class CommentDAC {
    	/*
    	 * Default constructor.
    	 */
    	public CommentDAC () 
        {
            // Gets the string connection from a unique location
            connection = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
    	}

    	/*
    	 * Creation in the DB of a comment.
    	 */
    	public void insertComment (CommentBE comment) {
            SqlConnection c = new SqlConnection(connection);
            c.Open();
            SqlCommand com;
            com = new SqlCommand("Insert into comments (project, usr, date, comment)" +
                "values ('" + comment.Project.Code + "', '" + comment.Writer.Email + "', '" +
                comment.Date.ToString("G") + "', '" + comment.Content + "')", c);

            com.ExecuteNonQuery();
            c.Close();
    	}

    	/*
    	 * It returns a comment given a code. If the code
    	 * does not exist an empty comment will be returned.
    	 */
    	public CommentBE getComment () {
    		CommentBE comment = new CommentBE();

    		return comment;
    	}

        /*
         * Obtain the top three commentarties in a given project.
         */
        public List<CommentBE> getTopCommentsProject (ProjectBE project) {
            List<CommentBE> topComments=new List<CommentBE>();

            return topComments;
        }

        /*
         * Method for obtaining all the comments a given user has written in
         * a determined project.
         */
        public List<CommentBE> getCommentsInProjectBy (ProjectBE project, UserBE user) {
            List<CommentBE> comments=new List<CommentBE>();

            return comments;
        }

        /*
         * Update, in general, a comment.
         */
        public void update (CommentBE comment) {

        }

    	/*
    	 * We are able to change the title of a comment.
    	 */
    	public void updateTitleComment (string code, string title) {

    	}

    	/*
    	 * It is possible to edit the comment content.
    	 */
    	public void updateContentComment (string code, string content) {

    	}

    	/*
    	 * We can change the assessment the writer is giving to the 
    	 * the project where the comment has been written.
    	 */
    	public void updateProjectAssessmentComment (string code, int assessment) {

    	}

    	/*
    	 * We can change the assessment of a comment. It can increase or
    	 * be decreased by the votes of other users.
    	 */
    	public void updateCommentAssessmentComment (string code, int assessment) {

    	}

    	/*
    	 * Delete the given comment.
    	 */
    	public void deleteComment (CommentBE comment) {

    	}

    	/*
    	 * Properties.
    	 */ 
    	private string connection;
    }
}
