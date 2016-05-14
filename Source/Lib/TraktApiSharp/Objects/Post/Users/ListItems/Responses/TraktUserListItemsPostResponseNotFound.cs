namespace TraktApiSharp.Objects.Post.Users.ListItems.Responses
{
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserListItemsPostResponseNotFound
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktUserListItemsPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktUserListItemsPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktUserListItemsPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktUserListItemsPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }

        [JsonProperty(PropertyName = "people")]
        public IEnumerable<TraktUserListItemsPostResponseNotFoundItem<TraktPersonIds>> People { get; set; }
    }
}
