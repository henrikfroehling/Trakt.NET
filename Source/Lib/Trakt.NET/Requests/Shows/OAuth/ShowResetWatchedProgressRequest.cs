namespace TraktNet.Requests.Shows.OAuth
{
    using Extensions;
    using Objects.Post.Shows;
    using Requests.Base;
    using System;
    using System.Collections.Generic;

    internal sealed class ShowResetWatchedProgressRequest : APostRequest<ITraktShowResetWatchedProgressPost, ITraktShowResetWatchedProgressPost>
    {
        public override ITraktShowResetWatchedProgressPost RequestBody { get; set; }

        public string Id { get; set; }

        public override string UriTemplate => "shows/{id}/progress/watched/reset";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            return uriParams;
        }

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("show id not valid", nameof(Id));

            base.Validate();
        }
    }
}
