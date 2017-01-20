namespace TraktApiSharp.Experimental.Requests.Genres
{
    using Base;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Basic;

    internal sealed class TraktGenresMoviesRequest : ATraktGetRequest<TraktGenre>
    {
        public override string UriTemplate => "genres/movies";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
