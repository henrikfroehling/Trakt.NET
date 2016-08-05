namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Attributes;
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
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }

        [JsonProperty(PropertyName = "people")]
        [Nullable]
        public IEnumerable<TraktUserCustomListItemsPostResponseNotFoundItem<TraktPersonIds>> People { get; set; }
    }
}
