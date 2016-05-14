namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserCustomListItemsPostResponseNotFound
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }

        [JsonProperty(PropertyName = "people")]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktPersonIds>> People { get; set; }
    }
}
