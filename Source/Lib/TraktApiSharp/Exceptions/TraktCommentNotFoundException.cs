namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if a comment was not found.<para /> 
    /// Contains, additional to the basic information, the comment id of the comment, which was not found.
    /// </summary>
    public class TraktCommentNotFoundException : TraktObjectNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktCommentNotFoundException" /> class with a default exception message.
        /// </summary>
        /// <param name="commentId">The comment id of the comment, which was not found.</param>
        public TraktCommentNotFoundException(string commentId) : this("Comment Not Found - method exists, but no record found", commentId) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktCommentNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="commentId">The comment id of the comment, which was not found.</param>
        public TraktCommentNotFoundException(string message, string commentId) : base(message, commentId) { }
    }
}
