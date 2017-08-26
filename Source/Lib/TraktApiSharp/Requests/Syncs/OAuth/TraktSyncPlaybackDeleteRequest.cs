namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktSyncPlaybackDeleteRequest : ADeleteRequest, ITraktHasId
    {
        public string Id { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public override string UriTemplate => "sync/playback/{id}";

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
                throw new ArgumentException("object id not valid", nameof(Id));
        }
    }
}
