namespace TraktNet.Objects.Get.Watched
{
    using Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktWatchedShow : ITraktShow
    {
        int? Plays { get; set; }

        DateTime? LastWatchedAt { get; set; }

        ITraktShow Show { get; set; }

        IEnumerable<ITraktWatchedShowSeason> WatchedSeasons { get; set; }
    }
}
