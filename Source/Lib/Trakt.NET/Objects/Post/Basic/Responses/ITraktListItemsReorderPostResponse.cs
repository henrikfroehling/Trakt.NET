namespace TraktNet.Objects.Post.Basic.Responses
{
    using System.Collections.Generic;

    public interface ITraktListItemsReorderPostResponse
    {
        int? Updated { get; set; }

        IEnumerable<uint> SkippedIds { get; set; }
    }
}
