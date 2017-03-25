namespace TraktApiSharp.Requests.Movies
{
    using Base;
    using Interfaces;
    using Objects.Get.Movies;
    using Parameters;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    internal sealed class TraktMoviesBoxOfficeRequest : ATraktGetRequest<TraktBoxOfficeMovie>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "movies/boxoffice{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }

        public override void Validate() { }
    }
}
