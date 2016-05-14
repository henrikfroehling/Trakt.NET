namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Get.Shows;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsShowItem
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktUserCustomListItemsShowSeasonItem> Seasons { get; set; }
    }
}
