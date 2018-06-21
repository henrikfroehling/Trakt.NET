namespace TraktNet.Objects.Get.Shows
{
    using Episodes;
    using Seasons;
    using System.Collections.Generic;

    public interface ITraktShowProgress
    {
        int? Aired { get; set; }

        int? Completed { get; set; }

        IEnumerable<ITraktSeason> HiddenSeasons { get; set; }

        ITraktEpisode NextEpisode { get; set; }

        ITraktEpisode LastEpisode { get; set; }
    }
}
