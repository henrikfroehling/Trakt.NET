namespace TraktNet.Requests.Notes.OAuth
{
    using System.Collections.Generic;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;

    internal sealed class NoteDeleteRequest : ADeleteRequest
    {
        internal ulong Id { get; set; }

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
