namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Post.Comments;

    public interface ITraktCommentPostBuilder<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktCommentPostBuilder<TPostBuilder, TPostObject>
        where TPostObject : ITraktCommentPost
    {
        TPostBuilder WithComment(string comment);

        TPostBuilder WithSpoiler(bool hasSpoiler = true);

        TPostBuilder WithSharing(ITraktConnections sharing);

        TPostObject Build();
    }
}
