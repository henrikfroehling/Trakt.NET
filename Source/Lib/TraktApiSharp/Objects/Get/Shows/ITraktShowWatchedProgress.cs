namespace TraktNet.Objects.Get.Shows
{
    using Seasons;
    using System;
    using System.Collections.Generic;

    public interface ITraktShowWatchedProgress : ITraktShowProgress
    {
        DateTime? LastWatchedAt { get; set; }

        DateTime? ResetAt { get; set; }

        IEnumerable<ITraktSeasonWatchedProgress> Seasons { get; set; }
    }
}
