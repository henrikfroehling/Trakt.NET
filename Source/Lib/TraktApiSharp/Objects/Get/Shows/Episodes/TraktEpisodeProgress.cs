namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Newtonsoft.Json;

    /// <summary>Represents the progress of a Trakt episode.</summary>
    public abstract class TraktEpisodeProgress
    {
        /// <summary>Gets or sets the number of the collected or watched episode.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>Gets or sets, whether the episode was collected or watched.</summary>
        [JsonProperty(PropertyName = "completed")]
        public bool? Completed { get; set; }
    }
}
