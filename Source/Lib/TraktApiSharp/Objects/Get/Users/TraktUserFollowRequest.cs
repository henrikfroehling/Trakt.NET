namespace TraktApiSharp.Objects.Get.Users
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    /// <summary>Represents a Trakt user follow request.</summary>
    public class TraktUserFollowRequest
    {
        /// <summary>Gets or sets the id of the follow request.</summary>
        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the request was made.</summary>
        [JsonProperty(PropertyName = "requested_at")]
        public DateTime? RequestedAt { get; set; }

        /// <summary>
        /// Gets or sets the Trakt user, who is requesting.
        /// See also <seealso cref="TraktUser" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        [Nullable]
        public TraktUser User { get; set; }
    }
}
