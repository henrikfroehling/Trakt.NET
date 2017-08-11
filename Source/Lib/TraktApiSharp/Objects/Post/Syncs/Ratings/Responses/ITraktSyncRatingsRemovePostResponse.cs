namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Syncs.Responses;

    public interface ITraktSyncRatingsRemovePostResponse
    {
        ITraktSyncPostResponseGroup Deleted { get; set; }

        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
