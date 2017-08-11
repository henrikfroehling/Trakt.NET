namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses
{
    using Syncs.Responses;

    public interface ITraktSyncCollectionPostResponse
    {
        ITraktSyncPostResponseGroup Added { get; set; }

        ITraktSyncPostResponseGroup Updated { get; set; }

        ITraktSyncPostResponseGroup Existing { get; set; }

        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
