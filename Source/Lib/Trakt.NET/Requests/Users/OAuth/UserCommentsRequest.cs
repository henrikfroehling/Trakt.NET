namespace TraktNet.Requests.Users.OAuth
{
    using Enums;
    using Exceptions;
    using Extensions;
    using Objects.Get.Users;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class UserCommentsRequest : AUsersPagedGetRequest<ITraktUserComment>
    {
        internal string Username { get; set; }

        internal TraktCommentType CommentType { get; set; }

        internal TraktObjectType ObjectType { get; set; }

        internal TraktIncludeReplies? IncludeReplies { get; set; }

        public override string UriTemplate => "users/{username}/comments{/comment_type}{/object_type}{?include_replies,extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (CommentType != null && CommentType != TraktCommentType.Unspecified)
                uriParams.Add("comment_type", CommentType.UriName);

            if (ObjectType != null && ObjectType != TraktObjectType.Unspecified)
                uriParams.Add("object_type", ObjectType.UriName);

            if (IncludeReplies.HasValue)
                uriParams.Add("include_replies", IncludeReplies.Value.ToString().ToLower());

            return uriParams;
        }

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");
        }
    }
}
