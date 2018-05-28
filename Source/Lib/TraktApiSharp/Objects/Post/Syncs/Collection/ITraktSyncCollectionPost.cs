namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    public interface ITraktSyncCollectionPost : IRequestBody
    {
        IEnumerable<ITraktSyncCollectionPostMovie> Movies { get; set; }

        IEnumerable<ITraktSyncCollectionPostShow> Shows { get; set; }

        IEnumerable<ITraktSyncCollectionPostEpisode> Episodes { get; set; }
    }
}
