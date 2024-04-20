namespace TraktNet.Requests.Notes.OAuth
{
    using System.Collections.Generic;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Requests.Base;

    internal sealed class NoteGetRequest : AGetRequest<ITraktNote>
    {
        internal ulong Id { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public override string UriTemplate => "notes/{id}";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                { "id", Id.ToString() }
            };

        public override void Validate()
        {
            if (Id == 0)
                throw new TraktRequestValidationException(nameof(Id), "note id not valid");
        }
    }
}
