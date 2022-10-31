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
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException($"{nameof(show)}.Ids");

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("show ids have no valid id", $"{nameof(show)}.Ids");

            _show = show;
            return this;
        }

        public override ITraktShowCommentPost Build()
        {
            ITraktShowCommentPost showCommentPost = new TraktShowCommentPost
            {
                Comment = _comment,
                Sharing = _sharing,
                Show = _show
            };

            if (_hasSpoiler.HasValue)
                showCommentPost.Spoiler = _hasSpoiler.Value;

            showCommentPost.Validate();
            return showCommentPost;
        }

        protected override ITraktShowCommentPostBuilder GetBuilder() => this;
    }
}
