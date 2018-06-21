namespace TraktNet.Objects.Get.Shows
{
    using Seasons;
    using System;
    using System.Collections.Generic;

    public interface ITraktShowCollectionProgress : ITraktShowProgress
    {
        DateTime? LastCollectedAt { get; set; }

        IEnumerable<ITraktSeasonCollectionProgress> Seasons { get; set; }
    }
}
