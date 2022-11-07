namespace TraktNet.Requests.Movies
{
    using Base;
    using Interfaces;
    using Objects.Get.Movies;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class MoviesBoxOfficeRequest : AGetRequest<ITraktBoxOfficeMovie>, ISupportsExtendedInfo
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
