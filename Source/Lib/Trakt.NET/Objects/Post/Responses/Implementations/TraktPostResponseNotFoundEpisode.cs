namespace TraktNet.Objects.Post.Responses
{
    using Get.Episodes;

    /// <summary>A Trakt episode, which was not found.</summary>
    public class TraktPostResponseNotFoundEpisode : ITraktPostResponseNotFoundEpisode
    {
        /// <summary>Gets or sets the ids of the not found episode. See also <seealso cref="ITraktEpisodeIds" />.</summary>
        public ITraktEpisodeIds Ids { get; set; }
    }
}
