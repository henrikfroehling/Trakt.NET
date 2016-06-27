namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Get.People;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktUserCustomListItemsPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktUserCustomListItemsShow> Shows { get; set; }

        [JsonProperty(PropertyName = "people")]
        public IEnumerable<TraktPerson> People { get; set; }
    }
}
