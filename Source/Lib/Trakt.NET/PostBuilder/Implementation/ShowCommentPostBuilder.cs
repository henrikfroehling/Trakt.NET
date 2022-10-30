namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Comments;

    internal sealed class ShowCommentPostBuilder : ACommentPostBuilder<ITraktShowCommentPostBuilder, ITraktShowCommentPost>, ITraktShowCommentPostBuilder
    {
        private ITraktShow _show;

        public ITraktShowCommentPostBuilder WithShow(ITraktShow show)
        {
            _show = show ?? throw new ArgumentNullException(nameof(show));
            return this;
        }

        public override ITraktShowCommentPost Build()
        {
            ITraktShowCommentPost showCommentPost = new TraktShowCommentPost
            {
                Comment = _comment,
                Spoiler = _hasSpoiler,
                Sharing = _sharing,
                Show = _show
            };

            showCommentPost.Validate();
            return showCommentPost;
        }

        protected override ITraktShowCommentPostBuilder GetBuilder() => this;
    }
}
