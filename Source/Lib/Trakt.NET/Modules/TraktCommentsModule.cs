namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Episodes;
    using Objects.Get.Lists;
    using Objects.Get.Movies;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Get.Users;
    using Objects.Post.Comments;
    using Objects.Post.Comments.Responses;
    using PostBuilder;
    using Requests.Comments;
    using Requests.Comments.OAuth;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Extensions;
    using TraktNet.Parameters;

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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktComment" /> instance with the queried comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktComment>> GetCommentAsync(uint commentId, CancellationToken cancellationToken = default)
        {
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCommentItem" /> instance with the queried comment's media item.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCommentItem>> GetCommentItemAsync(uint commentId, TraktExtendedInfo extendedInfo = null,
                                                                          CancellationToken cancellationToken = default)
        {
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktCommentLike}"/> instance containing the queried likes and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktCommentLike" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktCommentLike>> GetCommentLikesAsync(uint commentId, TraktExtendedInfo extendedInfo = null,
                                                                                TraktPagedParameters pagedParameters = null,
                                                                                CancellationToken cancellationToken = default)
        {
            var request = new CommentLikesRequest
            {
                Id = commentId.ToString(),
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of <see cref="ITraktComment" /> instances with the data of each queried comment.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        [Obsolete("GetMutlipleCommentsAsync is deprecated, please use GetCommentsStreamAsync instead.")]
        public async Task<IEnumerable<TraktResponse<ITraktComment>>> GetMutlipleCommentsAsync(uint[] commentIds, CancellationToken cancellationToken = default)
        {
            if (commentIds == null || commentIds.Length == 0)
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
        /// Gets multiple different <see cref="ITraktComment" />s or replies at once with the given Trakt-Ids or -Slugs.
        /// <para>OAuth authorization not required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comment/get-a-comment-or-reply">"Trakt API Doc - Comments: Comment"</a> for more information.
        /// </para>
        /// <para>See also <seealso cref="GetCommentAsync(uint, CancellationToken)" />.</para>
        /// </summary>
        /// <param name="commentIds">A list of comment ids.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <a href="https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1?view=net-7.0">async stream</a> of <see cref="ITraktComment" /> instances with the data of each queried comment.</returns>
        /// <exception cref="TraktException">Thrown, if one request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public async IAsyncEnumerable<TraktResponse<ITraktComment>> GetCommentsStreamAsync(IEnumerable<uint> commentIds, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (commentIds == null || commentIds.Count() == 0)
                yield break;

            var tasks = new List<Task<TraktResponse<ITraktComment>>>();

            foreach (var commentId in commentIds)
            {
                Task<TraktResponse<ITraktComment>> task = GetCommentAsync(commentId, cancellationToken);
                tasks.Add(task);
            }

            await foreach(TraktResponse<ITraktComment> result in tasks.StreamFinishedTaskResultsAsync())
            {
                yield return result;
            }
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
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
            var request = new CommentsUpdatesRequest
            {
                CommentType = commentType,
                ObjectType = objectType,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
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
            var request = new CommentsRecentRequest
            {
                CommentType = commentType,
                ObjectType = objectType,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
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
            var request = new CommentsTrendingRequest
            {
                CommentType = commentType,
                ObjectType = objectType,
                IncludeReplies = includeReplies,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktMovie" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktMovieCommentPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktMovieCommentPost" />.
        /// See also <seealso cref="TraktPost.NewMovieCommentPost()" />.
        /// </para>
        /// </summary>
        /// <param name="movieCommentPost">An <see cref="ITraktMovieCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostMovieCommentAsync(ITraktMovieCommentPost movieCommentPost,
                                                                                    CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktMovieCommentPost>
            {
                RequestBody = movieCommentPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktShow" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktShowCommentPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktShowCommentPost" />.
        /// See also <seealso cref="TraktPost.NewShowCommentPost()" />.
        /// </para>
        /// </summary>
        /// <param name="showCommentPost">An <see cref="ITraktShowCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostShowCommentAsync(ITraktShowCommentPost showCommentPost,
                                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktShowCommentPost>
            {
                RequestBody = showCommentPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktSeason" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktSeasonCommentPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktSeasonCommentPost" />.
        /// See also <seealso cref="TraktPost.NewSeasonCommentPost()" />.
        /// </para>
        /// </summary>
        /// <param name="seasonCommentPost">An <see cref="ITraktSeasonCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostSeasonCommentAsync(ITraktSeasonCommentPost seasonCommentPost,
                                                                                     CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktSeasonCommentPost>
            {
                RequestBody = seasonCommentPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktEpisode" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktEpisodeCommentPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktEpisodeCommentPost" />.
        /// See also <seealso cref="TraktPost.NewEpisodeCommentPost()" />.
        /// </para>
        /// </summary>
        /// <param name="episodeCommentPost">An <see cref="ITraktEpisodeCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostEpisodeCommentAsync(ITraktEpisodeCommentPost episodeCommentPost,
                                                                                      CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktEpisodeCommentPost>
            {
                RequestBody = episodeCommentPost
            },
            cancellationToken);
        }

        /// <summary>
        /// Posts a comment for the given <see cref="ITraktList" />.
        /// <para>OAuth authorization required.</para>
        /// <para>
        /// See <a href="http://docs.trakt.apiary.io/#reference/comments/comments/post-a-comment">"Trakt API Doc - Comments: Comments"</a> for more information.
        /// </para>
        /// <para>
        /// It is recommended to use the <see cref="ITraktListCommentPostBuilder" /> to create an instance
        /// of the required <see cref="ITraktListCommentPost" />.
        /// See also <seealso cref="TraktPost.NewListCommentPost()" />.
        /// </para>
        /// </summary>
        /// <param name="listCommentPost">An <see cref="ITraktListCommentPost" /> instance, which should be posted.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostListCommentAsync(ITraktListCommentPost listCommentPost,
                                                                                   CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(Client);

            return requestHandler.ExecuteSingleItemRequestAsync(new CommentPostRequest<ITraktListCommentPost>
            {
                RequestBody = listCommentPost
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully updated comment's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> UpdateCommentAsync(uint commentId, string comment, bool? containsSpoiler = null,
                                                                                 CancellationToken cancellationToken = default)
        {
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>An <see cref="ITraktCommentPostResponse" /> instance, containing the successfully posted reply's data.</returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktPostValidationException">Thrown, if validation of post data fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktResponse<ITraktCommentPostResponse>> PostCommentReplyAsync(uint commentId, string comment, bool? containsSpoiler = null,
                                                                                    CancellationToken cancellationToken = default)
        {
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> DeleteCommentAsync(uint commentId, CancellationToken cancellationToken = default)
        {
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> LikeCommentAsync(uint commentId, CancellationToken cancellationToken = default)
        {
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
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktNoContentResponse> UnlikeCommentAsync(uint commentId, CancellationToken cancellationToken = default)
        {
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
        /// <param name="pagedParameters">Specifies pagination parameters. <see cref="TraktPagedParameters" />.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried replies and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetCommentRepliesAsync(uint commentId, TraktPagedParameters pagedParameters = null,
                                                                              CancellationToken cancellationToken = default)
        {
            var request = new CommentRepliesRequest
            {
                Id = commentId.ToString(),
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit,
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }
    }
}
