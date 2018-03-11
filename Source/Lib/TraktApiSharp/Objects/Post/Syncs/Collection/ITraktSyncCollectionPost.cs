namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using System.Collections.Generic;

    public interface ITraktSyncCollectionPost
    {
        IEnumerable<ITraktSyncCollectionPostMovie> Movies { get; set; }

        IEnumerable<ITraktSyncCollectionPostShow> Shows { get; set; }

        IEnumerable<ITraktSyncCollectionPostEpisode> Episodes { get; set; }
    }
}
