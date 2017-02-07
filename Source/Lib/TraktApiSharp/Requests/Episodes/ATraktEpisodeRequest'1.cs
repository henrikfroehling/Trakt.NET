namespace TraktApiSharp.Requests.Episodes
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal abstract class ATraktEpisodeRequest<TContentType> : ATraktGetRequest<TContentType>, ITraktHasId
    {
        public string Id { get; set; }

        internal uint SeasonNumber { get; set; }

        internal uint EpisodeNumber { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

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
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("show id not valid", nameof(Id));

            if (EpisodeNumber == 0)
                throw new ArgumentOutOfRangeException(nameof(EpisodeNumber), "episode number must be a positive integer greater than zero");
        }
    }
}
