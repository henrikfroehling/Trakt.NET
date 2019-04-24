namespace TraktNet.Objects.Post.Users.HiddenItems
{
    /// <summary>An user hidden items post season, containing the required season number.</summary>
    public interface ITraktUserHiddenItemsPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        int Number { get; set; }
    }
}
