namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Movies;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktMovieSummaryRequest : ATraktSingleItemGetByIdRequest<TraktMovie>, ITraktExtendedInfo
    {
        internal TraktMovieSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "movies/{id}{?extended}";
    }
}
