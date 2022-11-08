namespace TraktNet.Requests.Shows.OAuth
{
    using Exceptions;
    using Extensions;
    using Objects.Post.Shows;
    using Requests.Base;
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
            base.Validate();

            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "show id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "show id not valid");
        }
    }
}
