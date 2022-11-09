namespace TraktNet.Requests.Seasons
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using System.Collections.Generic;

    internal abstract class ASeasonRequest<TResponseContentType> : AGetRequest<TResponseContentType>, IHasId
    {
        public string Id { get; set; }

        internal uint SeasonNumber { get; set; }

        public virtual RequestObjectType RequestObjectType => RequestObjectType.Seasons;

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id,
                ["season"] = SeasonNumber.ToString()
            };

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "show id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "show id not valid");
        }
    }
}
