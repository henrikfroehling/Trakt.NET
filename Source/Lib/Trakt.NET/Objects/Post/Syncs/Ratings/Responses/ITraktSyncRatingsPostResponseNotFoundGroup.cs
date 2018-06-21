namespace TraktNet.Objects.Post.Syncs.Ratings.Responses
{
    using System.Collections.Generic;

    public interface ITraktSyncRatingsPostResponseNotFoundGroup
    {
        IEnumerable<ITraktSyncRatingsPostResponseNotFoundMovie> Movies { get; set; }

        IEnumerable<ITraktSyncRatingsPostResponseNotFoundShow> Shows { get; set; }

        IEnumerable<ITraktSyncRatingsPostResponseNotFoundSeason> Seasons { get; set; }

        IEnumerable<ITraktSyncRatingsPostResponseNotFoundEpisode> Episodes { get; set; }
    }
}
