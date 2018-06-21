namespace TraktNet.Objects.Get.Seasons
{
    using Episodes;
    using System.Collections.Generic;

    public interface ITraktSeasonWatchedProgress : ITraktSeasonProgress
    {
        IEnumerable<ITraktEpisodeWatchedProgress> Episodes { get; set; }
    }
}
