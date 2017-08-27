namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Objects.Get.Users.Statistics;
    using System;
    using System.Collections.Generic;

    internal sealed class UserStatisticsRequest : AGetRequest<ITraktUserStatistics>
    {
        internal string Username { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/stats";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username
            };

        public override void Validate()
        {
            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
