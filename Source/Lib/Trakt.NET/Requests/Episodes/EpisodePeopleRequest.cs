namespace TraktNet.Requests.Episodes
{
    using Interfaces;
    using Objects.Get.Shows;
    using Parameters;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal sealed class EpisodePeopleRequest : AEpisodeRequest<ITraktShowCastAndCrew>, ISupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/people{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
