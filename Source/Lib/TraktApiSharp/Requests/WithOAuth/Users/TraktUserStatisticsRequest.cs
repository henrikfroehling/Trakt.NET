namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Objects.Get.Users.Statistics;
    using System.Collections.Generic;

    internal class TraktUserStatisticsRequest : TraktGetRequest<TraktUserStatistics, TraktUserStatistics>
    {
        internal TraktUserStatisticsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username } };
        }

        protected override string UriTemplate => "users/{username}/stats";
    }
}
