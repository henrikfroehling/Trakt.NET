namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsPostShowSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostShowEpisode> Episodes { get; set; }
    }
}
