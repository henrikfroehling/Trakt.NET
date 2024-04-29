namespace TraktNet.Requests.Notes.OAuth
{
    using System.Collections.Generic;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Objects.Post.Notes;
    using TraktNet.Requests.Base;

    internal sealed class NoteUpdateRequest : APutRequest<ITraktNote, ITraktNotePost>
    {
        internal ulong Id { get; set; }

        public override ITraktNotePost RequestBody { get; set; }

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

            base.Validate();
        }
    }
}
