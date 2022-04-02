namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    /// <summary>A collection containing the number of movies, shows and seasons.</summary>
    public class TraktUserHiddenItemsPostResponseGroup : ITraktUserHiddenItemsPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        public int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        public int? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        public int? Seasons { get; set; }

        /// <summary>Gets or sets the number of users.</summary>
        public int? Users { get; set; }
    }
}
