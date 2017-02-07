namespace TraktApiSharp.Objects.Get.Users
{
    using Basic;
    using Newtonsoft.Json;

    /// <summary>A collection of images and image sets for a Trakt user.</summary>
    public class TraktUserImages
    {
        /// <summary>Gets or sets the avatar image. See also <seealso cref="TraktImage" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "avatar")]
        public TraktImage Avatar { get; set; }
    }
}
