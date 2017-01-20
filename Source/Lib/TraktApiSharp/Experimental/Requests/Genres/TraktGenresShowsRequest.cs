namespace TraktApiSharp.Experimental.Requests.Genres
{
    using Base;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Basic;

    internal sealed class TraktGenresShowsRequest : ATraktGetRequest<TraktGenre>
    {
        public override string UriTemplate => "genres/shows";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
