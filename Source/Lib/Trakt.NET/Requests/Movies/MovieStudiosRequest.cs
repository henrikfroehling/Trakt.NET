namespace TraktNet.Requests.Movies
{
    using Requests.Base;

    internal sealed class MovieStudiosRequest : AStudiosRequest
    {
        public override string UriTemplate => "movies/{id}/studios";

        public override RequestObjectType RequestObjectType => RequestObjectType.Movies;
    }
}
