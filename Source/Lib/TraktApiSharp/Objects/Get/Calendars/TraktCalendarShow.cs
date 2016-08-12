namespace TraktApiSharp.Objects.Get.Calendars
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;
    using Shows.Episodes;
    using System;

    /// <summary>A Trakt calendar show, containing episode and show information.</summary>
    public class TraktCalendarShow
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Episode" /> first aired.</summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the Trakt episode. See also <seealso cref="TraktEpisode" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="TraktShow" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }
    }
}
