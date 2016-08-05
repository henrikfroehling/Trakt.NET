namespace TraktApiSharp.Objects.Get.Shows
{
    using Attributes;
    using Newtonsoft.Json;
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>Represents the collection progress of a Trakt show.</summary>
    public class TraktShowCollectionProgress : TraktShowProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last collection occured.</summary>
        [JsonProperty(PropertyName = "last_collected_at")]
        public DateTime? LastCollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected seasons. See also <seealso cref="TraktSeasonCollectionProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSeasonCollectionProgress> Seasons { get; set; }
    }
}
