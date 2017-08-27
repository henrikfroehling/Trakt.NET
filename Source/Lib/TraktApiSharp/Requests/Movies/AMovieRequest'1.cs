namespace TraktApiSharp.Requests.Movies
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
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
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("movie id not valid", nameof(Id));
        }
    }
}
