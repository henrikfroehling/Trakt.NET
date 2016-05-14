namespace TraktApiSharp.Objects.Post.Users.ListItems
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserListItemsShowSeasonItem
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktUserListItemsShowEpisodeItem> Episodes { get; set; }
    }
}
