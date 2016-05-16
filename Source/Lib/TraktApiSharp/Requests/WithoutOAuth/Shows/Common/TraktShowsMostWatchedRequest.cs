namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Common;
    using System.Collections.Generic;

    internal class TraktShowsMostWatchedRequest : TraktGetRequest<TraktPaginationListResult<TraktMostWatchedShow>, TraktMostWatchedShow>
    {
        internal TraktShowsMostWatchedRequest(TraktClient client) : base(client) { Period = TraktPeriod.Weekly; }

        internal TraktPeriod Period { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Period != TraktPeriod.Unspecified)
                uriParams.Add("period", Period.AsString());

            return uriParams;
        }

        protected override string UriTemplate => "shows/watched{/period}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
