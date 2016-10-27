namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Movies;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieSummaryRequest : ATraktSingleItemGetByIdRequest<TraktMovie>, ITraktObjectRequest
    {
        internal TraktMovieSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "movies/{id}{?extended}";
    }
}
