namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Shows.Seasons;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonsAllRequest : ATraktListGetByIdRequest<TraktSeason>, ITraktObjectRequest
    {
        public TraktSeasonsAllRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/seasons{?extended}";
    }
}
