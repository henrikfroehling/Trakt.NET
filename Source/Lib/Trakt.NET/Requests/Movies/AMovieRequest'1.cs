namespace TraktNet.Requests.Movies
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using System.Collections.Generic;

    internal abstract class AMovieRequest<TResponseContentType> : AGetRequest<TResponseContentType>, IHasId
    {
        public string Id { get; set; }

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
