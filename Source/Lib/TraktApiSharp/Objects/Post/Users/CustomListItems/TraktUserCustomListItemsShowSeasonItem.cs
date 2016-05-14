namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsShowSeasonItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktUserCustomListItemsShowEpisodeItem> Episodes { get; set; }
    }
}
