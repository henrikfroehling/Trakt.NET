namespace TraktNet.Objects.Post.Syncs.Collection
{
    using Basic;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktSyncCollectionPostShow : ITraktMetadata
    {
        DateTime? CollectedAt { get; set; }

        string Title { get; set; }

        int? Year { get; set; }

        ITraktShowIds Ids { get; set; }

        IEnumerable<ITraktSyncCollectionPostShowSeason> Seasons { get; set; }
    }
}
