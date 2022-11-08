﻿namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses
{
    /// <summary>A collection containing the number of movies, shows, seasons, episodes and people.</summary>
    public class TraktUserPersonalListItemsPostResponseGroup : ITraktUserPersonalListItemsPostResponseGroup
    {
        /// <summary>Gets or sets the number of movies.</summary>
        public int? Movies { get; set; }

        /// <summary>Gets or sets the number of shows.</summary>
        public int? Shows { get; set; }

        /// <summary>Gets or sets the number of seasons.</summary>
        public int? Seasons { get; set; }

        /// <summary>Gets or sets the number of episodes.</summary>
        public int? Episodes { get; set; }

        /// <summary>Gets or sets the number of people.</summary>
        public int? People { get; set; }
    }
}
