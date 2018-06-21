namespace TraktNet.Objects.Post.Syncs.Ratings
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktSyncRatingsPostShow
    {
        DateTime? RatedAt { get; set; }

        int? Rating { get; set; }

        string Title { get; set; }

        int? Year { get; set; }

        ITraktShowIds Ids { get; set; }

        IEnumerable<ITraktSyncRatingsPostShowSeason> Seasons { get; set; }
    }
}
