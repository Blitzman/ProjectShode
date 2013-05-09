using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Task performed by Brayan
 */
namespace ShodeLibrary {
    public class CommentDAC {
    	/*
    	 * Default constructor.
    	 */
    	public CommentDAC () {

    	}

    	/*
    	 * Creation in the DB of a comment.
    	 */
    	public string createComment (CommentBE comment) {
    		string code="";

    		return code;
    	}

    	/*
    	 * It returns a comment given a code. If the code
    	 * does not exist an empty comment will be returned.
    	 */
    	public CommentBE getComment (string code) {
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
        public void update (CommentBE) {

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
    	public void deleteComment (string code) {

    	}

    	/*
    	 * Properties.
    	 */ 
    	private string connection;
    }
}
