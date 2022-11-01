namespace TraktNet.Requests.Episodes
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using System.Collections.Generic;

    internal abstract class AEpisodeRequest<TResponseContentType> : AGetRequest<TResponseContentType>, IHasId
    {
        public string Id { get; set; }

        internal uint SeasonNumber { get; set; }

        internal uint EpisodeNumber { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Episodes;

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id,
                ["season"] = SeasonNumber.ToString(),
                ["episode"] = EpisodeNumber.ToString()
            };

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "show id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "show id not valid");

            if (SeasonNumber < 0)
                throw new TraktRequestValidationException(nameof(SeasonNumber), "season number must be a positive integer greater than or equal to zero");

            if (EpisodeNumber < 1)
                throw new TraktRequestValidationException(nameof(EpisodeNumber), "episode number must be a positive integer greater than zero");
        }
    }
}
