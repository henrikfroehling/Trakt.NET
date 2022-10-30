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
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Ids == null)
                throw new ArgumentNullException(nameof(list.Ids));

            if (!list.Ids.HasAnyId)
                throw new ArgumentException("list ids have no valid id", nameof(list.Ids));

            _list = list;
            return this;
        }

        public override ITraktListCommentPost Build()
        {
            ITraktListCommentPost listCommentPost = new TraktListCommentPost
            {
                Comment = _comment,
                Sharing = _sharing,
                List = _list
            };

            if (_hasSpoiler.HasValue)
                listCommentPost.Spoiler = _hasSpoiler.Value;

            listCommentPost.Validate();
            return listCommentPost;
        }

        protected override ITraktListCommentPostBuilder GetBuilder() => this;
    }
}
