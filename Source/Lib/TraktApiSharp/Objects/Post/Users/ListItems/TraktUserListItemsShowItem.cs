namespace TraktApiSharp.Objects.Post.Users.ListItems
{
    using Get.Shows;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserListItemsShowItem
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktUserListItemsShowSeasonItem> Seasons { get; set; }
    }
}
