namespace TraktNet.Requests.Base
{
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Basic;
    using System.Collections.Generic;

    internal abstract class AStudiosRequest : AGetRequest<ITraktStudio>, IHasId
    {
        public string Id { get; set; }

        public abstract RequestObjectType RequestObjectType { get; }

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id
            };

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "id not valid");
        }
    }
}
