namespace TraktNet.Objects.Post.Syncs.Collection.Responses
{
    using Syncs.Responses;

    public interface ITraktSyncCollectionRemovePostResponse
    {
        ITraktSyncPostResponseGroup Deleted { get; set; }

        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
