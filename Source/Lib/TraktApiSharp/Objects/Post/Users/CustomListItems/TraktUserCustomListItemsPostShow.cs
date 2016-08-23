namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Attributes;
    using Get.Shows;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// An user custom list items post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public class TraktUserCustomListItemsPostShow
    {
        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktShowIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktUserCustomListItemsPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the custom list.
        /// Otherwise, only the specified seasons and / or episodes will be added to the custom list.
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostShowSeason> Seasons { get; set; }
    }
}
