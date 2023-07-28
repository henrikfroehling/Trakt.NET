namespace TraktNet.Modules
{
    using Enums;
    using Exceptions;
    using Objects.Basic;
    using Objects.Get.Lists;
    using Parameters;
    using Requests.Handler;
    using Requests.Lists;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TraktListsModule : ATraktModule
    {
        /// <summary>
        /// Gets top level comments for a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-comments/get-all-list-comments">"Trakt API Doc - Lists: List Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIdOrSlug">The id or slug of the list, for which the comments should be queried.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
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
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried list comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetListCommentsAsync(string listIdOrSlug, TraktCommentSortOrder commentSortOrder = null,
                                                                            TraktExtendedInfo extendedInfo = null, TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default)
        {
            var request = new ListCommentsRequest
            {
                Id = listIdOrSlug,
                SortOrder = commentSortOrder,
                ExtendedInfo = extendedInfo,
                Page = pagedParameters?.Page,
                Limit = pagedParameters?.Limit
            };

            return RequestHandler.ExecutePagedRequestAsync(Client, request, cancellationToken);
        }

        /// <summary>
        /// Gets top level comments for a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-comments/get-all-list-comments">"Trakt API Doc - Lists: List Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="traktListId">The list's Trakt-Id. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
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
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried list comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="traktListId"/> is 0.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetListCommentsAsync(uint traktListId, TraktCommentSortOrder commentSortOrder = null,
                                                                            TraktExtendedInfo extendedInfo = null, TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default)
        {
            if (traktListId == 0)
                throw new ArgumentException("list id must not be 0", nameof(traktListId));

            return GetListCommentsAsync(traktListId.ToString(), commentSortOrder, extendedInfo, pagedParameters, cancellationToken);
        }

        /// <summary>
        /// Gets top level comments for a list.
        /// <para>
        /// See <a href="https://trakt.docs.apiary.io/#reference/lists/list-comments/get-all-list-comments">"Trakt API Doc - Lists: List Comments"</a> for more information.
        /// </para>
        /// </summary>
        /// <param name="listIds">The list's ids. See also <seealso cref="ITraktListIds" />.</param>
        /// <param name="commentSortOrder">The comments sort order. See also <seealso cref="TraktCommentSortOrder" />.</param>
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
        /// An <see cref="TraktPagedResponse{ITraktComment}"/> instance containing the queried list comments and which also
        /// contains the queried page number, the page's item count, maximum page count and maximum item count.
        /// <para>
        /// See also <seealso cref="TraktPagedResponse{ListItem}" /> and <seealso cref="ITraktComment" />.
        /// </para>
        /// </returns>
        /// <exception cref="TraktException">Thrown, if the request fails.</exception>
        /// <exception cref="TraktRequestValidationException">Thrown, if validation of request data fails.</exception>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="listIds"/> is null.</exception>
        public Task<TraktPagedResponse<ITraktComment>> GetListCommentsAsync(ITraktListIds listIds, TraktCommentSortOrder commentSortOrder = null,
                                                                            TraktExtendedInfo extendedInfo = null, TraktPagedParameters pagedParameters = null,
                                                                            CancellationToken cancellationToken = default)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} has not any ids set", nameof(listIds));

            return GetListCommentsAsync(listIds.GetBestId(), commentSortOrder, extendedInfo, pagedParameters, cancellationToken);
        }
    }
}
