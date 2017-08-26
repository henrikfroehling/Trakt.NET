namespace TraktApiSharp.Requests.People
{
    using Base;
    using Extensions;
    using Interfaces;
    using Parameters;
    using System;
    using System.Collections.Generic;

    internal abstract class ATraktPersonRequest<TResponseContentType> : AGetRequest<TResponseContentType>, ITraktHasId, ITraktSupportsExtendedInfo
    {
        public string Id { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.People;

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("person id or slug not valid", nameof(Id));
        }
    }
}
