namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Parameters;
    using Requests.Handler;
    using Requests.Movies;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktMoviesModule : ATraktModule
    {
        /// <summary>
        /// Gets top level comments for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/translations/get-all-movie-comments">"Trakt API Doc - Movies: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIdOrSlug">The movie's Trakt-Id or -Slug. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktExtendedCommentSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about a comment's media item should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried movie comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetMovieCommentsAsync(string movieIdOrSlug,
                                                                             TraktExtendedCommentSortOrder commentSortOrder = null,
                                                                             TraktExtendedInfo extendedInfo = null,
                                                                             TraktPagedParameters pagedParameters = null,
                                                                             CancellationToken cancellationToken = default)
        {
            var request = new MovieCommentsRequest
            {
                Id = movieIdOrSlug,
                SortOrder = commentSortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets top level comments for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/translations/get-all-movie-comments">"Trakt API Doc - Movies: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktMovieId">The movie's Trakt-Id. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktExtendedCommentSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about a comment's media item should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried movie comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktMovieId"/> is 0.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetMovieCommentsAsync(uint traktMovieId,
                                                                             TraktExtendedCommentSortOrder commentSortOrder = null,
                                                                             TraktExtendedInfo extendedInfo = null,
                                                                             TraktPagedParameters pagedParameters = null,
                                                                             CancellationToken cancellationToken = default)
        {
            if (traktMovieId == 0)
                throw new ArgumentException("movie id must not be 0", nameof(traktMovieId));

            return GetMovieCommentsAsync(traktMovieId.ToString(), commentSortOrder, extendedInfo, pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets top level comments for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/translations/get-all-movie-comments">"Trakt API Doc - Movies: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movieIds">The movie's ids. See also <seealso cref="ITraktMovieIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktExtendedCommentSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about a comment's media item should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried movie comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movieIds"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="movieIds"/> has not any ids set.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetMovieCommentsAsync(ITraktMovieIds movieIds,
                                                                             TraktExtendedCommentSortOrder commentSortOrder = null,
                                                                             TraktExtendedInfo extendedInfo = null,
                                                                             TraktPagedParameters pagedParameters = null,
                                                                             CancellationToken cancellationToken = default)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            if (!movieIds.HasAnyId)
                throw new ArgumentException($"{nameof(movieIds)} has not any ids set", nameof(movieIds));

            return GetMovieCommentsAsync(movieIds.GetBestId(), commentSortOrder, extendedInfo, pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets top level comments for a <see cref="ITraktMovie" /> with the given Trakt-Id or -Slug.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://trakt.docs.apiary.io/#reference/movies/translations/get-all-movie-comments">"Trakt API Doc - Movies: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The movie. See also <seealso cref="ITraktMovie" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktExtendedCommentSortOrder" />.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about a comment's media item should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried movie comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="movie"/> is null.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetMovieCommentsAsync(ITraktMovie movie,
                                                                             TraktExtendedCommentSortOrder commentSortOrder = null,
                                                                             TraktExtendedInfo extendedInfo = null,
                                                                             TraktPagedParameters pagedParameters = null,
                                                                             CancellationToken cancellationToken = default)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            return GetMovieCommentsAsync(movie.Ids, commentSortOrder, extendedInfo, pagedParameters, cancellationToken);
        }
    }
}
