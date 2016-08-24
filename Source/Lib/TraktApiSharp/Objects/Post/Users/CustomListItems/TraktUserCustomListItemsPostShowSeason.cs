namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>An user custom list items post season, containing the required season number and optional episodes.</summary>
    public class TraktUserCustomListItemsPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserCustomListItemsPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the custom list.
        /// Otherwise, only the specified episodes will be added to the custom list.
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostShowEpisode> Episodes { get; set; }
    }
}
