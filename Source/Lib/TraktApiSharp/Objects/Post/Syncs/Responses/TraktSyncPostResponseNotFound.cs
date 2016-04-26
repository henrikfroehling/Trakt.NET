namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktSyncPostResponseNotFound
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktSyncPostResponseNotFoundMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncPostResponseNotFoundShow> Shows { get; set; }

        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSyncPostResponseNotFoundSeason> Seasons { get; set; }

        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncPostResponseNotFoundEpisode> Episodes { get; set; }
    }
}
