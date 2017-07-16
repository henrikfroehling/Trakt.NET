namespace TraktApiSharp.Objects.Post.Syncs.History.Responses
{
    using Syncs.Responses;

    public interface ITraktSyncHistoryPostResponse
    {
        ITraktSyncPostResponseGroup Added { get; set; }

        ITraktSyncPostResponseNotFoundGroup NotFound { get; set; }
    }
}
