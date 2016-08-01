namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Newtonsoft.Json;
    using System;

    /// <summary>An updated Trakt show.</summary>
    public class TraktRecentlyUpdatedShow
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Show" /> was updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="TraktShow" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
