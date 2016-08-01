namespace TraktApiSharp.Objects.Get.Shows.Episodes
{
    using Newtonsoft.Json;
    using System;

    /// <summary>Represents the collection progress of a Trakt episode.</summary>
    public class TraktEpisodeCollectionProgress : TraktEpisodeProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the episode was collected.</summary>
        [JsonProperty(PropertyName = "collected_at")]
        public DateTime? CollectedAt { get; set; }
    }
}
