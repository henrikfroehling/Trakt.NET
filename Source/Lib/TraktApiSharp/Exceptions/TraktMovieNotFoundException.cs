namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if a movie was not found.<para /> 
    /// Contains, additional to the basic information, the movie id of the movie, which was not found.
    /// </summary>
    public class TraktMovieNotFoundException : TraktObjectNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMovieNotFoundException" /> class with a default exception message.
        /// </summary>
        /// <param name="movieId">The Trakt-Id or -Slug of the movie, which was not found.</param>
        public TraktMovieNotFoundException(string movieId) : this("Movie Not Found - method exists, but no record found", movieId) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMovieNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="movieId">The Trakt-Id or -Slug of the movie, which was not found.</param>
        public TraktMovieNotFoundException(string message, string movieId) : base(message, movieId) { }
    }
}
