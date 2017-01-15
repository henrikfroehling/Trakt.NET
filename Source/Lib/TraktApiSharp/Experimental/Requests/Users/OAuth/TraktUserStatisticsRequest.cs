namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users.Statistics;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserStatisticsRequest : ATraktUsersSingleItemGetRequest<TraktUserStatistics>
    {
        internal TraktUserStatisticsRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => throw new NotImplementedException();
    }
}
