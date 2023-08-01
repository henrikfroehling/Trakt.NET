namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Get.Shows;
    using Objects.Post.Comments;
    using System;

    internal sealed class ShowCommentPostBuilder : ACommentPostBuilder<ITraktShowCommentPostBuilder, ITraktShowCommentPost>, ITraktShowCommentPostBuilder
    {
        private ITraktShow _show;
        private ITraktShowIds _showIds;

        public ITraktShowCommentPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException($"{nameof(show)}.Ids");

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("show ids have no valid id", $"{nameof(show)}.Ids");

            _show = show;
            _showIds = null;
            return this;
        }

        public ITraktShowCommentPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (!showIds.HasAnyId)
                throw new ArgumentException($"{nameof(showIds)} have no valid id");

            _show = null;
            _showIds = showIds;
            return this;
        }

        public override ITraktShowCommentPost Build()
        {
            ITraktShowCommentPost showCommentPost = new TraktShowCommentPost
            {
                Comment = _comment,
                Sharing = _sharing
            };

            if (_hasSpoiler.HasValue)
                showCommentPost.Spoiler = _hasSpoiler.Value;

            if (_show == null && _showIds == null)
                throw new TraktPostValidationException("Empty comment post. No show value set.");

            if (_show != null)
            {
                showCommentPost.Show = _show;
            }
            else
            {
                showCommentPost.Show = new TraktShow
                {
                    Ids = _showIds
                };
            }

            showCommentPost.Validate();
            return showCommentPost;
        }

        protected override ITraktShowCommentPostBuilder GetBuilder() => this;
    }
}
