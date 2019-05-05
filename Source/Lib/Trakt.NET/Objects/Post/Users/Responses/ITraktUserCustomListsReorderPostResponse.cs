namespace TraktNet.Objects.Post.Users.Responses
{
    using System.Collections.Generic;

    public interface ITraktUserCustomListsReorderPostResponse
    {
        int? Updated { get; set; }

        IEnumerable<uint> SkippedIds { get; set; }
    }
}
