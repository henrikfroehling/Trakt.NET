namespace TraktNet.Requests.Shows.OAuth
{
    using System.Collections.Generic;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Interfaces;

    internal sealed class ShowRefreshRequest : ABodylessPostRequest, IHasId
    {
        public string Id { get; set; }

        public override string UriTemplate => "shows/{id}/refresh";

        public RequestObjectType RequestObjectType => RequestObjectType.Shows;

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id
            };

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "show id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "show id not valid");
        }
    }
}
