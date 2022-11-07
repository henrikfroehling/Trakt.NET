namespace TraktNet.Requests.People
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Parameters;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal abstract class APersonRequest<TResponseContentType> : AGetRequest<TResponseContentType>, IHasId, ISupportsExtendedInfo
    {
        public string Id { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.People;

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
                throw new TraktRequestValidationException(nameof(Id), "person id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "person id or slug not valid");
        }
    }
}
