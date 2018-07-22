namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Movies;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Get.Users;
    using Objects.Get.Users.Lists;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using Requests.Comments;
    using Requests.Comments.OAuth;
    using Requests.Handler;
    using Requests.Parameters;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to data retrieving methods specific to comments.
    /// <para>
    /// This module contains all methods of the <a href ="http://docs.trakt.apiary.io/#reference/comments">"Trakt API Doc - Comments"</a> section.
    /// </para>
    /// </summary>
    public class TraktCommentsModule : ATraktModule
    {
        internal TraktCommentsModule(TraktClient client) : base(client)
        {
        }

        /// <summary>
        /// Gets a <see cref="ITraktComment" /> or reply with the given id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comment/get-a-comment-or-reply">"Trakt API Doc - Comments: Comment"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetMutlipleCommentsAsync(uint[], CancellationToken)" />.</para>
        /// </summary>
        /// <param name="commentId">The comment's id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktComment" /> instance with the queried comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given commentId is null, empty or contains spaces.</exception>
        public Task<TraktResponse<ITraktComment>> GetCommentAsync(uint commentId, CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentSummaryRequest
            {
                Id = commentId.ToString()
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets the attached media <see cref="ITraktCommentItem" /> from a comment with the given id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/comments/item/get-the-attached-media-item">"Trakt API Doc - Comments: Item"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The comment's id.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the comment's media item should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktCommentItem" /> instance with the queried comment's media item.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given commentId is null, empty or contains spaces.</exception>
        public Task<TraktResponse<ITraktCommentItem>> GetCommentItemAsync(uint commentId, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentItemRequest
            {
                Id = commentId.ToString(),
                ExtendedInfo = extendedInfo
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets likes for comment with the given id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/comments/likes/get-all-users-who-liked-a-comment">"Trakt API Doc - Comments: Likes"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The comment's id.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the comment's likes should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktCommentLike}"/> instance containing the queried likes and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktCommentLike" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        public Task<TraktPagedResponse<ITraktCommentLike>> GetCommentLikesAsync(uint commentId, TraktExtendedInfo extendedInfo = null,
                                                                                TraktPagedParameters pagedParameters = null,
                                                                                CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new CommentLikesRequest
            {
                Id = commentId.ToString(),
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets multiple different <see cref="ITraktComment" />s or replies at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comment/get-a-comment-or-reply">"Trakt API Doc - Comments: Comment"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetCommentAsync(uint, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="commentIds">An array of comment ids.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="ITraktComment" /> instances with the data of each queried comment.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if one of the given comment ids is null, empty or contains spaces.</exception>
        public async Task<IEnumerable<TraktResponse<ITraktComment>>> GetMutlipleCommentsAsync(uint[] commentIds, CancellationToken cancellationToken = default)
        {
            if (commentIds == null || commentIds.Length <= 0)
                return new List<TraktResponse<ITraktComment>>();

            var tasks = new List<Task<TraktResponse<ITraktComment>>>();

            for (int i = 0; i < commentIds.Length; i++)
            {
                Task<TraktResponse<ITraktComment>> task = GetCommentAsync(commentIds[i], cancellationToken);
                tasks.Add(task);
            }

            TraktResponse<ITraktComment>[] comments = await Task.WhenAll(tasks).ConfigureAwait(false);
            return comments.ToList();
        }

        /// <summary>
        /// Gets recently updated comments.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/comments/updates/get-recently-updated-comments">"Trakt API Doc - Comments: Updates"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentType">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="objectType">Determines, for which object types comments should be queried. See also <seealso cref="TraktObjectType" />.</param>
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the commented objects should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserComment}"/> instance containing the queried recently updated comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktUserComment>> GetRecentlyUpdatedCommentsAsync(TraktCommentType commentType = null,
                                                                                           TraktObjectType objectType = null,
                                                                                           bool? includeReplies = null,
                                                                                           TraktExtendedInfo extendedInfo = null,
                                                                                           TraktPagedParameters pagedParameters = null,
                                                                                           CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new CommentsUpdatesRequest
            {
                CommentType = commentType,
                ObjectType = objectType,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets recently created comments.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/comments/recent/get-recently-created-comments">"Trakt API Doc - Comments: Recent"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentType">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="objectType">Determines, for which object types comments should be queried. See also <seealso cref="TraktObjectType" />.</param>
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the commented objects should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserComment}"/> instance containing the queried recently created comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktUserComment>> GetRecentlyCreatedCommentsAsync(TraktCommentType commentType = null,
                                                                                           TraktObjectType objectType = null,
                                                                                           bool? includeReplies = null,
                                                                                           TraktExtendedInfo extendedInfo = null,
                                                                                           TraktPagedParameters pagedParameters = null,
                                                                                           CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new CommentsRecentRequest
            {
                CommentType = commentType,
                ObjectType = objectType,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets trending comments.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/comments/trending/get-trending-comments">"Trakt API Doc - Comments: Trending"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentType">Determines, which type of comments should be queried. See also <seealso cref="TraktCommentType" />.</param>
        /// <param name="objectType">Determines, for which object types comments should be queried. See also <seealso cref="TraktObjectType" />.</param>
        /// <param name="includeReplies">Determines, whether replies should be retrieved alongside with comments.</param>
        /// <param name="extendedInfo">
        /// The extended info, which determines how much data about the commented objects should be queried.
        /// See also <seealso cref="TraktExtendedInfo" />.
        /// </param>
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktUserComment}"/> instance containing the queried trending comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktUserComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        public Task<TraktPagedResponse<ITraktUserComment>> GetTrendingCommentsAsync(TraktCommentType commentType = null,
                                                                                    TraktObjectType objectType = null,
                                                                                    bool? includeReplies = null,
                                                                                    TraktExtendedInfo extendedInfo = null,
                                                                                    TraktPagedParameters pagedParameters = null,
                                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new CommentsTrendingRequest
            {
                CommentType = commentType,
                ObjectType = objectType,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="movie">The <see cref="ITraktMovie" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given movie. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="ITraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie's title is null, empty or contains spaces.
        /// Thrown, if the given movie has no valid ids. See also <seealso cref="ITraktMovieIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given movie is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given movie's year is not valid.
        /// Thrown, if the given comment's word count is below five.
        /// </exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostMovieCommentAsync(ITraktMovie movie, string comment,
                                                                                    bool? containsSpoiler = null, ITraktSharing sharing = null,
                                                                                    CancellationToken cancellationToken = default)
        {
            ValidateMovie(movie);
            ValidateComment(comment);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktMovieCommentPost>
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
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktShow" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="show">The <see cref="ITraktShow" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given show. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="ITraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show's title is null, empty or contains spaces.
        /// Thrown, if the given show has no valid ids. See also <seealso cref="ITraktShowIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given show is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostShowCommentAsync(ITraktShow show, string comment,
                                                                                   bool? containsSpoiler = null, ITraktSharing sharing = null,
                                                                                   CancellationToken cancellationToken = default)
        {
            ValidateShow(show);
            ValidateComment(comment);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktShowCommentPost>
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
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktSeason" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="season">The <see cref="ITraktSeason" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given season. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="ITraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given season has no valid ids. See also <seealso cref="ITraktSeasonIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given season is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostSeasonCommentAsync(ITraktSeason season, string comment,
                                                                                     bool? containsSpoiler = null, ITraktSharing sharing = null,
                                                                                     CancellationToken cancellationToken = default)
        {
            ValidateSeason(season);
            ValidateComment(comment);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktSeasonCommentPost>
            {
                RequestBody = new TraktSeasonCommentPost
                {
                    Season = new TraktSeason
                    {
                        Ids = season.Ids
                    },
                    Comment = comment,
                    Spoiler = containsSpoiler,
                    Sharing = sharing
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="episode">The <see cref="ITraktEpisode" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given episode. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="ITraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given episode has no valid ids. See also <seealso cref="ITraktEpisodeIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given episode is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostEpisodeCommentAsync(ITraktEpisode episode, string comment,
                                                                                      bool? containsSpoiler = null, ITraktSharing sharing = null,
                                                                                      CancellationToken cancellationToken = default)
        {
            ValidateEpisode(episode);
            ValidateComment(comment);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktEpisodeCommentPost>
            {
                RequestBody = new TraktEpisodeCommentPost
                {
                    Episode = new TraktEpisode
                    {
                        Ids = episode.Ids
                    },
                    Comment = comment,
                    Spoiler = containsSpoiler,
                    Sharing = sharing
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktList" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="list">The <see cref="ITraktList" />, for which the comment should be posted.</param>
        /// <param name="comment">The comment's content for the given list. Should be at least five words long.</param>
        /// <param name="containsSpoiler">Determines, if the <paramref name="comment" /> contains any spoilers.</param>
        /// <param name="sharing"><see cref="ITraktSharing" /> instance, containing sharing information for the comment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given list has no valid ids. See also <seealso cref="ITraktListIds" />.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given list is null or its ids are null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostListCommentAsync(ITraktList list, string comment,
                                                                                   bool? containsSpoiler = null, ITraktSharing sharing = null,
                                                                                   CancellationToken cancellationToken = default)
        {
            ValidateList(list);
            ValidateComment(comment);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktListCommentPost>
            {
                RequestBody = new TraktListCommentPost
                {
                    List = new TraktList
                    {
                        Ids = list.Ids
                    },
                    Comment = comment,
                    Spoiler = containsSpoiler,
                    Sharing = sharing
                }
            },
            cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully updated comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given comment id is null, empty or contains spaces.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> UpdateCommentAsync(uint commentId, string comment, bool? containsSpoiler = null,
                                                                                 CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            ValidateComment(comment);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentUpdateRequest
            {
                Id = commentId.ToString(),
                RequestBody = new TraktCommentUpdatePost
                {
                    Comment = comment,
                    Spoiler = containsSpoiler
                }
            },
            cancellationToken);
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
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted reply's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given comment id is null, empty or contains spaces.
        /// Thrown, if the given comment is null or empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given comment's word count is below five.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostCommentReplyAsync(uint commentId, string comment, bool? containsSpoiler = null,
                                                                                    CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            ValidateComment(comment);

            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentReplyRequest
            {
                Id = commentId.ToString(),
                RequestBody = new TraktCommentReplyPost
                {
                    Comment = comment,
                    Spoiler = containsSpoiler
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Deletes a comment with the given comment id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comment/delete-a-comment-or-reply">"Trakt API Doc - Comments: Comment"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, which should be deleted.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        public Task<TraktNoContentResponse> DeleteCommentAsync(uint commentId, CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new CommentDeleteRequest
            {
                Id = commentId.ToString()
            },
            cancellationToken);
        }

        /// <summary>
        /// Likes a comment with the given comment id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/like/like-a-comment">"Trakt API Doc - Comments: Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, which should be liked.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        public Task<TraktNoContentResponse> LikeCommentAsync(uint commentId, CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new CommentLikeRequest
            {
                Id = commentId.ToString()
            },
            cancellationToken);
        }

        /// <summary>
        /// Unlikes a comment with the given comment id.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/like/remove-like-on-a-comment">"Trakt API Doc - Comments: Like"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, which should be unliked.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        public Task<TraktNoContentResponse> UnlikeCommentAsync(uint commentId, CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteNoContentRequestAsync(new CommentUnlikeRequest
            {
                Id = commentId.ToString()
            },
            cancellationToken);
        }

        /// <summary>
        /// Gets replies for comment with the given id.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/replies/get-replies-for-a-comment">"Trakt API Doc - Comments: Replies"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="commentId">The id of the comment, for which the replies should be queried.</param>
        /// <param name="pagedParameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried replies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given comment id is null, empty or contains spaces.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetCommentRepliesAsync(uint commentId, TraktPagedParameters pagedParameters = null,
                                                                              CancellationToken cancellationToken = default)
        {
            ValidateId(commentId);
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecutePagedRequestAsync(new CommentRepliesRequest
            {
                Id = commentId.ToString(),
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit,
            },
            cancellationToken);
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

        private void ValidateMovie(ITraktMovie movie)
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

        private void ValidateShow(ITraktShow show)
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

        private void ValidateSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season), "season must not be null");

            if (season.Ids == null)
                throw new ArgumentNullException(nameof(season.Ids), "season ids must not be null");

            if (!season.Ids.HasAnyId)
                throw new ArgumentException("season ids have no valid id", nameof(season.Ids));
        }

        private void ValidateEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode), "episode must not be null");

            if (episode.Ids == null)
                throw new ArgumentNullException(nameof(episode.Ids), "episode ids must not be null");

            if (!episode.Ids.HasAnyId)
                throw new ArgumentException("episode ids have no valid id", nameof(episode.Ids));
        }

        private void ValidateList(ITraktList list)
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
