namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Get.Movies.Common;
    using System.Collections.Generic;

    internal class TraktMoviesBoxOfficeRequest : TraktGetRequest<IEnumerable<TraktBoxOfficeMovie>, TraktBoxOfficeMovie>
    {
        internal TraktMoviesBoxOfficeRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "movies/boxoffice{?extended}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool IsListResult => true;
    }
}
