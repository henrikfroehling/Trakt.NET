namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>A collection of ids for a Trakt user.</summary>
    public class TraktUserIds
    {
        /// <summary>Gets or sets the Trakt slug.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "slug")]
        [Nullable]
        public string Slug { get; set; }

        /// <summary>Returns, whether any id has been set.</summary>
        [JsonIgnore]
        public bool HasAnyId => !string.IsNullOrEmpty(Slug);

        /// <summary>Gets the most reliable id from those that have been set.</summary>
        /// <returns>The id as a string or an empty string, if no id is set.</returns>
        public string GetBestId()
        {
            if (!string.IsNullOrEmpty(Slug))
                return Slug;

            return string.Empty;
        }
    }
}
