namespace TraktApiSharp.Objects.Get.Seasons
{
    using Episodes;
    using System.Collections.Generic;

    public interface ITraktSeasonCollectionProgress : ITraktSeasonProgress
    {
        IEnumerable<ITraktEpisodeCollectionProgress> Episodes { get; set; }
    }
}
