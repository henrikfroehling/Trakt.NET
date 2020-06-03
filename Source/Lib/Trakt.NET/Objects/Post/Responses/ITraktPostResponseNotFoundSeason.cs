namespace TraktNet.Objects.Post.Responses
{
    using Get.Seasons;

    /// <summary>A Trakt season, which was not found.</summary>
    public interface ITraktPostResponseNotFoundSeason
    {
        /// <summary>Gets or sets the ids of the not found season. See also <seealso cref="ITraktSeasonIds" />.</summary>
        ITraktSeasonIds Ids { get; set; }
    }
}
