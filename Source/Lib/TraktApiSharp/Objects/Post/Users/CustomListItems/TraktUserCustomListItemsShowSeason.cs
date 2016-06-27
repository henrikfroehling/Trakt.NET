namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsShowSeason
    {
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktUserCustomListItemsShowEpisode> Episodes { get; set; }
    }
}
