namespace TraktNet.Requests.Notes.OAuth
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Notes;
    using TraktNet.Objects.Post.Notes;
    using TraktNet.Requests.Base;

    internal sealed class NotesAddRequest : APostRequest<ITraktNote, ITraktNotePost>
    {
        public override ITraktNotePost RequestBody { get; set; }

        public override string UriTemplate => "notes";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
