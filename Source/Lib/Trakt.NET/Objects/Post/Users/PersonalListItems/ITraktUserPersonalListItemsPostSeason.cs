namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    using Get.Seasons;

    /// <summary>An user personal list items post season, containing the required season ids.</summary>
    public interface ITraktUserPersonalListItemsPostSeason
    {
        /// <summary>Gets or sets the required season ids. See also <seealso cref="ITraktSeasonIds" />.</summary>
        ITraktSeasonIds Ids { get; set; }

        /// <summary>Gets or sets the season notes.</summary>
        string Notes { get; set; }
    }
}
