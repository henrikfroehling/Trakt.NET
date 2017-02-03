namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Interfaces;
    using Objects.Basic;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktShowPeopleRequest : ATraktShowRequest<TraktCastAndCrew>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "shows/{id}/people{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
