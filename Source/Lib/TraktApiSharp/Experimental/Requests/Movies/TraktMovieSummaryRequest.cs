namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Interfaces;
    using Objects.Get.Movies;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktMovieSummaryRequest : ATraktMovieRequest<TraktMovie>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }
        
        public override string UriTemplate => "movies/{id}{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
