namespace TraktNet.Requests.Lists
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal abstract class AListRequest<TResponseContentType> : AGetRequest<TResponseContentType>, IHasId
    {
        public string Id { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Lists;

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
                throw new ArgumentException("list id not valid", nameof(Id));
        }
    }
}
