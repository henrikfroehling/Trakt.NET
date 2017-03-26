namespace TraktApiSharp.Objects.Get.Seasons.Implementations
{
    using Newtonsoft.Json;

    /// <summary>Represents the progress of a Trakt season.</summary>
    public abstract class TraktSeasonProgress : ITraktSeasonProgress
    {
        /// <summary>Gets or sets the number of the collected or watched season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>Gets or sets the number of episodes in the season, which already aired.</summary>
        [JsonProperty(PropertyName = "aired")]
        public int? Aired { get; set; }

        /// <summary>Gets or sets the number of episodes in the season already collected or watched.</summary>
        [JsonProperty(PropertyName = "completed")]
        public int? Completed { get; set; }
    }
}
