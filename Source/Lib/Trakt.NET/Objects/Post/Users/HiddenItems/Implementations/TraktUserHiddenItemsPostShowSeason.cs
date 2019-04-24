namespace TraktNet.Objects.Post.Users.HiddenItems
{
    /// <summary>An user hidden items post season, containing the required season number.</summary>
    public class TraktUserHiddenItemsPostShowSeason : ITraktUserHiddenItemsPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }
    }
}
