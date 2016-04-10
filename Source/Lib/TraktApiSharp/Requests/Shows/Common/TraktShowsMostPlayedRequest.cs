namespace TraktApiSharp.Requests.Shows.Common
{
    using Base.Get;
    using Enums;
    using Objects;
    using Objects.Shows.Common;
    using System.Collections.Generic;

    internal class TraktShowsMostPlayedRequest : TraktGetRequest<TraktPaginationListResult<TraktShowsMostPlayedItem>, TraktShowsMostPlayedItem>
    {
        internal TraktShowsMostPlayedRequest(TraktClient client) : base(client) { Period = TraktPeriod.Weekly; }

        internal TraktPeriod Period { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "period", Period.AsString() } };
        }

        protected override string UriTemplate => "shows/played/{period}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
