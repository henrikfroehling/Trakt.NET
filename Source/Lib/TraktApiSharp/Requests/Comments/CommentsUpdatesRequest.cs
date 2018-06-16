namespace TraktApiSharp.Requests.Comments
{
    using Base;
    using Enums;
    using Interfaces;
    using Objects.Get.Users;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class CommentsUpdatesRequest : AGetRequest<ITraktUserComment>, ISupportsExtendedInfo, ISupportsPagination
    {
        internal TraktCommentType CommentType { get; set; }

        internal TraktObjectType ObjectType { get; set; }

        internal bool? IncludeReplies { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "comments/updates{/comment_type}{/object_type}{?include_replies,extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (CommentType != null && CommentType != TraktCommentType.Unspecified)
                uriParams.Add("comment_type", CommentType.UriName);

            if (ObjectType != null && ObjectType != TraktObjectType.Unspecified)
                uriParams.Add("object_type", ObjectType.UriName);

            if (IncludeReplies.HasValue)
                uriParams.Add("include_replies", IncludeReplies.ToString().ToLower());

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate()
        {
        }
    }
}
