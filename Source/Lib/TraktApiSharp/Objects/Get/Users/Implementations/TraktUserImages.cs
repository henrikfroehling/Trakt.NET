namespace TraktApiSharp.Objects.Get.Users.Implementations
{
    using Basic;

    /// <summary>A collection of images and image sets for a Trakt user.</summary>
    public class TraktUserImages : ITraktUserImages
    {
        /// <summary>Gets or sets the avatar image. See also <seealso cref="ITraktImage" />.<para>Nullable</para></summary>
        public ITraktImage Avatar { get; set; }
    }
}
