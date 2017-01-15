namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCommentsRequest : ATraktUsersPaginationGetRequest<TraktUserComment>
    {
        internal TraktUserCommentsRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktCommentType CommentType { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/comments{/comment_type}{/type}{?extended,page,limit}";
    }
}
