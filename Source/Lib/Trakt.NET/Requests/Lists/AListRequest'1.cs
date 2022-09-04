namespace TraktNet.Requests.Lists
{
    using Base;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal abstract class AListRequest<TResponseContentType> : AGetRequest<TResponseContentType>, IHasId<int>
    {
        public int Id { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Lists;

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id.ToString()
            };

        public override void Validate()
        {
            if (Id <= 0)
                throw new ArgumentException("list id not valid", nameof(Id));
        }
    }
}
