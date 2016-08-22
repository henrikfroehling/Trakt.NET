namespace TraktApiSharp.Objects.Get.Users.Lists
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A collection of ids for various web services, including the Trakt id, for a Trakt list.</summary>
    public class TraktListIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        [JsonProperty(PropertyName = "trakt")]
        public uint Trakt { get; set; }

        /// <summary>Gets or sets the Trakt slug.</summary>
        [JsonProperty(PropertyName = "slug")]
        [Nullable]
        public string Slug { get; set; }

        /// <summary>Returns, whether any id has been set.</summary>
        [JsonIgnore]
        public bool HasAnyId => Trakt > 0 || !string.IsNullOrEmpty(Slug);

        /// <summary>Gets the most reliable id from those that have been set.</summary>
        /// <returns>The id as a string or an empty string, if no id is set.</returns>
        public string GetBestId()
        {
            if (Trakt > 0)
                return Trakt.ToString();

            if (!string.IsNullOrEmpty(Slug))
                return Slug;

            return string.Empty;
        }
    }
}
