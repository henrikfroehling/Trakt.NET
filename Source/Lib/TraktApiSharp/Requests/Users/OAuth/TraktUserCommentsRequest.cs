namespace TraktApiSharp.Requests.Users.OAuth
{
    using Enums;
    using Extensions;
    using Objects.Get.Users;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktUserCommentsRequest : ATraktUsersPagedGetRequest<TraktUserComment>
    {
        internal string Username { get; set; }

        internal TraktCommentType CommentType { get; set; }

        internal TraktObjectType ObjectType { get; set; }

        public override string UriTemplate => "users/{username}/comments{/comment_type}{/object_type}{?extended,page,limit}";

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

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
