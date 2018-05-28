namespace TraktApiSharp.Objects.Post.Syncs.Ratings
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktSyncRatingsPost : IRequestBody
    {
        IEnumerable<ITraktSyncRatingsPostMovie> Movies { get; set; }

        IEnumerable<ITraktSyncRatingsPostShow> Shows { get; set; }

        IEnumerable<ITraktSyncRatingsPostEpisode> Episodes { get; set; }
    }
}
