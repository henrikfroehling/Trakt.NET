namespace TraktNet.Objects.Post.Users.Responses
{
    using System.Collections.Generic;

    public class TraktUserCustomListsReorderPostResponse : ITraktUserCustomListsReorderPostResponse
    {
        public int? Updated { get; set; }

        public IEnumerable<uint> SkippedIds { get; set; }
    }
}
