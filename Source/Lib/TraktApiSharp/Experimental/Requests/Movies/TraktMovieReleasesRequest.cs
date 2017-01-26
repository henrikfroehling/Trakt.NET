namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal sealed class TraktMovieReleasesRequest : ATraktMovieRequest<TraktMovieRelease>
    {
        internal string CountryCode { get; set; }
        
        public override string UriTemplate => "movies/{id}/releases{/country}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (!string.IsNullOrEmpty(CountryCode))
                uriParams.Add("country", CountryCode);

            return uriParams;
        }
    }
}
