namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Shows.Seasons;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSeasonsAllRequest : ATraktListGetByIdRequest<TraktSeason>, ITraktExtendedInfo
    {
        internal TraktSeasonsAllRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/seasons{?extended}";
    }
}
