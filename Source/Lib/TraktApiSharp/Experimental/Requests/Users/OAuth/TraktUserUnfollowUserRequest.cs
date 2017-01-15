namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Delete;
    using System;

    internal sealed class TraktUserUnfollowUserRequest : ATraktNoContentDeleteRequest
    {
        internal TraktUserUnfollowUserRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
