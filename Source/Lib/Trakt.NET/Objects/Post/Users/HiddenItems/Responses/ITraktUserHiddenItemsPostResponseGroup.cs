namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    /// <summary>A collection containing the number of movies, shows and seasons.</summary>
    public interface ITraktUserHiddenItemsPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        int? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        int? Seasons { get; set; }

        /// <summary>Gets or sets the number of users.</summary>
        int? Users { get; set; }
    }
}
