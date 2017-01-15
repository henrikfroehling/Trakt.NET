namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Watched;
    using System;

    internal sealed class TraktUserWatchedMoviesRequest : ATraktUsersListGetRequest<TraktWatchedMovie>
    {
        internal TraktUserWatchedMoviesRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
