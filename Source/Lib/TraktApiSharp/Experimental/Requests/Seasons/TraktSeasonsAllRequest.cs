namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Objects.Get.Shows.Seasons;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonsAllRequest : ATraktListGetByIdRequest<TraktSeason>
    {
        public TraktSeasonsAllRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/seasons{?extended}";
    }
}
