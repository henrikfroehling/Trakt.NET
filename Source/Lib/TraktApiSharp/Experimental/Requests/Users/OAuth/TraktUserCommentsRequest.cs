namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class TraktUserCommentsRequest : ATraktUsersPaginationGetRequest<TraktUserComment>
    {
        internal TraktUserCommentsRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktCommentType CommentType { get; set; }

        internal TraktObjectType ObjectType { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (CommentType != null && CommentType != TraktCommentType.Unspecified)
                uriParams.Add("comment_type", CommentType.UriName);

            if (ObjectType != null && ObjectType != TraktObjectType.Unspecified)
                uriParams.Add("object_type", ObjectType.UriName);

            return uriParams;
        }

        public override string UriTemplate => "users/{username}/comments{/comment_type}{/object_type}{?extended,page,limit}";
    }
}
