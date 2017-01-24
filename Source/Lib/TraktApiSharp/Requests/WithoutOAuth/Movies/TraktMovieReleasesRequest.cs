namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal class TraktMovieReleasesRequest : TraktGetByIdRequest<IEnumerable<TraktMovieRelease>, TraktMovieRelease>
    {
        internal TraktMovieReleasesRequest(TraktClient client) : base(client) { }

        internal string CountryCode { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (!string.IsNullOrEmpty(CountryCode))
                uriParams.Add("country", CountryCode);

            return uriParams;
        }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/releases{/country}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
