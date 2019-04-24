namespace TraktNet.Objects.Post.Users.CustomListItems.Responses
{
    /// <summary>A collection containing the number of movies, shows, seasons, episodes and people.</summary>
    public interface ITraktUserCustomListItemsPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        int? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        int? Seasons { get; set; }

        /// <summary>Gets or sets the number of episodes.</summary>
        int? Episodes { get; set; }

        /// <summary>Gets or sets the number of people.</summary>
        int? People { get; set; }
    }
}
