namespace TraktNet.Requests.Recommendations.OAuth
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal abstract class AUserRecommendationHideRequest : ADeleteRequest, IHasId
    {
        public string Id { get; set; }

        public abstract RequestObjectType RequestObjectType { get; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("id or slug not valid", nameof(Id));
        }
    }
}
