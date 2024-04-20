namespace TraktNet.Requests.Notes.OAuth
{
    using System.Collections.Generic;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Interfaces;

    internal sealed class NoteItemGetRequest : AGetRequest<ITraktNoteItem>, ISupportsExtendedInfo
    {
        internal ulong Id { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "notes/{id}/item{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                { "id", Id.ToString() }
            };

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (Id == 0)
                throw new TraktRequestValidationException(nameof(Id), "note id not valid");
        }
    }
}
