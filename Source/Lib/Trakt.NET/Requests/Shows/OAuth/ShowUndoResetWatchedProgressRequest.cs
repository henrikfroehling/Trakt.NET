namespace TraktNet.Requests.Shows.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using System.Collections.Generic;

    internal sealed class ShowUndoResetWatchedProgressRequest : ADeleteRequest
    {
        public string Id { get; set; }

        public override string UriTemplate => "shows/{id}/progress/watched/reset";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "show id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "show id not valid");
        }
    }
}
