namespace TraktApiSharp.Requests.Genres
{
    using Base;
    using Objects.Basic;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Basic.Implementations;

    internal sealed class TraktGenresMoviesRequest : ATraktGetRequest<TraktGenre>
    {
        public override string UriTemplate => "genres/movies";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
