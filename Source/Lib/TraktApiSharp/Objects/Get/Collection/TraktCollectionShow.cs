namespace TraktApiSharp.Objects.Get.Collection
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>Contains information about a collected Trakt show.</summary>
    public class TraktCollectionShow
    {
        /// <summary>Gets or sets the UTC datetime, when the last episode was collected in the show.</summary>
        [JsonProperty(PropertyName = "last_collected_at")]
        public DateTime? LastCollectedAt { get; set; }

        /// <summary>
        /// Gets or sets the collected Trakt show. See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets a list of collected seasons in the collected show.
        /// See also <seealso cref="TraktCollectionShowSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktCollectionShowSeason> Seasons { get; set; }
    }
}
