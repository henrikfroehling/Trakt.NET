namespace TraktNet.Requests.Movies.OAuth
{
    using System.Collections.Generic;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Interfaces;

    internal sealed class MovieRefreshRequest : ABodylessPostRequest, IHasId
    {
        public string Id { get; set; }

        public override string UriTemplate => "movies/{id}/refresh";

        public RequestObjectType RequestObjectType => RequestObjectType.Movies;

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id
            };

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "movie id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "movie id not valid");
        }
    }
}
