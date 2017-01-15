namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users.Statistics;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserStatisticsRequest : ATraktUsersSingleItemGetRequest<TraktUserStatistics>
    {
        internal TraktUserStatisticsRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/stats";
    }
}
