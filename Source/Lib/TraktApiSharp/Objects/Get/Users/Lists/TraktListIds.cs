namespace TraktApiSharp.Objects.Get.Users.Lists
{
    using Newtonsoft.Json;
    using System.Globalization;

    /// <summary>
    /// A collection of ids for various web services for a Trakt list.
    /// </summary>
    public class TraktListIds
    {
        /// <summary>
        /// The Trakt numeric id for the list.
        /// </summary>
        [JsonProperty(PropertyName = "trakt")]
        public int Trakt { get; set; }

        /// <summary>
        /// The Trakt slug for the list.
        /// </summary>
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Tests, if at least one id has been set.
        /// </summary>
        public bool HasAnyId => Trakt > 0 || !string.IsNullOrEmpty(Slug);

        /// <summary>
        /// Get the most reliable id from those that have been set for the list.
        /// </summary>
        /// <returns>The id as a string.</returns>
        public string GetBestId()
        {
            if (Trakt > 0)
                return Trakt.ToString(CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(Slug))
                return Slug;

            return string.Empty;
        }
    }
}
