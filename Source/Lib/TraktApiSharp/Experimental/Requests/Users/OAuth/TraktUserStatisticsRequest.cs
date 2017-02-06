namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users.Statistics;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserStatisticsRequest //: ATraktUsersSingleItemGetRequest<TraktUserStatistics>
    {
        internal TraktUserStatisticsRequest(TraktClient client)  {}

        internal string Username { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public string UriTemplate => "users/{username}/stats";
    }
}
