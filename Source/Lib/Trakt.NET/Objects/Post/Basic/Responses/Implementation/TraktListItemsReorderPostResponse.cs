namespace TraktNet.Objects.Post.Basic.Responses
{
    using System.Collections.Generic;

    public class TraktListItemsReorderPostResponse : ITraktListItemsReorderPostResponse
    {
        public int? Updated { get; set; }

        public IEnumerable<uint> SkippedIds { get; set; }
    }
}
