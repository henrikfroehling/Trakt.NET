namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Get.Seasons;

    /// <summary>An user hidden items post season, containing the required season ids.</summary>
    public class TraktUserHiddenItemsPostSeason : ITraktUserHiddenItemsPostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        public ITraktSeasonIds Ids { get; set; }
    }
}
