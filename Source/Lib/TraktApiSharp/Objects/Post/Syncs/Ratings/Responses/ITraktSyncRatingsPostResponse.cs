namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Syncs.Responses;

    public interface ITraktSyncRatingsPostResponse
    {
        ITraktSyncPostResponseGroup Added { get; set; }

        ITraktSyncRatingsPostResponseNotFoundGroup NotFound { get; set; }
    }
}
