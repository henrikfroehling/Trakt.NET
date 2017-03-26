namespace TraktApiSharp.Requests.Genres
{
    using Base;
    using Objects.Basic.Implementations;
    using System.Collections.Generic;

    internal sealed class TraktGenresShowsRequest : ATraktGetRequest<TraktGenre>
    {
        public override string UriTemplate => "genres/shows";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
