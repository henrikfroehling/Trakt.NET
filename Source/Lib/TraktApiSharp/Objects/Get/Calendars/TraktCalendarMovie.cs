namespace TraktApiSharp.Objects.Get.Calendars
{
    using Attributes;
    using Movies;
    using Newtonsoft.Json;
    using System;

    /// <summary>A Trakt calendar movie.</summary>
    public class TraktCalendarMovie
    {
        /// <summary>Gets or sets the release date of the <see cref="Movie" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "released")]
        public DateTime? Released { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="TraktMovie" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
