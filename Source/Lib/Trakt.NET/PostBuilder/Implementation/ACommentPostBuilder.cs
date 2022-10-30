namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Post.Comments;

    internal abstract class ACommentPostBuilder<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktCommentPostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktCommentPost
    {
        protected string _comment;
        protected bool _hasSpoiler;
        protected ITraktConnections _sharing;

        protected ACommentPostBuilder()
        {
            _comment = string.Empty;
            _hasSpoiler = false;
            _sharing = null;
        }

        public TPostBuilder WithComment(string comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            if (comment.WordCount() < 5)
                throw new ArgumentOutOfRangeException(nameof(comment), "comment has too few words - at least five words are required");

            _comment = comment;
            return GetBuilder();
        }

        public TPostBuilder WithSpoiler(bool hasSpoiler = true)
        {
            _hasSpoiler = hasSpoiler;
            return GetBuilder();
        }

        public TPostBuilder WithSharing(ITraktConnections sharing)
        {
            _sharing = sharing ?? throw new ArgumentNullException(nameof(sharing));
            return GetBuilder();
        }

        public abstract TPostObject Build();

        protected abstract TPostBuilder GetBuilder();
    }
}
