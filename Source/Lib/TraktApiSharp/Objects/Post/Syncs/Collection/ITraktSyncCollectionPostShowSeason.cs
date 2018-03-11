namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using System.Collections.Generic;

    public interface ITraktSyncCollectionPostShowSeason
    {
        int Number { get; set; }

        IEnumerable<ITraktSyncCollectionPostShowEpisode> Episodes { get; set; }
    }
}
