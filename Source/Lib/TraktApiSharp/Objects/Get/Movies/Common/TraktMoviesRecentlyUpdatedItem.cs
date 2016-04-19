namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;
    using System;

    public class TraktMoviesRecentlyUpdatedItem
    {
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
