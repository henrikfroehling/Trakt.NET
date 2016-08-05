namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TraktUserRatingsStatistics
    {
        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        [JsonProperty(PropertyName = "distribution")]
        [Nullable]
        public Dictionary<string, int> Distribution { get; set; }
    }
}
