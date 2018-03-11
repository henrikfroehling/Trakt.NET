namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using System.Collections.Generic;

    public interface ITraktSyncRatingsPost
    {
        IEnumerable<ITraktSyncRatingsPostMovie> Movies { get; set; }

        IEnumerable<ITraktSyncRatingsPostShow> Shows { get; set; }

        IEnumerable<ITraktSyncRatingsPostEpisode> Episodes { get; set; }
    }
}
