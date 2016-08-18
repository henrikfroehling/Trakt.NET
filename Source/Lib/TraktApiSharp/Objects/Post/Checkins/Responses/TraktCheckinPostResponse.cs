namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;
    using System;

    public abstract class TraktCheckinPostResponse
    {
        /// <summary>Gets or sets the UTC datetime, when the checked in movie or episode was watched.</summary>
        [JsonProperty(PropertyName = "watched_at")]
        public DateTime? WatchedAt { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the checkin response.
        /// See also <seealso cref="TraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sharing")]
        [Nullable]
        public TraktSharing Sharing { get; set; }
    }
}
