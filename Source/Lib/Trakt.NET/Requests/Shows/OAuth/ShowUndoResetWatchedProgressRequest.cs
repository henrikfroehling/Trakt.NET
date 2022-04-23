namespace TraktNet.Requests.Shows.OAuth
{
    using Base;
    using Extensions;
    using System;
    using System.Collections.Generic;

    internal sealed class ShowUndoResetWatchedProgressRequest : ADeleteRequest
    {
        public string Id { get; set; }

        public override string UriTemplate => "shows/{id}/progress/watched/reset";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("show id not valid", nameof(Id));
        }
    }
}
