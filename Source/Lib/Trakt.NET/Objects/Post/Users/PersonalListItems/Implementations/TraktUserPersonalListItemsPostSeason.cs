namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    using Get.Seasons;

    /// <summary>An user personal list items post season, containing the required season ids.</summary>
    public class TraktUserPersonalListItemsPostSeason : ITraktUserPersonalListItemsPostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        public ITraktSeasonIds Ids { get; set; }

        /// <summary>Gets or sets the season notes.</summary>
        public string Notes { get; set; }
    }
}
