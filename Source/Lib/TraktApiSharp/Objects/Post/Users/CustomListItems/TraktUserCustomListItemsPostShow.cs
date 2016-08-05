namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Attributes;
    using Get.Shows;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsPostShow
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostShowSeason> Seasons { get; set; }
    }
}
