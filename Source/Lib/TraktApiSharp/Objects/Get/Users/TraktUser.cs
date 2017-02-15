namespace TraktApiSharp.Objects.Get.Users
{
    using Newtonsoft.Json;
    using System;

    /// <summary>A Trakt user.</summary>
    public class TraktUser : ITraktUser
    {
        /// <summary>Gets or sets the user's username.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>Gets or sets the user's privacy status.</summary>
        [JsonProperty(PropertyName = "private")]
        public bool? IsPrivate { get; set; }

        /// <summary>Gets or sets the collection of ids for the user. See also <seealso cref="TraktUserIds" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktUserIds Ids { get; set; }

        /// <summary>Gets or sets the user's name.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the user's VIP status.</summary>
        [JsonProperty(PropertyName = "vip")]
        public bool? IsVIP { get; set; }

        /// <summary>Gets or sets the user's VIP EP status.</summary>
        [JsonProperty(PropertyName = "vip_ep")]
        public bool? IsVIP_EP { get; set; }

        /// <summary>Gets or sets the UTC datetime when the user joined Trakt.</summary>
        [JsonProperty(PropertyName = "joined_at")]
        public DateTime? JoinedAt { get; set; }

        /// <summary>Gets or sets the user's location.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>Gets or sets the user's about information.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "about")]
        public string About { get; set; }

        /// <summary>Gets or sets the user's gender.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        /// <summary>Gets or sets the user's age.</summary>
        [JsonProperty(PropertyName = "age")]
        public int? Age { get; set; }

        /// <summary>Gets or sets the collection of images for the user. See also <seealso cref="TraktUserImages" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "images")]
        public TraktUserImages Images { get; set; }
    }
}
