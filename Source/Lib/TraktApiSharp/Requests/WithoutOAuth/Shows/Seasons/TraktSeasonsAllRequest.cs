namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Base.Get;
    using Objects.Get.Shows.Seasons;
    using System.Collections.Generic;

    internal class TraktSeasonsAllRequest : TraktGetByIdRequest<IEnumerable<TraktSeason>, TraktSeason>
    {
        internal TraktSeasonsAllRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/seasons{?extended}";

        protected override bool IsListResult => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;
    }
}
