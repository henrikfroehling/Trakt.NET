namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Objects.Get.Users;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
