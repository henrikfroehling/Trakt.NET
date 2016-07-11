namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Get.Shows.Episodes;
    using System.Collections.Generic;

    internal class TraktSeasonSingleRequest : TraktGetByIdSeasonRequest<IEnumerable<TraktEpisode>, TraktEpisode>
    {
        internal TraktSeasonSingleRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}{?extended}";

        protected override bool IsListResult => true;
    }
}
