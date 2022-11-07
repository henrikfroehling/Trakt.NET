﻿namespace TraktNet.Requests.Episodes
{
    using Interfaces;
    using Objects.Get.Episodes;
    using Parameters;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal sealed class EpisodeSummaryRequest : AEpisodeRequest<ITraktEpisode>, ISupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
