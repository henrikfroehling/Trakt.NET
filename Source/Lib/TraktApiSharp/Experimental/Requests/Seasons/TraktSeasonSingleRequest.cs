namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Interfaces;
    using Objects.Get.Shows.Episodes;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSeasonSingleRequest : ATraktSeasonRequest<TraktEpisode>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
