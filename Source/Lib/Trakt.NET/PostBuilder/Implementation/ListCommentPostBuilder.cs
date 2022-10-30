namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Post.Comments;

    internal sealed class ListCommentPostBuilder : ACommentPostBuilder<ITraktListCommentPostBuilder, ITraktListCommentPost>, ITraktListCommentPostBuilder
    {
        private ITraktList _list;

        public ITraktListCommentPostBuilder WithList(ITraktList list)
        {
            _list = list ?? throw new ArgumentNullException(nameof(list));
            return this;
        }

        public override ITraktListCommentPost Build()
        {
            ITraktListCommentPost listCommentPost = new TraktListCommentPost
            {
                Comment = _comment,
                Spoiler = _hasSpoiler,
                Sharing = _sharing,
                List = _list
            };

            listCommentPost.Validate();
            return listCommentPost;
        }

        protected override ITraktListCommentPostBuilder GetBuilder() => this;
    }
}
