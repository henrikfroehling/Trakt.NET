namespace TraktApiSharp.Objects.Get.Watched
{
    using Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktWatchedMovie
    {
        [JsonProperty(PropertyName = "plays")]
        public int Plays { get; set; }

        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime LastWatchedAt { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
