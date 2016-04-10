namespace TraktApiSharp.Requests.Shows.Common
{
    using Base.Get;
    using Enums;
    using Objects;
    using Objects.Shows.Common;
    using System.Collections.Generic;

    internal class TraktShowsMostWatchedRequest : TraktGetRequest<TraktPaginationListResult<TraktShowsMostWatchedItem>, TraktShowsMostWatchedItem>
    {
        internal TraktShowsMostWatchedRequest(TraktClient client) : base(client) { Period = TraktPeriod.Weekly; }

        internal TraktPeriod Period { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "period", Period.AsString() } };
        }

        protected override string UriTemplate => "shows/watched/{period}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}
