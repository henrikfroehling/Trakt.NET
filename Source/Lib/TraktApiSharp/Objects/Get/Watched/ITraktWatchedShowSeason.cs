namespace TraktNet.Objects.Get.Watched
{
    using System.Collections.Generic;

    public interface ITraktWatchedShowSeason
    {
        int? Number { get; set; }

        IEnumerable<ITraktWatchedShowEpisode> Episodes { get; set; }
    }
}
