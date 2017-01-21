namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Requests;

    internal abstract class ATraktUserRecommendationHideRequest : ATraktDeleteRequest, ITraktHasId
    {
        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("movie id or slug not valid", nameof(Id));
        }
    }
}
