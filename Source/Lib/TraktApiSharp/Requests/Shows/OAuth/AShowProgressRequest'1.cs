namespace TraktApiSharp.Requests.Shows.OAuth
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal abstract class AShowProgressRequest<TResponseContentType> : AGetRequest<TResponseContentType>, IHasId
    {
        public string Id { get; set; }

        internal bool? Hidden { get; set; }

        internal bool? Specials { get; set; }

        internal bool? CountSpecials { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public RequestObjectType RequestObjectType => RequestObjectType.Shows;

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            if (Hidden.HasValue)
                uriParams.Add("hidden", Hidden.Value.ToString().ToLower());

            if (Specials.HasValue)
                uriParams.Add("specials", Specials.Value.ToString().ToLower());

            if (CountSpecials.HasValue)
                uriParams.Add("count_specials", CountSpecials.Value.ToString().ToLower());

            return uriParams;
        }

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("show id not valid", nameof(Id));
        }
    }
}
