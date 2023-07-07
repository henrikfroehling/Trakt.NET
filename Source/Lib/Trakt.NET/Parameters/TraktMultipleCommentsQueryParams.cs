namespace TraktNet.Parameters
{
    /// <summary>
    /// Collection containing multiple different combinations of comment ids and optionalextended infos.
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new TraktMultipleCommentsQueryParams
    /// {
    ///     // { comment-id[, extended info] }
    ///     { 1 },
    ///     { 3, new TraktExtendedInfo { Full = true } }
    /// };
    /// </code>
    /// </example>
    public class TraktMultipleCommentsQueryParams : TraktMultipleQueryParams<TraktCommentQueryParams>
    {
        /// <summary>Adds a new episode query parameter pack to the collection.</summary>
        /// <param name="commentId">A comment id.</param>
        /// <param name="extendedInfo">An optional extended info. See also <see cref="TraktExtendedInfo" />.</param>
        public void Add(uint commentId, TraktExtendedInfo extendedInfo = null)
            => Add(new TraktCommentQueryParams(commentId, extendedInfo));
    }

    /// <summary>
    /// A single query parameter for multiple comment queries.
    /// Contains a combination of a comment id and an optional extended info.
    /// </summary>
    public readonly struct TraktCommentQueryParams
    {
        /// <summary>Initializes a new instance of the <see cref="TraktCommentQueryParams" /> class.</summary>
        /// <param name="commentId">A comment id.</param>
        /// <param name="extendedInfo">An optional extended info. See also <see cref="TraktExtendedInfo" />.</param>
        public TraktCommentQueryParams(uint commentId, TraktExtendedInfo extendedInfo)
        {
            CommentId = commentId;
            ExtendedInfo = extendedInfo;
        }

        /// <summary>Returns the comment id.</summary>
        public uint CommentId { get; }

        /// <summary>
        /// Returns the optional extended info.
        /// <para>Nullable.</para>
        /// </summary>
        public TraktExtendedInfo ExtendedInfo { get; }
    }
}
