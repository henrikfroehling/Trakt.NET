namespace TraktApiSharp.Modules
{
    using Attributes;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Shows;
    using Objects.Get.Shows.Episodes;
    using Objects.Get.Shows.Seasons;
    using Objects.Get.Users.Lists;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using Requests;
    using Requests.WithOAuth.Comments;
    using Requests.WithoutOAuth.Comments;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to comments.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/comments">"Trakt API Doc - Comments"</a> section.
    /// </para>
    /// </summary>
    public class TraktCommentsModule : TraktBaseModule
    {
        internal TraktCommentsModule(TraktClient client) : base(client) { }

        /// <summary>
        /// Gets a <see cref="TraktComment" /> or reply with the given id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comment/get-a-comment-or-reply">"Trakt API Doc - Comments: Comment"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMutlipleCommentsAsync(uint[])" />.</para>
        /// </summary>
        /// <param name="commentId">The comment's id.</param>
        /// <returns>An <see cref="TraktComment" /> instance with the queried comment's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given commentId is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktComment> GetCommentAsync(uint commentId)
        {
            ValidateId(commentId);

            return await QueryAsync(new TraktCommentSummaryRequest(Client) { Id = commentId.ToString() });
        }

        /// <summary>
        /// Gets multiple different <see cref="TraktComment" />s or replies at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comment/get-a-comment-or-reply">"Trakt API Doc - Comments: Comment"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetCommentAsync(uint)" />.</para>
        /// </summary>
        /// <param name="commentIds">An array of comment ids.</param>
        /// <returns>A list of <see cref="TraktComment" /> instances with the data of each queried comment.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given comment ids is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<IEnumerable<TraktComment>> GetMutlipleCommentsAsync(uint[] commentIds)
        {
            if (commentIds == null || commentIds.Length <= 0)
                return new List<TraktComment>();

            var tasks = new List<Task<TraktComment>>();

            for (int i = 0; i < commentIds.Length; i++)
            {
                Task<TraktComment> task = GetCommentAsync(commentIds[i]);
                tasks.Add(task);
            }

            var comments = await Task.WhenAll(tasks);
            return comments.ToList();
        }

        /// <summary>
        /// Posts a comment for the given <see cref="TraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="TraktMovie" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given movie. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="TraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <returns>An <see cref="TraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie's title is null, empty or contains spaces.
        /// Thrown, if the given movie has no valid ids. See also <seealso cref="TraktMovieIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given movie's year is not valid.
        /// Thrown, if the given comment's word count is below five.
        /// </exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktCommentPostResponse> PostMovieCommentAsync([NotNull] TraktMovie movie, [NotNull] string comment,
                                                                          bool? containsSpoiler = null, TraktSharing sharing = null)
        {
            ValidateMovie(movie);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktMovieCommentPost>(Client)
            {
                RequestBody = new TraktMovieCommentPost
                {
                    Movie = new TraktMovie
                    {
                        Title = movie.Title,
                        Year = movie.Year,
                        Ids = movie.Ids
                    },
                    Comment = comment,
                    Spoiler = containsSpoiler,
                    Sharing = sharing
                }
            });
        }

        /// <summary>
        /// Posts a comment for the given <see cref="TraktShow" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="show">The <see cref="TraktShow" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given show. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="TraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <returns>An <see cref="TraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show's title is null, empty or contains spaces.
        /// Thrown, if the given show has no valid ids. See also <seealso cref="TraktShowIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given show is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktCommentPostResponse> PostShowCommentAsync([NotNull] TraktShow show, [NotNull] string comment,
                                                                         bool? containsSpoiler = null, TraktSharing sharing = null)
        {
            ValidateShow(show);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktShowCommentPost>(Client)
            {
                RequestBody = new TraktShowCommentPost
                {
                    Show = new TraktShow
                    {
                        Title = show.Title,
                        Ids = show.Ids
                    },
                    Comment = comment,
                    Spoiler = containsSpoiler,
                    Sharing = sharing
                }
            });
        }

        /// <summary>
        /// Posts a comment for the given <see cref="TraktSeason" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="season">The <see cref="TraktSeason" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given season. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="TraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <returns>An <see cref="TraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given season has no valid ids. See also <seealso cref="TraktSeasonIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given season is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktCommentPostResponse> PostSeasonCommentAsync([NotNull] TraktSeason season, [NotNull] string comment,
                                                                           bool? containsSpoiler = null, TraktSharing sharing = null)
        {
            ValidateSeason(season);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktSeasonCommentPost>(Client)
            {
                RequestBody = new TraktSeasonCommentPost
                {
                    Season = new TraktSeason { Ids = season.Ids },
                    Comment = comment,
                    Spoiler = containsSpoiler,
                    Sharing = sharing
                }
            });
        }

        /// <summary>
        /// Posts a comment for the given <see cref="TraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="TraktEpisode" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given episode. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="TraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <returns>An <see cref="TraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given episode has no valid ids. See also <seealso cref="TraktEpisodeIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktCommentPostResponse> PostEpisodeCommentAsync([NotNull] TraktEpisode episode, [NotNull] string comment,
                                                                            bool? containsSpoiler = null, TraktSharing sharing = null)
        {
            ValidateEpisode(episode);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktEpisodeCommentPost>(Client)
            {
                RequestBody = new TraktEpisodeCommentPost
                {
                    Episode = new TraktEpisode { Ids = episode.Ids },
                    Comment = comment,
                    Spoiler = containsSpoiler,
                    Sharing = sharing
                }
            });
        }

        /// <summary>
        /// Posts a comment for the given <see cref="TraktList" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="list">The <see cref="TraktList" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given list. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="TraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <returns>An <see cref="TraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given list has no valid ids. See also <seealso cref="TraktListIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given list is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktCommentPostResponse> PostListCommentAsync([NotNull] TraktList list, [NotNull] string comment,
                                                                         bool? containsSpoiler = null, TraktSharing sharing = null)
        {
            ValidateList(list);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentPostRequest<TraktListCommentPost>(Client)
            {
                RequestBody = new TraktListCommentPost
                {
                    List = new TraktList { Ids = list.Ids },
                    Comment = comment,
                    Spoiler = containsSpoiler,
                    Sharing = sharing
                }
            });
        }

        /// <summary>
        /// Updates a comment or reply with the given comment id, which was posted within the last hour.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comment/update-a-comment-or-reply">"Trakt API Doc - Comments: Comment"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, which should be updated.</param>
        /// <param name="comment">The new comment's content. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <returns>An <see cref="TraktCommentPostResponse" /> instance, containing the successfully updated comment's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given comment id is null, empty or contains spaces.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktCommentPostResponse> UpdateCommentAsync(uint commentId, [NotNull] string comment, bool? containsSpoiler = null)
        {
            ValidateId(commentId);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentUpdateRequest(Client)
            {
                Id = commentId.ToString(),
                RequestBody = new TraktCommentUpdatePost
                {
                    Comment = comment,
                    Spoiler = containsSpoiler
                }
            });
        }

        /// <summary>
        /// Posts a reply to a comment with the given comment id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/replies/post-a-reply-for-a-comment">"Trakt API Doc - Comments: Replies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, for which the reply should be posted.</param>
        /// <param name="comment">The comment's content. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <returns>An <see cref="TraktCommentPostResponse" /> instance, containing the successfully posted reply's data.</returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given comment id is null, empty or contains spaces.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        [OAuthAuthorizationRequired]
        public async Task<TraktCommentPostResponse> PostCommentReplyAsync(uint commentId, [NotNull] string comment, bool? containsSpoiler = null)
        {
            ValidateId(commentId);
            ValidateComment(comment);

            return await QueryAsync(new TraktCommentReplyRequest(Client)
            {
                Id = commentId.ToString(),
                RequestBody = new TraktCommentReplyPost
                {
                    Comment = comment,
                    Spoiler = containsSpoiler
                }
            });
        }

        /// <summary>
        /// Deletes a comment with the given comment id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comment/delete-a-comment-or-reply">"Trakt API Doc - Comments: Comment"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, which should be deleted.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task DeleteCommentAsync(uint commentId)
        {
            ValidateId(commentId);

            await QueryAsync(new TraktCommentDeleteRequest(Client) { Id = commentId.ToString() });
        }

        /// <summary>
        /// Likes a comment with the given comment id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/like/like-a-comment">"Trakt API Doc - Comments: Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, which should be liked.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task LikeCommentAsync(uint commentId)
        {
            ValidateId(commentId);

            await QueryAsync(new TraktCommentLikeRequest(Client) { Id = commentId.ToString() });
        }

        /// <summary>
        /// Unlikes a comment with the given comment id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/like/remove-like-on-a-comment">"Trakt API Doc - Comments: Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, which should be unliked.</param>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired]
        public async Task UnlikeCommentAsync(uint commentId)
        {
            ValidateId(commentId);

            await QueryAsync(new TraktCommentUnlikeRequest(Client) { Id = commentId.ToString() });
        }

        /// <summary>
        /// Gets replies for comment with the given id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/replies/get-replies-for-a-comment">"Trakt API Doc - Comments: Replies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, for which the replies should be queried.</param>
        /// <param name="page">The page of the replies list, that should be queried. Defaults to the first page.</param>
        /// <param name="limitPerPage">The maximum item count of replies for each page, that should be queried.</param>
        /// <returns>
        /// An <see cref="TraktPaginationListResult{TraktComment}"/> instance containing the queried replies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPaginationListResult{ListItem}" /> and <seealso cref="TraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="Exceptions.TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        [OAuthAuthorizationRequired(false)]
        public async Task<TraktPaginationListResult<TraktComment>> GetCommentRepliesAsync(uint commentId, int? page = null, int? limitPerPage = null)
        {
            ValidateId(commentId);

            return await QueryAsync(new TraktCommentRepliesRequest(Client)
            {
                Id = commentId.ToString(),
                PaginationOptions = new TraktPaginationOptions(page, limitPerPage)
            });
        }

        private void ValidateId(uint commentId)
        {
            if (commentId == 0)
                throw new ArgumentException("comment id not valid", nameof(commentId));
        }

        private void ValidateComment(string comment)
        {
            if (string.IsNullOrEmpty(comment))
                throw new ArgumentException("comment is empty", nameof(comment));

            if (comment.WordCount() < 5)
                throw new ArgumentOutOfRangeException(nameof(comment), "comment has too few words - at least five words are required");
        }

        private void ValidateMovie(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "movie must not be null");

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("movie title not valid", nameof(movie.Title));

            if (movie.Year <= 0 || movie.Year.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(movie.Year), "movie year not valid");

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids), "movie ids must not be null");

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("movie ids have no valid id", nameof(movie.Ids));
        }

        private void ValidateShow(TraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show), "show must not be null");

            if (string.IsNullOrEmpty(show.Title))
                throw new ArgumentException("show title not valid", nameof(show.Title));

            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids), "show ids must not be null");

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("show ids have no valid id", nameof(show.Ids));
        }

        private void ValidateSeason(TraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season), "season must not be null");

            if (season.Ids == null)
                throw new ArgumentNullException(nameof(season.Ids), "season ids must not be null");

            if (!season.Ids.HasAnyId)
                throw new ArgumentException("season ids have no valid id", nameof(season.Ids));
        }

        private void ValidateEpisode(TraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode), "episode must not be null");

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids), "episode ids must not be null");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode ids have no valid id", nameof(episode.Ids));
        }

        private void ValidateList(TraktList list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "list must not be null");

            if (list.Ids == null)
                throw new ArgumentNullException(nameof(list.Ids), "list ids must not be null");

            if (!list.Ids.HasAnyId)
                throw new ArgumentException("list ids have no valid id", nameof(list.Ids));
        }
    }
}
