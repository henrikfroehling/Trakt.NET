namespace TraktApiSharp.Requests.Genres
{
    using Base;
    using Objects.Basic;
    using System.Collections.Generic;

    internal sealed class TraktGenresMoviesRequest : AGetRequest<ITraktGenre>
    {
        public override string UriTemplate => "genres/movies";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
