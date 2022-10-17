namespace TraktNet.Objects.Post.Syncs.Ratings
{
    /// <summary>
    /// A Trakt ratings remove post, containing all movies, shows and / or episodes,
    /// which should be removed from the user's ratings.
    /// </summary>
    public class TraktSyncRatingsRemovePost : TraktSyncRatingsPost, ITraktSyncRatingsRemovePost
    {
    }
}
