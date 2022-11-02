namespace TraktNet.Requests.Movies
{
    using Exceptions;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal sealed class MovieReleasesRequest : AMovieRequest<ITraktMovieRelease>
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

        public override void Validate()
        {
            base.Validate();

            if (CountryCode != null && CountryCode.Length != 2)
                throw new TraktRequestValidationException(nameof(CountryCode), "country code has wrong length; country code should be two characters long");
        }
    }
}
