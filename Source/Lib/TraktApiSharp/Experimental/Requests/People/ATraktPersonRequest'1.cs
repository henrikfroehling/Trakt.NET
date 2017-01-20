namespace TraktApiSharp.Experimental.Requests.People
{
    using Base;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktPersonRequest<TContentType> : ATraktGetRequest<TContentType>, ITraktHasId, ITraktSupportsExtendedInfo
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
