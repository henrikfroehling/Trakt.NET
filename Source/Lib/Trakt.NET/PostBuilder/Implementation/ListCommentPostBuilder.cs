namespace TraktNet.PostBuilder
{
    using Exceptions;
    using Objects.Get.Lists;
    using Objects.Post.Comments;
    using System;

    internal sealed class ListCommentPostBuilder : ACommentPostBuilder<ITraktListCommentPostBuilder, ITraktListCommentPost>, ITraktListCommentPostBuilder
    {
        private ITraktList _list;
        private ITraktListIds _listIds;

        public ITraktListCommentPostBuilder WithList(ITraktList list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (list.Ids == null)
                throw new ArgumentNullException($"{nameof(list)}.Ids");

            if (!list.Ids.HasAnyId)
                throw new ArgumentException("list ids have no valid id", $"{nameof(list)}.Ids");

            _list = list;
            _listIds = null;
            return this;
        }

        public ITraktListCommentPostBuilder WithList(ITraktListIds listIds)
        {
            if (listIds == null)
                throw new ArgumentNullException(nameof(listIds));

            if (!listIds.HasAnyId)
                throw new ArgumentException($"{nameof(listIds)} have no valid id");

            _list = null;
            _listIds = listIds;
            return this;
        }

        public override ITraktListCommentPost Build()
        {
            ITraktListCommentPost listCommentPost = new TraktListCommentPost
            {
                Comment = _comment,
                Sharing = _sharing
            };

            if (_hasSpoiler.HasValue)
                listCommentPost.Spoiler = _hasSpoiler.Value;

            if (_list == null && _listIds == null)
                throw new TraktPostValidationException("Empty comment post. No list value set.");

            if (_list != null)
            {
                listCommentPost.List = _list;
            }
            else
            {
                listCommentPost.List = new TraktList
                {
                    Ids = _listIds
                };
            }

            listCommentPost.Validate();
            return listCommentPost;
        }

        protected override ITraktListCommentPostBuilder GetBuilder() => this;
    }
}
