namespace TraktNet.Objects.Post.Syncs.Responses
{
    using Post.Responses;
    using System.Collections.Generic;

    public interface ITraktSyncPostResponseNotFoundGroup
    {
        IEnumerable<ITraktPostResponseNotFoundMovie> Movies { get; set; }

        IEnumerable<ITraktPostResponseNotFoundShow> Shows { get; set; }

        IEnumerable<ITraktPostResponseNotFoundSeason> Seasons { get; set; }

        IEnumerable<ITraktPostResponseNotFoundEpisode> Episodes { get; set; }
    }
}
